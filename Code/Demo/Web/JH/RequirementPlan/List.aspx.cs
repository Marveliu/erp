using FineUI;
using System;
using System.Data;

namespace Demo.Web.JH.RequirementPlan
{
    public partial class List : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                btnAdd.OnClientClick = windowPop.GetShowReference("Add.aspx", "新增需求计划");
                btnDelete.OnClientClick = gridPlanSource.GetNoSelectionAlertReference("至少选择一项");
                LoadData();
                BindGrid();
            }
        }

        private void LoadData()
        {
            string strWhere = string.Format("ParameterNO in ('{0}','{1}')", "JH_StartDate", "JH_EndDate");
            BLL.tb_SYS_Parameter bllParameter = new BLL.tb_SYS_Parameter();
            DataTable dt = bllParameter.GetList(strWhere).Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["ParameterNO"].ToString() == "JH_StartDate")
                {
                    dapStartDate.Text = (dr["Value"].ToString() == "") ? DateTime.Today.AddDays(-90).ToString() : dr["Value"].ToString();
                }
                else
                {
                    dapEndDate.Text = (dr["Value"].ToString() == "") ? DateTime.Today.AddDays(90).ToString() : dr["Value"].ToString();
                }
            }
        }

        private void BindGrid()
        {
            string strWhere = string.Format("[EndDate] between '{0}' and '{1}'", dapStartDate.Text, dapEndDate.Text);
            string order = string.Format("EndDate ASC,BillType ASC");
            int pageSize = gridPlanSource.PageSize;
            int pageIndex = gridPlanSource.PageIndex;
            long recordCount;

            BLL.vw_JH_PlannedSource bllPlannedSource = new BLL.vw_JH_PlannedSource();
            DataSet dsPlannedSource = bllPlannedSource.GetListByPage(strWhere, order, pageSize, pageIndex, out recordCount);
            DataTable dtSource = dsPlannedSource.Tables[0];

            gridPlanSource.DataSource = dtSource;
            gridPlanSource.RecordCount = (int)recordCount;
            gridPlanSource.DataBind();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            #region 检查
            string amount = gridPlanSource.Rows[gridPlanSource.SelectedRowIndex].Values[8].ToString();
            if(amount != "0.00")
            {
                Alert.ShowInTop("已分解,不能删除", "警告", MessageBoxIcon.Warning);
                return;
            }
            #endregion

            #region 删除
            string id = gridPlanSource.DataKeys[gridPlanSource.SelectedRowIndex][0].ToString();
            BLL.tb_JH_PlannedSource bllPlannedSource = new BLL.tb_JH_PlannedSource();
            bool result = bllPlannedSource.Delete(id);
            if(result)
            {
                Alert.ShowInTop("删除成功", "信息", MessageBoxIcon.Information);
                BindGrid();
            }
            else
            {
                Alert.ShowInTop("删除失败", "错误", MessageBoxIcon.Error);
            }
            #endregion     
        }

        protected void wd_Close(object sender, FineUI.WindowCloseEventArgs e)
        {
            if(e.CloseArgument.Contains("Success"))
            {
                BindGrid();
            }         
        }

        protected void btnResearch_Click(object sender, EventArgs e)
        {
            BindGrid();
            BLL.tb_SYS_Parameter bllParameter = new BLL.tb_SYS_Parameter();
            string startDateID = bllParameter.GetList("ParameterNO='JH_StartDate'").Tables[0].Rows[0]["ID"].ToString();
            string endDateID = bllParameter.GetList("ParameterNO='JH_EndDate'").Tables[0].Rows[0]["ID"].ToString();
            Model.tb_SYS_Parameter modelParameter = new Model.tb_SYS_Parameter();
            //更新起始时间
            modelParameter.ID = startDateID;
            modelParameter.ParameterNO = "JH_StartDate";
            modelParameter.Value = dapStartDate.Text;
            modelParameter.Status = "Y";
            bllParameter.Update(modelParameter);
            //更新截至时间
            modelParameter.ID = endDateID;
            modelParameter.ParameterNO = "JH_EndDate";
            modelParameter.Value = dapEndDate.Text;
            bllParameter.Update(modelParameter);
        }
    }
}
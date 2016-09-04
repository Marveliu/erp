using FineUI;
using System;
using System.Data;

namespace Demo.Web.JH.AssignPlan
{
    public partial class List : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
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
            strWhere += (ddlBillType.SelectedValue == "A") ? "" : string.Format(" and BillType = '{0}'", ddlBillType.SelectedValue);
            strWhere += string.Format(" and Status in ('{0}','{1}')","R","A");
            string order = string.Format("EndDate ASC,BillType ASC");
            int pageSize = gridSource.PageSize;
            int pageIndex = gridSource.PageIndex;
            long recordCount;

            BLL.vw_JH_PlannedSource bllPlannedSource = new BLL.vw_JH_PlannedSource();
            DataSet dsPlannedSource = bllPlannedSource.GetListByPage(strWhere, order, pageSize, pageIndex, out recordCount);
            DataTable dtSource = dsPlannedSource.Tables[0];

            gridSource.DataSource = dtSource;
            gridSource.RecordCount = (int)recordCount;
            gridSource.DataBind();
        }

        private void BindGridSub(string id)
        {
            string strWhere = string.Format("SourceID='{0}'", id);
            string order = string.Format("Date ASC,BillType ASC");
            int pageSize = gridTask.PageSize;
            int pageIndex = gridTask.PageIndex;
            long recordCount;

            BLL.vw_JH_Task bllTask = new BLL.vw_JH_Task();
            DataSet dsTask = bllTask.GetListByPage(strWhere, order, pageSize, pageIndex, out recordCount);
            DataTable dtSource = dsTask.Tables[0];

            gridTask.DataSource = dtSource;
            gridTask.RecordCount = (int)recordCount;
            gridTask.DataBind();
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

        protected void gridSource_RowCommand(object sender, GridCommandEventArgs e)
        {
            if(e.CommandName == "ActionAssign")
            {
                BLL.tb_JH_Task bllTask = new BLL.tb_JH_Task();
                #region 检查
                string strWhere = string.Format("SourceID='{0}'",gridSource.DataKeys[e.RowIndex][0]);
                int count = bllTask.GetList(strWhere).Tables[0].Rows.Count;
                if (count > 0)
                {
                    Alert.ShowInTop("不能重复下达", "警告", MessageBoxIcon.Warning);
                    return;
                }
                #endregion
                #region 下达
                string sourceID = gridSource.DataKeys[e.RowIndex][0].ToString();
                int result = bllTask.AssignPlan(sourceID);
                if(result == 0)
                {
                    Alert.ShowInTop("下达成功", "信息", MessageBoxIcon.Information);
                    int selectedIndex = gridSource.SelectedRowIndex;
                    BindGrid();
                    gridSource.SelectedRowIndex = selectedIndex;
                    BindGridSub(sourceID);
                }
                else
                {
                    Alert.ShowInTop("下达失败", "错误", MessageBoxIcon.Error);
                }
                #endregion
            }
        }

        protected void gridSource_RowSelect(object sender, GridRowSelectEventArgs e)
        {
            string id = gridSource.DataKeys[e.RowIndex][0].ToString();
            BindGridSub(id);
        }
    }
}
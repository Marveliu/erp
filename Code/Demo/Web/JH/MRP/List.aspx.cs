using FineUI;
using System;
using System.Data;

namespace Demo.Web.JH.MRP
{
    public partial class List : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
                gridMRP.SortField = "NeedDate";
                BindGridMPS();
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

        private void BindGridMPS()
        {
            string strWhere = string.Format("[EndDate] between '{0}' and '{1}'", dapStartDate.Text, dapEndDate.Text);
            string order = string.Format("EndDate ASC,PlannedSourceID ASC");
            int pageSize = gridMPS.PageSize;
            int pageIndex = gridMPS.PageIndex;
            long recordCount;

            BLL.vw_JH_MPS bllMPS = new BLL.vw_JH_MPS();
            DataSet dsMPS = bllMPS.GetListByPage(strWhere, order, pageSize, pageIndex, out recordCount);
            DataTable dtSource = dsMPS.Tables[0];

            gridMPS.DataSource = dtSource;
            gridMPS.RecordCount = (int)recordCount;
            gridMPS.DataBind();
        }

        private void BindGridMRP(string reference)
        {
            string strWhere = string.Format("MPSID='{0}'", reference);
            string order = string.Format("{0} {1}", gridMRP.SortField, gridMRP.SortDirection);
            int pageSize = gridMRP.PageSize;
            int pageIndex = gridMRP.PageIndex;
            long recordCount;

            BLL.vw_JH_MRP bllMRP = new BLL.vw_JH_MRP();
            DataSet dsMRP = bllMRP.GetListByPage(strWhere, order, pageSize, pageIndex, out recordCount);
            DataTable dtSource = dsMRP.Tables[0];

            gridMRP.DataSource = dtSource;
            gridMRP.RecordCount = (int)recordCount;
            gridMRP.DataBind();
        }

        protected void grid_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
        {
            FineUI.Grid grid = (FineUI.Grid)sender;
            if (grid.ID == "gridMPS")
            {
                gridMPS.PageIndex = e.NewPageIndex;
                this.BindGridMPS();
            }
            if (grid.ID == "gridMRP")
            {
                gridMRP.PageIndex = e.NewPageIndex;
                string referenceID = gridMPS.DataKeys[gridMPS.SelectedRowIndex][0].ToString();
                this.BindGridMRP(referenceID);
            }
        }

        protected void grid_Sort(object sender, FineUI.GridSortEventArgs e)
        {
            gridMRP.SortDirection = e.SortDirection;
            gridMRP.SortField = e.SortField;
            string referenceID = gridMPS.DataKeys[gridMPS.SelectedRowIndex][0].ToString();
            this.BindGridMRP(referenceID);
        }

        protected void gridMPS_RowCommand(object sender, FineUI.GridCommandEventArgs e)
        {
            if (e.CommandName == "ActionDel")
            {
                //BLL.tb_JH_MPS bllMPS = new BLL.tb_JH_MPS();
                //string ID = gridMPS.DataKeys[gridMPS.SelectedRowIndex][0].ToString();
                //string materialNO = gridMPS.Rows[gridMPS.SelectedRowIndex].Values[4].ToString();
                //bool result = bllMPS.DeleteMPS(ID, materialNO);
                //if (result)
                //{
                //    Alert.ShowInTop("删除成功", "信息", MessageBoxIcon.Information);
                //}
                //else
                //{
                //    Alert.ShowInTop("删除失败", "错误", MessageBoxIcon.Error);
                //}
            }
            if (e.CommandName == "ActionAssign")
            {
                #region 检查
                string PlanAmount = gridMPS.Rows[e.RowIndex].Values[6].ToString();
                string ResolveAmount = gridMPS.Rows[e.RowIndex].Values[7].ToString();
                if (PlanAmount == ResolveAmount)
                {
                    Alert.ShowInTop("不能重复分解", "警告", MessageBoxIcon.Warning);
                    return;
                }
                #endregion
                #region 分解
                BLL.tb_JH_MRP bllMRP = new BLL.tb_JH_MRP();
                int result = bllMRP.ResolveMRP(gridMPS.DataKeys[e.RowIndex][0].ToString());
                if (result == 0)
                {
                    Alert.ShowInTop("分解完毕", "信息", MessageBoxIcon.Information);
                }
                else
                {
                    Alert.ShowInTop("分解失败", "错误", MessageBoxIcon.Error);
                }
                #endregion
            }
            int selectedIndex = gridMPS.SelectedRowIndex;
            BindGridMPS();
            gridMPS.SelectedRowIndex = selectedIndex;
            BindGridMRP(gridMPS.DataKeys[selectedIndex][0].ToString());
        }

        protected void gridMPS_RowSelect(object sender, GridRowSelectEventArgs e)
        {
            string reference = gridMPS.DataKeys[e.RowIndex][0].ToString();
            BindGridMRP(reference);
        }

        protected void wd_Close(object sender, WindowCloseEventArgs e)
        {
            if (e.CloseArgument.Contains("Add"))
            {
                int index = gridMPS.SelectedRowIndex;
                BindGridMPS();
                gridMPS.SelectedRowIndex = index;
            }
            string MPSID = gridMPS.DataKeys[gridMPS.SelectedRowIndex][0].ToString();
            BindGridMRP(MPSID);
        }

        protected void btnResearch_Click(object sender, EventArgs e)
        {
            BindGridMPS();
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
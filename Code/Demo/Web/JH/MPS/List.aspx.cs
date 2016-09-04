using FineUI;
using System;
using System.Data;

namespace Demo.Web.JH.MPS
{
    public partial class List : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                btnAdd.OnClientClick = gridSource.GetNoSelectionAlertReference("先选择一项计划来源单据！");
                LoadData();
                gridMPS.SortField = "EndDate";
                BindGrid();
            }
        }

        private void LoadData()
        {
            string strWhere = string.Format("ParameterNO in ('{0}','{1}')", "JH_StartDate","JH_EndDate");
            BLL.tb_SYS_Parameter bllParameter = new BLL.tb_SYS_Parameter();
            DataTable dt = bllParameter.GetList(strWhere).Tables[0];
            foreach(DataRow dr in dt.Rows)
            {
                if(dr["ParameterNO"].ToString() == "JH_StartDate")
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

        private void BindGridMPS(string reference)
        {
            string strWhere = string.Format("PlannedSourceID='{0}'", reference);
            string order = string.Format("{0} {1}",gridMPS.SortField,gridMPS.SortDirection);
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

        protected void grid_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
        {
            FineUI.Grid grid = (FineUI.Grid)sender;
            if (grid.ID == "gridSource")
            {
                gridSource.PageIndex = e.NewPageIndex;
                this.BindGrid();
            }
            if (grid.ID == "gridMPS")
            {
                gridMPS.PageIndex = e.NewPageIndex;
                string referenceID = gridSource.DataKeys[gridSource.SelectedRowIndex][0].ToString();
                this.BindGridMPS(referenceID);
            }
        }

        protected void grid_Sort(object sender, FineUI.GridSortEventArgs e)
        {
            gridMPS.SortDirection = e.SortDirection;
            gridMPS.SortField = e.SortField;
            string referenceID = gridSource.DataKeys[gridSource.SelectedRowIndex][0].ToString();
            this.BindGridMPS(referenceID);
        }

        protected void gridMPS_RowCommand(object sender, FineUI.GridCommandEventArgs e)
        {
            if(e.CommandName == "ActionDel")
            {
                BLL.tb_JH_MPS bllMPS = new BLL.tb_JH_MPS();
                string ID = gridMPS.DataKeys[gridMPS.SelectedRowIndex][0].ToString();
                string materialNO = gridMPS.Rows[gridMPS.SelectedRowIndex].Values[4].ToString();
                bool result = bllMPS.DeleteMPS(ID, materialNO);
                if(result)
                {
                    Alert.ShowInTop("删除成功", "信息", MessageBoxIcon.Information);
                }
                else
                {
                    Alert.ShowInTop("删除失败", "错误", MessageBoxIcon.Error);
                }
            }
            if(e.CommandName == "ActionAssign")
            {
                #region 检查
                string PlanAmount = gridSource.Rows[e.RowIndex].Values[6].ToString();
                string DownAmount = gridSource.Rows[e.RowIndex].Values[7].ToString();
                if(PlanAmount == DownAmount)
                {
                    Alert.ShowInTop("不能重复拆分", "警告", MessageBoxIcon.Warning);
                    return;
                }
                #endregion
                #region 拆分
                BLL.tb_JH_MPS bllMPS = new BLL.tb_JH_MPS();
                int result = bllMPS.DownMPS(gridSource.DataKeys[e.RowIndex][0].ToString());
                if(result == 0)
                {
                    Alert.ShowInTop("拆分完毕", "信息", MessageBoxIcon.Information);
                }
                else if(result == 1)
                {
                    Alert.ShowInTop("请先拆分日期在前的需求计划", "错误", MessageBoxIcon.Error);
                }
                else if(result == 3)
                {
                    Alert.ShowInTop("能力不足", "错误", MessageBoxIcon.Error);
                }
                else
                {
                    Alert.ShowInTop("拆分失败", "错误", MessageBoxIcon.Error);
                }
                #endregion
            }
            int selectedIndex = gridSource.SelectedRowIndex;
            BindGrid();
            gridSource.SelectedRowIndex = selectedIndex;
            BindGridMPS(gridSource.DataKeys[selectedIndex][0].ToString());
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string strWhere = string.Format("ID='{0}'",gridSource.DataKeys[gridSource.SelectedRowIndex][0].ToString());
            BLL.tb_JH_PlannedSource bllPlannedSource = new BLL.tb_JH_PlannedSource();
            string status = bllPlannedSource.GetList(strWhere).Tables[0].Rows[0]["Status"].ToString();
            if(status == "Y")
            {
                Alert.ShowInTop("无法新增，您可以选择删除已分解的MPS单", "错误", MessageBoxIcon.Error);
                return;
            }
            else
            {
                string url = string.Format("Add.aspx?PlannedSourceID={0}", gridSource.DataKeys[gridSource.SelectedRowIndex][0].ToString());
                windowPop.Hidden = false;
                windowPop.IFrameUrl = url;
                windowPop.Title = "新增MPS单-" + gridSource.Rows[gridSource.SelectedRowIndex].Values[4];
            }
        }

        protected void gridSource_RowSelect(object sender, GridRowSelectEventArgs e)
        {
            string reference = gridSource.DataKeys[e.RowIndex][0].ToString();
            BindGridMPS(reference);
        }

        protected void wd_Close(object sender, WindowCloseEventArgs e)
        {
            if(e.CloseArgument.Contains("Add"))
            {
                int index = gridSource.SelectedRowIndex;
                BindGrid();
                gridSource.SelectedRowIndex = index;
            }
            string plannedSourceID = gridSource.DataKeys[gridSource.SelectedRowIndex][0].ToString();
            BindGridMPS(plannedSourceID);
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
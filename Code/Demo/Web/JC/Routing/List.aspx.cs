using System;
using FineUI;
using System.Data;

namespace Demo.Web.JC.Routing
{
    public partial class List : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnDelete.OnClientClick = gridRouting.GetNoSelectionAlertReference("至少选择一项!");
                btnDeleteSub.OnClientClick = gridRoutingSub.GetNoSelectionAlertReference("至少选择一项!");
                btnAddSub.OnClientClick = gridRouting.GetNoSelectionAlertReference("至少选择一项!");
                btnAdd.OnClientClick = windowPop.GetShowReference("Add.aspx", "新增工艺路线");
                gridRouting.SortField = "ID";
                gridRoutingSub.SortField = "ID";
                BindGrid();
            }
        }

        //Grid绑定数据源
        private void BindGrid()
        {
            string strWhere = string.Format("1=1");
            string order = string.Format("{0} {1}", gridRouting.SortField, gridRouting.SortDirection);
            int pageSize = gridRouting.PageSize;
            int pageIndex = gridRouting.PageIndex;
            long totalRecord;
            BLL.tb_JC_Routing bllRouting = new BLL.tb_JC_Routing();
            DataTable dtSource = bllRouting.GetListByPage(strWhere, order, pageSize, pageIndex, out totalRecord).Tables[0];

            gridRouting.DataSource = dtSource;
            gridRouting.RecordCount = (int)totalRecord;
            gridRouting.DataBind();
        }

        private void BindGridSub(string id)
        {
            string strWhere = string.Format("RoutingID='{0}'",id);
            string order = string.Format("{0} {1}", gridRoutingSub.SortField, gridRoutingSub.SortDirection);
            int pageSize = gridRoutingSub.PageSize;
            int pageIndex = gridRoutingSub.PageIndex;
            long totalRecord;
            BLL.vw_JC_RoutingSub bllRoutingSub = new BLL.vw_JC_RoutingSub();
            DataTable dtSource = bllRoutingSub.GetListByPage(strWhere, order, pageSize, pageIndex, out totalRecord).Tables[0];

            gridRoutingSub.DataSource = dtSource;
            gridRoutingSub.RecordCount = (int)totalRecord;
            gridRoutingSub.DataBind();
        }

        //删除选中记录集
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            FineUI.Button btn = (FineUI.Button)sender;
            #region 主表删除事件
            if (btn.ID == "btnDelete")
            {
                if (gridRoutingSub.RecordCount > 0)
                {
                    Alert.ShowInTop("在删除该项前,请删除所有子项", "错误", MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    BLL.tb_JC_Routing bllRouting = new BLL.tb_JC_Routing();
                    string id = gridRouting.DataKeys[gridRouting.SelectedRowIndex][0].ToString();
                    bool result = bllRouting.Delete(id);
                    if (result)
                    {
                        Alert.ShowInTop("删除成功", "信息", MessageBoxIcon.Information);
                        BindGrid();
                    }
                    else
                    {
                        Alert.ShowInTop("删除失败", "错误", MessageBoxIcon.Error);
                    }
                    return;
                }
            }
            #endregion
            #region 删除子表记录
            if (btn.ID == "btnDeleteSub")
            {
                BLL.tb_JC_RoutingSub bllRoutingSub = new BLL.tb_JC_RoutingSub();
                string id = gridRoutingSub.DataKeys[gridRoutingSub.SelectedRowIndex][0].ToString();
                bool result = bllRoutingSub.Delete(id);
                if (result)
                {
                    Alert.ShowInTop("删除成功", "信息", MessageBoxIcon.Information);
                    BindGridSub(gridRouting.DataKeys[gridRouting.SelectedRowIndex][0].ToString());
                }
                else
                {
                    Alert.ShowInTop("删除失败", "错误", MessageBoxIcon.Error);
                }
                return;
            }
            #endregion
        }

        //清空筛选条件
        protected void btnClearCondition_Click(object sender, EventArgs e)
        {
        }

        //翻页
        protected void grid_PageIndexChange(object sender, GridPageEventArgs e)
        {
            FineUI.Grid grid = (FineUI.Grid)sender;
            if (grid.ID == "gridRouting")
            {
                gridRouting.PageIndex = e.NewPageIndex;
                this.BindGrid();
            }
            else
            {
                gridRoutingSub.PageIndex = e.NewPageIndex;
                string id = gridRouting.DataKeys[gridRouting.SelectedRowIndex][0].ToString();
                this.BindGridSub(id);
            }
        }

        //排序
        protected void grid_Sort(object sender, GridSortEventArgs e)
        {
            FineUI.Grid grid = (FineUI.Grid)sender;
            if (grid.ID == "gridRouting")
            {
                gridRouting.SortDirection = e.SortDirection;
                gridRouting.SortField = e.SortField;
                BindGrid();
            }
            if (grid.ID == "gridRoutingSub")
            {
                gridRoutingSub.SortDirection = e.SortDirection;
                gridRoutingSub.SortField = e.SortField;
                string id = gridRouting.DataKeys[gridRouting.SelectedRowIndex][0].ToString();
                this.BindGridSub(id);
            }
        }

        //弹出窗口关闭事件(不包含对话框)
        protected void wd_Close(object sender, WindowCloseEventArgs e)
        {
            if(e.CloseArgument.Contains("Sub"))
            {
                string id = gridRouting.DataKeys[gridRouting.SelectedRowIndex][0].ToString();
                BindGridSub(id);
            }
            else
            {
                this.BindGrid();
                gridRoutingSub.DataSource = null;
                gridRoutingSub.DataBind();
            }
        }

        protected void gridRouting_RowSelect(object sender, GridRowSelectEventArgs e)
        {
            string id = gridRouting.DataKeys[e.RowIndex][0].ToString();
            this.BindGridSub(id);
        }

        protected void btnAddSub_Click(object sender, EventArgs e)
        {
            if (gridRouting.SelectedRowIndex >= 0)
            {
                string url = string.Format("..\\RoutingSub\\Add.aspx?RoutingID={0}", gridRouting.DataKeys[gridRouting.SelectedRowIndex][0]);
                windowPop.Hidden = false;
                windowPop.IFrameUrl = url;
                windowPop.Title = "新增工艺路线子项-" + gridRouting.Rows[gridRouting.SelectedRowIndex].Values[2];
            }
        }
    }
}
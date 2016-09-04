using FineUI;
using System;
using System.Data;
using System.Text;
using Demo.Web.Code;

namespace Demo.Web.Sys.Menu
{
    public partial class List : PageBase
    {
        private StringBuilder condition = new StringBuilder("1=1");

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                btnDelete.OnClientClick = gridMenu.GetNoSelectionAlertReference("至少选择一项！");
                btnAdd.OnClientClick = windowPop.GetShowReference("Add.aspx", "新增");

                BindGrid();
            }
        }

        //Grid绑定数据源
        private void BindGrid()
        {
            condition.Append(" and ID != '0'");
            string sortField = gridMenu.SortField;
            string sortDirection = gridMenu.SortDirection;

            BLL.vw_SYS_Menu bllMenu = new BLL.vw_SYS_Menu();
            DataSet dsMenu = bllMenu.GetList(condition.ToString());
            DataView dvMenu = dsMenu.Tables[0].DefaultView;
            dvMenu.Sort = String.Format("{0} {1}", sortField, sortDirection);

            DataTable dtSource = dvMenu.ToTable();
            gridMenu.RecordCount = dtSource.Rows.Count;
            DataTable dtCurrent = PublicMethod.getPageTable(dtSource, gridMenu.PageIndex, gridMenu.PageSize);
            gridMenu.DataSource = dtCurrent;
            gridMenu.DataBind();
        }

        //删除选中记录集
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            #region 不可用
            //int selectedCount = gridMenu.SelectedRowIndexArray.Length;
            //int deletedCount = 0;
            
            //StringBuilder sb = new StringBuilder();
            //foreach (int row in gridMenu.SelectedRowIndexArray)
            //{
            //    sb.Append("'");
            //    sb.Append(gridMenu.DataKeys[row][0].ToString());
            //    sb.Append("',");
            //}
            //sb.Append("''");

            //BLL.tb_SYS_Menu bllMenu = new BLL.tb_SYS_Menu();
            //bool result = bllMenu.DeleteList(sb.ToString());
            //if(result)
            //{
            //    deletedCount = selectedCount; 
            //}
            //Alert.ShowInTop("你选择了" + selectedCount.ToString() + "行\n成功删除" + deletedCount.ToString() + "行");
            //BindGrid();
            #endregion

            #region 2016/01/30修正
            string id = gridMenu.DataKeys[gridMenu.SelectedRowIndex][0].ToString();

            BLL.tb_SYS_Menu bllMenu = new BLL.tb_SYS_Menu();
            string result = bllMenu.Delete(id);
            if(result == "0")
            {
                Alert.ShowInTop("删除成功", "提示信息", MessageBoxIcon.Information);
                BindGrid();
            }
            else
            {
                hdfMarkRawNO.Text = gridMenu.SelectedRowIndex.ToString();
                Alert.ShowInTop("该项被其他项引用，不能删除！", "提示信息", MessageBoxIcon.Error, "highlightRows();");
            }
            #endregion            
        }

        //清空筛选条件
        protected void btnClearCondition_Click(object sender, EventArgs e)
        {
            //if (Request.Cookies["QueryCondition"] != null)
            //{
            //    Request.Cookies["QueryCondition"].Value = null;
            //    HttpCookie cookie = Request.Cookies["QueryCondition"];
            //    cookie.Expires = DateTime.Now.AddDays(-1);
            //    Response.AppendCookie(cookie);
            //    Alert.ShowInTop("已取消筛选");
            //    this.BindGrid();
            //}
            //else
            //{
            //    Alert.ShowInTop("没有筛选条件");
            //}
        }

        //排序
        protected void gridMenu_Sort(object sender, GridSortEventArgs e)
        {
            gridMenu.SortDirection = e.SortDirection;
            gridMenu.SortField = e.SortField;
            BindGrid();
        }

        //翻页
        protected void grid_PageIndexChange(object sender, GridPageEventArgs e)
        {
            gridMenu.PageIndex = e.NewPageIndex;
            this.BindGrid();
        }

        //弹出窗口关闭事件(不包含对话框)
        protected void wd_Close(object sender, EventArgs e)
        {
            this.BindGrid();
            Alert.ShowInTop("弹出窗口关闭了！");
        }

        //行绑定事件
        protected void gridMenu_RowDataBound(object sender, GridRowEventArgs e)
        {
            hdfMarkRawNO.Text = "";
        }
        
    }
}
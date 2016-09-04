using Demo.Web.Code;
using FineUI;
using System;
using System.Data;
using System.Text;

namespace Demo.Web.Sys.Role
{
    public partial class List : PageBase
    {
        private StringBuilder condition = new StringBuilder("1=1");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnDelete.OnClientClick = gridRole.GetNoSelectionAlertReference("至少选择一项！");
                btnAdd.OnClientClick = windowPop.GetShowReference("Add.aspx", "新增");

                BindGrid();
            }
        }

        //Grid绑定数据源
        private void BindGrid()
        {
            string sortField = gridRole.SortField;
            string sortDirection = gridRole.SortDirection;

            BLL.vw_SYS_Role bllRole = new BLL.vw_SYS_Role();
            DataSet dsRole = bllRole.GetList(condition.ToString());
            DataView dvRole = dsRole.Tables[0].DefaultView;
            dvRole.Sort = String.Format("{0} {1}", sortField, sortDirection);

            DataTable dtSource = dvRole.ToTable();
            gridRole.RecordCount = dtSource.Rows.Count;
            DataTable dtCurrent = PublicMethod.getPageTable(dtSource, gridRole.PageIndex, gridRole.PageSize);
            gridRole.DataSource = dtCurrent;
            gridRole.DataBind();
        }

        //删除选中记录集
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string id = gridRole.DataKeys[gridRole.SelectedRowIndex][0].ToString();

            BLL.tb_SYS_Role bllRole = new BLL.tb_SYS_Role();
            string result = bllRole.Delete(id);
            if (result == "0")
            {
                Alert.ShowInTop("删除成功", "提示信息", MessageBoxIcon.Information);
                BindGrid();
            }
            else
            {
                hdfMarkRawNO.Text = gridRole.SelectedRowIndex.ToString();
                Alert.ShowInTop("该项被其他项引用，不能删除！", "提示信息", MessageBoxIcon.Error, "highlightRows();");
            }

            BLL.tb_SYS_RoleXML bllRoleXML = new BLL.tb_SYS_RoleXML();
            bllRoleXML.Delete(id);
            BLL.tb_SYS_RoleMenu bllRoleMenu = new BLL.tb_SYS_RoleMenu();
            bllRoleMenu.Delete("RoleID='"+id+"'");
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
        protected void gridRole_Sort(object sender, GridSortEventArgs e)
        {
            gridRole.SortDirection = e.SortDirection;
            gridRole.SortField = e.SortField;
            BindGrid();
        }

        //翻页
        protected void grid_PageIndexChange(object sender, GridPageEventArgs e)
        {
            gridRole.PageIndex = e.NewPageIndex;
            this.BindGrid();
        }

        //弹出窗口关闭事件(不包含对话框)
        protected void wd_Close(object sender, EventArgs e)
        {
            this.BindGrid();
            Alert.ShowInTop("弹出窗口关闭了！");
        }

        //行绑定事件
        protected void gridRole_RowDataBound(object sender, GridRowEventArgs e)
        {
            hdfMarkRawNO.Text = "";
        }
    }
}
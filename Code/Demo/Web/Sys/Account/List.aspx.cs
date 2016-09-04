using Demo.Web.Code;
using FineUI;
using System;
using System.Data;
using System.Text;

namespace Demo.Web.Sys.Account
{
    public partial class List : PageBase
    {
        private StringBuilder condition = new StringBuilder("1=1");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnDelete.OnClientClick = gridAccount.GetNoSelectionAlertReference("至少选择一项！");

                BindGrid();
            }
        }

        //Grid绑定数据源
        private void BindGrid()
        {
            string sortField = gridAccount.SortField;
            string sortDirection = gridAccount.SortDirection;

            BLL.tb_SYS_Account bllAccount = new BLL.tb_SYS_Account();
            DataSet dsAccount = bllAccount.GetList(condition.ToString());
            DataView dvAccount = dsAccount.Tables[0].DefaultView;
            dvAccount.Sort = String.Format("{0} {1}", sortField, sortDirection);

            DataTable dtSource = dvAccount.ToTable();
            gridAccount.RecordCount = dtSource.Rows.Count;
            DataTable dtCurrent = PublicMethod.getPageTable(dtSource, gridAccount.PageIndex, gridAccount.PageSize);
            gridAccount.DataSource = dtCurrent;
            gridAccount.DataBind();
        }

        //绑定角色名称
        protected string getRoleName(string roleID)
        {
            BLL.tb_SYS_Role bllRole = new BLL.tb_SYS_Role();
            DataSet dsRole = bllRole.GetList("ID='" + roleID + "'");
            string roleName = dsRole.Tables[0].Rows[0]["RoleName"].ToString();
            return roleName;
        }

        //删除选中记录集
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string id = gridAccount.DataKeys[gridAccount.SelectedRowIndex][0].ToString();

            BLL.tb_SYS_Account bllAccount = new BLL.tb_SYS_Account();
            bool result = bllAccount.Delete(id);
            if (result)
            {
                Alert.ShowInTop("删除成功", "提示信息", MessageBoxIcon.Information);
                BindGrid();
            }
            else
            {
                Alert.ShowInTop("删除失败", "提示信息", MessageBoxIcon.Error);
            }
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
        protected void gridAccount_Sort(object sender, GridSortEventArgs e)
        {
            gridAccount.SortDirection = e.SortDirection;
            gridAccount.SortField = e.SortField;
            BindGrid();
        }

        //翻页
        protected void grid_PageIndexChange(object sender, GridPageEventArgs e)
        {
            gridAccount.PageIndex = e.NewPageIndex;
            this.BindGrid();
        }

        //弹出窗口关闭事件(不包含对话框)
        protected void wd_Close(object sender, EventArgs e)
        {
            this.BindGrid();
            Alert.ShowInTop("弹出窗口关闭了！");
        }
    }
}
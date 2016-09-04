using FineUI;
using System;
using System.Data;

namespace Demo.Web.Trigger
{
    public partial class Role : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }
        }

        //Grid绑定数据源
        private void BindGrid()
        {
            string strWhere = string.Format("1=1");
            string order = string.Format("{0} {1}", gridRole.SortField, gridRole.SortDirection);
            int pageSize = gridRole.PageSize;
            int pageIndex = gridRole.PageIndex;
            long recordCount;

            BLL.tb_SYS_Role bllRole = new BLL.tb_SYS_Role();
            DataSet dsRole = bllRole.GetListByPage(strWhere, order, pageSize, pageIndex, out recordCount);
            DataTable dtSource = dsRole.Tables[0];

            gridRole.DataSource = dtSource;
            gridRole.RecordCount = (int)recordCount;
            gridRole.DataBind();
        }

        //保存选择
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (gridRole.SelectedRowIndexArray.Length == 0)
            {
                Alert.ShowInTop("未选择数据", "提示信息", MessageBoxIcon.Error);
                return;
            }
            //关闭本窗体，然后回发父窗体
            PageContext.RegisterStartupScript(ActiveWindow.GetWriteBackValueReference(gridRole.DataKeys[gridRole.SelectedRowIndex][1].ToString()
                , gridRole.DataKeys[gridRole.SelectedRowIndex][0].ToString())
                + ActiveWindow.GetHidePostBackReference());
        }

        //关闭页面
        protected void btnClose_Click(object sender, EventArgs e)
        {
            if (gridRole.SelectedRowIndexArray.Length == 0)
            {
                Alert.ShowInTop("未选择数据", "提示信息", MessageBoxIcon.Information, ActiveWindow.GetHideReference());
            }
            else
            {
                Alert.ShowInTop("您已选择了一条数据，是否确认关闭本窗口？", "提示信息", MessageBoxIcon.Question, ActiveWindow.GetHideReference());
            }
        }
    }
}
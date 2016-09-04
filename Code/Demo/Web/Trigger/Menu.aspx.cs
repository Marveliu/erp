using FineUI;
using System;
using System.Data;
using Demo.Web.Code;

namespace Demo.Web.Trigger
{
    public partial class Menu : PageBase
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
            BLL.tb_SYS_Menu bllMenu = new BLL.tb_SYS_Menu();
            DataSet dsMenu = bllMenu.GetList("1=1 order by MenuNO");

            DataTable dtSource = PublicMethod.sortToTree(dsMenu.Tables[0], "MenuNO", "ID", "ParentID");
            gridMenu.DataSource = dtSource;
            gridMenu.DataBind();
        }

        //保存选择
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if(gridMenu.SelectedRowIndexArray.Length == 0)
            {
                Alert.ShowInTop("未选择数据", "提示信息", MessageBoxIcon.Error);
                return;
            }
            //关闭本窗体，然后回发父窗体
            PageContext.RegisterStartupScript(ActiveWindow.GetWriteBackValueReference(gridMenu.DataKeys[gridMenu.SelectedRowIndex][2].ToString()
                ,gridMenu.DataKeys[gridMenu.SelectedRowIndex][0].ToString(),gridMenu.DataKeys[gridMenu.SelectedRowIndex][1].ToString()) 
                + ActiveWindow.GetHidePostBackReference());
        }

        //关闭页面
        protected void btnClose_Click(object sender, EventArgs e)
        {
            if(gridMenu.SelectedRowIndexArray.Length == 0)
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
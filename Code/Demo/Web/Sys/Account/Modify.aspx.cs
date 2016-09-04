using FineUI;
using System;
using System.Data;
using System.Text;

namespace Demo.Web.Sys.Account
{
    public partial class Modify : PageBase
    {
        private StringBuilder condition = new StringBuilder();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
            }
        }

        //加载数据
        private void LoadData()
        {
            //绑定修改前数据
            condition.Append("ID='").Append(Request.QueryString["ID"].ToString()).Append("'");
            BLL.vw_SYS_Account bllAccount_vw = new BLL.vw_SYS_Account();
            DataTable dtAccount = bllAccount_vw.GetList(condition.ToString()).Tables[0];

            txbAccountName.Text = dtAccount.Rows[0]["AccountName"].ToString();
            txbPassword.Text = dtAccount.Rows[0]["Password"].ToString();
            tgbRoleName.Text = dtAccount.Rows[0]["RoleName"].ToString();
            hdfRoleID.Text = dtAccount.Rows[0]["RoleID"].ToString();
        }

        //保存修改
        protected void btnSave_Click(object sender, EventArgs e)
        {
            Model.tb_SYS_Account modelAccount = new Model.tb_SYS_Account();
            modelAccount.ID = Request.QueryString["ID"].ToString();
            modelAccount.AccountName = txbAccountName.Text;
            modelAccount.Password = txbPassword.Text;
            modelAccount.RoleID = hdfRoleID.Text;
            modelAccount.UpdateID = Session["AccountID"].ToString();
            modelAccount.UpdateTime = DateTime.Now;

            BLL.tb_SYS_Account bllAccount = new BLL.tb_SYS_Account();
            bool result = bllAccount.Update(modelAccount);
            if (!result)
            {
                Alert.ShowInTop("更新失败", "提示信息", MessageBoxIcon.Error, ActiveWindow.GetHideRefreshReference());
            }
            else
            {
                Alert.ShowInTop("更新成功", "提示信息", MessageBoxIcon.Information, ActiveWindow.GetHideRefreshReference());
            }
        }

        //关闭页面
        protected void btnClose_Click(object sender, EventArgs e)
        {
            Alert.ShowInTop("关闭本窗口,您所做的修改将不被保存", "提示信息", MessageBoxIcon.Information, ActiveWindow.GetHideReference());
        }

        //弹出窗口关闭事件(不包含对话框)
        protected void wd_Close(object sender, EventArgs e)
        {
            Alert.ShowInTop("弹出窗口关闭了！");
        }
    }
}
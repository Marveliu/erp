using System;
using FineUI;
using System.Data;

namespace Demo.Web
{
    public partial class Login : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
            }
            if(Session["AccountName"] != null)
            {
                Response.Redirect("Default.aspx");
            }
        }

        //登录事件
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            //检测账户信息是否正确
            BLL.vw_SYS_Account bllAccount_vw = new BLL.vw_SYS_Account();
            string strWhere = "AccountName='" + txbUserName.Text + "' and Password='" + txbPassword.Text + "'";
            DataSet dsAccount = bllAccount_vw.GetList(strWhere);
            if (dsAccount.Tables[0].Rows.Count > 0)
            {
                Session["AccountName"] = txbUserName.Text;
                Session["AccountID"] = dsAccount.Tables[0].Rows[0]["ID"].ToString();
                Session["RoleName"] = dsAccount.Tables[0].Rows[0]["RoleName"].ToString();
                Alert.ShowInTop("登陆成功!", "提示信息", MessageBoxIcon.Information, "location.href='Default.aspx';");
                return;
            }
            else
            {
                Alert.ShowInTop("用户名不存在 或 密码错误！", "提示信息", MessageBoxIcon.Warning);
            }

            #region 是否为系统初始账户
            if (txbUserName.Text == "YJQ" && txbPassword.Text == "1111")
            {
                Model.tb_SYS_Account modelAccount = new Model.tb_SYS_Account();

                modelAccount.ID = Guid.NewGuid().ToString();
                modelAccount.AccountName = txbUserName.Text;
                modelAccount.Password = txbPassword.Text;
                modelAccount.AccountType = "0";
                modelAccount.CreateID = modelAccount.ID;
                modelAccount.CreateTime = DateTime.Now;
                modelAccount.State = "1";

                BLL.tb_SYS_Account bllAccount = new BLL.tb_SYS_Account();
                bool result = bllAccount.Add(modelAccount);
                if(!result)
                {
                    Alert.ShowInTop("初始账户添加失败！", "提示信息", MessageBoxIcon.Error);
                }
                else
                {
                    Alert.ShowInTop("成功添加初始账户!", "提示信息", MessageBoxIcon.Information, "location.href='Default.aspx';");
                }
            }
            #endregion
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }
    }
}
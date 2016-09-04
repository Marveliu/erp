using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FineUI;
using Demo.Model;
using Demo.BLL;

namespace Demo.Web
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
            }
        }


        private void LoadData()
        {
            InitCaptchaCode();
        }

        /// <summary>
        /// 初始化验证码
        /// </summary>
        private void InitCaptchaCode()
        {
            // 创建一个 6 位的随机数并保存在 Session 对象中
            Session["CaptchaImageText"] = GenerateRandomCode();
            imgCaptcha.ImageUrl = "captcha.ashx?w=150&h=30&t=" + DateTime.Now.Ticks;
        }

        /// <summary>
        /// 创建一个 6 位的随机数
        /// </summary>
        /// <returns></returns>
        private string GenerateRandomCode()
        {
            string s = String.Empty;
            Random random = new Random();
            for (int i = 0; i < 6; i++)
            {
                s += random.Next(10).ToString();
            }
            return s;
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            InitCaptchaCode();
        }


        protected void btnRegister_Click(object sender, EventArgs e)
        {
            if (tbxCaptcha.Text != Session["CaptchaImageText"].ToString())
            {
                Alert.ShowInTop("验证码错误！");
                return;
            }
            //检验账号是否被注册
            Demo.BLL.tb_SYS_Account bll = new Demo.BLL.tb_SYS_Account();

            if (bll.GetModelList("AccountName = '" + tbxUserName +"'").Count>0)
            {
                //该用户已经被注册
                Alert.ShowInTop("该用户已经被注册！", MessageBoxIcon.Error);
            }
            else
            {
                //注册该用户

                Demo.Model.tb_SYS_Account model = new Demo.Model.tb_SYS_Account();

                model.ID = Guid.NewGuid().ToString();
                model.AccountName = tbxUserName.Text.Trim();
                model.CreateID = Guid.NewGuid().ToString();
                model.Password = tbxPassword.Text.ToString();
                model.CreateTime = DateTime.Now;
                model.RoleID = "a58ed217-31b5-48fe-b8ed-b28d452a797d";

                if(bll.Add(model))
                {
                    Alert.ShowInTop("注册成功！", MessageBoxIcon.Information);
                    Session["AccountName"] = tbxUserName.Text;
                    Session["AccountID"] = model.ID;
                    Session["RoleName"] =  "未认证角色";
                    Response.Redirect("Default.aspx");
                }
                else
                {
                    Alert.ShowInTop("注册失败！", MessageBoxIcon.Error);
                }


            }
        }
    }
}
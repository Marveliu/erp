using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Demo.BLL;
using Demo.Model;
using FineUI;


namespace Demo.Web.JC.Deptment
{
    public partial class listdeptmodify : System.Web.UI.Page
    {
        public static string id = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                id = Request.QueryString["id"].ToString().Trim();
                BindGrid(id);
            }
        }

        public void BindGrid(string id)
        {
            Demo.BLL.tb_JC_Department bll = new Demo.BLL.tb_JC_Department();
            Demo.Model.tb_JC_Department dept = new Demo.Model.tb_JC_Department();

            dept = bll.GetModel(id);

            DeptmentId.Text = dept.ID;
            DepartmentNO.Text = dept.DepartmentNO;
            DepartmentName.Text = dept.DepartmentName;

        }


        protected void btnSaveRefresh_Click(object sender, EventArgs e)
        {
            // 1. 这里放置保存窗体中数据的逻辑

            Demo.BLL.tb_JC_Department bll = new Demo.BLL.tb_JC_Department();
            Demo.Model.tb_JC_Department dept = new Demo.Model.tb_JC_Department();

            dept.ID = DeptmentId.Text.Trim();
            dept.DepartmentNO = DepartmentNO.Text.Trim();
            dept.DepartmentName = DepartmentName.Text.Trim();

            if (bll.Update(dept))
            {
                Alert.ShowInTop("添加成功");
            }
            else
            {
                Alert.ShowInTop("添加失败");
            }

            // 2. 关闭本窗体，然后刷新父窗体
            PageContext.RegisterStartupScript(ActiveWindow.GetHideRefreshReference());
        }
    }
}
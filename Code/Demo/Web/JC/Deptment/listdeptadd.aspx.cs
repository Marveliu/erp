using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FineUI;
using Demo.BLL;
using Demo.Model;

namespace Demo.Web.JC.Deptment
{
    public partial class listdeptadd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSaveRefresh_Click(object sender, EventArgs e)
        {
            // 1. 这里放置保存窗体中数据的逻辑

            Demo.BLL.tb_JC_Department bll = new Demo.BLL.tb_JC_Department();
            Demo.Model.tb_JC_Department dept = new Demo.Model.tb_JC_Department();

            dept.ID = Guid.NewGuid().ToString();
            dept.DepartmentNO = DepartmentNO.Text.Trim();
            dept.DepartmentName = DepartmentName.Text.Trim();

            if (bll.Add(dept))
            {
                Alert.ShowInTop("添加成功");
            }
            else
            {
                Alert.ShowInTop("添加失败");
            }

            // 2. 关闭本窗体，然后刷新父窗体
            PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
        }
    }
}
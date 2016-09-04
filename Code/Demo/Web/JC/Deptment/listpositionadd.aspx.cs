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
    public partial class add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDataTableToDropDownList();

            }
        }


        #region BindDataTableToDropDownList

        private void BindDataTableToDropDownList()
        {
            List<CustomClass> myList = new List<CustomClass>();

            Demo.BLL.tb_JC_Department bll = new Demo.BLL.tb_JC_Department();

            //泛型
            List<Demo.Model.tb_JC_Department> model = new List<Demo.Model.tb_JC_Department>();

            model = bll.GetModelList("");

            foreach (Demo.Model.tb_JC_Department temp in model)
            {
                myList.Add(new CustomClass(temp.DepartmentNO, temp.DepartmentName));

            }


            DropDownList1.DataTextField = "Name";
            DropDownList1.DataValueField = "ID";
            DropDownList1.DataSource = myList;
            DropDownList1.DataBind();
        }

        #endregion

        #region Events

        protected void btnGetSelection_Click(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedItem != null)
            {
                labResult.Text = String.Format("部门名称：{0}（编号：{1}）", DropDownList1.SelectedItem.Text, DropDownList1.SelectedValue);
            }
            else
            {
                labResult.Text = "无选中项";
            }
        }

        protected void btnSaveRefresh_Click(object sender, EventArgs e)
        {
            // 1. 这里放置保存窗体中数据的逻辑

            Demo.BLL.tb_JC_Position bll = new Demo.BLL.tb_JC_Position();
            Demo.Model.tb_JC_Position model = new Demo.Model.tb_JC_Position();

            model.ID = Guid.NewGuid().ToString();
            model.PositionNO = positionnno.Text.Trim();
            model.PositionName = positionname.Text.Trim();
            model.DepartmentNO = DropDownList1.SelectedItem.Value.Trim();


            if (bll.Add(model))
            {
                Alert.ShowInTop("添加成功");
            }
            else
            {
                Alert.ShowInTop("添加失败");
            }
            PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
        }

        public class CustomClass
        {
            private string _id;

            public string ID
            {
                get { return _id; }
                set { _id = value; }
            }
            private string _name;

            public string Name
            {
                get { return _name; }
                set { _name = value; }
            }

            public CustomClass(string id, string name)
            {
                _id = id;
                _name = name;
            }
        }
        #endregion
    }
}
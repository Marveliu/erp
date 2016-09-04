using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using FineUI;
using Demo.BLL;
using Demo.Model;

namespace Demo.Web.JC.Deptment
{
    public partial class listemployeemodify : System.Web.UI.Page
    {
        public static string id = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                id = Request.QueryString["id"].ToString().Trim();
                dept();
                position();
                BindGrid(id);
            }
        }

        public void BindGrid(string id)
        {
            Demo.BLL.tb_JC_Employee bll = new Demo.BLL.tb_JC_Employee();
            Demo.Model.tb_JC_Employee model = new Demo.Model.tb_JC_Employee();

            model = bll.GetModel(id);

            employeeno.Text = model.EmployeeName.ToString();
            employeename.Text = model.EmployeeName.ToString();
            emid.Text = model.ID.ToString();

            DropDownList2.SelectedValue = model.PositionNO.ToString();
            DropDownList1.SelectedValue = model.DepartmentNO.ToString();
            sex.SelectedValue = model.Sex.ToString();

            age.Text = model.Age.ToString();
            email.Text = model.Email.ToString();
            phone.Text = model.MobileNumber.ToString();

            entrydate.Text = model.EntryDate.ToString();
            leavedate.Text = model.LeaveDate.ToString();

            nation.Text = model.Nation.ToString();
            nativeplace.Text = model.NativePlace.ToString();
            politicalstatus.SelectedValue = model.PoliticalStatus.ToString();
            Maritialstatus.SelectedValue = model.MaritialStatus.ToString();

            // deptno.SelectedValue = deptbll.GetModelList("where DeptmentNo = "+  model.DepartmentNO)[0].DepartmentName;


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
        private void dept()
        {

            List<CustomClass> myList1 = new List<CustomClass>();
            Demo.BLL.tb_JC_Department bll = new Demo.BLL.tb_JC_Department();

            //泛型
            List<Demo.Model.tb_JC_Department> model = new List<Demo.Model.tb_JC_Department>();
            model = bll.GetModelList("");
            foreach (Demo.Model.tb_JC_Department temp in model)
            {
                myList1.Add(new CustomClass(temp.DepartmentNO, temp.DepartmentName));

            }

            DropDownList1.DataTextField = "Name";
            DropDownList1.DataValueField = "ID";
            DropDownList1.DataSource = myList1;
            DropDownList1.DataBind();

            DropDownList1.Items.Insert(0, new ListItem("请选择部门", "-1"));
            DropDownList1.SelectedValue = "-1";
        }

        /// <summary>
        /// 二级联动职位
        /// </summary>
        private void position()
        {
            string deptno = DropDownList1.SelectedValue;

            if (deptno != "-1")
            {
                List<CustomClass> myList2 = new List<CustomClass>();

                Demo.BLL.tb_JC_Position bll = new Demo.BLL.tb_JC_Position();
                List<Demo.Model.tb_JC_Position> model = new List<Demo.Model.tb_JC_Position>();
                //联动
                model = bll.GetModelList("DepartmentNO = '" + deptno + "'");

                foreach (Demo.Model.tb_JC_Position temp in model)
                {
                    myList2.Add(new CustomClass(temp.PositionNO, temp.PositionName));
                }

                DropDownList2.DataTextField = "Name";
                DropDownList2.DataValueField = "ID";
                DropDownList2.DataSource = myList2;
                DropDownList2.DataBind();
            }

            DropDownList2.Items.Insert(0, new ListItem("请选择职位", "-1"));
            DropDownList2.SelectedValue = "-1";

            // 是否禁用
            DropDownList2.Enabled = !(DropDownList1.Items.Count == 1);
        }

        /// <summary>
        /// 重新绑定职位
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList2.Items.Clear();
            position();
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        protected void btnSaveRefresh_Click(object sender, EventArgs e)
        {
            // 1. 这里放置保存窗体中数据的逻辑

            Demo.BLL.tb_JC_Employee bll = new Demo.BLL.tb_JC_Employee();
            Demo.Model.tb_JC_Employee model = new Demo.Model.tb_JC_Employee();


            model.EmployeeNO = employeeno.Text.Trim();
            model.EmployeeName = employeename.Text.Trim();

            model.ID = Guid.NewGuid().ToString();
            model.PositionNO = DropDownList2.SelectedValue;
            model.DepartmentNO = DropDownList1.SelectedValue;
            model.Sex = sex.SelectedText; ;
            model.Age = Convert.ToInt16(age.Text.Trim());
            model.Email = email.Text.Trim();
            model.MobileNumber = phone.Text.Trim();

            model.EntryDate = Convert.ToDateTime(entrydate.SelectedDate);
            model.LeaveDate = Convert.ToDateTime(leavedate.SelectedDate.HasValue ? entrydate.SelectedDate.Value.ToString("yyyy-MM-dd") : "");

            model.Nation = nation.Text;
            model.NativePlace = nativeplace.Text;
            model.PoliticalStatus = politicalstatus.SelectedValue;
            model.MaritialStatus = Maritialstatus.SelectedValue;


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



        protected void entrydate_TextChanged(object sender, EventArgs e)
        {
            if (entrydate.SelectedDate.HasValue)
            {
                leavedate.SelectedDate = entrydate.SelectedDate.Value.AddMonths(3);
            }
        }
    }
}
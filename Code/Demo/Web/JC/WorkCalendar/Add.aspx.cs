using System;
using System.Linq;
using FineUI;
using System.Collections.Generic;

namespace Demo.Web.JC.WorkCalendar
{
    public partial class Add : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                btnClose.OnClientClick = ActiveWindow.GetHideReference();
            }           
        }

        private void ddlWeekBind()
        {
            Dictionary<string, string> week = new Dictionary<string, string>();
            week.Add("--请选择--", "0");
            week.Add("星期一", "1");
            week.Add("星期二", "2");
            week.Add("星期三", "3");
            week.Add("星期四", "4");
            week.Add("星期五", "5");
            week.Add("星期六", "6");
            week.Add("星期日", "7");

            ddlWeek.DataSource = week;
            ddlWeek.DataTextField = "Key";
            ddlWeek.DataValueField = "Value";           
            ddlWeek.DataBind();
        }

        protected void ddlExceptionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlExceptionType.SelectedValue == "W")
            {
                nbxMonth.Hidden = true;
                nbxDay.Hidden = true;
                ddlWeekBind();
                ddlWeek.Hidden = false;
            }
            else if (ddlExceptionType.SelectedValue == "D")
            {
                ddlWeek.Hidden = true;
                nbxMonth.Hidden = false;
                nbxDay.Hidden = false;
            }
            else if (ddlExceptionType.SelectedValue == "M")
            {
                ddlWeek.Hidden = true;
                nbxMonth.Hidden = false;
                nbxDay.Hidden = true;
            }
            else
            {
                nbxMonth.Hidden = true;
                nbxDay.Hidden = true;
                ddlWeek.Hidden = true;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            #region 空值检测
            if ("C" == ddlExceptionType.SelectedValue)
            {
                Alert.ShowInTop("无有效设置", "警告", MessageBoxIcon.Warning);
                return;
            }
            if ("W" == ddlExceptionType.SelectedValue && ddlWeek.SelectedIndex < 1)
            {
                Alert.ShowInTop("请选择星期", "警告", MessageBoxIcon.Warning);
                return;
            }
            if ("D" == ddlExceptionType.SelectedValue && "" == nbxMonth.Text)
            {
                Alert.ShowInTop("请选择月份", "警告", MessageBoxIcon.Warning);
                return;
            }
            if ("D" == ddlExceptionType.SelectedValue && "" == nbxDay.Text)
            {
                Alert.ShowInTop("请选择日期", "警告", MessageBoxIcon.Warning);
                return;
            }
            if ("M" == ddlExceptionType.SelectedValue && "" == nbxMonth.Text)
            {
                Alert.ShowInTop("请选择月份", "警告", MessageBoxIcon.Warning);
                return;
            }
            #endregion
            #region 日期规则检测
            string[] month30 = { "4", "6", "9", "11" };
            if (month30.Contains(nbxMonth.Text) && int.Parse(nbxDay.Text) > 30)
            {         
                Alert.ShowInTop(nbxDay.Text + "月共有30天！", "错误", MessageBoxIcon.Error);
            }
            if ("2" == nbxMonth.Text && int.Parse(nbxDay.Text) > 29)
            {
                Alert.ShowInTop("2月最多29天！", "错误", MessageBoxIcon.Error);
            }
            #endregion
            #region 保存
            Model.tb_JC_WorkCalendarRule modelRule = new Model.tb_JC_WorkCalendarRule();
            modelRule.ID = Guid.NewGuid().ToString();
            modelRule.ExceptionType = ddlExceptionType.SelectedValue;
            if(ddlExceptionType.SelectedValue == "W")
            {
                modelRule.ExceptionTime = ddlWeek.SelectedValue;
            }
            else if(ddlExceptionType.SelectedValue == "M")
            {
                modelRule.ExceptionTime = nbxMonth.Text;
            }
            else
            {
                modelRule.ExceptionTime = string.Format("{0}-{1}", nbxMonth, nbxDay);
            }
            BLL.tb_JC_WorkCalendarRule bllRule = new BLL.tb_JC_WorkCalendarRule();
            bool result = bllRule.Add(modelRule);
            if(result)
            {
                Alert.ShowInTop("添加成功", "信息", MessageBoxIcon.Information, ActiveWindow.GetHidePostBackReference("Main_Add_Success"));
            }
            else
            {
                Alert.ShowInTop("添加失败", "错误", MessageBoxIcon.Error, ActiveWindow.GetHidePostBackReference("Main_Add_Fail"));
            }
            #endregion
        }
    }
}
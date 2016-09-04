using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI.WebControls;
using System.Drawing;

namespace Demo.Web.JC.WorkCalendar
{
    public partial class Calendar : PageBase
    {
        private List<DateTime?> Dates = new List<DateTime?>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                InitDates(DateTime.Today.Month);
            }
        }

        private void InitDates(int month)
        {
            string strWhere = string.Format("datepart(month,[Date]) in ({0},{1},{2})",month-1, month,month+1);
            BLL.tb_JC_WorkCalendar bllCalendar = new BLL.tb_JC_WorkCalendar();
            DataTable dtSource = bllCalendar.GetList(strWhere).Tables[0];
            foreach(DataRow dr in dtSource.Rows)
            {
                Dates.Add((DateTime?)dr["Date"]);
            }
        }

        protected void calendarWork_DayRender(object sender, DayRenderEventArgs e)
        {
            e.Day.IsSelectable = false;
            if(!Dates.Contains(e.Day.Date))
            {
                e.Cell.BackColor = ColorTranslator.FromHtml("#e7e7e7");
                e.Cell.Font.Strikeout = true;
                //e.Cell.ForeColor = ColorTranslator.FromHtml("#e7e7e7");
            }
        }

        protected void calendarWork_VisibleMonthChanged(object sender, MonthChangedEventArgs e)
        {
            InitDates(e.NewDate.Month);
        }
    }
}
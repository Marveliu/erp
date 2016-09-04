using System;
using FineUI;
using System.Data;

namespace Demo.Web.JC.WorkCalendar
{
    public partial class List : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                btnAdd.OnClientClick = windowPop.GetShowReference("Add.aspx", "新增");
                gridCalendarRule.SortField = "ID";
                BindGrid();
            }
        }

        protected string getExceptionType(string key)
        {
            string value;
            switch (key)
            {
                case "W": value = "星期"; break;
                case "D": value = "日期"; break;
                case "M": value = "月份"; break;
                default : value = "Error"; break;
            }
            return value;
        }

        private void BindGrid()
        {
            string strWhere = "1=1";
            string order = string.Format("{0} {1}", gridCalendarRule.SortField, gridCalendarRule.SortDirection);
            int pageSize = gridCalendarRule.PageSize;
            int pageIndex = gridCalendarRule.PageIndex;
            long totalRecord;
            BLL.tb_JC_WorkCalendarRule bllRule = new BLL.tb_JC_WorkCalendarRule();
            DataTable dtSource = bllRule.GetListByPage(strWhere, order, pageSize, pageIndex, out totalRecord).Tables[0];
            gridCalendarRule.DataSource = dtSource;
            gridCalendarRule.RecordCount = (int)totalRecord;
            gridCalendarRule.DataBind();
        }

        protected void grid_Sort(object sender, GridSortEventArgs e)
        {
            gridCalendarRule.SortDirection = e.SortDirection;
            gridCalendarRule.SortField = e.SortField;
            BindGrid();
        }

        protected void grid_PageIndexChange(object sender, GridPageEventArgs e)
        {
            gridCalendarRule.PageIndex = e.NewPageIndex;
            this.BindGrid();
        }

        protected void wd_Close(object sender, EventArgs e)
        {
            this.BindGrid();
        }

        protected void btnBuildCalendar_Click(object sender, EventArgs e)
        {
            BLL.tb_JC_WorkCalendarRule bllRule = new BLL.tb_JC_WorkCalendarRule();
            bllRule.BuildCalendar(DateTime.Today);
            //重新加载日历页面
            string script = string.Format("{0}.src='Calendar.aspx';",panelBottom.FindControl("calendar").ClientID);
            PageContext.RegisterStartupScript(script);
        }

        protected void gridCalendarRule_RowCommand(object sender, GridCommandEventArgs e)
        {
            if(e.CommandName == "ActionDel")
            {
                BLL.tb_JC_WorkCalendarRule bllRule = new BLL.tb_JC_WorkCalendarRule();
                bool result = bllRule.Delete(gridCalendarRule.DataKeys[e.RowIndex][0].ToString());
                if(result)
                {
                    Alert.ShowInTop("删除成功", "信息", MessageBoxIcon.Information);
                }
                else
                {
                    Alert.ShowInTop("删除失败", "错误", MessageBoxIcon.Error);
                }
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using FineUI;
using System.Text;
using System.IO;
using AspNet = System.Web.UI.WebControls;
using Demo.BLL;

namespace Demo.Web.JC.Deptment
{
    public partial class list1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid1();
                BindGrid2();
                BindGrid3();
                ddlPageSize.SelectedValue = Grid1.PageSize.ToString();
                ddlPageSize2.SelectedValue = Grid2.PageSize.ToString();
                ddlPageSize3.SelectedValue = Grid3.PageSize.ToString();
            }
        }

        #region GRID1 DEPT
        private void BindGrid1()
        {
            // 1.设置总项数
            Grid1.RecordCount = GetTotalCount();

            // 2.获取当前分页数据
            DataTable table = GetPagedDataTable(Grid1.PageIndex, Grid1.PageSize);

            // 3.绑定到Grid
            Grid1.DataSource = table;
            Grid1.DataBind();
        }

        /// <summary>
        /// 模拟返回总项数
        /// </summary>
        /// <returns></returns>
        private int GetTotalCount()
        {
            Demo.BLL.tb_JC_Department bll = new Demo.BLL.tb_JC_Department();
            return bll.GetList("").Tables[0].Rows.Count;
        }

        /// <summary>
        /// 模拟数据库分页
        /// </summary>
        /// <returns></returns>
        private DataTable GetPagedDataTable(int pageIndex, int pageSize)
        {


            Demo.BLL.tb_JC_Department bll = new Demo.BLL.tb_JC_Department();
            DataTable source = bll.GetList("").Tables[0];

            DataTable paged = source.Clone();

            int rowbegin = pageIndex * pageSize;
            int rowend = (pageIndex + 1) * pageSize;
            if (rowend > source.Rows.Count)
            {
                rowend = source.Rows.Count;
            }

            for (int i = rowbegin; i < rowend; i++)
            {
                paged.ImportRow(source.Rows[i]);
            }

            return paged;
        }
   
        protected void Grid1_PageIndexChange(object sender, GridPageEventArgs e)
        {
            Grid1.PageIndex = e.NewPageIndex;
            BindGrid1();
        }

        protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            Grid1.PageSize = Convert.ToInt32(ddlPageSize.SelectedValue);

            //// 更改每页显示数目时，防止 PageIndex 越界
            //if (Grid1.PageIndex > Grid1.PageCount - 1)
            //{
            //    Grid1.PageIndex = Grid1.PageCount - 1;
            //}

            BindGrid1();
        }

        protected void btnExport1_Click(object sender, EventArgs e)
        {
            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment; filename=news.xls");
            Response.ContentType = "application/excel";
            Response.ContentEncoding = System.Text.Encoding.UTF8;
            Response.Write(GetGridTableHtml(Grid1));
            Response.End();
        }

        protected void ttbSearch1_Trigger1Click(object sender, EventArgs e)
        {
            //clear
            ttbSearch1.Text = String.Empty;
            ttbSearch1.ShowTrigger1 = false;

            Alert.ShowInTop("well！");
        }

        protected void ttbSearch1_Trigger2Click(object sender, EventArgs e)
        {
            //search
            Demo.BLL.tb_JC_Department bll = new Demo.BLL.tb_JC_Department();
            Demo.Model.tb_JC_Department model = new Demo.Model.tb_JC_Department();
            string deptname = ttbSearch1.Text.Trim();
            model = bll.GetModelList("DepartmentName = '" + deptname + "'")[0];

            if (model.DepartmentNO == null)
            {
                Alert.ShowInTop("未找到改部门！");
            }
            else
            {
                PageContext.RegisterStartupScript(Window1.GetShowReference(String.Format("~/Web/JC/deptment/listdeptmodify.aspx?id={0}&deptno={1}", model.ID, model.DepartmentNO), "编辑"));
            }
        }

        protected void btnInsert1_Click(object sender, EventArgs e)
        {
            PageContext.RegisterStartupScript(Window1.GetShowReference("~/Web/JC/deptment/listdeptadd.aspx", "新增"));
        }

        protected void btnEdit1_Click(object sender, EventArgs e)
        {
            if (Grid1.SelectedRowIndexArray.Length == 0)
            {
                Alert.ShowInTop("请至少选择一条记录！");
                return;
            }
            object[] keys = Grid1.DataKeys[Grid1.SelectedRowIndex];
            PageContext.RegisterStartupScript(Window1.GetShowReference(String.Format("~/Web/JC/deptment/listdeptmodify.aspx?id={0}&deptno={1}", keys[0], HttpUtility.UrlEncode(keys[1].ToString())), "编辑"));

        }

        protected void btnDelete1_Click(object sender, EventArgs e)
        {
            if (Grid1.SelectedRowIndexArray.Length == 0)
            {
                Alert.ShowInTop("请至少选择一条记录！");
                return;
            }

            Demo.BLL.tb_JC_Department bll = new Demo.BLL.tb_JC_Department();

            foreach (int n in Grid1.SelectedRowIndexArray)
            {
                object[] keys = Grid1.DataKeys[n];
                string id = keys[0].ToString();
                bll.Delete(id);
            }

            BindGrid1();

            Alert.ShowInTop("删除成功");
        }

        protected void Grid1_RowDoubleClick(object sender, GridRowClickEventArgs e)
        {
            Alert.ShowInTop("FUCK");
        }
        #endregion

        #region GRID2 POSITION
        private void BindGrid2()
        {
            // 1.设置总项数
            Grid2.RecordCount = GetTotalCount2();

            // 2.获取当前分页数据
            DataTable table = GetPagedDataTable2(Grid2.PageIndex, Grid2.PageSize);

            // 3.绑定到Grid
            Grid2.DataSource = table;
            Grid2.DataBind();
        }

        /// <summary>
        /// 模拟返回总项数
        /// </summary>
        /// <returns></returns>
        private int GetTotalCount2()
        {
            Demo.BLL.tb_JC_Position bll = new Demo.BLL.tb_JC_Position();
            return bll.GetList("").Tables[0].Rows.Count;
        }

        /// <summary>
        /// 模拟数据库分页
        /// </summary>
        /// <returns></returns>
        private DataTable GetPagedDataTable2(int pageIndex, int pageSize)
        {


            Demo.BLL.tb_JC_Position bll = new Demo.BLL.tb_JC_Position();
            DataTable source = bll.GetList("").Tables[0];

            DataTable paged = source.Clone();

            int rowbegin = pageIndex * pageSize;
            int rowend = (pageIndex + 1) * pageSize;
            if (rowend > source.Rows.Count)
            {
                rowend = source.Rows.Count;
            }

            for (int i = rowbegin; i < rowend; i++)
            {
                paged.ImportRow(source.Rows[i]);
            }

            return paged;
        }
        protected void ddlPageSize2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Grid2.PageSize = Convert.ToInt32(ddlPageSize2.SelectedValue);

            //// 更改每页显示数目时，防止 PageIndex 越界
            //if (Grid1.PageIndex > Grid1.PageCount - 1)
            //{
            //    Grid1.PageIndex = Grid1.PageCount - 1;
            //}

            BindGrid2();
        }
        protected void Grid2_PageIndexChange(object sender, GridPageEventArgs e)
        {
            Grid2.PageIndex = e.NewPageIndex;
            BindGrid2();
        }

        protected void Grid2_RowDoubleClick(object sender, GridRowClickEventArgs e)
        {
            Alert.ShowInTop("wait");
        }
        protected void btnInsert2_Click(object sender, EventArgs e)
        {
            PageContext.RegisterStartupScript(Window1.GetShowReference("~/Web/JC/deptment/listpositionadd.aspx", "新增"));
        }

        protected void btnEdit2_Click(object sender, EventArgs e)
        {
            if (Grid2.SelectedRowIndexArray.Length == 0)
            {
                Alert.ShowInTop("请至少选择一条记录！");
                return;
            }
            object[] keys = Grid2.DataKeys[Grid2.SelectedRowIndex];
            PageContext.RegisterStartupScript(Window1.GetShowReference(String.Format("~/Web/JC/deptment/listpositionmodify.aspx?id={0}&positionno={1}", keys[0], HttpUtility.UrlEncode(keys[1].ToString())), "编辑"));
        }

        protected void btnDelete2_Click(object sender, EventArgs e)
        {
            if (Grid2.SelectedRowIndexArray.Length == 0)
            {
                Alert.ShowInTop("请至少选择一条记录！");
                return;
            }

            Demo.BLL.tb_JC_Position bll = new Demo.BLL.tb_JC_Position();

            foreach (int n in Grid2.SelectedRowIndexArray)
            {
                object[] keys = Grid2.DataKeys[n];
                string id = keys[0].ToString();
                bll.Delete(id);
            }

            BindGrid2();

            Alert.ShowInTop("删除选中的 " + Grid2.SelectedRowIndexArray.Length + " 项纪录！");
        }

        protected void btmImport2_Click(object sender, EventArgs e)
        {
            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment; filename=news.xls");
            Response.ContentType = "application/excel";
            Response.ContentEncoding = System.Text.Encoding.UTF8;
            Response.Write(GetGridTableHtml(Grid2));
            Response.End();
        }

        protected void ttbSearch2_Trigger1Click(object sender, EventArgs e)
        {
            //clear
            ttbSearch1.Text = String.Empty;
            ttbSearch1.ShowTrigger1 = false;

            Alert.ShowInTop("well！");
        }

        protected void ttbSearch2_Trigger2Click(object sender, EventArgs e)
        {
            //search
            Demo.BLL.tb_JC_Position bll = new Demo.BLL.tb_JC_Position();
            Demo.Model.tb_JC_Position model = new Demo.Model.tb_JC_Position();
            string posiname = ttbSearch2.Text.Trim();

          

            if (bll.GetModelList("PositionName = '" + posiname + "'").Count == 0)
            {
                Alert.ShowInTop("未找到该职位！");
            }
            else
            {
                model = bll.GetModelList("PositionName = '" + posiname + "'")[0];
                PageContext.RegisterStartupScript(Window1.GetShowReference(String.Format("~/Web/JC/deptment/listpositionmodify.aspx?id={0}&PositionNO={1}", model.ID, model.PositionNO), "编辑"));
            }
        }
        #endregion

        #region GRID2 POSITION
        private void BindGrid3()
        {
            // 1.设置总项数
            Grid3.RecordCount = GetTotalCount3();

            // 2.获取当前分页数据
            DataTable table = GetPagedDataTable3(Grid3.PageIndex, Grid3.PageSize);

            // 3.绑定到Grid
            Grid3.DataSource = table;
            Grid3.DataBind();
        }

        /// <summary>
        /// 模拟返回总项数
        /// </summary>
        /// <returns></returns>
        private int GetTotalCount3()
        {
            Demo.BLL.tb_JC_Position bll = new Demo.BLL.tb_JC_Position();
            return bll.GetList("").Tables[0].Rows.Count;
        }

        /// <summary>
        /// 模拟数据库分页
        /// </summary>
        /// <returns></returns>
        private DataTable GetPagedDataTable3(int pageIndex, int pageSize)
        {


            Demo.BLL.tb_JC_Employee bll = new Demo.BLL.tb_JC_Employee();
            DataTable source = bll.GetList("").Tables[0];

            DataTable paged = source.Clone();

            int rowbegin = pageIndex * pageSize;
            int rowend = (pageIndex + 1) * pageSize;
            if (rowend > source.Rows.Count)
            {
                rowend = source.Rows.Count;
            }

            for (int i = rowbegin; i < rowend; i++)
            {
                paged.ImportRow(source.Rows[i]);
            }

            return paged;
        }
        protected void ddlPageSize3_SelectedIndexChanged(object sender, EventArgs e)
        {
            Grid3.PageSize = Convert.ToInt32(ddlPageSize3.SelectedValue);

            //// 更改每页显示数目时，防止 PageIndex 越界
            //if (Grid1.PageIndex > Grid1.PageCount - 1)
            //{
            //    Grid1.PageIndex = Grid1.PageCount - 1;
            //}

            BindGrid3();
        }
        protected void Grid3_PageIndexChange(object sender, GridPageEventArgs e)
        {
            Grid3.PageIndex = e.NewPageIndex;
            BindGrid3();
        }

        protected void Grid3_RowDoubleClick(object sender, GridRowClickEventArgs e)
        {
            Alert.ShowInTop("wait");
        }
        protected void btnInsert3_Click(object sender, EventArgs e)
        {
            PageContext.RegisterStartupScript(Window1.GetShowReference("~/Web/JC/deptment/listemployeeadd.aspx", "新增"));
        }

        protected void btnEdit3_Click(object sender, EventArgs e)
        {
            if (Grid3.SelectedRowIndexArray.Length == 0)
            {
                Alert.ShowInTop("请至少选择一条记录！");
                return;
            }
            object[] keys = Grid3.DataKeys[Grid3.SelectedRowIndex];
            PageContext.RegisterStartupScript(Window1.GetShowReference(String.Format("~/Web/JC/deptment/listemployeemodify.aspx?id={0}", keys[0]), "编辑"));
        }

        protected void btnDelete3_Click(object sender, EventArgs e)
        {
            if (Grid3.SelectedRowIndexArray.Length == 0)
            {
                Alert.ShowInTop("请至少选择一条记录！");
                return;
            }

            Demo.BLL.tb_JC_Employee bll = new Demo.BLL.tb_JC_Employee();

            foreach (int n in Grid3.SelectedRowIndexArray)
            {
                object[] keys = Grid3.DataKeys[n];
                string id = keys[0].ToString();
                bll.Delete(id);
            }

            BindGrid3();

            Alert.ShowInTop("删除选中的 " + Grid3.SelectedRowIndexArray.Length + " 项纪录！");
        }

        protected void btmImport3_Click(object sender, EventArgs e)
        {
            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment; filename=news.xls");
            Response.ContentType = "application/excel";
            Response.ContentEncoding = System.Text.Encoding.UTF8;
            Response.Write(GetGridTableHtml(Grid3));
            Response.End();
        }

        protected void ttbSearch3_Trigger1Click(object sender, EventArgs e)
        {
            //clear
            ttbSearch3.Text = String.Empty;
            ttbSearch3.ShowTrigger1 = false;

            Alert.ShowInTop("well！");
        }

        protected void ttbSearch3_Trigger2Click(object sender, EventArgs e)
        {
            //search
            Demo.BLL.tb_JC_Employee bll = new Demo.BLL.tb_JC_Employee();
            Demo.Model.tb_JC_Employee model = new Demo.Model.tb_JC_Employee();
            string name = ttbSearch3.Text.Trim();
            model = bll.GetModelList("EmployeeName = '" + name + "'")[0];

            if (model.DepartmentNO == null)
            {
                Alert.ShowInTop("未找到该员工！");
            }
            else
            {
                PageContext.RegisterStartupScript(Window1.GetShowReference(String.Format("~/Web/JC/deptment/listemployeemodify.aspx?id={0}&employeename={1}", model.ID, model.EmployeeNO), "编辑"));
            }
        }
        #endregion


        #region Common event

        /// <summary>
        /// 获得gridtable
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        private string GetGridTableHtml(Grid grid)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("<meta http-equiv=\"content-type\" content=\"application/excel; charset=UTF-8\"/>");

            sb.Append("<table cellspacing=\"0\" rules=\"all\" border=\"1\" style=\"border-collapse:collapse;\">");

            sb.Append("<tr>");
            foreach (GridColumn column in grid.Columns)
            {
                sb.AppendFormat("<td>{0}</td>", column.HeaderText);
            }
            sb.Append("</tr>");


            foreach (GridRow row in grid.Rows)
            {
                sb.Append("<tr>");
                foreach (object value in row.Values)
                {
                    string html = value.ToString();
                    if (html.StartsWith(Grid.TEMPLATE_PLACEHOLDER_PREFIX))
                    {
                        // 模板列
                        string templateID = html.Substring(Grid.TEMPLATE_PLACEHOLDER_PREFIX.Length);
                        Control templateCtrl = row.FindControl(templateID);
                        html = GetRenderedHtmlSource(templateCtrl);
                    }
                    else
                    {
                        // 处理CheckBox
                        if (html.Contains("f-grid-static-checkbox"))
                        {
                            if (html.Contains("uncheck"))
                            {
                                html = "×";
                            }
                            else
                            {
                                html = "√";
                            }
                        }

                        // 处理图片
                        if (html.Contains("<img"))
                        {
                            string prefix = Request.Url.AbsoluteUri.Replace(Request.Url.AbsolutePath, "");
                            html = html.Replace("src=\"", "src=\"" + prefix);
                        }
                    }

                    sb.AppendFormat("<td>{0}</td>", html);
                }
                sb.Append("</tr>");
            }

            sb.Append("</table>");

            return sb.ToString();
        }

        /// <summary>
        /// 获取控件渲染后的HTML源代码
        /// </summary>
        /// <param name="ctrl"></param>
        /// <returns></returns>
        private string GetRenderedHtmlSource(Control ctrl)
        {
            if (ctrl != null)
            {
                using (StringWriter sw = new StringWriter())
                {
                    using (HtmlTextWriter htw = new HtmlTextWriter(sw))
                    {
                        ctrl.RenderControl(htw);

                        return sw.ToString();
                    }
                }
            }
            return String.Empty;
        }


        /// <summary>
        /// 关闭弹窗
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Window1_Close(object sender, EventArgs e)
        {
            BindGrid1();
            BindGrid2();
            BindGrid3();
        }


        #endregion






    }
}
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
    public partial class list : System.Web.UI.Page
    {

        protected void Page_init(object sender, EventArgs e)
        {
            gird1init();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            BindGrid();
        }

        public void BindGrid()
        {
            BindGrid1();
        }

        #region Grid1 dept
        //init
        protected void gird1init()
        {
            Grid1.EnableRowDoubleClickEvent = true;
            Grid1.RowDoubleClick += grid1_RowDoubleClick;
            Grid1.PageIndexChange += grid1_PageIndexChange;
            Grid1.Sort += grid1_Sort;
            SetToolBar1();
            SetGridPageItems1();

        }
        private void SetToolBar1()
        {
            Toolbar tb;
            if (Grid1.Toolbars.Count > 0)
            {
                tb = Grid1.Toolbars[0];
            }
            else
            {
                tb = new Toolbar();
                Grid1.Toolbars.Add(tb);
            }

            Button btnInsert = new Button();
            btnInsert.ID = "btnInsert1";
            btnInsert.Text = "新增";
            btnInsert.Icon = Icon.Add;

            Button btnEdit = new Button();
            btnEdit.ID = "btnEdit1";
            btnEdit.Text = "编辑";
            btnEdit.Icon = Icon.PageEdit;


            Button btnDelete = new Button();
            btnDelete.ID = "btnDelete1";
            btnDelete.Text = "删除";
            btnDelete.Icon = Icon.Delete;

            btnInsert.Click += btnInsert1_Click;
            btnEdit.Click += btnEdit1_Click;
            btnDelete.Click += btnDelete1_Click;


            tb.Items.Insert(0, btnDelete);
            tb.Items.Insert(0, btnEdit);
            tb.Items.Insert(0, btnInsert);

        }
        private void SetGridPageItems1()
        {
            Grid1.PageItems.Add(new ToolbarSeparator());

            ToolbarText tbt = new ToolbarText();
            tbt.Text = "每页记录数：";
            Grid1.PageItems.Add(tbt);

            DropDownList ddlGridPageSize1 = new DropDownList();
            ddlGridPageSize1.AutoPostBack = true;
            ddlGridPageSize1.Items.Add(new ListItem("5", "5"));
            ddlGridPageSize1.Items.Add(new ListItem("10", "10"));
            ddlGridPageSize1.Items.Add(new ListItem("15", "15"));
            ddlGridPageSize1.Items.Add(new ListItem("30", "30"));
            ddlGridPageSize1.Width = 80;
            ddlGridPageSize1.SelectedIndexChanged += ddlGridPageSize1_SelectedIndexChanged;
            // 初始化选中值
            ddlGridPageSize1.SelectedValue = Grid1.PageSize.ToString();
            Grid1.PageItems.Add(ddlGridPageSize1);
        }

        //grid1绑定数据
        /// <summary>
        /// [ISingleGridPage]重新绑定表格
        /// </summary>
        public void BindGrid1()
        {
            // 1.设置总项数（特别注意：数据库分页一定要设置总记录数RecordCount）
            Grid1.RecordCount = GetTotalCount1();
            // 3.获取当前分页数据
            DataTable table = GetPagedDataTable1();
            // 3.绑定到Grid
            Grid1.DataSource = table;
            Grid1.DataBind();
        }

        /// <summary>
        /// 模拟数据库分页
        /// </summary>
        /// <returns></returns>
        private DataTable GetPagedDataTable1()
        {

            Demo.BLL.tb_JC_Department bll = new Demo.BLL.tb_JC_Department();

            int pageIndex = Grid1.PageIndex;
            int pageSize = Grid1.PageSize;

            string sortField = Grid1.SortField;
            string sortDirection = Grid1.SortDirection;

            DataTable table3 = bll.GetList("").Tables[0];

            DataView view3 = table3.DefaultView;
            view3.Sort = String.Format("{0} {1}", sortField, sortDirection);

            DataTable table = view3.ToTable();

            DataTable paged = table.Clone();

            int rowbegin = pageIndex * pageSize;
            int rowend = (pageIndex + 1) * pageSize;
            if (rowend > table.Rows.Count)
            {
                rowend = table.Rows.Count;
            }

            for (int i = rowbegin; i < rowend; i++)
            {
                paged.ImportRow(table.Rows[i]);
            }

            return paged;
        }
        private int GetTotalCount1()
        {
            Demo.BLL.tb_JC_Department bll = new Demo.BLL.tb_JC_Department();
            return bll.GetList("").Tables[0].Rows.Count;
        }

        #region grid1Events

        /// <summary>
        /// 表格每页显示项数改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlGridPageSize1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Grid1.PageSize = System.Convert.ToInt32(((DropDownList)sender).SelectedValue);

            BindGrid();
        }

        /// <summary>
        /// 点击新增按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnInsert1_Click(object sender, EventArgs e)
        {
            PageContext.RegisterStartupScript(Window1.GetShowReference("~/Web/JC/deptment/listdeptadd.aspx", "新增"));
        }

        /// <summary>
        /// 点击编辑按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// 点击删除按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

            PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
            Alert.ShowInTop("删除选中的 " + Grid1.SelectedRowIndexArray.Length + " 项纪录！");
        }

        /// <summary>
        /// excel 导出数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnExport1_Click(object sender, EventArgs e)
        {
            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment; filename=news.xls");
            Response.ContentType = "application/excel";
            Response.ContentEncoding = System.Text.Encoding.UTF8;
            Response.Write(GetGridTableHtml(Grid1));
            Response.End();
        }

        /// <summary>
        /// 表格行双击（编辑本行）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grid1_RowDoubleClick(object sender, GridRowClickEventArgs e)
        {
            if (Grid1.SelectedRowIndexArray.Length == 0)
            {
                Alert.ShowInTop("请至少选择一条记录！");
                return;
            }
            object[] keys = Grid1.DataKeys[Grid1.SelectedRowIndex];
            PageContext.RegisterStartupScript(Window1.GetShowReference(String.Format("~/Web/JC/deptment/listdeptmodify.aspx?id={0}&deptno={1}", keys[0], HttpUtility.UrlEncode(keys[1].ToString())), "编辑"));

        }

        /// <summary>
        /// 表格分页改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grid1_PageIndexChange(object sender, GridPageEventArgs e)
        {
            //Grid1.PageIndex = e.NewPageIndex;

            BindGrid1();
        }

        /// <summary>
        /// 表格排序事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grid1_Sort(object sender, GridSortEventArgs e)
        {
            //Grid1.SortDirection = e.SortDirection;
            //Grid1.SortField = e.SortField;

            BindGrid1();
        }


        #endregion


        #region searchEvents


        protected void ttbSearch1_Trigger1Click(object sender, EventArgs e)
        {
            ttbSearch1.Text = String.Empty;
            ttbSearch1.ShowTrigger1 = false;

            Alert.ShowInTop("尚未实现！");
        }

        protected void ttbSearch1_Trigger2Click(object sender, EventArgs e)
        {
            ttbSearch1.Text = String.Empty;
            ttbSearch1.ShowTrigger1 = false;

            Alert.ShowInTop("尚未实现！");
        }
        #endregion



        #endregion


        

        #region Methods

        public void SetBtnInsertVisible(bool bVisible)
        {
            Toolbar tbToolBar = Grid1.Toolbars[0];
            tbToolBar.FindControl("btnInsert").Visible = bVisible;
        }

        public void SetBtnEditVisible(bool bVisible)
        {
            Toolbar tbToolBar = Grid1.Toolbars[0];
            tbToolBar.FindControl("btnEdit").Visible = bVisible;
        }

        public void SetBtnDeleteVisible(bool bVisible)
        {
            Toolbar tbToolBar = Grid1.Toolbars[0];
            tbToolBar.FindControl("btnDelete").Visible = bVisible;
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
            BindGrid();
        }
        #endregion

    }
}
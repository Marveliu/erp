using System;
using FineUI;
using System.Data;

namespace Demo.Web.JC.Procedure
{
    public partial class List : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnDelete.OnClientClick = gridProcedure.GetNoSelectionAlertReference("至少选择一项！");
                btnAdd.OnClientClick = windowPop.GetShowReference("Add.aspx", "新增工序信息");
                gridProcedure.SortField = "ID";
                BindGrid();
            }
        }

        //Grid绑定数据源
        private void BindGrid() 
        {
            string strWhere = string.Format("Status='Y'");
            string order = string.Format("{0} {1}", gridProcedure.SortField, gridProcedure.SortDirection);
            int pageSize = gridProcedure.PageSize;
            int pageIndex = gridProcedure.PageIndex;
            long records;

            BLL.tb_JC_Procedure bllProcedure = new BLL.tb_JC_Procedure();
            DataSet dsProcedure = bllProcedure.GetListByPage(strWhere, order, pageSize, pageIndex, out records);
            DataTable dtSource = dsProcedure.Tables[0];

            gridProcedure.DataSource = dtSource;
            gridProcedure.DataBind();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            BLL.tb_JC_Procedure bllProcedure = new BLL.tb_JC_Procedure();
            string id = gridProcedure.DataKeys[gridProcedure.SelectedRowIndex][0].ToString();
            Model.tb_JC_Procedure modelProcedure = bllProcedure.GetModel(id);
            modelProcedure.Status = "N";
            bool result = bllProcedure.Update(modelProcedure);
            if (result)
            {
                Alert.ShowInTop("删除成功", "信息", MessageBoxIcon.Information);
                BindGrid();
            }
            else
            {
                Alert.ShowInTop("删除失败", "错误", MessageBoxIcon.Error);
            }
        }

        //弹出窗口关闭事件(不包含对话框)
        protected void wd_Close(object sender, EventArgs e)
        {
            this.BindGrid();
        }

        protected void grid_Sort(object sender, GridSortEventArgs e)
        {
            gridProcedure.SortDirection = e.SortDirection;
            gridProcedure.SortField = e.SortField;
            BindGrid();
        }

        protected void grid_PageIndexChange(object sender, GridPageEventArgs e)
        {
            gridProcedure.PageIndex = e.NewPageIndex;
            this.BindGrid();
        }
    }
}
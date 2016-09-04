using FineUI;
using System;
using System.Data;

namespace Demo.Web.JC.Material
{
    public partial class List : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                btnAdd.OnClientClick = windowPop.GetShowReference("Add.aspx", "新增物料");
                btnDelete.OnClientClick = gridMaterial.GetNoSelectionAlertReference("至少选择一项！");
                gridMaterial.SortField = "ID";
                BindGrid();
            }
        }

        protected void BindGrid()
        {
            string strWhere = string.Format("Status = 'Y'");
            string order = string.Format("{0} {1}", gridMaterial.SortField, gridMaterial.SortDirection);
            int pageSize = gridMaterial.PageSize;
            int pageIndex = gridMaterial.PageIndex;
            long records;

            BLL.vw_JC_Material bllMaterial = new BLL.vw_JC_Material();
            DataSet dsMaterial = bllMaterial.GetListByPage(strWhere, order, pageSize, pageIndex, out records);
            DataTable dtSource = dsMaterial.Tables[0];

            gridMaterial.DataSource = dtSource;
            gridMaterial.RecordCount = (int)records;
            gridMaterial.DataBind();
        }

        protected void wd_Close(object sender, WindowCloseEventArgs e)
        {
            this.BindGrid();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            BLL.tb_JC_Material_B bllMaterial_B = new BLL.tb_JC_Material_B();
            string id = gridMaterial.DataKeys[gridMaterial.SelectedRowIndex][0].ToString();
            Model.tb_JC_Material_B modelMaterial_B = bllMaterial_B.GetModel(id);
            modelMaterial_B.Status = "N";
            bool result = bllMaterial_B.Update(modelMaterial_B);
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

        protected void grid_Sort(object sender, GridSortEventArgs e)
        {
            gridMaterial.SortDirection = e.SortDirection;
            gridMaterial.SortField = e.SortField;
            BindGrid();
        }

        protected void grid_PageIndexChange(object sender, GridPageEventArgs e)
        {
            gridMaterial.PageIndex = e.NewPageIndex;
            this.BindGrid();
        }
    }
}
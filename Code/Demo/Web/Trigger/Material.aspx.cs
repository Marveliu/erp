using FineUI;
using System;
using System.Data;
using System.Text;

namespace Demo.Web.Trigger
{
    public partial class Material : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnSave.OnClientClick = gridMaterial.GetNoSelectionAlertReference("至少选择一项!");
                BindGrid();
            }
        }

        //Grid绑定数据源
        private void BindGrid()
        {
            StringBuilder strWhere = new StringBuilder("1=1");
            if(Request.QueryString["Type"] != null)
            {
                string[] except = Request.QueryString["Type"].Split('_');
                strWhere.Append(" and Property not in (");
                foreach(string item in except)
                {
                    strWhere.Append("'").Append(item).Append("',");
                }
                strWhere.Remove(strWhere.Length-1, 1).Append(")");
            }
            BLL.tb_JC_Material_B bllMaterial = new BLL.tb_JC_Material_B();
            DataSet dsMaterial = bllMaterial.GetList(strWhere.ToString());
            DataTable dtSource = dsMaterial.Tables[0];
            gridMaterial.DataSource = dtSource;
            gridMaterial.DataBind();
        }

        //保存选择
        protected void btnSave_Click(object sender, EventArgs e)
        {
            object[] rowValue = gridMaterial.Rows[gridMaterial.SelectedRowIndex].Values;
            //关闭本窗体，然后回发父窗体
            PageContext.RegisterStartupScript(
                ActiveWindow.GetWriteBackValueReference(rowValue[0].ToString(), rowValue[1].ToString(),rowValue[5].ToString(),rowValue[4].ToString())
                + ActiveWindow.GetHidePostBackReference());
        }

        //关闭页面
        protected void btnClose_Click(object sender, EventArgs e)
        {
            if (gridMaterial.SelectedRowIndexArray.Length == 0)
            {
                Alert.ShowInTop("未选择数据", "信息", MessageBoxIcon.Information, ActiveWindow.GetHideReference());
            }
            else
            {
                Alert.ShowInTop("您已选择了一条数据，是否确认关闭本窗口？", "询问", MessageBoxIcon.Question, ActiveWindow.GetHideReference());
            }
        }
    }
}
using FineUI;
using System;
using System.Data;
using System.Text;

namespace Demo.Web.Trigger
{
    public partial class Employee : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                btnSave.OnClientClick = gridEmployee.GetNoSelectionAlertReference("至少选择一项!");
                BindGrid();
            }
                
        }

        //Grid绑定数据源
        private void BindGrid()
        {
            StringBuilder strWhere = new StringBuilder("1=1");
            BLL.vw_JC_Employee bllEmployee = new BLL.vw_JC_Employee();
            DataSet dsEmployee = bllEmployee.GetList(strWhere.ToString());
            DataTable dtSource = dsEmployee.Tables[0];
            gridEmployee.DataSource = dtSource;
            gridEmployee.DataBind();
        }

        //保存选择
        protected void btnSave_Click(object sender, EventArgs e)
        {
            object[] rowValue = gridEmployee.Rows[gridEmployee.SelectedRowIndex].Values;
            //关闭本窗体，然后回发父窗体
            PageContext.RegisterStartupScript(
                ActiveWindow.GetWriteBackValueReference(rowValue[0].ToString(), rowValue[1].ToString())
                + ActiveWindow.GetHidePostBackReference());
        }

        //关闭页面
        protected void btnClose_Click(object sender, EventArgs e)
        {
            if (gridEmployee.SelectedRowIndexArray.Length == 0)
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
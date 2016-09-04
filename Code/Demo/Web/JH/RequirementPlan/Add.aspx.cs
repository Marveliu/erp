using FineUI;
using System;

namespace Demo.Web.JH.RequirementPlan
{
    public partial class Add : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                btnClose.OnClientClick = ActiveWindow.GetHideReference();
                tgbMaterialNO.OnClientTriggerClick =
                    windowPop.GetSaveStateReference(tgbMaterialNO.ClientID, txbMaterialName.ClientID, hdfOther.ClientID, hdfOther.ClientID)
                    + windowPop.GetShowReference("~\\Web\\Trigger\\Material.aspx?Type=B_P_S_F_O_C_V", "选择物料");
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            #region 检查
            #endregion

            #region 保存
            Model.tb_JH_PlannedSource modelPlannedSource = new Model.tb_JH_PlannedSource();
            modelPlannedSource.ID = Guid.NewGuid().ToString();
            modelPlannedSource.BillNO = txbBillNO.Text;
            modelPlannedSource.BillType = ddlBillType.SelectedValue;
            modelPlannedSource.MaterialNO = tgbMaterialNO.Text;
            modelPlannedSource.PlanAmount = Decimal.Parse(nbxPlanAmount.Text);
            modelPlannedSource.DownAmount = (Decimal)0.00;
            modelPlannedSource.EndDate = dapEndDate.SelectedDate;
            modelPlannedSource.Status = "C";

            BLL.tb_JH_PlannedSource bllPlannedSource = new BLL.tb_JH_PlannedSource();
            bool result = bllPlannedSource.Add(modelPlannedSource);
            if(result)
            {
                Alert.ShowInTop("添加成功！", "信息", MessageBoxIcon.Information, ActiveWindow.GetHidePostBackReference("Main_Add_Success"));
            }
            else
            {
                Alert.ShowInTop("添加失败！", "错误", MessageBoxIcon.Error, ActiveWindow.GetHidePostBackReference("Main_Add_Fail"));
            }
            #endregion
        }

        protected void dap_PreRender(object sender, EventArgs e)
        {
            DatePicker dap = (DatePicker)sender;
            dap.MinDate = DateTime.Today;
        }
    }
}
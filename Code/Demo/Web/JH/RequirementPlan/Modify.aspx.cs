using FineUI;
using System;
using System.Data;

namespace Demo.Web.JH.RequirementPlan
{
    public partial class Modify : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnClose.OnClientClick = ActiveWindow.GetHideReference();
                tgbMaterialNO.OnClientTriggerClick =
                    windowPop.GetSaveStateReference(tgbMaterialNO.ClientID, txbMaterialName.ClientID, hdfOther.ClientID, hdfOther.ClientID)
                    + windowPop.GetShowReference("~\\Web\\Trigger\\Material.aspx?Type=B_P_S_F_O_C_V", "选择物料");
                LoadData();
            }
        }

        private void LoadData()
        {
            string strWhere = string.Format("ID='{0}'", Request.QueryString["ID"]);
            BLL.vw_JH_PlannedSource bllPlannedSource = new BLL.vw_JH_PlannedSource();
            DataRow dr = bllPlannedSource.GetList(strWhere).Tables[0].Rows[0];
            txbBillNO.Text = dr["BillNO"].ToString();
            ddlBillType.SelectedValue = dr["BillType"].ToString();
            tgbMaterialNO.Text = dr["MaterialNO"].ToString();
            txbMaterialName.Text = dr["MaterialName"].ToString();
            nbxPlanAmount.Text = dr["PlanAmount"].ToString();
            dapEndDate.SelectedDate = DateTime.Parse(dr["EndDate"].ToString());
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            #region 检查
            #endregion

            #region 保存
            Model.tb_JH_PlannedSource modelPlannedSource = new Model.tb_JH_PlannedSource();
            modelPlannedSource.ID = Request.QueryString["ID"];
            modelPlannedSource.BillNO = txbBillNO.Text;
            modelPlannedSource.BillType = ddlBillType.SelectedValue;
            modelPlannedSource.MaterialNO = tgbMaterialNO.Text;
            modelPlannedSource.PlanAmount = Decimal.Parse(nbxPlanAmount.Text);
            modelPlannedSource.DownAmount = (Decimal)0.00;
            modelPlannedSource.EndDate = dapEndDate.SelectedDate;
            modelPlannedSource.Status = "I";

            BLL.tb_JH_PlannedSource bllPlannedSource = new BLL.tb_JH_PlannedSource();
            bool result = bllPlannedSource.Update(modelPlannedSource);
            if (result)
            {
                Alert.ShowInTop("更新成功！", "信息", MessageBoxIcon.Information, ActiveWindow.GetHidePostBackReference("Main_Modify_Success"));
            }
            else
            {
                Alert.ShowInTop("更新失败！", "错误", MessageBoxIcon.Error, ActiveWindow.GetHidePostBackReference("Main_Modify_Fail"));
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
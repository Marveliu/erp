using FineUI;
using System;
using System.Data;

namespace Demo.Web.JH.MPS
{
    public partial class Modify : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnClose.OnClientClick = FineUI.ActiveWindow.GetHideReference();
                LoadData();
            }
        }

        private void LoadData()
        {
            string strWhere = string.Format("ID='{0}'", Request.QueryString["ID"].ToString());
            BLL.vw_JH_MPS bllMPS = new BLL.vw_JH_MPS();
            DataRow drSource = bllMPS.GetList(strWhere).Tables[0].Rows[0];
            txbMaterialNO.Text = drSource["MaterialNO"].ToString();
            txbMaterialName.Text = drSource["MaterialName"].ToString();
            txbPlanNO.Text = drSource["PlanNO"].ToString();
            nbxPlanAmount.Text = drSource["PlanAmount"].ToString();
            dapEndDate.SelectedDate = DateTime.Parse(drSource["EndDate"].ToString());
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            BLL.tb_JH_MPS bllMPS = new BLL.tb_JH_MPS();
            #region 检查
            #endregion
            #region 保存
            string ID = Request.QueryString["ID"].ToString();
            string planNO = txbPlanNO.Text;
            bool result = bllMPS.updateMPS(ID, planNO);

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
    }
}
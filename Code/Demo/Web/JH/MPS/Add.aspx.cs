using FineUI;
using System;
using System.Data;

namespace Demo.Web.JH.MPS
{
    public partial class Add : PageBase
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
            string strWhere = string.Format("ID={0}", Request.QueryString["PlannedSourceID"].ToString());
            BLL.vw_JH_PlannedSource bllSource = new BLL.vw_JH_PlannedSource();
            DataRow drSource = bllSource.GetList(strWhere).Tables[0].Rows[0];
            txbMaterialNO.Text = drSource["MaterialNO"].ToString();
            txbMaterialName.Text = drSource["MaterialName"].ToString();
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            BLL.tb_JH_MPS bllMPS = new BLL.tb_JH_MPS();
            #region 检查
            #endregion
            #region 保存
            Model.tb_JH_MPS modelMPS = new Model.tb_JH_MPS();
            modelMPS.ID = Guid.NewGuid().ToString();
            modelMPS.PlannedSourceID = Request.QueryString["PlannedSourceID"].ToString();
            modelMPS.PlanNO = txbPlanNO.Text;
            modelMPS.MaterialNO = txbMaterialNO.Text;
            modelMPS.PlanAmount = decimal.Parse(nbxPlanAmount.Text);
            modelMPS.EndDate = dapEndDate.SelectedDate;

            int result = bllMPS.insertMPS(modelMPS);

            if (result == 0)
            {
                Alert.ShowInTop("添加成功！", "信息", MessageBoxIcon.Information, ActiveWindow.GetHidePostBackReference("Main_Add_Success"));
            }
            else if(result == 1)
            {
                Alert.ShowInTop("能力不足！", "错误", MessageBoxIcon.Error, ActiveWindow.GetHidePostBackReference("Main_Add_Fail"));
            }
            else
            {
                Alert.ShowInTop("下达失败！", "错误", MessageBoxIcon.Error, ActiveWindow.GetHidePostBackReference("Main_Add_Fail"));
            }
            #endregion
        }
    }
}
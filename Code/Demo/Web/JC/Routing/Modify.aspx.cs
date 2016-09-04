using System;
using System.Data;
using FineUI;

namespace Demo.Web.JC.Routing
{
    public partial class Modify : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnClose.OnClientClick = ActiveWindow.GetHideReference();
                LoadData();
            }
        }
        private void LoadData()
        {
            string strWhere = string.Format("ID = '{0}'", Request.QueryString["ID"]);
            BLL.tb_JC_Routing bllRouting = new BLL.tb_JC_Routing();
            DataRow dr = bllRouting.GetList(strWhere).Tables[0].Rows[0];
            txbRoutingNO.Text = dr["RoutingNO"].ToString();
            txbRoutingName.Text = dr["RoutingName"].ToString();
            nbxProcedureAmount.Text = dr["ProcedureAmount"].ToString();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            #region 逻辑检查
            if (nbxProcedureAmount.Text == "0")
            {
                Alert.ShowInTop("工序数量不能为0", "错误", MessageBoxIcon.Error);
                return;
            }
            #endregion
            #region 保存数据
            BLL.tb_JC_Routing bllRouting = new BLL.tb_JC_Routing();
            Model.tb_JC_Routing modelRouting = new Model.tb_JC_Routing();
            modelRouting.ID = Request.QueryString["ID"];
            modelRouting.RoutingNO = txbRoutingNO.Text;
            modelRouting.RoutingName = txbRoutingName.Text;
            modelRouting.ProcedureAmount = int.Parse(nbxProcedureAmount.Text);
            modelRouting.Status = "Y";
            bool result = bllRouting.Update(modelRouting);
            if (!result)
            {
                Alert.ShowInTop("更新失败", "错误", MessageBoxIcon.Error, ActiveWindow.GetHidePostBackReference("Main_Modify_Fail"));
            }
            else
            {
                Alert.ShowInTop("更新成功", "信息", MessageBoxIcon.Information, ActiveWindow.GetHidePostBackReference("Main_Modify_Success"));
            }
            #endregion
        }

    }
}
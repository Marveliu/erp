using System;
using System.Data;
using FineUI;

namespace Demo.Web.JC.RoutingSub
{
    public partial class Modify : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnClose.OnClientClick = ActiveWindow.GetHideReference();
                tgbProcedureNO.OnClientTriggerClick =
                    windowPop.GetSaveStateReference(tgbProcedureNO.ClientID, txbProcedureName.ClientID)
                    +windowPop.GetShowReference("~/Web/Trigger/Procedure.aspx","选择工序");
                LoadData();
            }
        }

        private void LoadData()
        {
            string strWhere = string.Format("ID='{0}'", Request.QueryString["ID"]);
            BLL.vw_JC_RoutingSub bllRoutingSub = new BLL.vw_JC_RoutingSub();
            DataRow dr = bllRoutingSub.GetList(strWhere).Tables[0].Rows[0];
            txbProcedureName.Text = dr["ProcedureName"].ToString();
            nbxProcedureOrder.Text = dr["ProcedureOrder"].ToString();
            tgbProcedureNO.Text = dr["ProcedureNO"].ToString();
            hdfRoutingID.Text = dr["RoutingID"].ToString();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            #region 逻辑检查
            if(nbxProcedureOrder.Text == "0")
            {
                Alert.ShowInTop("次序应当为大于0的整数", "错误", MessageBoxIcon.Error);
                return;
            }
            #endregion
            #region 保存
            Model.tb_JC_RoutingSub modelRoutingSub = new Model.tb_JC_RoutingSub();
            modelRoutingSub.ID = Request.QueryString["ID"];
            modelRoutingSub.RoutingID = hdfRoutingID.Text;
            modelRoutingSub.ProcedureNO = tgbProcedureNO.Text;
            modelRoutingSub.ProcedureOrder = int.Parse(nbxProcedureOrder.Text);

            BLL.tb_JC_RoutingSub bllRoutingSub = new BLL.tb_JC_RoutingSub();
            bool result = bllRoutingSub.Update(modelRoutingSub);
            if(result)
            {
                Alert.ShowInTop("修改成功", "信息", MessageBoxIcon.Information, ActiveWindow.GetHidePostBackReference("Sub_Modify_Success"));
            }
            else
            {
                Alert.ShowInTop("修改失败", "错误", MessageBoxIcon.Error, ActiveWindow.GetHidePostBackReference("Sub_Modify_Fail"));
            }
            #endregion
        }
    }
}
using System;
using FineUI;

namespace Demo.Web.JC.RoutingSub
{
    public partial class Add : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnClose.OnClientClick = ActiveWindow.GetHideReference();
                tgbProcedureNO.OnClientTriggerClick =
                    windowPop.GetSaveStateReference(tgbProcedureNO.ClientID, txbProcedureName.ClientID)
                    + windowPop.GetShowReference("~/Web/Trigger/Procedure.aspx", "选择工序");
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            #region 检查
            if (nbxProcedureOrder.Text == "0")
            {
                Alert.ShowInTop("次序应当为大于0的整数", "错误", MessageBoxIcon.Error);
                return;
            }
            #endregion
            #region 保存
            Model.tb_JC_RoutingSub modelRoutingSub = new Model.tb_JC_RoutingSub();
            modelRoutingSub.ID = Guid.NewGuid().ToString();
            modelRoutingSub.RoutingID = Request.QueryString["RoutingID"];
            modelRoutingSub.ProcedureNO = tgbProcedureNO.Text;
            modelRoutingSub.ProcedureOrder = int.Parse(nbxProcedureOrder.Text);

            BLL.tb_JC_RoutingSub bllRoutingSub = new BLL.tb_JC_RoutingSub();
            bool result = bllRoutingSub.Add(modelRoutingSub);
            if (result)
            {
                Alert.ShowInTop("添加成功", "信息", MessageBoxIcon.Information, ActiveWindow.GetHidePostBackReference("Sub_Add_Success"));
            }
            else
            {
                Alert.ShowInTop("添加失败", "错误", MessageBoxIcon.Error, ActiveWindow.GetHidePostBackReference("Sub_Add_Fail"));
            }
            #endregion
        }
    }
}
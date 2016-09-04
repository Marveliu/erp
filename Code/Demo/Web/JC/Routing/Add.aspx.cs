using System;
using FineUI;

namespace Demo.Web.JC.Routing
{
    public partial class Add : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnClose.OnClientClick = ActiveWindow.GetHideReference();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            #region 逻辑检查
            string strWhere = string.Format("RoutingNO = '{0}'", txbRoutingNO.Text);
            BLL.tb_JC_Routing bllRouting = new BLL.tb_JC_Routing();
            int count = bllRouting.GetList(strWhere).Tables[0].Rows.Count;
            if(count > 0)
            {
                Alert.ShowInTop("工艺路线编号已存在", "错误", MessageBoxIcon.Error);
                return;
            }
            if(nbxProcedureAmount.Text == "0")
            {
                Alert.ShowInTop("工序数量不能为0", "错误", MessageBoxIcon.Error);
                return;
            }
            #endregion
            #region 保存数据
            Model.tb_JC_Routing modelRouting = new Model.tb_JC_Routing();
            modelRouting.ID = Guid.NewGuid().ToString();
            modelRouting.RoutingNO = txbRoutingNO.Text;
            modelRouting.RoutingName = txbRoutingName.Text;
            modelRouting.ProcedureAmount = int.Parse(nbxProcedureAmount.Text);
            modelRouting.Status = "Y";
            bool result = bllRouting.Add(modelRouting);
            if (!result)
            {
                Alert.ShowInTop("添加失败", "错误", MessageBoxIcon.Error, ActiveWindow.GetHidePostBackReference("Main_Add_Fail"));
            }
            else
            {
                Alert.ShowInTop("添加成功", "信息", MessageBoxIcon.Information, ActiveWindow.GetHidePostBackReference("Main_Add_Success"));
            }
            #endregion
        }
    }
}
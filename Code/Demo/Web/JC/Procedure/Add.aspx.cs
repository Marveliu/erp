using System;
using FineUI;

namespace Demo.Web.JC.Procedure
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
            #region 检查
            #endregion
            #region 保存
            Model.tb_JC_Procedure modelProcedure = new Model.tb_JC_Procedure();
            modelProcedure.ID = Guid.NewGuid().ToString();
            modelProcedure.ProcedureNO = txbProcedureNO.Text;
            modelProcedure.ProcedureName = txbProcedureName.Text;
            modelProcedure.WorkCenterNO = hdfWorkCenterNO.Text;
            modelProcedure.Status = "Y";

            BLL.tb_JC_Procedure bllProcedure = new BLL.tb_JC_Procedure();
            bool result = bllProcedure.Add(modelProcedure);
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
    }
}
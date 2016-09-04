using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using FineUI;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Demo.Web.JC.Procedure
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
            #region 加载数据
            string strWhere = string.Format("ID='{0}'", Request.QueryString["ID"].ToString());
            BLL.vw_JC_Procedure bllProcedure = new BLL.vw_JC_Procedure();
            DataRow drProcedure = bllProcedure.GetList(strWhere).Tables[0].Rows[0];

            txbProcedureNO.Text = drProcedure["ProcedureNO"].ToString();
            txbProcedureName.Text = drProcedure["ProcedureName"].ToString();
            tgbWorkCenter.Text = drProcedure["WorkCenterName"].ToString();
            hdfWorkCenterNO.Text = drProcedure["WorkCenterNO"].ToString();
            #endregion
            #region 设置操作权限
            #endregion
            #region 自动填充项
            #endregion
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            #region 检查
            #endregion
            #region 保存
            Model.tb_JC_Procedure modelProcedure = new Model.tb_JC_Procedure();
            modelProcedure.ID = Request.QueryString["ID"].ToString();
            modelProcedure.ProcedureNO = txbProcedureNO.Text;
            modelProcedure.ProcedureName = txbProcedureName.Text;
            modelProcedure.WorkCenterNO = hdfWorkCenterNO.Text;
            modelProcedure.Status = "Y";

            BLL.tb_JC_Procedure bllProcedure = new BLL.tb_JC_Procedure();
            bool result = bllProcedure.Update(modelProcedure);
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
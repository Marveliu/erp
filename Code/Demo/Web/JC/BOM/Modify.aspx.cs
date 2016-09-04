using System;
using System.Data;
using FineUI;

namespace Demo.Web.JC.BOM
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
            #region 加载数据
            string strWhere = string.Format("ID='{0}'",Request.QueryString["id"].ToString());
            BLL.vw_JC_BOMParent bllBOMParent = new BLL.vw_JC_BOMParent();
            DataTable dtBOMParent = bllBOMParent.GetList(strWhere).Tables[0];
            txbMaterialName.Text = dtBOMParent.Rows[0]["MaterialName"].ToString();
            txbMaterialNO.Text = dtBOMParent.Rows[0]["MaterialNO"].ToString();
            tgbCheckName.Text = dtBOMParent.Rows[0]["CheckName"].ToString();
            hdfCheckNO.Text = dtBOMParent.Rows[0]["CheckNO"].ToString();
            hdfPropertyNO.Text = dtBOMParent.Rows[0]["MaterialType"].ToString();
            txbPropertyName.Text = dtBOMParent.Rows[0]["PropertyName"].ToString();
            if (dtBOMParent.Rows[0]["CheckDate"].ToString() != "")
            {
                dapCheckDate.SelectedDate = DateTime.Parse(dtBOMParent.Rows[0]["CheckDate"].ToString());
            }
            ddlCheckStatus.SelectedValue = dtBOMParent.Rows[0]["CheckStatus"].ToString();
            ddlStatus.SelectedValue = dtBOMParent.Rows[0]["Status"].ToString();
            #endregion

            #region 设置操作权限
            #endregion

            #region 自动填充项
            if(tgbCheckName.Hidden == false)
            {
            }
            #endregion
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            BLL.tb_JC_BOM bllBOM = new BLL.tb_JC_BOM();

            Model.tb_JC_BOM modelBOM = new Model.tb_JC_BOM();
            modelBOM.ID = Request.QueryString["id"].ToString();
            modelBOM.MaterialNO = txbMaterialNO.Text;
            modelBOM.MaterialType = hdfPropertyNO.Text;
            modelBOM.CheckNO = hdfCheckNO.Text;
            modelBOM.CheckDate = dapCheckDate.SelectedDate;
            modelBOM.CheckStatus = ddlCheckStatus.SelectedValue;
            modelBOM.Status = ddlStatus.SelectedValue;

            bool result = bllBOM.Update(modelBOM);
            if(result)
            {
                Alert.ShowInTop("更新成功", "信息", MessageBoxIcon.Information, ActiveWindow.GetHidePostBackReference("Main_Modify_Success"));
            }
            else
            {
                Alert.ShowInTop("更新失败", "错误", MessageBoxIcon.Error, ActiveWindow.GetHidePostBackReference("Main_Modify_Fail"));
            }
        }
    }
}
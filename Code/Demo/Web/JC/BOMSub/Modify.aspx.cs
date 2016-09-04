using FineUI;
using System;
using System.Data;

namespace Demo.Web.JC.BOMSub
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
            string strWhere = string.Format("ID = '{0}'",Request.QueryString["id"].ToString());
            BLL.vw_JC_BOMSub bllBOMSub = new BLL.vw_JC_BOMSub();
            DataRow drBOMSub = bllBOMSub.GetList(strWhere).Tables[0].Rows[0];
            txbMaterialNO.Text = drBOMSub["MaterialNO"].ToString();
            txbMaterialName.Text = drBOMSub["MaterialName"].ToString();
            hdfPropertyNO.Text = drBOMSub["MaterialType"].ToString();
            txbPropertyName.Text = drBOMSub["PropertyName"].ToString();
            txbUnit.Text = drBOMSub["Unit"].ToString();
            nbxAmount.Text = drBOMSub["Amount"].ToString();
            nbxLeadTimeOffset.Text = drBOMSub["LeadTimeOffset"].ToString();
            ddlBackFlush.SelectedValue = drBOMSub["BackFlush"].ToString();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            #region 检查
            if (nbxAmount.Text == "0")
            {
                Alert.ShowInTop("数量不能为0！", "错误", MessageBoxIcon.Error);
                nbxAmount.Focus();
                return;
            }
            #endregion
            #region 保存
            Model.tb_JC_BOMSub modelBOMSub = new Model.tb_JC_BOMSub();
            modelBOMSub.ID = Request.QueryString["id"].ToString();
            modelBOMSub.MaterialNO = txbMaterialNO.Text;
            modelBOMSub.MaterialType = hdfPropertyNO.Text;
            modelBOMSub.ParentNO = Request.QueryString["parentNO"].ToString();
            modelBOMSub.Amount = decimal.Parse(nbxAmount.Text);
            modelBOMSub.BackFlush = ddlBackFlush.SelectedValue;
            modelBOMSub.LeadTimeOffset = decimal.Parse(nbxLeadTimeOffset.Text + ".00");
            BLL.tb_JC_BOMSub bllBOMSub = new BLL.tb_JC_BOMSub();
            bool result = bllBOMSub.Update(modelBOMSub);
            if (result)
            {
                if (result)
                {
                    Alert.ShowInTop("更新成功！", "信息", MessageBoxIcon.Information, ActiveWindow.GetHidePostBackReference("Sub_Modify_Success"));
                }
                else
                {
                    Alert.ShowInTop("更新失败！", "错误", MessageBoxIcon.Error, ActiveWindow.GetHidePostBackReference("Sub_Modify_Fail"));
                }
            }
            #endregion
        }
    }
}
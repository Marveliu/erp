using System;
using FineUI;
using System.Web;
using System.Data;

namespace Demo.Web.JC.BOM
{
    public partial class Add : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnClose.OnClientClick = ActiveWindow.GetHideReference();
                tgbMaterialNO.OnClientTriggerClick =
                    windowPop.GetSaveStateReference(tgbMaterialNO.ClientID, txbMaterialName.ClientID, hdfPropertyNO.ClientID, hdfOther.ClientID)
                    + windowPop.GetShowReference("~\\Web\\Trigger\\Material.aspx?Type=P", "选择物料");
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            BLL.tb_JC_BOM bllBOM = new BLL.tb_JC_BOM();
            #region 检查
            DataSet dsBOM = bllBOM.GetList("MaterialNO='" + tgbMaterialNO.Text+"'");
            if(dsBOM.Tables[0].Rows.Count > 0)
            {
                Alert.ShowInTop("该项已存在！", "错误", MessageBoxIcon.Error);
                return;
            }
            #endregion
            #region 保存
            Model.tb_JC_BOM modelBOM = new Model.tb_JC_BOM();
            modelBOM.ID = Guid.NewGuid().ToString();
            modelBOM.MaterialNO = tgbMaterialNO.Text;
            modelBOM.MaterialType = hdfPropertyNO.Text;
            modelBOM.CheckStatus = "C";
            modelBOM.Status = "N";
            bool result = bllBOM.Add(modelBOM);

            if(Request.Cookies["RootNO"] != null)
            {
                Request.Cookies["RootNO"].Value = tgbMaterialNO.Text;
            }
            else
            {
                HttpCookie rootNO = new HttpCookie("RootNO", tgbMaterialNO.Text);
                Response.Cookies.Add(rootNO);
            }           

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

        protected void hdfPropertyNO_TextChanged(object sender, EventArgs e)
        {
            BLL.tb_JC_MaterialProperty bllProperty = new BLL.tb_JC_MaterialProperty();
            DataSet dsProperty = bllProperty.GetList("PropertyNO='" + hdfPropertyNO.Text + "'");
            txbPropertyName.Text = dsProperty.Tables[0].Rows[0]["PropertyName"].ToString();
        }
   }
}
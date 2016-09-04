using FineUI;
using System;
using System.Data;
using System.Text;

namespace Demo.Web.JC.BOMSub
{
    public partial class Add : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnClose.OnClientClick = FineUI.ActiveWindow.GetHideReference();
                tgbMaterialNO.OnClientTriggerClick =
                    windowPop.GetSaveStateReference(tgbMaterialNO.ClientID, txbMaterialName.ClientID, hdfPropertyNO.ClientID, txbUnit.ClientID)
                    + windowPop.GetShowReference("~\\Web\\Trigger\\Material.aspx?Type=A", "选择物料");
                LoadData();
            }          
        }

        private void LoadData()
        {
            nbxLeadTimeOffset.Text = "0";
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            #region 检查
            //重复查询
            StringBuilder strwhere = new StringBuilder();
            strwhere.AppendFormat("ParentNO='{0}' and MaterialNO = '{1}'",Request.QueryString["parentNO"],tgbMaterialNO.Text);
            BLL.tb_JC_BOMSub bllBOMSub = new BLL.tb_JC_BOMSub();
            DataTable dtBOMSub = bllBOMSub.GetList(strwhere.ToString()).Tables[0];
            if(dtBOMSub.Rows.Count > 0)
            {
                Alert.ShowInTop("该项已存在！", "错误", MessageBoxIcon.Error);
                return;
            }
            if(nbxAmount.Text == "0")
            {
                Alert.ShowInTop("数量不能为0！", "错误", MessageBoxIcon.Error);
                nbxAmount.Focus();
                return;
            }
            //嵌套查询
            BLL.proc_BOM bllBOM_proc = new BLL.proc_BOM();
            int exit = bllBOM_proc.isNesting(Request.QueryString["parentNO"], tgbMaterialNO.Text);
            if(Request.QueryString["parentNO"].Equals(tgbMaterialNO.Text))
            {
                exit = 1;
            }
            if(exit == 1)
            {
                Alert.ShowInTop("存在嵌套,不能添加此物料！", "错误", MessageBoxIcon.Error);
                return;
            }
            #endregion
            #region 保存
            Model.tb_JC_BOMSub modelBOMSub = new Model.tb_JC_BOMSub();
            modelBOMSub.ID = Guid.NewGuid().ToString();
            modelBOMSub.MaterialNO = tgbMaterialNO.Text;
            modelBOMSub.MaterialType = hdfPropertyNO.Text;
            modelBOMSub.ParentNO = Request.QueryString["parentNO"].ToString();
            modelBOMSub.Amount = decimal.Parse(nbxAmount.Text);
            modelBOMSub.BackFlush = ddlBackFlush.SelectedValue;
            modelBOMSub.LeadTimeOffset = decimal.Parse(nbxLeadTimeOffset.Text + ".00");
            bool result = bllBOMSub.Add(modelBOMSub);
            if(result)
            {
                if (result)
                {
                    Alert.ShowInTop("添加成功！", "信息", MessageBoxIcon.Information, ActiveWindow.GetHidePostBackReference("Sub_Add_Success"));
                }
                else
                {
                    Alert.ShowInTop("添加失败！", "错误", MessageBoxIcon.Error, ActiveWindow.GetHidePostBackReference("Sub_Add_Fail"));
                }
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
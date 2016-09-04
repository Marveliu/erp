using FineUI;
using System;
using System.Data;

namespace Demo.Web.JC.Material
{
    public partial class Add : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                btnClose.OnClientClick = FineUI.ActiveWindow.GetHideReference();
                BindProperty();
            }
        }

        private void BindProperty()
        {
            BLL.tb_JC_MaterialProperty bllProperty = new BLL.tb_JC_MaterialProperty();
            DataSet dsProperty = bllProperty.GetList("1=1");
            DataTable dtSource = dsProperty.Tables[0];

            ddlPropertyName.DataSource = dtSource;
            ddlPropertyName.DataTextField = "PropertyName";
            ddlPropertyName.DataValueField = "PropertyNO";
            ddlPropertyName.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            #region 检查
            #endregion
            #region 保存
            Model.tb_JC_Material_B modelMaterial_B = new Model.tb_JC_Material_B();
            modelMaterial_B.ID = Guid.NewGuid().ToString();
            modelMaterial_B.MaterialNO = txbMaterialNO.Text;
            modelMaterial_B.MaterialName = txbMaterialName.Text;
            modelMaterial_B.Specification = txbSpecification.Text;
            modelMaterial_B.Model = txbModel.Text;
            modelMaterial_B.Property = ddlPropertyName.SelectedValue;
            modelMaterial_B.Unit = txbUnit.Text;
            modelMaterial_B.UnitStandardCost = decimal.Parse(nbxUnitStandardCost.Text);
            modelMaterial_B.FixedLeadTime = int.Parse(nbxFixedLeadTime.Text);
            modelMaterial_B.VariableLeadTime = int.Parse(nbxVariableLeadTime.Text);
            modelMaterial_B.VariableBatch = int.Parse(nbxVariableBatch.Text);
            modelMaterial_B.Status = "Y";
            BLL.tb_JC_Material_B bllMaterial_B = new BLL.tb_JC_Material_B();
            bool result = bllMaterial_B.Add(modelMaterial_B);

            Model.tb_JC_Material_P modelMaterial_P = new Model.tb_JC_Material_P();
            modelMaterial_P.ID = modelMaterial_B.ID;
            modelMaterial_P.MaterialNO = modelMaterial_B.MaterialNO;
            modelMaterial_P.UnitStandardTime = decimal.Parse(nbxUnitStandardTime.Text);
            modelMaterial_P.ProcessRouteNO = tgbProcessRouteNO.Text;
            modelMaterial_P.ProductionVolume = decimal.Parse(nbxProductionVolume.Text);
            modelMaterial_P.IncreaseAmount = decimal.Parse(nbxIncreaseAmount.Text);
            BLL.tb_JC_Material_P bllMaterial_P = new BLL.tb_JC_Material_P();
            result = result && bllMaterial_P.Add(modelMaterial_P);

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
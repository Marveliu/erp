using FineUI;
using System;
using System.Data;

namespace Demo.Web.Sys.Role
{
    public partial class Add : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                tgbParentName.OnClientTriggerClick = windowPop.GetSaveStateReference(tgbParentName.ClientID, hdfParentID.ClientID)
    + windowPop.GetShowReference("~\\Web\\Trigger\\Role.aspx", "选择菜单项");
                LoadData();
            }
        }

        //加载数据
        private void LoadData()
        {
        }

        //保存修改
        protected void btnSave_Click(object sender, EventArgs e)
        {
            #region 逻辑检查
            BLL.tb_SYS_Role bllRole = new BLL.tb_SYS_Role();
            DataSet dsRole = bllRole.GetList("RoleName='" + txbRoleName.Text.ToString() + "'");
            if (dsRole.Tables[0].Rows.Count > 0)
            {
                Alert.ShowInTop("该角色名称已存在", "提示信息", MessageBoxIcon.Error);
                return;
            }
            #endregion

            #region 保存数据
            Model.tb_SYS_Role modelRole = new Model.tb_SYS_Role();
            modelRole.ID = Guid.NewGuid().ToString();
            modelRole.RoleNO = roleid.Text.ToString();
            modelRole.RoleName = txbRoleName.Text.ToString();
            modelRole.DefaultUrl = txbDefaultUrl.Text.ToString();
            modelRole.ParentID = hdfParentID.Text.ToString();
            modelRole.State = ddlState.SelectedValue.ToString();
            modelRole.CreateID = Session["AccountID"].ToString();
            modelRole.CreateTime = DateTime.Now;


            bool result = bllRole.Add(modelRole);
            if (!result)
            {
                Alert.ShowInTop("添加失败", "提示信息", MessageBoxIcon.Error, ActiveWindow.GetHideRefreshReference());
            }
            else
            {
                Alert.ShowInTop("添加成功", "提示信息", MessageBoxIcon.Information, ActiveWindow.GetHideRefreshReference());
            }
            #endregion
        }

        //关闭页面
        protected void btnClose_Click(object sender, EventArgs e)
        {
            Alert.ShowInTop("关闭本窗口,您所做的修改将不被保存", "提示信息", MessageBoxIcon.Information, ActiveWindow.GetHideReference());
        }

        //弹出窗口关闭事件(不包含对话框)
        protected void wd_Close(object sender, EventArgs e)
        {
            Alert.ShowInTop("弹出窗口关闭了！");
        }
    }
}
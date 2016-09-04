using FineUI;
using System;
using System.Data;

namespace Demo.Web.Sys.Menu
{
    public partial class Add : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                tgbParentName.OnClientTriggerClick = windowPop.GetSaveStateReference(tgbParentName.ClientID,hdfParentID.ClientID,hdfParentNO.ClientID)
    + windowPop.GetShowReference("~\\Web\\Trigger\\Menu.aspx","选择菜单项");
                LoadData();
            }
            setMenuLevel();
        }

        //加载数据
        private void LoadData()
        {
            //btnClose.OnClientClick = ActiveWindow.GetHideReference();
            tgbParentName.Text = "根项";
            hdfParentID.Text = "0";
            hdfParentNO.Text = "0";
        }

        //设置菜单级别
        private void setMenuLevel()
        {
            //自动计算菜单级别
            nbbMenuNO.Text = (int.Parse(hdfParentNO.Text.ToString()) + 1).ToString();
        }

        //保存修改
        protected void btnSave_Click(object sender, EventArgs e)
        {
            #region 逻辑检查
            BLL.tb_SYS_Menu bllMenu = new BLL.tb_SYS_Menu();
            DataSet dsMenu = bllMenu.GetList("MenuName='" + txbMenuName.Text.ToString() + "'");
            if(dsMenu.Tables[0].Rows.Count > 0)
            {
                Alert.ShowInTop("该菜单名称已存在", "提示信息", MessageBoxIcon.Error);
                return;
            }
            #endregion

            #region 保存数据
            Model.tb_SYS_Menu modelMenu = new Model.tb_SYS_Menu();
            modelMenu.ID = Guid.NewGuid().ToString();
            modelMenu.MenuNO = nbbMenuNO.Text.ToString();
            modelMenu.MenuName = txbMenuName.Text.ToString();
            modelMenu.MenuUrl = txbMenuUrl.Text.ToString();
            //modelMenu.ImageUrl = txbImageUrl.Text.ToString();
            modelMenu.ParentID = hdfParentID.Text.ToString();
            modelMenu.State = ddlState.SelectedValue.ToString();
            modelMenu.CreateID = Session["AccountID"].ToString();
            modelMenu.CreateTime = DateTime.Now;

            bool result = bllMenu.Add(modelMenu);
            if (!result)
            {
                Alert.ShowInTop("添加失败", "提示信息", MessageBoxIcon.Error, ActiveWindow.GetHideRefreshReference());
            }
            else
            {
                Alert.ShowInTop("添加成功", "提示信息", MessageBoxIcon.Information, ActiveWindow.GetHideRefreshReference());
            }
            #endregion

            //关闭本窗体，然后刷新父窗体
            //PageContext.RegisterStartupScript(ActiveWindow.GetHideRefreshReference());
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
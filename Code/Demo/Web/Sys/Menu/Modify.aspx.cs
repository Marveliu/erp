using FineUI;
using System;
using System.Data;
using System.Text;

namespace Demo.Web.Sys.Menu
{
    public partial class Modify : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                tgbParentName.OnClientTriggerClick = windowPop.GetSaveStateReference(tgbParentName.ClientID, hdfParentID.ClientID, hdfParentNO.ClientID)
    + windowPop.GetShowReference("~\\Web\\Trigger\\Menu.aspx", "选择菜单项");
                LoadData();
            }
            else
            {
                updateMenuLevel();
            }
        }

        //加载数据
        private void LoadData()
        {
            //btnClose.OnClientClick = ActiveWindow.GetHidePostBackReference();

            //绑定修改前数据
            BLL.tb_SYS_Menu bllMenu = new BLL.tb_SYS_Menu();
            DataSet dsMenu = bllMenu.GetList("ID='" + Request.QueryString["ID"] + "'");
            nbbMenuNO.Text = dsMenu.Tables[0].Rows[0]["MenuNO"].ToString();
            txbMenuName.Text = dsMenu.Tables[0].Rows[0]["MenuName"].ToString();
            txbMenuUrl.Text = dsMenu.Tables[0].Rows[0]["MenuUrl"].ToString();
            tgbParentName.Text = Request.QueryString["ParentName"].ToString();
            //txbImageUrl.Text = dsMenu.Tables[0].Rows[0]["ImageUrl"].ToString();
            ddlState.SelectedValue = dsMenu.Tables[0].Rows[0]["State"].ToString();
            hdfParentID.Text = dsMenu.Tables[0].Rows[0]["ParentID"].ToString();
            hdfParentNO.Text = (int.Parse(nbbMenuNO.Text) - 1).ToString();
        }

        //更新菜单等级
        private void updateMenuLevel()
        {
            //自动计算菜单级别
            nbbMenuNO.Text = (int.Parse(hdfParentNO.Text.ToString()) + 1).ToString();
        }

        //保存修改
        protected void btnSave_Click(object sender, EventArgs e)
        {
            #region 逻辑检查
            StringBuilder strWhere = new StringBuilder("MenuName='");
            strWhere.Append(txbMenuName.Text.ToString());
            strWhere.Append("' and ID!='");
            strWhere.Append(Request.QueryString["ID"]);
            strWhere.Append("'");
            BLL.tb_SYS_Menu bllMenu = new BLL.tb_SYS_Menu();
            DataSet dsMenu = bllMenu.GetList(strWhere.ToString());
            if (dsMenu.Tables[0].Rows.Count > 0)
            {
                Alert.ShowInTop("该菜单名称已存在", "提示信息", MessageBoxIcon.Error);
                return;
            }
            #endregion

            #region 保存数据
            Model.tb_SYS_Menu modelMenu = new Model.tb_SYS_Menu();
            modelMenu.ID = Request.QueryString["ID"];
            modelMenu.MenuNO = nbbMenuNO.Text.ToString();
            modelMenu.MenuName = txbMenuName.Text.ToString();
            modelMenu.MenuUrl = txbMenuUrl.Text.ToString();
            //modelMenu.ImageUrl = txbImageUrl.Text.ToString();
            modelMenu.ParentID = hdfParentID.Text.ToString();
            modelMenu.State = ddlState.SelectedValue.ToString();
            modelMenu.UpdateID = Session["AccountID"].ToString();
            modelMenu.UpdateTime = DateTime.Now;

            bool result = bllMenu.Update(modelMenu);
            if (!result)
            {
                Alert.ShowInTop("更新失败", "提示信息", MessageBoxIcon.Error, ActiveWindow.GetHideRefreshReference());
            }
            else
            {
                Alert.ShowInTop("更新成功", "提示信息", MessageBoxIcon.Information, ActiveWindow.GetHideRefreshReference());
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
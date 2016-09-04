using Demo.Web.Code;
using FineUI;
using System;
using System.Data;
using System.Xml;

namespace Demo.Web.Sys.RoleAuthorization
{
    public partial class List : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                BindGrid();
            }
        }

        //绑定数据源
        protected void BindGrid()
        {
            BLL.tb_SYS_RoleMenu bllRoleMenu = new BLL.tb_SYS_RoleMenu();
            DataSet dsRoleMenu = bllRoleMenu.GetList(Request.QueryString["ID"], "MenuNO"); //此处DAL层GetList()方法已重写
            DataTable dtSource = PublicMethod.sortToTree(dsRoleMenu.Tables[0], "MenuNO", "MenuID", "ParentID");
            foreach(DataRow dr in dtSource.Rows)
            {
                dr["AuthorizationInsert"] = (dr["AuthorizationInsert"].ToString() == "1") ? true : false;
                dr["AuthorizationSelect"] = (dr["AuthorizationSelect"].ToString() == "1") ? true : false;
                dr["AuthorizationUpdate"] = (dr["AuthorizationUpdate"].ToString() == "1") ? true : false;
                dr["AuthorizationDelete"] = (dr["AuthorizationDelete"].ToString() == "1") ? true : false;
            }
            gridAuthorization.DataSource = dtSource;
            gridAuthorization.DataBind();
        }

        //行事件：复选框状态检测
        protected void gridAuthorization_RowCommand(object sender, GridCommandEventArgs e)
        {
            bool checkState;
            if (e.CommandName == "CheckBoxSelect")
            {
                checkState = ((FineUI.CheckBoxField)gridAuthorization.FindColumn("AuthorizationSelect_1")).GetCheckedState(e.RowIndex);
                if (checkState == false)
                {
                    //取消访问权限时，自动取消增、删、改权限
                    ((FineUI.CheckBoxField)gridAuthorization.FindColumn(e.ColumnIndex + 1)).SetCheckedState(e.RowIndex, false);
                    ((FineUI.CheckBoxField)gridAuthorization.FindColumn(e.ColumnIndex + 2)).SetCheckedState(e.RowIndex, false);
                    ((FineUI.CheckBoxField)gridAuthorization.FindColumn(e.ColumnIndex + 3)).SetCheckedState(e.RowIndex, false);
                }
            }

            //没有访问权限时，不能授予其他权限
            if (e.CommandName=="CheckBoxOther")
            {
                checkState = ((FineUI.CheckBoxField)gridAuthorization.FindColumn("AuthorizationSelect_1")).GetCheckedState(e.RowIndex);
                if(checkState == false)
                {
                    ((FineUI.CheckBoxField)gridAuthorization.FindColumn(e.ColumnIndex)).SetCheckedState(e.RowIndex, false);
                    Alert.ShowInTop("请先授予访问权限", "提示信息", MessageBoxIcon.Warning);
                }
            }

            int i,j;
            bool isAll = true;
            int indexFatherNode = -1;
            checkState = ((FineUI.CheckBoxField)gridAuthorization.FindColumn(e.ColumnIndex)).GetCheckedState(e.RowIndex);
            if(checkState == true)
            {
                #region 授予父项菜单权限时，自动授予子项菜单权限
                i = e.RowIndex + 1;
                if (i != gridAuthorization.RecordCount)
                {
                    while (int.Parse(gridAuthorization.DataKeys[i][2].ToString()) > int.Parse(gridAuthorization.DataKeys[e.RowIndex][2].ToString()))
                    {
                        ((FineUI.CheckBoxField)gridAuthorization.FindColumn(e.ColumnIndex)).SetCheckedState(i, true);
                        i++;
                        if (i == gridAuthorization.RecordCount)
                        {
                            break;
                        }
                    }
                }
                #endregion

                #region 授予所有子项菜单的权限时，自动授予父项菜单权限
                j = e.RowIndex;
                if (gridAuthorization.DataKeys[e.RowIndex][2].ToString() != "0")
                {
                    while (true)
                    {
                        for (i = 0; i < gridAuthorization.RecordCount; i++)
                        {
                            if (gridAuthorization.DataKeys[i][0].ToString() == gridAuthorization.DataKeys[j][3].ToString())
                            {
                                indexFatherNode = i;
                            }
                            if (i == 0)
                            {
                                continue;//根节点必然没有兄弟节点
                            }
                            if (gridAuthorization.DataKeys[i][3].ToString() == gridAuthorization.DataKeys[j][3].ToString())
                            {
                                isAll = ((FineUI.CheckBoxField)gridAuthorization.FindColumn(e.ColumnIndex)).GetCheckedState(i);
                                if (!isAll)
                                {
                                    break;
                                }
                            }
                        }
                        if (isAll)
                        {
                            ((FineUI.CheckBoxField)gridAuthorization.FindColumn(e.ColumnIndex)).SetCheckedState(indexFatherNode, true);
                            j = indexFatherNode;
                            if(j == 0)
                            {
                                break;
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                #endregion
            }
            else
            {
                #region 撤回父项菜单权限时，自动撤回子项菜单权限
                i = e.RowIndex + 1;
                if (i != gridAuthorization.RecordCount)
                {
                    while (int.Parse(gridAuthorization.DataKeys[i][2].ToString()) > int.Parse(gridAuthorization.DataKeys[e.RowIndex][2].ToString()))
                    {
                        ((FineUI.CheckBoxField)gridAuthorization.FindColumn(e.ColumnIndex)).SetCheckedState(i, false);
                        if (e.CommandName == "CheckBoxSelect")
                        {
                            //取消访问权限时，自动取消增、删、改权限
                            ((FineUI.CheckBoxField)gridAuthorization.FindColumn(e.ColumnIndex + 1)).SetCheckedState(i, false);
                            ((FineUI.CheckBoxField)gridAuthorization.FindColumn(e.ColumnIndex + 2)).SetCheckedState(i, false);
                            ((FineUI.CheckBoxField)gridAuthorization.FindColumn(e.ColumnIndex + 3)).SetCheckedState(i, false);
                        }
                        i++;
                        if (i == gridAuthorization.RecordCount)
                        {
                            break;
                        }
                    }
                }
                #endregion

                #region 撤回子项菜单权限时，自动撤回级联父项菜单权限
                i = j = e.RowIndex;
                while(true)
                {
                    if (i == -1 || j == 0)
                    {
                        break;
                    }
                    if (gridAuthorization.DataKeys[i][0].ToString() == gridAuthorization.DataKeys[j][3].ToString())
                    {
                        ((FineUI.CheckBoxField)gridAuthorization.FindColumn(e.ColumnIndex)).SetCheckedState(i, false);
                        if (e.CommandName == "CheckBoxSelect")
                        {
                            //取消访问权限时，自动取消增、删、改权限
                            ((FineUI.CheckBoxField)gridAuthorization.FindColumn(e.ColumnIndex + 1)).SetCheckedState(i, false);
                            ((FineUI.CheckBoxField)gridAuthorization.FindColumn(e.ColumnIndex + 2)).SetCheckedState(i, false);
                            ((FineUI.CheckBoxField)gridAuthorization.FindColumn(e.ColumnIndex + 3)).SetCheckedState(i, false);
                        }
                        j = i;
                    }
                    i--;
                }  
                #endregion
            }
            
        }

        //保存修改
        protected void btnSave_Click(object sender, EventArgs e)
        {
            bool checkState;
            FineUI.CheckBoxField checkField;
            Model.tb_SYS_RoleMenu modelRoleMenu = new Model.tb_SYS_RoleMenu();
            BLL.tb_SYS_RoleMenu bllRoleMenu = new BLL.tb_SYS_RoleMenu();

            for (int i = 0; i < gridAuthorization.RecordCount; i++)
            {
                checkField = (FineUI.CheckBoxField)gridAuthorization.FindColumn("AuthorizationSelect_1");
                checkState = checkField.GetCheckedState(i);
                
                if(checkState == false)
                {
                    if (gridAuthorization.DataKeys[i][1] != null)
                    {
                        bllRoleMenu.Delete("ID='" + gridAuthorization.DataKeys[i][1].ToString() + "'");
                    }
                    continue;
                }
                modelRoleMenu.RoleID = Request.QueryString["ID"];
                modelRoleMenu.MenuID = gridAuthorization.DataKeys[i][0].ToString();
                modelRoleMenu.AuthorizationInsert = (((FineUI.CheckBoxField)gridAuthorization.FindColumn("AuthorizationInsert_1")).GetCheckedState(i)) ? "1" : "0";
                modelRoleMenu.AuthorizationUpdate = (((FineUI.CheckBoxField)gridAuthorization.FindColumn("AuthorizationUpdate_1")).GetCheckedState(i)) ? "1" : "0";
                modelRoleMenu.AuthorizationDelete = (((FineUI.CheckBoxField)gridAuthorization.FindColumn("AuthorizationDelete_1")).GetCheckedState(i)) ? "1" : "0";

                if (gridAuthorization.DataKeys[i][1] != null)
                {
                    modelRoleMenu.ID = gridAuthorization.DataKeys[i][1].ToString();
                    modelRoleMenu.UpdateID = Session["AccountID"].ToString();
                    modelRoleMenu.UpdateTime = DateTime.Now;
                    bllRoleMenu.Update(modelRoleMenu);
                }
                else
                {
                    modelRoleMenu.ID = Guid.NewGuid().ToString();
                    modelRoleMenu.CreateID = Session["AccountID"].ToString();
                    modelRoleMenu.CreateTime = DateTime.Now;
                    bllRoleMenu.Add(modelRoleMenu);
                }
            }

            saveXml();
            //btnBack_Click(sender, e);
            BindGrid();
        }

        //存储XML
        private void saveXml()
        {
            BLL.vw_SYS_Menu bllMenu_vw = new BLL.vw_SYS_Menu();
            DataSet dsXmlResource = bllMenu_vw.GetList("1=1 order by MenuNO,ParentName");
            BLL.vw_SYS_RoleMenu bllRoleMenu_vw = new BLL.vw_SYS_RoleMenu();
            DataSet dsRemove = bllRoleMenu_vw.GetListNotInRoleMenu(Request.QueryString["ID"].ToString());
           
            XmlDocument xmlSource = new XmlDocument();
            XmlDeclaration xmlDeclaration = xmlSource.CreateXmlDeclaration("1.0", "utf-8", null);
            xmlSource.AppendChild(xmlDeclaration);
            XmlElement element = xmlSource.CreateElement("Tree");
            xmlSource.AppendChild(element);
            #region 载入全部菜单
            string parentName;
            foreach (DataRow dr in dsXmlResource.Tables[0].Rows)
            {
                if(dr["MenuNO"].ToString() == "0")
                {
                    continue;
                }
                parentName = dr["ParentName"].ToString();
                element = xmlSource.CreateElement("TreeNode");
                element.SetAttribute("Text", dr["MenuName"].ToString());
                if (dr["MenuUrl"].ToString() != "")
                {
                    element.SetAttribute("NavigateUrl", dr["MenuUrl"].ToString());
                }
                else
                {
                    element.SetAttribute("SingleClickExpand", "true");
                }
                if (dr["MenuNO"].ToString() == "1")
                {
                    xmlSource.SelectSingleNode("Tree").AppendChild(element);
                }
                else
                {
                    xmlSource.SelectSingleNode("//TreeNode[@Text='" + parentName + "']").AppendChild(element);
                }
            }
            #endregion
            #region 移除没有访问权限的菜单
            XmlNode node;
            foreach(DataRow dr in dsRemove.Tables[0].Rows)
            {
                node = xmlSource.SelectSingleNode("//TreeNode[@Text='" + dr["MenuName"].ToString() + "']");
                xmlSource.SelectSingleNode("//TreeNode[@Text='" + dr["ParentName"].ToString() + "']").RemoveChild(node);
            }
            #endregion
            #region 移除没有子节点的中间节点
            XmlNodeList xmlList = xmlSource.SelectNodes("//TreeNode[not(@NavigateUrl)]");
            foreach(XmlNode xmlNode in xmlList)
            {
                if(!xmlNode.HasChildNodes)
                {
                    xmlNode.ParentNode.RemoveChild(xmlNode);
                }
            }
            #endregion

            Model.tb_SYS_RoleXML modelRoleXML = new Model.tb_SYS_RoleXML();          
            modelRoleXML.RoleID = Request.QueryString["ID"].ToString();
            modelRoleXML.XML = PublicMethod.convertXmlToString(xmlSource);
            modelRoleXML.State = "0";
            modelRoleXML.UpdateID = Session["AccountID"].ToString();
            modelRoleXML.UpdateTime = DateTime.Now;

            BLL.tb_SYS_RoleXML bllRoleXML = new BLL.tb_SYS_RoleXML();

            if(!bllRoleXML.Update(modelRoleXML))
            {
                modelRoleXML.UpdateID = null;
                modelRoleXML.UpdateTime = null;
                modelRoleXML.ID = Guid.NewGuid().ToString();
                modelRoleXML.CreateID = Session["AccountID"].ToString();
                modelRoleXML.CreateTime = DateTime.Now;
                bllRoleXML.Add(modelRoleXML);
            }
        }

        //返回前一个页面
        protected void btnBack_Click(object sender, EventArgs e)
        {
            #region 界面控件显示与隐藏
            btnEdit.Hidden = false;
            btnClose.Hidden = false;
            btnSave.Hidden = true;
            btnBack.Hidden = true;
            gridAuthorization.FindColumn("AuthorizationSelect_1").Hidden = true;
            gridAuthorization.FindColumn("AuthorizationInsert_1").Hidden = true;
            gridAuthorization.FindColumn("AuthorizationDelete_1").Hidden = true;
            gridAuthorization.FindColumn("AuthorizationUpdate_1").Hidden = true;
            gridAuthorization.FindColumn("AuthorizationSelect_2").Hidden = false;
            gridAuthorization.FindColumn("AuthorizationInsert_2").Hidden = false;
            gridAuthorization.FindColumn("AuthorizationDelete_2").Hidden = false;
            gridAuthorization.FindColumn("AuthorizationUpdate_2").Hidden = false;
            #endregion
            BindGrid();
        }

        //编辑事件
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            #region 界面控件显示与隐藏
            btnEdit.Hidden = true;
            btnClose.Hidden = true;
            btnSave.Hidden = false;
            btnBack.Hidden = false;
            gridAuthorization.FindColumn("AuthorizationSelect_1").Hidden = false;
            gridAuthorization.FindColumn("AuthorizationInsert_1").Hidden = false;
            gridAuthorization.FindColumn("AuthorizationDelete_1").Hidden = false;
            gridAuthorization.FindColumn("AuthorizationUpdate_1").Hidden = false;
            gridAuthorization.FindColumn("AuthorizationSelect_2").Hidden = true;
            gridAuthorization.FindColumn("AuthorizationInsert_2").Hidden = true;
            gridAuthorization.FindColumn("AuthorizationDelete_2").Hidden = true;
            gridAuthorization.FindColumn("AuthorizationUpdate_2").Hidden = true;
            #endregion

            BindGrid();
        }

        //关闭页面
        protected void btnClose_Click(object sender, EventArgs e)
        {
            PageContext.RegisterStartupScript(ActiveWindow.GetHideReference());
        }
    }
}
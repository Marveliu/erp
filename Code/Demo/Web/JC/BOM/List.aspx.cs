using System;
using System.Web;
using FineUI;
using System.Data;
using System.Text;
using System.Xml;
using Demo.Web.Code;

namespace Demo.Web.JC.BOM
{
    public partial class List : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnDelete.OnClientClick = gridBOMParent.GetNoSelectionAlertReference("至少选择一项！");
                btnDeleteSub.OnClientClick = gridBOMSub.GetNoSelectionAlertReference("至少选择一项！");
                btnAdd.OnClientClick = windowPop.GetShowReference("Add.aspx", "新增BOM项");
                btnAddSub.OnClientClick = gridBOMParent.GetNoSelectionAlertReference("先选择一项父物料！");
                InitTreeBOM();
                gridBOMParent.SortField = "ID";
                gridBOMSub.SortField = "ParentNO";
                BindGrid();
            }
        }

        private XmlDocument getXmlDocument()
        {
            XmlDocument xmlDoc = new XmlDocument();
            if (gridBOMParent.SelectedRowIndex == -1)
            {
                xmlDoc = PublicMethod.getEmptyTree();
            }
            else
            {
                BLL.proc_BOM bllBOM = new BLL.proc_BOM();
                string materialNO = gridBOMParent.Rows[gridBOMParent.SelectedRowIndex].Values[1].ToString();
                DataSet dsBOM = bllBOM.Search(materialNO);
                xmlDoc = PublicMethod.getEmptyTree();
                if(dsBOM.Tables[0].Rows.Count == 0)
                {
                    return xmlDoc;
                }
                xmlDoc.SelectSingleNode("Tree").RemoveAll();
                XmlElement element = xmlDoc.CreateElement("TreeNode");
                element.SetAttribute("Text", dsBOM.Tables[0].Rows[0]["ParentName"].ToString());
                element.SetAttribute("Number", dsBOM.Tables[0].Rows[0]["ParentNO"].ToString());
                element.SetAttribute("SingleClickExpand", "true");
                element.SetAttribute("Level", "0");
                xmlDoc.SelectSingleNode("//Tree").AppendChild(element);
                foreach (DataRow dr in dsBOM.Tables[0].Rows)
                {
                    element = xmlDoc.CreateElement("TreeNode");
                    element.SetAttribute("Text", dr["MaterialName"].ToString());
                    element.SetAttribute("Number", dr["MaterialNO"].ToString());
                    element.SetAttribute("SingleClickExpand", "true");
                    element.SetAttribute("Level", dr["Level"].ToString());
                    string parentLevel = (int.Parse(dr["Level"].ToString()) - 1).ToString();
                    int i = 0;
                    string path = string.Format("//TreeNode[@Number='{0}' and @Level='{1}']", dr["ParentNO"], parentLevel);
                    while(true)
                    {
                        string childPath = string.Format("//TreeNode[@Number='{0}']",dr["MaterialNO"]);
                        if(xmlDoc.SelectNodes(path)[i].ChildNodes.Count != 0)
                        {
                            if(xmlDoc.SelectNodes(path)[i].SelectSingleNode(childPath) != null)
                            {
                                i = i + 1;
                                continue;
                            }
                            else
                            {
                                xmlDoc.SelectNodes(path)[i].AppendChild(element);
                                break;
                            }
                        }
                        else
                        {
                            xmlDoc.SelectNodes(path)[i].AppendChild(element);
                            break;
                        }
                    }
                }
            }
            return xmlDoc;
        }

        //BOM树绑定数据源
        private void InitTreeBOM()
        {
            XmlDocument xmlSource = getXmlDocument();
            treeBOM.DataSource = xmlSource;
            treeBOM.DataBind();
        }

        //Grid绑定数据源
        private void BindGrid()
        {
            string strWhere = "1=1";
            string order = string.Format("{0} {1}",gridBOMParent.SortField,gridBOMParent.SortDirection);
            int pageSize = gridBOMParent.PageSize;
            int pageIndex = gridBOMParent.PageIndex;
            long recordCount;

            BLL.vw_JC_BOMParent bllBOMParent = new BLL.vw_JC_BOMParent();
            DataSet dsBOMParent = bllBOMParent.GetListByPage(strWhere, order, pageSize, pageIndex, out recordCount);
            DataTable dtSource = dsBOMParent.Tables[0];
            
            gridBOMParent.DataSource = dtSource;
            gridBOMParent.RecordCount = (int)recordCount;
            gridBOMParent.DataBind();
        }

        //GridSub绑定数据源
        private void BindGridSub(string reference)
        {
            StringBuilder strWhere = new StringBuilder();
            strWhere.AppendFormat("ParentNO='{0}'",reference);
            string order = string.Format("{0} {1}", gridBOMSub.SortField, gridBOMSub.SortDirection);
            int pageSize = gridBOMParent.PageSize;
            int pageIndex = gridBOMParent.PageIndex;
            long recordCount;

            BLL.vw_JC_BOMSub bllBOMSub = new BLL.vw_JC_BOMSub();
            DataSet dsBOMSub = bllBOMSub.GetListByPage(strWhere.ToString(), order, pageSize, pageIndex, out recordCount);
            DataTable dtSource = dsBOMSub.Tables[0];

            gridBOMSub.DataSource = dtSource;
            gridBOMSub.RecordCount = (int)recordCount;
            gridBOMSub.DataBind();
        }

        //排序
        protected void grid_Sort(object sender, GridSortEventArgs e)
        {  
            FineUI.Grid grid = (FineUI.Grid)sender;
            if (grid.ID == "gridBOMParent")
            {
                gridBOMParent.SortDirection = e.SortDirection;
                gridBOMParent.SortField = e.SortField;
                BindGrid();
            }
            if (grid.ID == "gridBOMSub")
            {
                gridBOMSub.SortDirection = e.SortDirection;
                gridBOMSub.SortField = e.SortField;
                string materialNO = gridBOMParent.Rows[gridBOMParent.SelectedRowIndex].Values[1].ToString();
                this.BindGridSub(materialNO);
            }
        }

        //翻页
        protected void grid_PageIndexChange(object sender, GridPageEventArgs e)
        {
            FineUI.Grid grid = (FineUI.Grid)sender;
            if (grid.ID == "gridBOMParent")
            {
                gridBOMParent.PageIndex = e.NewPageIndex;
                this.BindGrid();
            }
            if(grid.ID == "gridBOMSub")
            {
                gridBOMSub.PageIndex = e.NewPageIndex;
                string materialNO = gridBOMParent.Rows[gridBOMParent.SelectedRowIndex].Values[1].ToString();
                this.BindGridSub(materialNO);
            }
        }

        //删除事件
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            FineUI.Button btn = (FineUI.Button)sender;
            #region 删除主表记录
            if(btn.ID == "btnDelete")
            {
                if(gridBOMSub.RecordCount > 0)
                {
                    Alert.ShowInTop("在删除该项前,请删除所有子项", "错误", MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    BLL.tb_JC_BOM bllBOM = new BLL.tb_JC_BOM();
                    string id = gridBOMParent.DataKeys[gridBOMParent.SelectedRowIndex][0].ToString();
                    bool result = bllBOM.Delete(id);
                    if(result)
                    {
                        Alert.ShowInTop("删除成功", "信息", MessageBoxIcon.Information);
                        BindGrid();
                    }
                    else
                    {
                        Alert.ShowInTop("删除失败", "错误", MessageBoxIcon.Error);
                    }
                    return;
                }
            }
            #endregion
            #region 删除子表记录
            if(btn.ID == "btnDeleteSub")
            {
                BLL.tb_JC_BOMSub bllBOMSub = new BLL.tb_JC_BOMSub();
                string id = gridBOMSub.DataKeys[gridBOMSub.SelectedRowIndex][0].ToString();
                bool result = bllBOMSub.Delete(id);
                if (result)
                {
                    Alert.ShowInTop("删除成功", "信息", MessageBoxIcon.Information);
                    BindGridSub(gridBOMParent.Rows[gridBOMParent.SelectedRowIndex].Values[1].ToString());
                }
                else
                {
                    Alert.ShowInTop("删除失败", "错误", MessageBoxIcon.Error);
                }
                return;
            }
            #endregion
        }

        //弹出窗口关闭事件(不包含对话框)
        protected void wd_Close(object sender, WindowCloseEventArgs e)
        {
            if (e.CloseArgument.Contains("Sub"))
            {
                string materialNO = gridBOMParent.Rows[gridBOMParent.SelectedRowIndex].Values[1].ToString();
                this.BindGridSub(materialNO);
            }
            else
            {
                this.BindGrid();
            }
           
        }

        //选中主表中某一条记录时，绑定子表和BOM树
        protected void gridBOMParent_RowSelect(object sender, GridRowSelectEventArgs e)
        {
            string materialNO = gridBOMParent.Rows[e.RowIndex].Values[1].ToString();
            InitTreeBOM();
            BindGridSub(materialNO);
        }

        //子表新增事件
        protected void btnAddSub_Click(object sender, EventArgs e)
        {
            if (gridBOMParent.SelectedRowIndex >= 0)
            {
                string url = string.Format("../BOMSub/Add.aspx?parentNO={0}", gridBOMParent.Rows[gridBOMParent.SelectedRowIndex].Values[1]);
                windowPop.Hidden = false;
                windowPop.IFrameUrl = url;
                windowPop.Title = "新增BOM子项-" + gridBOMParent.Rows[gridBOMParent.SelectedRowIndex].Values[2];
            }
        }
    }
}
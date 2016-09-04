using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Xml;

namespace Demo.Web.Code
{
    public class PublicMethod
    {
        /// <summary>
        /// 将DataTable中某一列转换为List
        /// </summary>
        /// <param name="dt">DataTable对象</param>
        /// <param name="columnName">列名</param>
        /// <returns></returns>
        public List<string> columnToList(DataTable dt,string columnName)
        {
            List<string> list = new List<string>();
            foreach(DataRow dr in dt.Rows)
            {
                list.Add(dr[columnName].ToString());
            }
            return list;
        }

        /// <summary>
        /// 将DataTable中多列转换为List
        /// </summary>
        /// <param name="dt">DataTable对象</param>
        /// <param name="columnName">列名数组</param>
        /// <returns></returns>
        public List<List<string>> columnToList(DataTable dt,string[] columnName)
        {
            List<List<string>> listColumn = new List<List<string>>();
            List<string> listRow = new List<string>();

            foreach(DataRow dr in dt.Rows)
            {
                for(int i=0; i<columnName.Length; i++)
                {
                    listRow.Add(dr[columnName[i]].ToString());
                }
                listColumn.Add(listRow);
                listRow.RemoveRange(0, columnName.Length);
            }

            return listColumn;
        }

        /// <summary>
        /// 对DataTable对象排序，以匹配DataSimulateTreeLevelField的数据要求
        /// </summary>
        /// <param name="dtSource">待排序的DataTable对象</param>
        /// <param name="sortColumn">DataSimulateTreeLevelField的值</param>
        /// <param name="keyColumn">主键名称</param>
        /// <param name="refColumn">外键名称</param>
        /// <returns></returns>
        public static DataTable sortToTree(DataTable dtSource,string sortColumn,string keyColumn,string refColumn)
        {
            DataTable dtDestination = dtSource.Clone();
            DataColumn[] primaryKey = new DataColumn[] { dtDestination.Columns[keyColumn] };
            dtDestination.PrimaryKey = primaryKey;

            int insertPos = -1;
            foreach (DataRow drSource in dtSource.Rows)
            {
                if (drSource[sortColumn].ToString() != "0")
                {
                    DataRow dr = dtDestination.NewRow();
                    dr.ItemArray = drSource.ItemArray;
                    insertPos = dtDestination.Rows.IndexOf(dtDestination.Rows.Find(drSource[refColumn])) + 1;
                    dtDestination.Rows.InsertAt(dr, insertPos);
                }
                else
                {
                    dtDestination.ImportRow(drSource);
                }
            }
            return dtDestination;
        }

        /// <summary>
        /// 获取子节点个数
        /// </summary>
        /// <param name="dtSource">数据源DataTable对象</param>
        /// <param name="keyColumn">主键名</param>
        /// <param name="refColumn">外建名</param>
        /// <param name="nodeKey">节点主键值</param>
        /// <returns></returns>
        public static int getChildNumber(DataTable dtSource,string keyColumn,string refColumn,string nodeKey)
        {
            int childNumber = 0;
            bool nodeIsExit = false;
            foreach(DataRow dr in dtSource.Rows)
            {
                if(dr[refColumn].ToString() == nodeKey)
                {
                    childNumber++;
                }
                if(dr[keyColumn].ToString() == nodeKey)
                {
                    nodeIsExit = true;
                }
            }
            if(childNumber == 0)
            {
                return (nodeIsExit ? childNumber : -1);
            }
            else
            {
                return childNumber;
            }           
        }

        /// <summary>
        /// 获取当前分页的DataTable对象
        /// </summary>
        /// <param name="dtSource">数据源</param>
        /// <param name="pageIndex">页面索引</param>
        /// <param name="pageSize">页面大小</param>
        /// <returns></returns>
        public static DataTable getPageTable(DataTable dtSource,int pageIndex, int pageSize)
        {
            DataTable pageTable = dtSource.Clone();

            int rowbegin = pageIndex * pageSize;
            int rowend = (pageIndex + 1) * pageSize;
            if (rowend > dtSource.Rows.Count)
            {
                rowend = dtSource.Rows.Count;
            }

            for (int i = rowbegin; i < rowend; i++)
            {
                pageTable.ImportRow(dtSource.Rows[i]);
            }

            return pageTable;
        }

        /// <summary>
        /// 将XmlDocument对象转化为string字符串
        /// </summary>
        /// <param name="xmlDoc"></param>
        /// <returns></returns>
        public static string convertXmlToString(XmlDocument xmlDoc)
        {
            MemoryStream stream = new MemoryStream();
            XmlTextWriter writer = new XmlTextWriter(stream, null);
            writer.Formatting = Formatting.Indented;
            xmlDoc.Save(writer);

            StreamReader streamReader = new StreamReader(stream, System.Text.Encoding.UTF8);
            stream.Position = 0;
            string returnValue = streamReader.ReadToEnd();

            streamReader.Close();
            stream.Close();

            return returnValue;
        }

        /// <summary>
        /// 返回一棵空树
        /// </summary>
        /// <returns></returns>
        public static XmlDocument getEmptyTree()
        {
            XmlDocument xml = new XmlDocument();
            XmlDeclaration xmlDeclaration = xml.CreateXmlDeclaration("1.0", "utf-8", null);
            xml.AppendChild(xmlDeclaration);
            XmlElement element = xml.CreateElement("Tree");
            xml.AppendChild(element);
            element = xml.CreateElement("TreeNode");
            element.SetAttribute("Text", "No Data");
            element.SetAttribute("SingleClickExpand", "true");
            xml.SelectSingleNode("Tree").AppendChild(element);

            return xml;
        }


        /// <summary>
        /// 执行键值转换
        /// </summary>
        /// <param name="type">转换类型</param>
        /// <param name="value">数据库中存储的值</param>
        /// <returns></returns>
        public static string getKey(string type,string value)
        {
            string key = "Error";
            if(type == "IF")
            {
                key = (value == "Y" ? "是" : "否");
            }
            if(type == "USE")
            {
                key = (value == "Y" ? "启用" : "未启用");
            }
            if(type == "CHECK")
            {
                if (value == "C") key = "未审核";
                if (value == "Y") key = "审核通过";
                if (value == "N") key = "审核未通过";
            }
            if(type == "SOURCE_JH")
            {
                if (value == "S") key = "销售订单";
                if (value == "F") key = "预测单";
            }
            if(type == "FINISH")
            {
                if (value == "Y") key = "结束";
                if (value == "N") key = "未结束";
            }
            if (type == "REQUIREMENT_JH")
            {
                if (value == "I") key = "录入";
                if (value == "C") key = "审批";
                if (value == "B") key = "拆分";
                if (value == "R") key = "分解";
                if (value == "A") key = "下达";
                if (value == "P") key = "部分执行";
                if (value == "F") key = "完工";
                if (value == "S") key = "中止";
            }
            if (type == "BILL")
            {
                if (value == "O") key = "委外单";
                if (value == "A") key = "生产单";
                if (value == "P") key = "采购单";
            }
            if (type == "TASK_JH")
            {
                if (value == "Y") key = "已执行";
                if (value == "N") key = "未执行";
            }
            if (type == "MRP_JH")
            {
                if (value == "Y") key = "已下达";
                if (value == "N") key = "未下达";
            }
            if (type == "MPS_JH")
            {
                if (value == "Y") key = "已分解";
                if (value == "N") key = "未分解";
            }
            return key;
        }
    }
}

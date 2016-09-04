using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Demo.Model;

namespace Demo.BLL
{
    public partial class proc_BOM
    {
        private readonly Demo.DAL.proc_BOM dal = new Demo.DAL.proc_BOM();

        public proc_BOM() { }

        /// <summary>
        /// 判断是否存在嵌套
        /// </summary>
        /// <param name="location">起始节点编号</param>
        /// <param name="materialNO">待检测节点编号</param>
        /// <returns></returns>
        public int isNesting(string location, string materialNO)
        {
            int result = dal.proc_IsNesting(location, materialNO);
            return result;
        }

        /// <summary>
        /// 查询前辈节点
        /// </summary>
        /// <param name="reverseLevel">反查级数（大于等于0的整数）</param>
        /// <param name="materialNO">待查询节点编号</param>
        /// <returns></returns>
        public DataSet reverseSearch(int reverseLevel,string materialNO)
        {
            DataSet ds = dal.proc_reverseSearch_BOM(reverseLevel, materialNO);
            return ds;
        }

        /// <summary>
        /// 查询子节点
        /// </summary>
        /// <param name="materialNO">待查询节点编号</param>
        /// <returns></returns>
        public DataSet Search(string materialNO)
        {
            return dal.proc_search_BOM(materialNO);
        }
    }
}

/**  版本信息模板在安装目录下，可自行修改。
* vw_JC_BOMSub.cs
*
* 功 能： N/A
* 类 名： vw_JC_BOMSub
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/5/16 16:36:26   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Demo.Model;
namespace Demo.BLL
{
	/// <summary>
	/// vw_JC_BOMSub
	/// </summary>
	public partial class vw_JC_BOMSub
	{
		private readonly Demo.DAL.vw_JC_BOMSub dal=new Demo.DAL.vw_JC_BOMSub();
		public vw_JC_BOMSub()
		{}
		#region  BasicMethod

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Demo.Model.vw_JC_BOMSub model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Demo.Model.vw_JC_BOMSub model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete()
		{
			//该表无主键信息，请自定义主键/条件字段
			return dal.Delete();
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Demo.Model.vw_JC_BOMSub GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			return dal.GetModel();
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Demo.Model.vw_JC_BOMSub GetModelByCache()
		{
			//该表无主键信息，请自定义主键/条件字段
			string CacheKey = "vw_JC_BOMSubModel-" ;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel();
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Demo.Model.vw_JC_BOMSub)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Demo.Model.vw_JC_BOMSub> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Demo.Model.vw_JC_BOMSub> DataTableToList(DataTable dt)
		{
			List<Demo.Model.vw_JC_BOMSub> modelList = new List<Demo.Model.vw_JC_BOMSub>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Demo.Model.vw_JC_BOMSub model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = dal.DataRowToModel(dt.Rows[n]);
					if (model != null)
					{
						modelList.Add(model);
					}
				}
			}
			return modelList;
		}

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string sqlWhere, string order, int pageSize, int pageIndex, out long totalRecord)
        {
            return dal.GetListByPage(sqlWhere, order, pageSize, pageIndex, out totalRecord);
        }

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}


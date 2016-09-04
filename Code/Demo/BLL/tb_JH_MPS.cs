/**  版本信息模板在安装目录下，可自行修改。
* tb_JH_MPS.cs
*
* 功 能： N/A
* 类 名： tb_JH_MPS
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/5/14 16:38:35   N/A    初版
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
	/// tb_JH_MPS
	/// </summary>
	public partial class tb_JH_MPS
	{
		private readonly Demo.DAL.tb_JH_MPS dal=new Demo.DAL.tb_JH_MPS();
		public tb_JH_MPS()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string ID)
		{
			return dal.Exists(ID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Demo.Model.tb_JH_MPS model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Demo.Model.tb_JH_MPS model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string ID)
		{
			
			return dal.Delete(ID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string IDlist )
		{
			return dal.DeleteList(Maticsoft.Common.PageValidate.SafeLongFilter(IDlist,0) );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Demo.Model.tb_JH_MPS GetModel(string ID)
		{
			
			return dal.GetModel(ID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Demo.Model.tb_JH_MPS GetModelByCache(string ID)
		{
			
			string CacheKey = "tb_JH_MPSModel-" + ID;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(ID);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Demo.Model.tb_JH_MPS)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Demo.Model.tb_JH_MPS> DataTableToList(DataTable dt)
		{
			List<Demo.Model.tb_JH_MPS> modelList = new List<Demo.Model.tb_JH_MPS>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Demo.Model.tb_JH_MPS model;
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
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
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
        public int DownMPS(string ID)
        {
            return dal.DownMPS(ID);
        }

        public bool DeleteMPS(string ID, string materialNO)
        {
            return dal.DeleteMPS(ID, materialNO);
        }

        public int insertMPS(Demo.Model.tb_JH_MPS model)
        {
            return dal.InsertMPS(model.ID, model.PlanNO, model.PlannedSourceID, model.MaterialNO, model.PlanAmount,model.EndDate);
        }

        public bool updateMPS(string ID, string planNO)
        {
            return dal.UpdateMPS(ID, planNO);
        }
		#endregion  ExtensionMethod
	}
}


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
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Demo.DAL
{
	/// <summary>
	/// 数据访问类:vw_JC_BOMSub
	/// </summary>
	public partial class vw_JC_BOMSub
	{
		public vw_JC_BOMSub()
		{}
		#region  BasicMethod



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Demo.Model.vw_JC_BOMSub model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into vw_JC_BOMSub(");
			strSql.Append("ID,MaterialNO,MaterialType,ParentNO,Amount,LeadTimeOffset,BackFlush,Status,MaterialName,Specification,Model,Unit,ParentName,PropertyName)");
			strSql.Append(" values (");
			strSql.Append("@ID,@MaterialNO,@MaterialType,@ParentNO,@Amount,@LeadTimeOffset,@BackFlush,@Status,@MaterialName,@Specification,@Model,@Unit,@ParentName,@PropertyName)");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,64),
					new SqlParameter("@MaterialNO", SqlDbType.NVarChar,64),
					new SqlParameter("@MaterialType", SqlDbType.NVarChar,1),
					new SqlParameter("@ParentNO", SqlDbType.NVarChar,64),
					new SqlParameter("@Amount", SqlDbType.Decimal,9),
					new SqlParameter("@LeadTimeOffset", SqlDbType.Decimal,9),
					new SqlParameter("@BackFlush", SqlDbType.NVarChar,1),
					new SqlParameter("@Status", SqlDbType.NVarChar,1),
					new SqlParameter("@MaterialName", SqlDbType.NVarChar,64),
					new SqlParameter("@Specification", SqlDbType.NVarChar,64),
					new SqlParameter("@Model", SqlDbType.NVarChar,64),
					new SqlParameter("@Unit", SqlDbType.NVarChar,64),
					new SqlParameter("@ParentName", SqlDbType.NVarChar,64),
					new SqlParameter("@PropertyName", SqlDbType.NVarChar,64)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.MaterialNO;
			parameters[2].Value = model.MaterialType;
			parameters[3].Value = model.ParentNO;
			parameters[4].Value = model.Amount;
			parameters[5].Value = model.LeadTimeOffset;
			parameters[6].Value = model.BackFlush;
			parameters[7].Value = model.Status;
			parameters[8].Value = model.MaterialName;
			parameters[9].Value = model.Specification;
			parameters[10].Value = model.Model;
			parameters[11].Value = model.Unit;
			parameters[12].Value = model.ParentName;
			parameters[13].Value = model.PropertyName;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Demo.Model.vw_JC_BOMSub model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update vw_JC_BOMSub set ");
			strSql.Append("ID=@ID,");
			strSql.Append("MaterialNO=@MaterialNO,");
			strSql.Append("MaterialType=@MaterialType,");
			strSql.Append("ParentNO=@ParentNO,");
			strSql.Append("Amount=@Amount,");
			strSql.Append("LeadTimeOffset=@LeadTimeOffset,");
			strSql.Append("BackFlush=@BackFlush,");
			strSql.Append("Status=@Status,");
			strSql.Append("MaterialName=@MaterialName,");
			strSql.Append("Specification=@Specification,");
			strSql.Append("Model=@Model,");
			strSql.Append("Unit=@Unit,");
			strSql.Append("ParentName=@ParentName,");
			strSql.Append("PropertyName=@PropertyName");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,64),
					new SqlParameter("@MaterialNO", SqlDbType.NVarChar,64),
					new SqlParameter("@MaterialType", SqlDbType.NVarChar,1),
					new SqlParameter("@ParentNO", SqlDbType.NVarChar,64),
					new SqlParameter("@Amount", SqlDbType.Decimal,9),
					new SqlParameter("@LeadTimeOffset", SqlDbType.Decimal,9),
					new SqlParameter("@BackFlush", SqlDbType.NVarChar,1),
					new SqlParameter("@Status", SqlDbType.NVarChar,1),
					new SqlParameter("@MaterialName", SqlDbType.NVarChar,64),
					new SqlParameter("@Specification", SqlDbType.NVarChar,64),
					new SqlParameter("@Model", SqlDbType.NVarChar,64),
					new SqlParameter("@Unit", SqlDbType.NVarChar,64),
					new SqlParameter("@ParentName", SqlDbType.NVarChar,64),
					new SqlParameter("@PropertyName", SqlDbType.NVarChar,64)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.MaterialNO;
			parameters[2].Value = model.MaterialType;
			parameters[3].Value = model.ParentNO;
			parameters[4].Value = model.Amount;
			parameters[5].Value = model.LeadTimeOffset;
			parameters[6].Value = model.BackFlush;
			parameters[7].Value = model.Status;
			parameters[8].Value = model.MaterialName;
			parameters[9].Value = model.Specification;
			parameters[10].Value = model.Model;
			parameters[11].Value = model.Unit;
			parameters[12].Value = model.ParentName;
			parameters[13].Value = model.PropertyName;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from vw_JC_BOMSub ");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
			};

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Demo.Model.vw_JC_BOMSub GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,MaterialNO,MaterialType,ParentNO,Amount,LeadTimeOffset,BackFlush,Status,MaterialName,Specification,Model,Unit,ParentName,PropertyName from vw_JC_BOMSub ");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
			};

			Demo.Model.vw_JC_BOMSub model=new Demo.Model.vw_JC_BOMSub();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Demo.Model.vw_JC_BOMSub DataRowToModel(DataRow row)
		{
			Demo.Model.vw_JC_BOMSub model=new Demo.Model.vw_JC_BOMSub();
			if (row != null)
			{
				if(row["ID"]!=null)
				{
					model.ID=row["ID"].ToString();
				}
				if(row["MaterialNO"]!=null)
				{
					model.MaterialNO=row["MaterialNO"].ToString();
				}
				if(row["MaterialType"]!=null)
				{
					model.MaterialType=row["MaterialType"].ToString();
				}
				if(row["ParentNO"]!=null)
				{
					model.ParentNO=row["ParentNO"].ToString();
				}
				if(row["Amount"]!=null && row["Amount"].ToString()!="")
				{
					model.Amount=decimal.Parse(row["Amount"].ToString());
				}
				if(row["LeadTimeOffset"]!=null && row["LeadTimeOffset"].ToString()!="")
				{
					model.LeadTimeOffset=decimal.Parse(row["LeadTimeOffset"].ToString());
				}
				if(row["BackFlush"]!=null)
				{
					model.BackFlush=row["BackFlush"].ToString();
				}
				if(row["Status"]!=null)
				{
					model.Status=row["Status"].ToString();
				}
				if(row["MaterialName"]!=null)
				{
					model.MaterialName=row["MaterialName"].ToString();
				}
				if(row["Specification"]!=null)
				{
					model.Specification=row["Specification"].ToString();
				}
				if(row["Model"]!=null)
				{
					model.Model=row["Model"].ToString();
				}
				if(row["Unit"]!=null)
				{
					model.Unit=row["Unit"].ToString();
				}
				if(row["ParentName"]!=null)
				{
					model.ParentName=row["ParentName"].ToString();
				}
				if(row["PropertyName"]!=null)
				{
					model.PropertyName=row["PropertyName"].ToString();
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,MaterialNO,MaterialType,ParentNO,Amount,LeadTimeOffset,BackFlush,Status,MaterialName,Specification,Model,Unit,ParentName,PropertyName ");
			strSql.Append(" FROM vw_JC_BOMSub ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string sqlWhere, string order, int pageSize, int pageIndex, out long totalRecord)
        {
            Common pageData = new Common();
            DataSet ds = pageData.getDataPage("vw_JC_BOMSub", "*", sqlWhere, order, pageSize, pageIndex, out totalRecord);
            return ds;
        }
		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}


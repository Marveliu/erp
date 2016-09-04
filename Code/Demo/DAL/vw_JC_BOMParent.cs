/**  版本信息模板在安装目录下，可自行修改。
* vw_JC_BOMParent.cs
*
* 功 能： N/A
* 类 名： vw_JC_BOMParent
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/5/16 16:36:22   N/A    初版
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
	/// 数据访问类:vw_JC_BOMParent
	/// </summary>
	public partial class vw_JC_BOMParent
	{
		public vw_JC_BOMParent()
		{}
		#region  BasicMethod



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Demo.Model.vw_JC_BOMParent model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into vw_JC_BOMParent(");
			strSql.Append("ID,MaterialNO,MaterialType,CheckNO,CheckStatus,CheckDate,Status,MaterialName,Specification,Model,Unit,CheckName,PropertyName)");
			strSql.Append(" values (");
			strSql.Append("@ID,@MaterialNO,@MaterialType,@CheckNO,@CheckStatus,@CheckDate,@Status,@MaterialName,@Specification,@Model,@Unit,@CheckName,@PropertyName)");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,64),
					new SqlParameter("@MaterialNO", SqlDbType.NVarChar,64),
					new SqlParameter("@MaterialType", SqlDbType.NVarChar,1),
					new SqlParameter("@CheckNO", SqlDbType.NVarChar,64),
					new SqlParameter("@CheckStatus", SqlDbType.NVarChar,1),
					new SqlParameter("@CheckDate", SqlDbType.DateTime),
					new SqlParameter("@Status", SqlDbType.NVarChar,1),
					new SqlParameter("@MaterialName", SqlDbType.NVarChar,64),
					new SqlParameter("@Specification", SqlDbType.NVarChar,64),
					new SqlParameter("@Model", SqlDbType.NVarChar,64),
					new SqlParameter("@Unit", SqlDbType.NVarChar,64),
					new SqlParameter("@CheckName", SqlDbType.NVarChar,64),
					new SqlParameter("@PropertyName", SqlDbType.NVarChar,64)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.MaterialNO;
			parameters[2].Value = model.MaterialType;
			parameters[3].Value = model.CheckNO;
			parameters[4].Value = model.CheckStatus;
			parameters[5].Value = model.CheckDate;
			parameters[6].Value = model.Status;
			parameters[7].Value = model.MaterialName;
			parameters[8].Value = model.Specification;
			parameters[9].Value = model.Model;
			parameters[10].Value = model.Unit;
			parameters[11].Value = model.CheckName;
			parameters[12].Value = model.PropertyName;

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
		public bool Update(Demo.Model.vw_JC_BOMParent model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update vw_JC_BOMParent set ");
			strSql.Append("ID=@ID,");
			strSql.Append("MaterialNO=@MaterialNO,");
			strSql.Append("MaterialType=@MaterialType,");
			strSql.Append("CheckNO=@CheckNO,");
			strSql.Append("CheckStatus=@CheckStatus,");
			strSql.Append("CheckDate=@CheckDate,");
			strSql.Append("Status=@Status,");
			strSql.Append("MaterialName=@MaterialName,");
			strSql.Append("Specification=@Specification,");
			strSql.Append("Model=@Model,");
			strSql.Append("Unit=@Unit,");
			strSql.Append("CheckName=@CheckName,");
			strSql.Append("PropertyName=@PropertyName");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,64),
					new SqlParameter("@MaterialNO", SqlDbType.NVarChar,64),
					new SqlParameter("@MaterialType", SqlDbType.NVarChar,1),
					new SqlParameter("@CheckNO", SqlDbType.NVarChar,64),
					new SqlParameter("@CheckStatus", SqlDbType.NVarChar,1),
					new SqlParameter("@CheckDate", SqlDbType.DateTime),
					new SqlParameter("@Status", SqlDbType.NVarChar,1),
					new SqlParameter("@MaterialName", SqlDbType.NVarChar,64),
					new SqlParameter("@Specification", SqlDbType.NVarChar,64),
					new SqlParameter("@Model", SqlDbType.NVarChar,64),
					new SqlParameter("@Unit", SqlDbType.NVarChar,64),
					new SqlParameter("@CheckName", SqlDbType.NVarChar,64),
					new SqlParameter("@PropertyName", SqlDbType.NVarChar,64)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.MaterialNO;
			parameters[2].Value = model.MaterialType;
			parameters[3].Value = model.CheckNO;
			parameters[4].Value = model.CheckStatus;
			parameters[5].Value = model.CheckDate;
			parameters[6].Value = model.Status;
			parameters[7].Value = model.MaterialName;
			parameters[8].Value = model.Specification;
			parameters[9].Value = model.Model;
			parameters[10].Value = model.Unit;
			parameters[11].Value = model.CheckName;
			parameters[12].Value = model.PropertyName;

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
			strSql.Append("delete from vw_JC_BOMParent ");
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
		public Demo.Model.vw_JC_BOMParent GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,MaterialNO,MaterialType,CheckNO,CheckStatus,CheckDate,Status,MaterialName,Specification,Model,Unit,CheckName,PropertyName from vw_JC_BOMParent ");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
			};

			Demo.Model.vw_JC_BOMParent model=new Demo.Model.vw_JC_BOMParent();
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
		public Demo.Model.vw_JC_BOMParent DataRowToModel(DataRow row)
		{
			Demo.Model.vw_JC_BOMParent model=new Demo.Model.vw_JC_BOMParent();
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
				if(row["CheckNO"]!=null)
				{
					model.CheckNO=row["CheckNO"].ToString();
				}
				if(row["CheckStatus"]!=null)
				{
					model.CheckStatus=row["CheckStatus"].ToString();
				}
				if(row["CheckDate"]!=null && row["CheckDate"].ToString()!="")
				{
					model.CheckDate=DateTime.Parse(row["CheckDate"].ToString());
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
				if(row["CheckName"]!=null)
				{
					model.CheckName=row["CheckName"].ToString();
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
			strSql.Append("select ID,MaterialNO,MaterialType,CheckNO,CheckStatus,CheckDate,Status,MaterialName,Specification,Model,Unit,CheckName,PropertyName ");
			strSql.Append(" FROM vw_JC_BOMParent ");
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
            DataSet ds = pageData.getDataPage("vw_JC_BOMParent", "*", sqlWhere, order, pageSize, pageIndex, out totalRecord);
            return ds;
		}

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}


/**  版本信息模板在安装目录下，可自行修改。
* vw_JC_Procedure.cs
*
* 功 能： N/A
* 类 名： vw_JC_Procedure
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/5/23 15:17:50   N/A    初版
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
	/// 数据访问类:vw_JC_Procedure
	/// </summary>
	public partial class vw_JC_Procedure
	{
		public vw_JC_Procedure()
		{}
		#region  BasicMethod



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Demo.Model.vw_JC_Procedure model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into vw_JC_Procedure(");
			strSql.Append("ID,ProcedureNO,ProcedureName,WorkCenterNO,Status,WorkCenterName)");
			strSql.Append(" values (");
			strSql.Append("@ID,@ProcedureNO,@ProcedureName,@WorkCenterNO,@Status,@WorkCenterName)");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,64),
					new SqlParameter("@ProcedureNO", SqlDbType.NVarChar,64),
					new SqlParameter("@ProcedureName", SqlDbType.NVarChar,64),
					new SqlParameter("@WorkCenterNO", SqlDbType.NVarChar,64),
					new SqlParameter("@Status", SqlDbType.NVarChar,1),
					new SqlParameter("@WorkCenterName", SqlDbType.NVarChar,64)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.ProcedureNO;
			parameters[2].Value = model.ProcedureName;
			parameters[3].Value = model.WorkCenterNO;
			parameters[4].Value = model.Status;
			parameters[5].Value = model.WorkCenterName;

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
		public bool Update(Demo.Model.vw_JC_Procedure model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update vw_JC_Procedure set ");
			strSql.Append("ID=@ID,");
			strSql.Append("ProcedureNO=@ProcedureNO,");
			strSql.Append("ProcedureName=@ProcedureName,");
			strSql.Append("WorkCenterNO=@WorkCenterNO,");
			strSql.Append("Status=@Status,");
			strSql.Append("WorkCenterName=@WorkCenterName");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,64),
					new SqlParameter("@ProcedureNO", SqlDbType.NVarChar,64),
					new SqlParameter("@ProcedureName", SqlDbType.NVarChar,64),
					new SqlParameter("@WorkCenterNO", SqlDbType.NVarChar,64),
					new SqlParameter("@Status", SqlDbType.NVarChar,1),
					new SqlParameter("@WorkCenterName", SqlDbType.NVarChar,64)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.ProcedureNO;
			parameters[2].Value = model.ProcedureName;
			parameters[3].Value = model.WorkCenterNO;
			parameters[4].Value = model.Status;
			parameters[5].Value = model.WorkCenterName;

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
			strSql.Append("delete from vw_JC_Procedure ");
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
		public Demo.Model.vw_JC_Procedure GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,ProcedureNO,ProcedureName,WorkCenterNO,Status,WorkCenterName from vw_JC_Procedure ");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
			};

			Demo.Model.vw_JC_Procedure model=new Demo.Model.vw_JC_Procedure();
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
		public Demo.Model.vw_JC_Procedure DataRowToModel(DataRow row)
		{
			Demo.Model.vw_JC_Procedure model=new Demo.Model.vw_JC_Procedure();
			if (row != null)
			{
				if(row["ID"]!=null)
				{
					model.ID=row["ID"].ToString();
				}
				if(row["ProcedureNO"]!=null)
				{
					model.ProcedureNO=row["ProcedureNO"].ToString();
				}
				if(row["ProcedureName"]!=null)
				{
					model.ProcedureName=row["ProcedureName"].ToString();
				}
				if(row["WorkCenterNO"]!=null)
				{
					model.WorkCenterNO=row["WorkCenterNO"].ToString();
				}
				if(row["Status"]!=null)
				{
					model.Status=row["Status"].ToString();
				}
				if(row["WorkCenterName"]!=null)
				{
					model.WorkCenterName=row["WorkCenterName"].ToString();
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
			strSql.Append("select ID,ProcedureNO,ProcedureName,WorkCenterNO,Status,WorkCenterName ");
			strSql.Append(" FROM vw_JC_Procedure ");
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
            DataSet ds = pageData.getDataPage("vw_JC_Procedure", "*", sqlWhere, order, pageSize, pageIndex, out totalRecord);
            return ds;
		}
		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}


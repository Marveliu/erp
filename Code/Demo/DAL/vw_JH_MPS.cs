/**  版本信息模板在安装目录下，可自行修改。
* vw_JH_MPS.cs
*
* 功 能： N/A
* 类 名： vw_JH_MPS
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/6/6 14:30:19   N/A    初版
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
	/// 数据访问类:vw_JH_MPS
	/// </summary>
	public partial class vw_JH_MPS
	{
		public vw_JH_MPS()
		{}
		#region  BasicMethod



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Demo.Model.vw_JH_MPS model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into vw_JH_MPS(");
			strSql.Append("ID,PlanNO,PlannedSourceID,MaterialNO,PlanAmount,ResolveAmount,EndDate,Status,MaterialName,Unit,PlannedSourceNO)");
			strSql.Append(" values (");
			strSql.Append("@ID,@PlanNO,@PlannedSourceID,@MaterialNO,@PlanAmount,@ResolveAmount,@EndDate,@Status,@MaterialName,@Unit,@PlannedSourceNO)");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,64),
					new SqlParameter("@PlanNO", SqlDbType.NVarChar,64),
					new SqlParameter("@PlannedSourceID", SqlDbType.NVarChar,64),
					new SqlParameter("@MaterialNO", SqlDbType.NVarChar,64),
					new SqlParameter("@PlanAmount", SqlDbType.Decimal,9),
					new SqlParameter("@ResolveAmount", SqlDbType.Decimal,9),
					new SqlParameter("@EndDate", SqlDbType.DateTime),
					new SqlParameter("@Status", SqlDbType.NVarChar,1),
					new SqlParameter("@MaterialName", SqlDbType.NVarChar,64),
					new SqlParameter("@Unit", SqlDbType.NVarChar,64),
					new SqlParameter("@PlannedSourceNO", SqlDbType.NVarChar,64)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.PlanNO;
			parameters[2].Value = model.PlannedSourceID;
			parameters[3].Value = model.MaterialNO;
			parameters[4].Value = model.PlanAmount;
			parameters[5].Value = model.ResolveAmount;
			parameters[6].Value = model.EndDate;
			parameters[7].Value = model.Status;
			parameters[8].Value = model.MaterialName;
			parameters[9].Value = model.Unit;
			parameters[10].Value = model.PlannedSourceNO;

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
		public bool Update(Demo.Model.vw_JH_MPS model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update vw_JH_MPS set ");
			strSql.Append("ID=@ID,");
			strSql.Append("PlanNO=@PlanNO,");
			strSql.Append("PlannedSourceID=@PlannedSourceID,");
			strSql.Append("MaterialNO=@MaterialNO,");
			strSql.Append("PlanAmount=@PlanAmount,");
			strSql.Append("ResolveAmount=@ResolveAmount,");
			strSql.Append("EndDate=@EndDate,");
			strSql.Append("Status=@Status,");
			strSql.Append("MaterialName=@MaterialName,");
			strSql.Append("Unit=@Unit,");
			strSql.Append("PlannedSourceNO=@PlannedSourceNO");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,64),
					new SqlParameter("@PlanNO", SqlDbType.NVarChar,64),
					new SqlParameter("@PlannedSourceID", SqlDbType.NVarChar,64),
					new SqlParameter("@MaterialNO", SqlDbType.NVarChar,64),
					new SqlParameter("@PlanAmount", SqlDbType.Decimal,9),
					new SqlParameter("@ResolveAmount", SqlDbType.Decimal,9),
					new SqlParameter("@EndDate", SqlDbType.DateTime),
					new SqlParameter("@Status", SqlDbType.NVarChar,1),
					new SqlParameter("@MaterialName", SqlDbType.NVarChar,64),
					new SqlParameter("@Unit", SqlDbType.NVarChar,64),
					new SqlParameter("@PlannedSourceNO", SqlDbType.NVarChar,64)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.PlanNO;
			parameters[2].Value = model.PlannedSourceID;
			parameters[3].Value = model.MaterialNO;
			parameters[4].Value = model.PlanAmount;
			parameters[5].Value = model.ResolveAmount;
			parameters[6].Value = model.EndDate;
			parameters[7].Value = model.Status;
			parameters[8].Value = model.MaterialName;
			parameters[9].Value = model.Unit;
			parameters[10].Value = model.PlannedSourceNO;

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
			strSql.Append("delete from vw_JH_MPS ");
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
		public Demo.Model.vw_JH_MPS GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,PlanNO,PlannedSourceID,MaterialNO,PlanAmount,ResolveAmount,EndDate,Status,MaterialName,Unit,PlannedSourceNO from vw_JH_MPS ");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
			};

			Demo.Model.vw_JH_MPS model=new Demo.Model.vw_JH_MPS();
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
		public Demo.Model.vw_JH_MPS DataRowToModel(DataRow row)
		{
			Demo.Model.vw_JH_MPS model=new Demo.Model.vw_JH_MPS();
			if (row != null)
			{
				if(row["ID"]!=null)
				{
					model.ID=row["ID"].ToString();
				}
				if(row["PlanNO"]!=null)
				{
					model.PlanNO=row["PlanNO"].ToString();
				}
				if(row["PlannedSourceID"]!=null)
				{
					model.PlannedSourceID=row["PlannedSourceID"].ToString();
				}
				if(row["MaterialNO"]!=null)
				{
					model.MaterialNO=row["MaterialNO"].ToString();
				}
				if(row["PlanAmount"]!=null && row["PlanAmount"].ToString()!="")
				{
					model.PlanAmount=decimal.Parse(row["PlanAmount"].ToString());
				}
				if(row["ResolveAmount"]!=null && row["ResolveAmount"].ToString()!="")
				{
					model.ResolveAmount=decimal.Parse(row["ResolveAmount"].ToString());
				}
				if(row["EndDate"]!=null && row["EndDate"].ToString()!="")
				{
					model.EndDate=DateTime.Parse(row["EndDate"].ToString());
				}
				if(row["Status"]!=null)
				{
					model.Status=row["Status"].ToString();
				}
				if(row["MaterialName"]!=null)
				{
					model.MaterialName=row["MaterialName"].ToString();
				}
				if(row["Unit"]!=null)
				{
					model.Unit=row["Unit"].ToString();
				}
				if(row["PlannedSourceNO"]!=null)
				{
					model.PlannedSourceNO=row["PlannedSourceNO"].ToString();
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
			strSql.Append("select ID,PlanNO,PlannedSourceID,MaterialNO,PlanAmount,ResolveAmount,EndDate,Status,MaterialName,Unit,PlannedSourceNO ");
			strSql.Append(" FROM vw_JH_MPS ");
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
            DataSet ds = pageData.getDataPage("vw_JH_MPS", "*", sqlWhere, order, pageSize, pageIndex, out totalRecord);
            return ds;
		}

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}


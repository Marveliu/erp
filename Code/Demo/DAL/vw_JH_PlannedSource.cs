/**  版本信息模板在安装目录下，可自行修改。
* vw_JH_PlannedSource.cs
*
* 功 能： N/A
* 类 名： vw_JH_PlannedSource
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/6/6 14:38:10   N/A    初版
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
	/// 数据访问类:vw_JH_PlannedSource
	/// </summary>
	public partial class vw_JH_PlannedSource
	{
		public vw_JH_PlannedSource()
		{}
		#region  BasicMethod



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Demo.Model.vw_JH_PlannedSource model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into vw_JH_PlannedSource(");
			strSql.Append("ID,BillNO,BillType,MaterialNO,PlanAmount,DownAmount,EndDate,Status,MaterialName,Property,Unit,PropertyName)");
			strSql.Append(" values (");
			strSql.Append("@ID,@BillNO,@BillType,@MaterialNO,@PlanAmount,@DownAmount,@EndDate,@Status,@MaterialName,@Property,@Unit,@PropertyName)");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,64),
					new SqlParameter("@BillNO", SqlDbType.NVarChar,64),
					new SqlParameter("@BillType", SqlDbType.NVarChar,1),
					new SqlParameter("@MaterialNO", SqlDbType.NVarChar,64),
					new SqlParameter("@PlanAmount", SqlDbType.Decimal,9),
					new SqlParameter("@DownAmount", SqlDbType.Decimal,9),
					new SqlParameter("@EndDate", SqlDbType.DateTime),
					new SqlParameter("@Status", SqlDbType.NVarChar,1),
					new SqlParameter("@MaterialName", SqlDbType.NVarChar,64),
					new SqlParameter("@Property", SqlDbType.NVarChar,1),
					new SqlParameter("@Unit", SqlDbType.NVarChar,64),
					new SqlParameter("@PropertyName", SqlDbType.NVarChar,64)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.BillNO;
			parameters[2].Value = model.BillType;
			parameters[3].Value = model.MaterialNO;
			parameters[4].Value = model.PlanAmount;
			parameters[5].Value = model.DownAmount;
			parameters[6].Value = model.EndDate;
			parameters[7].Value = model.Status;
			parameters[8].Value = model.MaterialName;
			parameters[9].Value = model.Property;
			parameters[10].Value = model.Unit;
			parameters[11].Value = model.PropertyName;

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
		public bool Update(Demo.Model.vw_JH_PlannedSource model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update vw_JH_PlannedSource set ");
			strSql.Append("ID=@ID,");
			strSql.Append("BillNO=@BillNO,");
			strSql.Append("BillType=@BillType,");
			strSql.Append("MaterialNO=@MaterialNO,");
			strSql.Append("PlanAmount=@PlanAmount,");
			strSql.Append("DownAmount=@DownAmount,");
			strSql.Append("EndDate=@EndDate,");
			strSql.Append("Status=@Status,");
			strSql.Append("MaterialName=@MaterialName,");
			strSql.Append("Property=@Property,");
			strSql.Append("Unit=@Unit,");
			strSql.Append("PropertyName=@PropertyName");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,64),
					new SqlParameter("@BillNO", SqlDbType.NVarChar,64),
					new SqlParameter("@BillType", SqlDbType.NVarChar,1),
					new SqlParameter("@MaterialNO", SqlDbType.NVarChar,64),
					new SqlParameter("@PlanAmount", SqlDbType.Decimal,9),
					new SqlParameter("@DownAmount", SqlDbType.Decimal,9),
					new SqlParameter("@EndDate", SqlDbType.DateTime),
					new SqlParameter("@Status", SqlDbType.NVarChar,1),
					new SqlParameter("@MaterialName", SqlDbType.NVarChar,64),
					new SqlParameter("@Property", SqlDbType.NVarChar,1),
					new SqlParameter("@Unit", SqlDbType.NVarChar,64),
					new SqlParameter("@PropertyName", SqlDbType.NVarChar,64)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.BillNO;
			parameters[2].Value = model.BillType;
			parameters[3].Value = model.MaterialNO;
			parameters[4].Value = model.PlanAmount;
			parameters[5].Value = model.DownAmount;
			parameters[6].Value = model.EndDate;
			parameters[7].Value = model.Status;
			parameters[8].Value = model.MaterialName;
			parameters[9].Value = model.Property;
			parameters[10].Value = model.Unit;
			parameters[11].Value = model.PropertyName;

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
			strSql.Append("delete from vw_JH_PlannedSource ");
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
		public Demo.Model.vw_JH_PlannedSource GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,BillNO,BillType,MaterialNO,PlanAmount,DownAmount,EndDate,Status,MaterialName,Property,Unit,PropertyName from vw_JH_PlannedSource ");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
			};

			Demo.Model.vw_JH_PlannedSource model=new Demo.Model.vw_JH_PlannedSource();
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
		public Demo.Model.vw_JH_PlannedSource DataRowToModel(DataRow row)
		{
			Demo.Model.vw_JH_PlannedSource model=new Demo.Model.vw_JH_PlannedSource();
			if (row != null)
			{
				if(row["ID"]!=null)
				{
					model.ID=row["ID"].ToString();
				}
				if(row["BillNO"]!=null)
				{
					model.BillNO=row["BillNO"].ToString();
				}
				if(row["BillType"]!=null)
				{
					model.BillType=row["BillType"].ToString();
				}
				if(row["MaterialNO"]!=null)
				{
					model.MaterialNO=row["MaterialNO"].ToString();
				}
				if(row["PlanAmount"]!=null && row["PlanAmount"].ToString()!="")
				{
					model.PlanAmount=decimal.Parse(row["PlanAmount"].ToString());
				}
				if(row["DownAmount"]!=null && row["DownAmount"].ToString()!="")
				{
					model.DownAmount=decimal.Parse(row["DownAmount"].ToString());
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
				if(row["Property"]!=null)
				{
					model.Property=row["Property"].ToString();
				}
				if(row["Unit"]!=null)
				{
					model.Unit=row["Unit"].ToString();
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
			strSql.Append("select ID,BillNO,BillType,MaterialNO,PlanAmount,DownAmount,EndDate,Status,MaterialName,Property,Unit,PropertyName ");
			strSql.Append(" FROM vw_JH_PlannedSource ");
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
            DataSet ds = pageData.getDataPage("vw_JH_PlannedSource", "*", sqlWhere, order, pageSize, pageIndex, out totalRecord);
            return ds;
		}

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}


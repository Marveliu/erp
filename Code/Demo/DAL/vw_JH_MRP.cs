/**  版本信息模板在安装目录下，可自行修改。
* vw_JH_MRP.cs
*
* 功 能： N/A
* 类 名： vw_JH_MRP
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/5/26 17:36:31   N/A    初版
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
	/// 数据访问类:vw_JH_MRP
	/// </summary>
	public partial class vw_JH_MRP
	{
		public vw_JH_MRP()
		{}
		#region  BasicMethod



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Demo.Model.vw_JH_MRP model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into vw_JH_MRP(");
			strSql.Append("ID,PlanNO,MPSID,MaterialNO,NeedAmount,NeedDate,Status,MaterialName,Unit,MPSNO,PropertyName)");
			strSql.Append(" values (");
			strSql.Append("@ID,@PlanNO,@MPSID,@MaterialNO,@NeedAmount,@NeedDate,@Status,@MaterialName,@Unit,@MPSNO,@PropertyName)");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,64),
					new SqlParameter("@PlanNO", SqlDbType.NVarChar,64),
					new SqlParameter("@MPSID", SqlDbType.NVarChar,64),
					new SqlParameter("@MaterialNO", SqlDbType.NVarChar,64),
					new SqlParameter("@NeedAmount", SqlDbType.Decimal,9),
					new SqlParameter("@NeedDate", SqlDbType.DateTime),
					new SqlParameter("@Status", SqlDbType.NVarChar,1),
					new SqlParameter("@MaterialName", SqlDbType.NVarChar,64),
					new SqlParameter("@Unit", SqlDbType.NVarChar,64),
					new SqlParameter("@MPSNO", SqlDbType.NVarChar,64),
					new SqlParameter("@PropertyName", SqlDbType.NVarChar,64)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.PlanNO;
			parameters[2].Value = model.MPSID;
			parameters[3].Value = model.MaterialNO;
			parameters[4].Value = model.NeedAmount;
			parameters[5].Value = model.NeedDate;
			parameters[6].Value = model.Status;
			parameters[7].Value = model.MaterialName;
			parameters[8].Value = model.Unit;
			parameters[9].Value = model.MPSNO;
			parameters[10].Value = model.PropertyName;

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
		public bool Update(Demo.Model.vw_JH_MRP model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update vw_JH_MRP set ");
			strSql.Append("ID=@ID,");
			strSql.Append("PlanNO=@PlanNO,");
			strSql.Append("MPSID=@MPSID,");
			strSql.Append("MaterialNO=@MaterialNO,");
			strSql.Append("NeedAmount=@NeedAmount,");
			strSql.Append("NeedDate=@NeedDate,");
			strSql.Append("Status=@Status,");
			strSql.Append("MaterialName=@MaterialName,");
			strSql.Append("Unit=@Unit,");
			strSql.Append("MPSNO=@MPSNO,");
			strSql.Append("PropertyName=@PropertyName");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,64),
					new SqlParameter("@PlanNO", SqlDbType.NVarChar,64),
					new SqlParameter("@MPSID", SqlDbType.NVarChar,64),
					new SqlParameter("@MaterialNO", SqlDbType.NVarChar,64),
					new SqlParameter("@NeedAmount", SqlDbType.Decimal,9),
					new SqlParameter("@NeedDate", SqlDbType.DateTime),
					new SqlParameter("@Status", SqlDbType.NVarChar,1),
					new SqlParameter("@MaterialName", SqlDbType.NVarChar,64),
					new SqlParameter("@Unit", SqlDbType.NVarChar,64),
					new SqlParameter("@MPSNO", SqlDbType.NVarChar,64),
					new SqlParameter("@PropertyName", SqlDbType.NVarChar,64)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.PlanNO;
			parameters[2].Value = model.MPSID;
			parameters[3].Value = model.MaterialNO;
			parameters[4].Value = model.NeedAmount;
			parameters[5].Value = model.NeedDate;
			parameters[6].Value = model.Status;
			parameters[7].Value = model.MaterialName;
			parameters[8].Value = model.Unit;
			parameters[9].Value = model.MPSNO;
			parameters[10].Value = model.PropertyName;

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
			strSql.Append("delete from vw_JH_MRP ");
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
		public Demo.Model.vw_JH_MRP GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,PlanNO,MPSID,MaterialNO,NeedAmount,NeedDate,Status,MaterialName,Unit,MPSNO,PropertyName from vw_JH_MRP ");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
			};

			Demo.Model.vw_JH_MRP model=new Demo.Model.vw_JH_MRP();
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
		public Demo.Model.vw_JH_MRP DataRowToModel(DataRow row)
		{
			Demo.Model.vw_JH_MRP model=new Demo.Model.vw_JH_MRP();
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
				if(row["MPSID"]!=null)
				{
					model.MPSID=row["MPSID"].ToString();
				}
				if(row["MaterialNO"]!=null)
				{
					model.MaterialNO=row["MaterialNO"].ToString();
				}
				if(row["NeedAmount"]!=null && row["NeedAmount"].ToString()!="")
				{
					model.NeedAmount=decimal.Parse(row["NeedAmount"].ToString());
				}
				if(row["NeedDate"]!=null && row["NeedDate"].ToString()!="")
				{
					model.NeedDate=DateTime.Parse(row["NeedDate"].ToString());
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
				if(row["MPSNO"]!=null)
				{
					model.MPSNO=row["MPSNO"].ToString();
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
			strSql.Append("select ID,PlanNO,MPSID,MaterialNO,NeedAmount,NeedDate,Status,MaterialName,Unit,MPSNO,PropertyName ");
			strSql.Append(" FROM vw_JH_MRP ");
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
            DataSet ds = pageData.getDataPage("vw_JH_MRP", "*", sqlWhere, order, pageSize, pageIndex, out totalRecord);
            return ds;
		}

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}


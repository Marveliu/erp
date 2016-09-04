/**  版本信息模板在安装目录下，可自行修改。
* vw_JH_Task.cs
*
* 功 能： N/A
* 类 名： vw_JH_Task
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/6/5 22:38:27   N/A    初版
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
	/// 数据访问类:vw_JH_Task
	/// </summary>
	public partial class vw_JH_Task
	{
		public vw_JH_Task()
		{}
		#region  BasicMethod



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Demo.Model.vw_JH_Task model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into vw_JH_Task(");
			strSql.Append("ID,SourceID,MRPID,BillType,BillNO,Date,Amount,ExecutedAmount,Status,SourceNO,MaterialNO,MaterialName,Unit)");
			strSql.Append(" values (");
			strSql.Append("@ID,@SourceID,@MRPID,@BillType,@BillNO,@Date,@Amount,@ExecutedAmount,@Status,@SourceNO,@MaterialNO,@MaterialName,@Unit)");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,64),
					new SqlParameter("@SourceID", SqlDbType.NVarChar,64),
					new SqlParameter("@MRPID", SqlDbType.NVarChar,64),
					new SqlParameter("@BillType", SqlDbType.NVarChar,1),
					new SqlParameter("@BillNO", SqlDbType.NVarChar,64),
					new SqlParameter("@Date", SqlDbType.DateTime),
					new SqlParameter("@Amount", SqlDbType.Decimal,9),
					new SqlParameter("@ExecutedAmount", SqlDbType.Decimal,9),
					new SqlParameter("@Status", SqlDbType.NVarChar,1),
					new SqlParameter("@SourceNO", SqlDbType.NVarChar,64),
					new SqlParameter("@MaterialNO", SqlDbType.NVarChar,64),
					new SqlParameter("@MaterialName", SqlDbType.NVarChar,64),
					new SqlParameter("@Unit", SqlDbType.NVarChar,64)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.SourceID;
			parameters[2].Value = model.MRPID;
			parameters[3].Value = model.BillType;
			parameters[4].Value = model.BillNO;
			parameters[5].Value = model.Date;
			parameters[6].Value = model.Amount;
			parameters[7].Value = model.ExecutedAmount;
			parameters[8].Value = model.Status;
			parameters[9].Value = model.SourceNO;
			parameters[10].Value = model.MaterialNO;
			parameters[11].Value = model.MaterialName;
			parameters[12].Value = model.Unit;

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
		public bool Update(Demo.Model.vw_JH_Task model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update vw_JH_Task set ");
			strSql.Append("ID=@ID,");
			strSql.Append("SourceID=@SourceID,");
			strSql.Append("MRPID=@MRPID,");
			strSql.Append("BillType=@BillType,");
			strSql.Append("BillNO=@BillNO,");
			strSql.Append("Date=@Date,");
			strSql.Append("Amount=@Amount,");
			strSql.Append("ExecutedAmount=@ExecutedAmount,");
			strSql.Append("Status=@Status,");
			strSql.Append("SourceNO=@SourceNO,");
			strSql.Append("MaterialNO=@MaterialNO,");
			strSql.Append("MaterialName=@MaterialName,");
			strSql.Append("Unit=@Unit");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,64),
					new SqlParameter("@SourceID", SqlDbType.NVarChar,64),
					new SqlParameter("@MRPID", SqlDbType.NVarChar,64),
					new SqlParameter("@BillType", SqlDbType.NVarChar,1),
					new SqlParameter("@BillNO", SqlDbType.NVarChar,64),
					new SqlParameter("@Date", SqlDbType.DateTime),
					new SqlParameter("@Amount", SqlDbType.Decimal,9),
					new SqlParameter("@ExecutedAmount", SqlDbType.Decimal,9),
					new SqlParameter("@Status", SqlDbType.NVarChar,1),
					new SqlParameter("@SourceNO", SqlDbType.NVarChar,64),
					new SqlParameter("@MaterialNO", SqlDbType.NVarChar,64),
					new SqlParameter("@MaterialName", SqlDbType.NVarChar,64),
					new SqlParameter("@Unit", SqlDbType.NVarChar,64)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.SourceID;
			parameters[2].Value = model.MRPID;
			parameters[3].Value = model.BillType;
			parameters[4].Value = model.BillNO;
			parameters[5].Value = model.Date;
			parameters[6].Value = model.Amount;
			parameters[7].Value = model.ExecutedAmount;
			parameters[8].Value = model.Status;
			parameters[9].Value = model.SourceNO;
			parameters[10].Value = model.MaterialNO;
			parameters[11].Value = model.MaterialName;
			parameters[12].Value = model.Unit;

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
			strSql.Append("delete from vw_JH_Task ");
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
		public Demo.Model.vw_JH_Task GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,SourceID,MRPID,BillType,BillNO,Date,Amount,ExecutedAmount,Status,SourceNO,MaterialNO,MaterialName,Unit from vw_JH_Task ");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
			};

			Demo.Model.vw_JH_Task model=new Demo.Model.vw_JH_Task();
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
		public Demo.Model.vw_JH_Task DataRowToModel(DataRow row)
		{
			Demo.Model.vw_JH_Task model=new Demo.Model.vw_JH_Task();
			if (row != null)
			{
				if(row["ID"]!=null)
				{
					model.ID=row["ID"].ToString();
				}
				if(row["SourceID"]!=null)
				{
					model.SourceID=row["SourceID"].ToString();
				}
				if(row["MRPID"]!=null)
				{
					model.MRPID=row["MRPID"].ToString();
				}
				if(row["BillType"]!=null)
				{
					model.BillType=row["BillType"].ToString();
				}
				if(row["BillNO"]!=null)
				{
					model.BillNO=row["BillNO"].ToString();
				}
				if(row["Date"]!=null && row["Date"].ToString()!="")
				{
					model.Date=DateTime.Parse(row["Date"].ToString());
				}
				if(row["Amount"]!=null && row["Amount"].ToString()!="")
				{
					model.Amount=decimal.Parse(row["Amount"].ToString());
				}
				if(row["ExecutedAmount"]!=null && row["ExecutedAmount"].ToString()!="")
				{
					model.ExecutedAmount=decimal.Parse(row["ExecutedAmount"].ToString());
				}
				if(row["Status"]!=null)
				{
					model.Status=row["Status"].ToString();
				}
				if(row["SourceNO"]!=null)
				{
					model.SourceNO=row["SourceNO"].ToString();
				}
				if(row["MaterialNO"]!=null)
				{
					model.MaterialNO=row["MaterialNO"].ToString();
				}
				if(row["MaterialName"]!=null)
				{
					model.MaterialName=row["MaterialName"].ToString();
				}
				if(row["Unit"]!=null)
				{
					model.Unit=row["Unit"].ToString();
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
			strSql.Append("select ID,SourceID,MRPID,BillType,BillNO,Date,Amount,ExecutedAmount,Status,SourceNO,MaterialNO,MaterialName,Unit ");
			strSql.Append(" FROM vw_JH_Task ");
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
            DataSet ds = pageData.getDataPage("vw_JH_Task", "*", sqlWhere, order, pageSize, pageIndex, out totalRecord);
            return ds;
		}

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}


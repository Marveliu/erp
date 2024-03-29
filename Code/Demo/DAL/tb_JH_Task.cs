﻿/**  版本信息模板在安装目录下，可自行修改。
* tb_JH_Task.cs
*
* 功 能： N/A
* 类 名： tb_JH_Task
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/6/5 22:38:26   N/A    初版
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
	/// 数据访问类:tb_JH_Task
	/// </summary>
	public partial class tb_JH_Task
	{
		public tb_JH_Task()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tb_JH_Task");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,64)			};
			parameters[0].Value = ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Demo.Model.tb_JH_Task model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_JH_Task(");
			strSql.Append("ID,SourceID,MRPID,BillType,BillNO,Date,Amount,ExecutedAmount,Status)");
			strSql.Append(" values (");
			strSql.Append("@ID,@SourceID,@MRPID,@BillType,@BillNO,@Date,@Amount,@ExecutedAmount,@Status)");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,64),
					new SqlParameter("@SourceID", SqlDbType.NVarChar,64),
					new SqlParameter("@MRPID", SqlDbType.NVarChar,64),
					new SqlParameter("@BillType", SqlDbType.NVarChar,1),
					new SqlParameter("@BillNO", SqlDbType.NVarChar,64),
					new SqlParameter("@Date", SqlDbType.DateTime),
					new SqlParameter("@Amount", SqlDbType.Decimal,9),
					new SqlParameter("@ExecutedAmount", SqlDbType.Decimal,9),
					new SqlParameter("@Status", SqlDbType.NVarChar,1)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.SourceID;
			parameters[2].Value = model.MRPID;
			parameters[3].Value = model.BillType;
			parameters[4].Value = model.BillNO;
			parameters[5].Value = model.Date;
			parameters[6].Value = model.Amount;
			parameters[7].Value = model.ExecutedAmount;
			parameters[8].Value = model.Status;

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
		public bool Update(Demo.Model.tb_JH_Task model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_JH_Task set ");
			strSql.Append("SourceID=@SourceID,");
			strSql.Append("MRPID=@MRPID,");
			strSql.Append("BillType=@BillType,");
			strSql.Append("BillNO=@BillNO,");
			strSql.Append("Date=@Date,");
			strSql.Append("Amount=@Amount,");
			strSql.Append("ExecutedAmount=@ExecutedAmount,");
			strSql.Append("Status=@Status");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@SourceID", SqlDbType.NVarChar,64),
					new SqlParameter("@MRPID", SqlDbType.NVarChar,64),
					new SqlParameter("@BillType", SqlDbType.NVarChar,1),
					new SqlParameter("@BillNO", SqlDbType.NVarChar,64),
					new SqlParameter("@Date", SqlDbType.DateTime),
					new SqlParameter("@Amount", SqlDbType.Decimal,9),
					new SqlParameter("@ExecutedAmount", SqlDbType.Decimal,9),
					new SqlParameter("@Status", SqlDbType.NVarChar,1),
					new SqlParameter("@ID", SqlDbType.NVarChar,64)};
			parameters[0].Value = model.SourceID;
			parameters[1].Value = model.MRPID;
			parameters[2].Value = model.BillType;
			parameters[3].Value = model.BillNO;
			parameters[4].Value = model.Date;
			parameters[5].Value = model.Amount;
			parameters[6].Value = model.ExecutedAmount;
			parameters[7].Value = model.Status;
			parameters[8].Value = model.ID;

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
		public bool Delete(string ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_JH_Task ");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,64)			};
			parameters[0].Value = ID;

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
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_JH_Task ");
			strSql.Append(" where ID in ("+IDlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
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
		public Demo.Model.tb_JH_Task GetModel(string ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,SourceID,MRPID,BillType,BillNO,Date,Amount,ExecutedAmount,Status from tb_JH_Task ");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,64)			};
			parameters[0].Value = ID;

			Demo.Model.tb_JH_Task model=new Demo.Model.tb_JH_Task();
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
		public Demo.Model.tb_JH_Task DataRowToModel(DataRow row)
		{
			Demo.Model.tb_JH_Task model=new Demo.Model.tb_JH_Task();
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
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,SourceID,MRPID,BillType,BillNO,Date,Amount,ExecutedAmount,Status ");
			strSql.Append(" FROM tb_JH_Task ");
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
            DataSet ds = pageData.getDataPage("tb_JH_Task", "*", sqlWhere, order, pageSize, pageIndex, out totalRecord);
            return ds;
		}

		#endregion  BasicMethod
		#region  ExtensionMethod
        public int AssignPlan(string SourceID)
        {
            SqlParameter[] parameters = {			 
			 			 new SqlParameter("@SourceID", SqlDbType.NVarChar,64), 
			 			 new SqlParameter("@result", SqlDbType.Int) 
			 			 };
            parameters[0].Value = SourceID;
            parameters[1].Direction = ParameterDirection.Output;
            DbHelperSQL.RunProcedure("proc_assignPlan", parameters).Close();
            return (int)parameters[1].Value;
        }

		#endregion  ExtensionMethod
	}
}


/**  版本信息模板在安装目录下，可自行修改。
* tb_JC_WorkCalendarRule.cs
*
* 功 能： N/A
* 类 名： tb_JC_WorkCalendarRule
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/6/1 23:27:15   N/A    初版
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
	/// 数据访问类:tb_JC_WorkCalendarRule
	/// </summary>
	public partial class tb_JC_WorkCalendarRule
	{
		public tb_JC_WorkCalendarRule()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tb_JC_WorkCalendarRule");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,64)			};
			parameters[0].Value = ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Demo.Model.tb_JC_WorkCalendarRule model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_JC_WorkCalendarRule(");
			strSql.Append("ID,ExceptionType,ExceptionTime)");
			strSql.Append(" values (");
			strSql.Append("@ID,@ExceptionType,@ExceptionTime)");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,64),
					new SqlParameter("@ExceptionType", SqlDbType.NVarChar,1),
					new SqlParameter("@ExceptionTime", SqlDbType.NVarChar,16)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.ExceptionType;
			parameters[2].Value = model.ExceptionTime;

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
		public bool Update(Demo.Model.tb_JC_WorkCalendarRule model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_JC_WorkCalendarRule set ");
			strSql.Append("ExceptionType=@ExceptionType,");
			strSql.Append("ExceptionTime=@ExceptionTime");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ExceptionType", SqlDbType.NVarChar,1),
					new SqlParameter("@ExceptionTime", SqlDbType.NVarChar,16),
					new SqlParameter("@ID", SqlDbType.NVarChar,64)};
			parameters[0].Value = model.ExceptionType;
			parameters[1].Value = model.ExceptionTime;
			parameters[2].Value = model.ID;

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
			strSql.Append("delete from tb_JC_WorkCalendarRule ");
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
			strSql.Append("delete from tb_JC_WorkCalendarRule ");
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
		public Demo.Model.tb_JC_WorkCalendarRule GetModel(string ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,ExceptionType,ExceptionTime from tb_JC_WorkCalendarRule ");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,64)			};
			parameters[0].Value = ID;

			Demo.Model.tb_JC_WorkCalendarRule model=new Demo.Model.tb_JC_WorkCalendarRule();
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
		public Demo.Model.tb_JC_WorkCalendarRule DataRowToModel(DataRow row)
		{
			Demo.Model.tb_JC_WorkCalendarRule model=new Demo.Model.tb_JC_WorkCalendarRule();
			if (row != null)
			{
				if(row["ID"]!=null)
				{
					model.ID=row["ID"].ToString();
				}
				if(row["ExceptionType"]!=null)
				{
					model.ExceptionType=row["ExceptionType"].ToString();
				}
				if(row["ExceptionTime"]!=null)
				{
					model.ExceptionTime=row["ExceptionTime"].ToString();
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
			strSql.Append("select ID,ExceptionType,ExceptionTime ");
			strSql.Append(" FROM tb_JC_WorkCalendarRule ");
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
            DataSet ds = pageData.getDataPage("tb_JC_WorkCalendarRule", "*", sqlWhere, order, pageSize, pageIndex, out totalRecord);
            return ds;
		}

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}


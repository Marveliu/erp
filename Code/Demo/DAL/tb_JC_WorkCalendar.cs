/**  版本信息模板在安装目录下，可自行修改。
* tb_JC_WorkCalendar.cs
*
* 功 能： N/A
* 类 名： tb_JC_WorkCalendar
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/6/1 23:27:14   N/A    初版
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
	/// 数据访问类:tb_JC_WorkCalendar
	/// </summary>
	public partial class tb_JC_WorkCalendar
	{
		public tb_JC_WorkCalendar()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ID", "tb_JC_WorkCalendar"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tb_JC_WorkCalendar");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Demo.Model.tb_JC_WorkCalendar model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_JC_WorkCalendar(");
			strSql.Append("Date)");
			strSql.Append(" values (");
			strSql.Append("@Date)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Date", SqlDbType.DateTime)};
			parameters[0].Value = model.Date;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Demo.Model.tb_JC_WorkCalendar model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_JC_WorkCalendar set ");
			strSql.Append("Date=@Date");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@Date", SqlDbType.DateTime),
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = model.Date;
			parameters[1].Value = model.ID;

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
		public bool Delete(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_JC_WorkCalendar ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
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
			strSql.Append("delete from tb_JC_WorkCalendar ");
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
		public Demo.Model.tb_JC_WorkCalendar GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,Date from tb_JC_WorkCalendar ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			Demo.Model.tb_JC_WorkCalendar model=new Demo.Model.tb_JC_WorkCalendar();
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
		public Demo.Model.tb_JC_WorkCalendar DataRowToModel(DataRow row)
		{
			Demo.Model.tb_JC_WorkCalendar model=new Demo.Model.tb_JC_WorkCalendar();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=int.Parse(row["ID"].ToString());
				}
				if(row["Date"]!=null && row["Date"].ToString()!="")
				{
					model.Date=DateTime.Parse(row["Date"].ToString());
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
			strSql.Append("select ID,Date ");
			strSql.Append(" FROM tb_JC_WorkCalendar ");
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
            DataSet ds = pageData.getDataPage("tb_JC_WorkCalendar", "*", sqlWhere, order, pageSize, pageIndex, out totalRecord);
            return ds;
		}

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}


/**  版本信息模板在安装目录下，可自行修改。
* tb_JH_WorkCenterLoad.cs
*
* 功 能： N/A
* 类 名： tb_JH_WorkCenterLoad
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/5/14 16:38:36   N/A    初版
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
	/// 数据访问类:tb_JH_WorkCenterLoad
	/// </summary>
	public partial class tb_JH_WorkCenterLoad
	{
		public tb_JH_WorkCenterLoad()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tb_JH_WorkCenterLoad");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,64)			};
			parameters[0].Value = ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Demo.Model.tb_JH_WorkCenterLoad model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_JH_WorkCenterLoad(");
			strSql.Append("ID,WorkCenterNO,AllLoad,Date)");
			strSql.Append(" values (");
			strSql.Append("@ID,@WorkCenterNO,@AllLoad,@Date)");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,64),
					new SqlParameter("@WorkCenterNO", SqlDbType.NVarChar,64),
					new SqlParameter("@AllLoad", SqlDbType.Decimal,9),
					new SqlParameter("@Date", SqlDbType.DateTime)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.WorkCenterNO;
			parameters[2].Value = model.AllLoad;
			parameters[3].Value = model.Date;

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
		public bool Update(Demo.Model.tb_JH_WorkCenterLoad model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_JH_WorkCenterLoad set ");
			strSql.Append("WorkCenterNO=@WorkCenterNO,");
			strSql.Append("AllLoad=@AllLoad,");
			strSql.Append("Date=@Date");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@WorkCenterNO", SqlDbType.NVarChar,64),
					new SqlParameter("@AllLoad", SqlDbType.Decimal,9),
					new SqlParameter("@Date", SqlDbType.DateTime),
					new SqlParameter("@ID", SqlDbType.NVarChar,64)};
			parameters[0].Value = model.WorkCenterNO;
			parameters[1].Value = model.AllLoad;
			parameters[2].Value = model.Date;
			parameters[3].Value = model.ID;

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
			strSql.Append("delete from tb_JH_WorkCenterLoad ");
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
			strSql.Append("delete from tb_JH_WorkCenterLoad ");
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
		public Demo.Model.tb_JH_WorkCenterLoad GetModel(string ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,WorkCenterNO,AllLoad,Date from tb_JH_WorkCenterLoad ");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,64)			};
			parameters[0].Value = ID;

			Demo.Model.tb_JH_WorkCenterLoad model=new Demo.Model.tb_JH_WorkCenterLoad();
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
		public Demo.Model.tb_JH_WorkCenterLoad DataRowToModel(DataRow row)
		{
			Demo.Model.tb_JH_WorkCenterLoad model=new Demo.Model.tb_JH_WorkCenterLoad();
			if (row != null)
			{
				if(row["ID"]!=null)
				{
					model.ID=row["ID"].ToString();
				}
				if(row["WorkCenterNO"]!=null)
				{
					model.WorkCenterNO=row["WorkCenterNO"].ToString();
				}
				if(row["AllLoad"]!=null && row["AllLoad"].ToString()!="")
				{
					model.AllLoad=decimal.Parse(row["AllLoad"].ToString());
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
			strSql.Append("select ID,WorkCenterNO,AllLoad,Date ");
			strSql.Append(" FROM tb_JH_WorkCenterLoad ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string order, int pageSize, int pageIndex, out long record)
        {
            Common common = new Common();
            DataSet ds = common.getDataPage("tb_JH_WorkCenterLoad", "*", strWhere, order, pageSize, pageIndex, out record);
            return ds;
        }

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}


/**  版本信息模板在安装目录下，可自行修改。
* vw_SYS_Account.cs
*
* 功 能： N/A
* 类 名： vw_SYS_Account
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/3/4 19:47:38   N/A    初版
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
	/// 数据访问类:vw_SYS_Account
	/// </summary>
	public partial class vw_SYS_Account
	{
		public vw_SYS_Account()
		{}
		#region  BasicMethod


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Demo.Model.vw_SYS_Account GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,AccountName,Password,AccountType,RoleID,RoleName,State,DefaultUrl from vw_SYS_Account ");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
			};

			Demo.Model.vw_SYS_Account model=new Demo.Model.vw_SYS_Account();
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
		public Demo.Model.vw_SYS_Account DataRowToModel(DataRow row)
		{
			Demo.Model.vw_SYS_Account model=new Demo.Model.vw_SYS_Account();
			if (row != null)
			{
				if(row["ID"]!=null)
				{
					model.ID=row["ID"].ToString();
				}
				if(row["AccountName"]!=null)
				{
					model.AccountName=row["AccountName"].ToString();
				}
				if(row["Password"]!=null)
				{
					model.Password=row["Password"].ToString();
				}
				if(row["AccountType"]!=null)
				{
					model.AccountType=row["AccountType"].ToString();
				}
				if(row["RoleID"]!=null)
				{
					model.RoleID=row["RoleID"].ToString();
				}
				if(row["RoleName"]!=null)
				{
					model.RoleName=row["RoleName"].ToString();
				}
				if(row["State"]!=null)
				{
					model.State=row["State"].ToString();
				}
				if(row["DefaultUrl"]!=null)
				{
					model.DefaultUrl=row["DefaultUrl"].ToString();
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
			strSql.Append("select ID,AccountName,Password,AccountType,RoleID,RoleName,State,DefaultUrl ");
			strSql.Append(" FROM vw_SYS_Account ");
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
            DataSet ds = pageData.getDataPage("vw_SYS_Account", "*", sqlWhere, order, pageSize, pageIndex, out totalRecord);
            return ds;
        }

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}


/**  版本信息模板在安装目录下，可自行修改。
* vw_SYS_RoleMenu.cs
*
* 功 能： N/A
* 类 名： vw_SYS_RoleMenu
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/3/1 10:18:16   N/A    初版
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
	/// 数据访问类:vw_SYS_RoleMenu
	/// </summary>
	public partial class vw_SYS_RoleMenu
	{
		public vw_SYS_RoleMenu()
		{}
		#region  BasicMethod



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Demo.Model.vw_SYS_RoleMenu model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into vw_SYS_RoleMenu(");
			strSql.Append("MenuID,RoleID,MenuNO,MenuName,MenuUrl,ParentName)");
			strSql.Append(" values (");
			strSql.Append("@MenuID,@RoleID,@MenuNO,@MenuName,@MenuUrl,@ParentName)");
			SqlParameter[] parameters = {
					new SqlParameter("@MenuID", SqlDbType.NVarChar,64),
					new SqlParameter("@RoleID", SqlDbType.NVarChar,64),
					new SqlParameter("@MenuNO", SqlDbType.NVarChar,64),
					new SqlParameter("@MenuName", SqlDbType.NVarChar,64),
					new SqlParameter("@MenuUrl", SqlDbType.NVarChar,255),
					new SqlParameter("@ParentName", SqlDbType.NVarChar,64)};
			parameters[0].Value = model.MenuID;
			parameters[1].Value = model.RoleID;
			parameters[2].Value = model.MenuNO;
			parameters[3].Value = model.MenuName;
			parameters[4].Value = model.MenuUrl;
			parameters[5].Value = model.ParentName;

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
		public bool Update(Demo.Model.vw_SYS_RoleMenu model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update vw_SYS_RoleMenu set ");
			strSql.Append("MenuID=@MenuID,");
			strSql.Append("RoleID=@RoleID,");
			strSql.Append("MenuNO=@MenuNO,");
			strSql.Append("MenuName=@MenuName,");
			strSql.Append("MenuUrl=@MenuUrl,");
			strSql.Append("ParentName=@ParentName");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
					new SqlParameter("@MenuID", SqlDbType.NVarChar,64),
					new SqlParameter("@RoleID", SqlDbType.NVarChar,64),
					new SqlParameter("@MenuNO", SqlDbType.NVarChar,64),
					new SqlParameter("@MenuName", SqlDbType.NVarChar,64),
					new SqlParameter("@MenuUrl", SqlDbType.NVarChar,255),
					new SqlParameter("@ParentName", SqlDbType.NVarChar,64)};
			parameters[0].Value = model.MenuID;
			parameters[1].Value = model.RoleID;
			parameters[2].Value = model.MenuNO;
			parameters[3].Value = model.MenuName;
			parameters[4].Value = model.MenuUrl;
			parameters[5].Value = model.ParentName;

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
			strSql.Append("delete from vw_SYS_RoleMenu ");
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
		public Demo.Model.vw_SYS_RoleMenu GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 MenuID,RoleID,MenuNO,MenuName,MenuUrl,ParentName from vw_SYS_RoleMenu ");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
			};

			Demo.Model.vw_SYS_RoleMenu model=new Demo.Model.vw_SYS_RoleMenu();
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
		public Demo.Model.vw_SYS_RoleMenu DataRowToModel(DataRow row)
		{
			Demo.Model.vw_SYS_RoleMenu model=new Demo.Model.vw_SYS_RoleMenu();
			if (row != null)
			{
				if(row["MenuID"]!=null)
				{
					model.MenuID=row["MenuID"].ToString();
				}
				if(row["RoleID"]!=null)
				{
					model.RoleID=row["RoleID"].ToString();
				}
				if(row["MenuNO"]!=null)
				{
					model.MenuNO=row["MenuNO"].ToString();
				}
				if(row["MenuName"]!=null)
				{
					model.MenuName=row["MenuName"].ToString();
				}
				if(row["MenuUrl"]!=null)
				{
					model.MenuUrl=row["MenuUrl"].ToString();
				}
				if(row["ParentName"]!=null)
				{
					model.ParentName=row["ParentName"].ToString();
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
			strSql.Append("select MenuID,RoleID,MenuNO,MenuName,MenuUrl,ParentName ");
			strSql.Append(" FROM vw_SYS_RoleMenu ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

        /// <summary>
        /// 获取没有权限的菜单数据列表
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
		public DataSet GetListNotInRoleMenu(string ID)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select MenuName,ParentName from vw_SYS_Menu where MenuNO = (select top 1 MenuNO from tb_SYS_Menu order by MenuNO Desc) and ID not in (select MenuID from vw_SYS_RoleMenu where RoleID = '");
            if (ID.Trim() != "")
			{
                strSql.Append(ID+"')");
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string sqlWhere, string order, int pageSize, int pageIndex, out long totalRecord)
        {
            Common pageData = new Common();
            DataSet ds = pageData.getDataPage("vw_SYS_RoleMenu", "*", sqlWhere, order, pageSize, pageIndex, out totalRecord);
            return ds;
        }

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}


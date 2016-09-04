/**  版本信息模板在安装目录下，可自行修改。
* vw_SYS_Role.cs
*
* 功 能： N/A
* 类 名： vw_SYS_Role
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/2/25 14:17:49   N/A    初版
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
	/// 数据访问类:vw_SYS_Role
	/// </summary>
	public partial class vw_SYS_Role
	{
		public vw_SYS_Role()
		{}
		#region  BasicMethod



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Demo.Model.vw_SYS_Role model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into vw_SYS_Role(");
			strSql.Append("ID,RoleNO,RoleName,ParentID,DefaultUrl,State,CreateID,CreateTime,UpdateID,UpdateTime,ParentName)");
			strSql.Append(" values (");
			strSql.Append("@ID,@RoleNO,@RoleName,@ParentID,@DefaultUrl,@State,@CreateID,@CreateTime,@UpdateID,@UpdateTime,@ParentName)");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,64),
					new SqlParameter("@RoleNO", SqlDbType.NVarChar,64),
					new SqlParameter("@RoleName", SqlDbType.NVarChar,64),
					new SqlParameter("@ParentID", SqlDbType.NVarChar,64),
					new SqlParameter("@DefaultUrl", SqlDbType.NVarChar,255),
					new SqlParameter("@State", SqlDbType.NVarChar,1),
					new SqlParameter("@CreateID", SqlDbType.NVarChar,64),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@UpdateID", SqlDbType.NVarChar,64),
					new SqlParameter("@UpdateTime", SqlDbType.DateTime),
					new SqlParameter("@ParentName", SqlDbType.NVarChar,64)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.RoleNO;
			parameters[2].Value = model.RoleName;
			parameters[3].Value = model.ParentID;
			parameters[4].Value = model.DefaultUrl;
			parameters[5].Value = model.State;
			parameters[6].Value = model.CreateID;
			parameters[7].Value = model.CreateTime;
			parameters[8].Value = model.UpdateID;
			parameters[9].Value = model.UpdateTime;
			parameters[10].Value = model.ParentName;

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
		public bool Update(Demo.Model.vw_SYS_Role model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update vw_SYS_Role set ");
			strSql.Append("ID=@ID,");
			strSql.Append("RoleNO=@RoleNO,");
			strSql.Append("RoleName=@RoleName,");
			strSql.Append("ParentID=@ParentID,");
			strSql.Append("DefaultUrl=@DefaultUrl,");
			strSql.Append("State=@State,");
			strSql.Append("CreateID=@CreateID,");
			strSql.Append("CreateTime=@CreateTime,");
			strSql.Append("UpdateID=@UpdateID,");
			strSql.Append("UpdateTime=@UpdateTime,");
			strSql.Append("ParentName=@ParentName");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,64),
					new SqlParameter("@RoleNO", SqlDbType.NVarChar,64),
					new SqlParameter("@RoleName", SqlDbType.NVarChar,64),
					new SqlParameter("@ParentID", SqlDbType.NVarChar,64),
					new SqlParameter("@DefaultUrl", SqlDbType.NVarChar,255),
					new SqlParameter("@State", SqlDbType.NVarChar,1),
					new SqlParameter("@CreateID", SqlDbType.NVarChar,64),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@UpdateID", SqlDbType.NVarChar,64),
					new SqlParameter("@UpdateTime", SqlDbType.DateTime),
					new SqlParameter("@ParentName", SqlDbType.NVarChar,64)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.RoleNO;
			parameters[2].Value = model.RoleName;
			parameters[3].Value = model.ParentID;
			parameters[4].Value = model.DefaultUrl;
			parameters[5].Value = model.State;
			parameters[6].Value = model.CreateID;
			parameters[7].Value = model.CreateTime;
			parameters[8].Value = model.UpdateID;
			parameters[9].Value = model.UpdateTime;
			parameters[10].Value = model.ParentName;

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
			strSql.Append("delete from vw_SYS_Role ");
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
		public Demo.Model.vw_SYS_Role GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,RoleNO,RoleName,ParentID,DefaultUrl,State,CreateID,CreateTime,UpdateID,UpdateTime,ParentName from vw_SYS_Role ");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
			};

			Demo.Model.vw_SYS_Role model=new Demo.Model.vw_SYS_Role();
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
		public Demo.Model.vw_SYS_Role DataRowToModel(DataRow row)
		{
			Demo.Model.vw_SYS_Role model=new Demo.Model.vw_SYS_Role();
			if (row != null)
			{
				if(row["ID"]!=null)
				{
					model.ID=row["ID"].ToString();
				}
				if(row["RoleNO"]!=null)
				{
					model.RoleNO=row["RoleNO"].ToString();
				}
				if(row["RoleName"]!=null)
				{
					model.RoleName=row["RoleName"].ToString();
				}
				if(row["ParentID"]!=null)
				{
					model.ParentID=row["ParentID"].ToString();
				}
				if(row["DefaultUrl"]!=null)
				{
					model.DefaultUrl=row["DefaultUrl"].ToString();
				}
				if(row["State"]!=null)
				{
					model.State=row["State"].ToString();
				}
				if(row["CreateID"]!=null)
				{
					model.CreateID=row["CreateID"].ToString();
				}
				if(row["CreateTime"]!=null && row["CreateTime"].ToString()!="")
				{
					model.CreateTime=DateTime.Parse(row["CreateTime"].ToString());
				}
				if(row["UpdateID"]!=null)
				{
					model.UpdateID=row["UpdateID"].ToString();
				}
				if(row["UpdateTime"]!=null && row["UpdateTime"].ToString()!="")
				{
					model.UpdateTime=DateTime.Parse(row["UpdateTime"].ToString());
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
			strSql.Append("select ID,RoleNO,RoleName,ParentID,DefaultUrl,State,CreateID,CreateTime,UpdateID,UpdateTime,ParentName ");
			strSql.Append(" FROM vw_SYS_Role ");
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
            DataSet ds = pageData.getDataPage("vw_SYS_Role", "*", sqlWhere, order, pageSize, pageIndex, out totalRecord);
            return ds;
        }

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}


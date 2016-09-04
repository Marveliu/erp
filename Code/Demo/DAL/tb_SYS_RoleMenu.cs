/**  版本信息模板在安装目录下，可自行修改。
* tb_SYS_RoleMenu.cs
*
* 功 能： N/A
* 类 名： tb_SYS_RoleMenu
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/2/25 14:00:51   N/A    初版
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
	/// 数据访问类:tb_SYS_RoleMenu
	/// </summary>
	public partial class tb_SYS_RoleMenu
	{
		public tb_SYS_RoleMenu()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tb_SYS_RoleMenu");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,64)			};
			parameters[0].Value = ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Demo.Model.tb_SYS_RoleMenu model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_SYS_RoleMenu(");
			strSql.Append("ID,MenuID,RoleID,AuthorizationDelete,AuthorizationUpdate,AuthorizationInsert,State,CreateID,CreateTime,UpdateID,UpdateTime)");
			strSql.Append(" values (");
			strSql.Append("@ID,@MenuID,@RoleID,@AuthorizationDelete,@AuthorizationUpdate,@AuthorizationInsert,@State,@CreateID,@CreateTime,@UpdateID,@UpdateTime)");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,64),
					new SqlParameter("@MenuID", SqlDbType.NVarChar,64),
					new SqlParameter("@RoleID", SqlDbType.NVarChar,64),
					new SqlParameter("@AuthorizationDelete", SqlDbType.NVarChar,1),
					new SqlParameter("@AuthorizationUpdate", SqlDbType.NVarChar,1),
					new SqlParameter("@AuthorizationInsert", SqlDbType.NVarChar,1),
					new SqlParameter("@State", SqlDbType.NVarChar,1),
					new SqlParameter("@CreateID", SqlDbType.NVarChar,64),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@UpdateID", SqlDbType.NVarChar,64),
					new SqlParameter("@UpdateTime", SqlDbType.DateTime)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.MenuID;
			parameters[2].Value = model.RoleID;
			parameters[3].Value = model.AuthorizationDelete;
			parameters[4].Value = model.AuthorizationUpdate;
			parameters[5].Value = model.AuthorizationInsert;
			parameters[6].Value = model.State;
			parameters[7].Value = model.CreateID;
			parameters[8].Value = model.CreateTime;
			parameters[9].Value = model.UpdateID;
			parameters[10].Value = model.UpdateTime;

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
		public bool Update(Demo.Model.tb_SYS_RoleMenu model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_SYS_RoleMenu set ");
			strSql.Append("MenuID=@MenuID,");
			strSql.Append("RoleID=@RoleID,");
			strSql.Append("AuthorizationDelete=@AuthorizationDelete,");
			strSql.Append("AuthorizationUpdate=@AuthorizationUpdate,");
			strSql.Append("AuthorizationInsert=@AuthorizationInsert,");
			//strSql.Append("State=@State,");
			//strSql.Append("CreateID=@CreateID,");
			//strSql.Append("CreateTime=@CreateTime,");
			strSql.Append("UpdateID=@UpdateID,");
			strSql.Append("UpdateTime=@UpdateTime");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@MenuID", SqlDbType.NVarChar,64),
					new SqlParameter("@RoleID", SqlDbType.NVarChar,64),
					new SqlParameter("@AuthorizationDelete", SqlDbType.NVarChar,1),
					new SqlParameter("@AuthorizationUpdate", SqlDbType.NVarChar,1),
					new SqlParameter("@AuthorizationInsert", SqlDbType.NVarChar,1),
					//new SqlParameter("@State", SqlDbType.NVarChar,1),
					//new SqlParameter("@CreateID", SqlDbType.NVarChar,64),
					//new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@UpdateID", SqlDbType.NVarChar,64),
					new SqlParameter("@UpdateTime", SqlDbType.DateTime),
					new SqlParameter("@ID", SqlDbType.NVarChar,64)};
			parameters[0].Value = model.MenuID;
			parameters[1].Value = model.RoleID;
			parameters[2].Value = model.AuthorizationDelete;
			parameters[3].Value = model.AuthorizationUpdate;
			parameters[4].Value = model.AuthorizationInsert;
			//parameters[5].Value = model.State;
			//parameters[6].Value = model.CreateID;
			//parameters[7].Value = model.CreateTime;
			parameters[5].Value = model.UpdateID;
			parameters[6].Value = model.UpdateTime;
			parameters[7].Value = model.ID;

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
        /// 按条件删除数据
        /// </summary>
        public bool Delete(string strWhere)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_SYS_RoleMenu where ");
            strSql.Append(strWhere);

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
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
			strSql.Append("delete from tb_SYS_RoleMenu ");
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
		public Demo.Model.tb_SYS_RoleMenu GetModel(string ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,MenuID,RoleID,AuthorizationDelete,AuthorizationUpdate,AuthorizationInsert,State,CreateID,CreateTime,UpdateID,UpdateTime from tb_SYS_RoleMenu ");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,64)			};
			parameters[0].Value = ID;

			Demo.Model.tb_SYS_RoleMenu model=new Demo.Model.tb_SYS_RoleMenu();
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
		public Demo.Model.tb_SYS_RoleMenu DataRowToModel(DataRow row)
		{
			Demo.Model.tb_SYS_RoleMenu model=new Demo.Model.tb_SYS_RoleMenu();
			if (row != null)
			{
				if(row["ID"]!=null)
				{
					model.ID=row["ID"].ToString();
				}
				if(row["MenuID"]!=null)
				{
					model.MenuID=row["MenuID"].ToString();
				}
				if(row["RoleID"]!=null)
				{
					model.RoleID=row["RoleID"].ToString();
				}
				if(row["AuthorizationDelete"]!=null)
				{
					model.AuthorizationDelete=row["AuthorizationDelete"].ToString();
				}
				if(row["AuthorizationUpdate"]!=null)
				{
					model.AuthorizationUpdate=row["AuthorizationUpdate"].ToString();
				}
				if(row["AuthorizationInsert"]!=null)
				{
					model.AuthorizationInsert=row["AuthorizationInsert"].ToString();
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
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,MenuID,RoleID,AuthorizationDelete,AuthorizationUpdate,AuthorizationInsert,State,CreateID,CreateTime,UpdateID,UpdateTime ");
			strSql.Append(" FROM tb_SYS_RoleMenu ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得指定的数据集合
		/// </summary>
		public DataSet GetList(string ID,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append(" select t1.ID as MenuID,t1.MenuNO,t1.MenuName,t1.ParentID,t2.ID as RoleMenuID,t2.AuthorizationDelete, ");
            strSql.Append(" t2.AuthorizationInsert,t2.AuthorizationUpdate,AuthorizationSelect=(case when (t1.ID = t2.MenuID) then '1' else '0' end)");
            strSql.Append(" from tb_SYS_Menu t1 left join tb_SYS_RoleMenu t2 on t1.ID = t2.MenuID and t2.RoleID = '");
			if(ID.Trim()!="")
			{
				strSql.Append(ID + "'");
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string sqlWhere, string order, int pageSize, int pageIndex, out long totalRecord)
        {
            Common pageData = new Common();
            DataSet ds = pageData.getDataPage("tb_SYS_RoleMenu", "*", sqlWhere, order, pageSize, pageIndex, out totalRecord);
            return ds;
        }

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}


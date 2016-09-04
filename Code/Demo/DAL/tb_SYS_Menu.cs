/**  版本信息模板在安装目录下，可自行修改。
* tb_SYS_Menu.cs
*
* 功 能： N/A
* 类 名： tb_SYS_Menu
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/1/17 15:38:34   N/A    初版
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
	/// 数据访问类:tb_SYS_Menu
	/// </summary>
	public partial class tb_SYS_Menu
	{
		public tb_SYS_Menu()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tb_SYS_Menu");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,64)			};
			parameters[0].Value = ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Demo.Model.tb_SYS_Menu model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_SYS_Menu(");
			strSql.Append("ID,MenuNO,MenuName,ParentID,MenuUrl,ImageUrl,State,CreateID,CreateTime,UpdateID,UpdateTime)");
			strSql.Append(" values (");
			strSql.Append("@ID,@MenuNO,@MenuName,@ParentID,@MenuUrl,@ImageUrl,@State,@CreateID,@CreateTime,@UpdateID,@UpdateTime)");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,64),
					new SqlParameter("@MenuNO", SqlDbType.NVarChar,64),
					new SqlParameter("@MenuName", SqlDbType.NVarChar,64),
					new SqlParameter("@ParentID", SqlDbType.NVarChar,64),
					new SqlParameter("@MenuUrl", SqlDbType.NVarChar,255),
					new SqlParameter("@ImageUrl", SqlDbType.NVarChar,255),
					new SqlParameter("@State", SqlDbType.NVarChar,1),
					new SqlParameter("@CreateID", SqlDbType.NVarChar,64),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@UpdateID", SqlDbType.NVarChar,64),
					new SqlParameter("@UpdateTime", SqlDbType.DateTime)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.MenuNO;
			parameters[2].Value = model.MenuName;
			parameters[3].Value = model.ParentID;
			parameters[4].Value = model.MenuUrl;
			parameters[5].Value = model.ImageUrl;
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
		public bool Update(Demo.Model.tb_SYS_Menu model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_SYS_Menu set ");
			strSql.Append("MenuNO=@MenuNO,");
			strSql.Append("MenuName=@MenuName,");
			strSql.Append("ParentID=@ParentID,");
			strSql.Append("MenuUrl=@MenuUrl,");
			strSql.Append("ImageUrl=@ImageUrl,");
			strSql.Append("State=@State,");
			//2016年1月30日 YJQ修改
            //strSql.Append("CreateID=@CreateID,");
			//strSql.Append("CreateTime=@CreateTime,");
			strSql.Append("UpdateID=@UpdateID,");
			strSql.Append("UpdateTime=@UpdateTime");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@MenuNO", SqlDbType.NVarChar,64),
					new SqlParameter("@MenuName", SqlDbType.NVarChar,64),
					new SqlParameter("@ParentID", SqlDbType.NVarChar,64),
					new SqlParameter("@MenuUrl", SqlDbType.NVarChar,255),
					new SqlParameter("@ImageUrl", SqlDbType.NVarChar,255),
					new SqlParameter("@State", SqlDbType.NVarChar,1),
					//new SqlParameter("@CreateID", SqlDbType.NVarChar,64),
					//new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@UpdateID", SqlDbType.NVarChar,64),
					new SqlParameter("@UpdateTime", SqlDbType.DateTime),
					new SqlParameter("@ID", SqlDbType.NVarChar,64)};
			parameters[0].Value = model.MenuNO;
			parameters[1].Value = model.MenuName;
			parameters[2].Value = model.ParentID;
			parameters[3].Value = model.MenuUrl;
			parameters[4].Value = model.ImageUrl;
			parameters[5].Value = model.State;
			//parameters[6].Value = model.CreateID;
			//parameters[7].Value = model.CreateTime;
			parameters[6].Value = model.UpdateID;
			parameters[7].Value = model.UpdateTime;
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
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_SYS_Menu ");
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
        /// 删除一条数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="result">执行结果</param>
        /// <returns></returns>
        public string Delete(string id)
        {
            SqlParameter[] parameters = {			 
			 			 new SqlParameter("@id", SqlDbType.NVarChar,64), 
			 			 new SqlParameter("@result", SqlDbType.NVarChar,32) 
			 			 };
            parameters[0].Value = id;
            parameters[1].Direction = ParameterDirection.Output;
            DbHelperSQL.RunProcedure("proc_delete_Menu", parameters).Close();
            return parameters[1].Value.ToString();
        }

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Demo.Model.tb_SYS_Menu GetModel(string ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,MenuNO,MenuName,ParentID,MenuUrl,ImageUrl,State,CreateID,CreateTime,UpdateID,UpdateTime from tb_SYS_Menu ");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,64)			};
			parameters[0].Value = ID;

			Demo.Model.tb_SYS_Menu model=new Demo.Model.tb_SYS_Menu();
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
		public Demo.Model.tb_SYS_Menu DataRowToModel(DataRow row)
		{
			Demo.Model.tb_SYS_Menu model=new Demo.Model.tb_SYS_Menu();
			if (row != null)
			{
				if(row["ID"]!=null)
				{
					model.ID=row["ID"].ToString();
				}
				if(row["MenuNO"]!=null)
				{
					model.MenuNO=row["MenuNO"].ToString();
				}
				if(row["MenuName"]!=null)
				{
					model.MenuName=row["MenuName"].ToString();
				}
				if(row["ParentID"]!=null)
				{
					model.ParentID=row["ParentID"].ToString();
				}
				if(row["MenuUrl"]!=null)
				{
					model.MenuUrl=row["MenuUrl"].ToString();
				}
				if(row["ImageUrl"]!=null)
				{
					model.ImageUrl=row["ImageUrl"].ToString();
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
			strSql.Append("select ID,MenuNO,MenuName,ParentID,MenuUrl,ImageUrl,State,CreateID,CreateTime,UpdateID,UpdateTime ");
			strSql.Append(" FROM tb_SYS_Menu ");
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
            DataSet ds = pageData.getDataPage("tb_SYS_Menu", "*", sqlWhere, order, pageSize, pageIndex, out totalRecord);
            return ds;
        }

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}


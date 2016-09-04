/**  版本信息模板在安装目录下，可自行修改。
* tb_JC_WorkCenterCapacity.cs
*
* 功 能： N/A
* 类 名： tb_JC_WorkCenterCapacity
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/5/14 16:38:34   N/A    初版
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
	/// 数据访问类:tb_JC_WorkCenterCapacity
	/// </summary>
	public partial class tb_JC_WorkCenterCapacity
	{
		public tb_JC_WorkCenterCapacity()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tb_JC_WorkCenterCapacity");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,64)			};
			parameters[0].Value = ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Demo.Model.tb_JC_WorkCenterCapacity model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_JC_WorkCenterCapacity(");
			strSql.Append("ID,WorkCenterNO,MaterialNO,CapacityType,UnitCapacity,CapacityUnit)");
			strSql.Append(" values (");
			strSql.Append("@ID,@WorkCenterNO,@MaterialNO,@CapacityType,@UnitCapacity,@CapacityUnit)");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,64),
					new SqlParameter("@WorkCenterNO", SqlDbType.NVarChar,64),
					new SqlParameter("@MaterialNO", SqlDbType.NVarChar,64),
					new SqlParameter("@CapacityType", SqlDbType.NVarChar,1),
					new SqlParameter("@UnitCapacity", SqlDbType.Decimal,9),
					new SqlParameter("@CapacityUnit", SqlDbType.NVarChar,64)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.WorkCenterNO;
			parameters[2].Value = model.MaterialNO;
			parameters[3].Value = model.CapacityType;
			parameters[4].Value = model.UnitCapacity;
			parameters[5].Value = model.CapacityUnit;

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
		public bool Update(Demo.Model.tb_JC_WorkCenterCapacity model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_JC_WorkCenterCapacity set ");
			strSql.Append("WorkCenterNO=@WorkCenterNO,");
			strSql.Append("MaterialNO=@MaterialNO,");
			strSql.Append("CapacityType=@CapacityType,");
			strSql.Append("UnitCapacity=@UnitCapacity,");
			strSql.Append("CapacityUnit=@CapacityUnit");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@WorkCenterNO", SqlDbType.NVarChar,64),
					new SqlParameter("@MaterialNO", SqlDbType.NVarChar,64),
					new SqlParameter("@CapacityType", SqlDbType.NVarChar,1),
					new SqlParameter("@UnitCapacity", SqlDbType.Decimal,9),
					new SqlParameter("@CapacityUnit", SqlDbType.NVarChar,64),
					new SqlParameter("@ID", SqlDbType.NVarChar,64)};
			parameters[0].Value = model.WorkCenterNO;
			parameters[1].Value = model.MaterialNO;
			parameters[2].Value = model.CapacityType;
			parameters[3].Value = model.UnitCapacity;
			parameters[4].Value = model.CapacityUnit;
			parameters[5].Value = model.ID;

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
			strSql.Append("delete from tb_JC_WorkCenterCapacity ");
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
			strSql.Append("delete from tb_JC_WorkCenterCapacity ");
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
		public Demo.Model.tb_JC_WorkCenterCapacity GetModel(string ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,WorkCenterNO,MaterialNO,CapacityType,UnitCapacity,CapacityUnit from tb_JC_WorkCenterCapacity ");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,64)			};
			parameters[0].Value = ID;

			Demo.Model.tb_JC_WorkCenterCapacity model=new Demo.Model.tb_JC_WorkCenterCapacity();
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
		public Demo.Model.tb_JC_WorkCenterCapacity DataRowToModel(DataRow row)
		{
			Demo.Model.tb_JC_WorkCenterCapacity model=new Demo.Model.tb_JC_WorkCenterCapacity();
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
				if(row["MaterialNO"]!=null)
				{
					model.MaterialNO=row["MaterialNO"].ToString();
				}
				if(row["CapacityType"]!=null)
				{
					model.CapacityType=row["CapacityType"].ToString();
				}
				if(row["UnitCapacity"]!=null && row["UnitCapacity"].ToString()!="")
				{
					model.UnitCapacity=decimal.Parse(row["UnitCapacity"].ToString());
				}
				if(row["CapacityUnit"]!=null)
				{
					model.CapacityUnit=row["CapacityUnit"].ToString();
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
			strSql.Append("select ID,WorkCenterNO,MaterialNO,CapacityType,UnitCapacity,CapacityUnit ");
			strSql.Append(" FROM tb_JC_WorkCenterCapacity ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" ID,WorkCenterNO,MaterialNO,CapacityType,UnitCapacity,CapacityUnit ");
			strSql.Append(" FROM tb_JC_WorkCenterCapacity ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM tb_JC_WorkCenterCapacity ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
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
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.ID desc");
			}
			strSql.Append(")AS Row, T.*  from tb_JC_WorkCenterCapacity T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "tb_JC_WorkCenterCapacity";
			parameters[1].Value = "ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}


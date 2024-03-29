﻿/**  版本信息模板在安装目录下，可自行修改。
* tb_JC_Material_P.cs
*
* 功 能： N/A
* 类 名： tb_JC_Material_P
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/5/23 12:10:30   N/A    初版
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
	/// 数据访问类:tb_JC_Material_P
	/// </summary>
	public partial class tb_JC_Material_P
	{
		public tb_JC_Material_P()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tb_JC_Material_P");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,64)			};
			parameters[0].Value = ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Demo.Model.tb_JC_Material_P model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_JC_Material_P(");
			strSql.Append("ID,MaterialNO,ProcessRouteNO,ProductionVolume,IncreaseAmount,UnitStandardTime)");
			strSql.Append(" values (");
			strSql.Append("@ID,@MaterialNO,@ProcessRouteNO,@ProductionVolume,@IncreaseAmount,@UnitStandardTime)");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,64),
					new SqlParameter("@MaterialNO", SqlDbType.NVarChar,64),
					new SqlParameter("@ProcessRouteNO", SqlDbType.NVarChar,64),
					new SqlParameter("@ProductionVolume", SqlDbType.Decimal,9),
					new SqlParameter("@IncreaseAmount", SqlDbType.Decimal,9),
					new SqlParameter("@UnitStandardTime", SqlDbType.Decimal,9)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.MaterialNO;
			parameters[2].Value = model.ProcessRouteNO;
			parameters[3].Value = model.ProductionVolume;
			parameters[4].Value = model.IncreaseAmount;
			parameters[5].Value = model.UnitStandardTime;

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
		public bool Update(Demo.Model.tb_JC_Material_P model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_JC_Material_P set ");
			strSql.Append("MaterialNO=@MaterialNO,");
			strSql.Append("ProcessRouteNO=@ProcessRouteNO,");
			strSql.Append("ProductionVolume=@ProductionVolume,");
			strSql.Append("IncreaseAmount=@IncreaseAmount,");
			strSql.Append("UnitStandardTime=@UnitStandardTime");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@MaterialNO", SqlDbType.NVarChar,64),
					new SqlParameter("@ProcessRouteNO", SqlDbType.NVarChar,64),
					new SqlParameter("@ProductionVolume", SqlDbType.Decimal,9),
					new SqlParameter("@IncreaseAmount", SqlDbType.Decimal,9),
					new SqlParameter("@UnitStandardTime", SqlDbType.Decimal,9),
					new SqlParameter("@ID", SqlDbType.NVarChar,64)};
			parameters[0].Value = model.MaterialNO;
			parameters[1].Value = model.ProcessRouteNO;
			parameters[2].Value = model.ProductionVolume;
			parameters[3].Value = model.IncreaseAmount;
			parameters[4].Value = model.UnitStandardTime;
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
			strSql.Append("delete from tb_JC_Material_P ");
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
			strSql.Append("delete from tb_JC_Material_P ");
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
		public Demo.Model.tb_JC_Material_P GetModel(string ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,MaterialNO,ProcessRouteNO,ProductionVolume,IncreaseAmount,UnitStandardTime from tb_JC_Material_P ");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,64)			};
			parameters[0].Value = ID;

			Demo.Model.tb_JC_Material_P model=new Demo.Model.tb_JC_Material_P();
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
		public Demo.Model.tb_JC_Material_P DataRowToModel(DataRow row)
		{
			Demo.Model.tb_JC_Material_P model=new Demo.Model.tb_JC_Material_P();
			if (row != null)
			{
				if(row["ID"]!=null)
				{
					model.ID=row["ID"].ToString();
				}
				if(row["MaterialNO"]!=null)
				{
					model.MaterialNO=row["MaterialNO"].ToString();
				}
				if(row["ProcessRouteNO"]!=null)
				{
					model.ProcessRouteNO=row["ProcessRouteNO"].ToString();
				}
				if(row["ProductionVolume"]!=null && row["ProductionVolume"].ToString()!="")
				{
					model.ProductionVolume=decimal.Parse(row["ProductionVolume"].ToString());
				}
				if(row["IncreaseAmount"]!=null && row["IncreaseAmount"].ToString()!="")
				{
					model.IncreaseAmount=decimal.Parse(row["IncreaseAmount"].ToString());
				}
				if(row["UnitStandardTime"]!=null && row["UnitStandardTime"].ToString()!="")
				{
					model.UnitStandardTime=decimal.Parse(row["UnitStandardTime"].ToString());
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
			strSql.Append("select ID,MaterialNO,ProcessRouteNO,ProductionVolume,IncreaseAmount,UnitStandardTime ");
			strSql.Append(" FROM tb_JC_Material_P ");
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
            DataSet ds = pageData.getDataPage("tb_JC_Material_P", "*", sqlWhere, order, pageSize, pageIndex, out totalRecord);
            return ds;
		}

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}


/**  版本信息模板在安装目录下，可自行修改。
* vw_JC_Material.cs
*
* 功 能： N/A
* 类 名： vw_JC_Material
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/5/23 11:07:15   N/A    初版
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
	/// 数据访问类:vw_JC_Material
	/// </summary>
	public partial class vw_JC_Material
	{
		public vw_JC_Material()
		{}
		#region  BasicMethod



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Demo.Model.vw_JC_Material model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into vw_JC_Material(");
			strSql.Append("ID,MaterialNO,MaterialName,Specification,Model,Unit,Property,UnitStandardCost,UnitStandardTime,FixedLeadTime,VariableLeadTime,VariableBatch,Status,ProcessRouteNO,ProductionVolume,IncreaseAmount)");
			strSql.Append(" values (");
			strSql.Append("@ID,@MaterialNO,@MaterialName,@Specification,@Model,@Unit,@Property,@UnitStandardCost,@UnitStandardTime,@FixedLeadTime,@VariableLeadTime,@VariableBatch,@Status,@ProcessRouteNO,@ProductionVolume,@IncreaseAmount)");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,64),
					new SqlParameter("@MaterialNO", SqlDbType.NVarChar,64),
					new SqlParameter("@MaterialName", SqlDbType.NVarChar,64),
					new SqlParameter("@Specification", SqlDbType.NVarChar,64),
					new SqlParameter("@Model", SqlDbType.NVarChar,64),
					new SqlParameter("@Unit", SqlDbType.NVarChar,64),
					new SqlParameter("@Property", SqlDbType.NVarChar,1),
					new SqlParameter("@UnitStandardCost", SqlDbType.Decimal,9),
					new SqlParameter("@UnitStandardTime", SqlDbType.Decimal,9),
					new SqlParameter("@FixedLeadTime", SqlDbType.Int,4),
					new SqlParameter("@VariableLeadTime", SqlDbType.Int,4),
					new SqlParameter("@VariableBatch", SqlDbType.Decimal,9),
					new SqlParameter("@Status", SqlDbType.NVarChar,1),
					new SqlParameter("@ProcessRouteNO", SqlDbType.NVarChar,64),
					new SqlParameter("@ProductionVolume", SqlDbType.Decimal,9),
					new SqlParameter("@IncreaseAmount", SqlDbType.Decimal,9)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.MaterialNO;
			parameters[2].Value = model.MaterialName;
			parameters[3].Value = model.Specification;
			parameters[4].Value = model.Model;
			parameters[5].Value = model.Unit;
			parameters[6].Value = model.Property;
			parameters[7].Value = model.UnitStandardCost;
			parameters[8].Value = model.UnitStandardTime;
			parameters[9].Value = model.FixedLeadTime;
			parameters[10].Value = model.VariableLeadTime;
			parameters[11].Value = model.VariableBatch;
			parameters[12].Value = model.Status;
			parameters[13].Value = model.ProcessRouteNO;
			parameters[14].Value = model.ProductionVolume;
			parameters[15].Value = model.IncreaseAmount;

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
		public bool Update(Demo.Model.vw_JC_Material model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update vw_JC_Material set ");
			strSql.Append("ID=@ID,");
			strSql.Append("MaterialNO=@MaterialNO,");
			strSql.Append("MaterialName=@MaterialName,");
			strSql.Append("Specification=@Specification,");
			strSql.Append("Model=@Model,");
			strSql.Append("Unit=@Unit,");
			strSql.Append("Property=@Property,");
			strSql.Append("UnitStandardCost=@UnitStandardCost,");
			strSql.Append("UnitStandardTime=@UnitStandardTime,");
			strSql.Append("FixedLeadTime=@FixedLeadTime,");
			strSql.Append("VariableLeadTime=@VariableLeadTime,");
			strSql.Append("VariableBatch=@VariableBatch,");
			strSql.Append("Status=@Status,");
			strSql.Append("ProcessRouteNO=@ProcessRouteNO,");
			strSql.Append("ProductionVolume=@ProductionVolume,");
			strSql.Append("IncreaseAmount=@IncreaseAmount");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,64),
					new SqlParameter("@MaterialNO", SqlDbType.NVarChar,64),
					new SqlParameter("@MaterialName", SqlDbType.NVarChar,64),
					new SqlParameter("@Specification", SqlDbType.NVarChar,64),
					new SqlParameter("@Model", SqlDbType.NVarChar,64),
					new SqlParameter("@Unit", SqlDbType.NVarChar,64),
					new SqlParameter("@Property", SqlDbType.NVarChar,1),
					new SqlParameter("@UnitStandardCost", SqlDbType.Decimal,9),
					new SqlParameter("@UnitStandardTime", SqlDbType.Decimal,9),
					new SqlParameter("@FixedLeadTime", SqlDbType.Int,4),
					new SqlParameter("@VariableLeadTime", SqlDbType.Int,4),
					new SqlParameter("@VariableBatch", SqlDbType.Decimal,9),
					new SqlParameter("@Status", SqlDbType.NVarChar,1),
					new SqlParameter("@ProcessRouteNO", SqlDbType.NVarChar,64),
					new SqlParameter("@ProductionVolume", SqlDbType.Decimal,9),
					new SqlParameter("@IncreaseAmount", SqlDbType.Decimal,9)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.MaterialNO;
			parameters[2].Value = model.MaterialName;
			parameters[3].Value = model.Specification;
			parameters[4].Value = model.Model;
			parameters[5].Value = model.Unit;
			parameters[6].Value = model.Property;
			parameters[7].Value = model.UnitStandardCost;
			parameters[8].Value = model.UnitStandardTime;
			parameters[9].Value = model.FixedLeadTime;
			parameters[10].Value = model.VariableLeadTime;
			parameters[11].Value = model.VariableBatch;
			parameters[12].Value = model.Status;
			parameters[13].Value = model.ProcessRouteNO;
			parameters[14].Value = model.ProductionVolume;
			parameters[15].Value = model.IncreaseAmount;

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
			strSql.Append("delete from vw_JC_Material ");
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
		public Demo.Model.vw_JC_Material GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,MaterialNO,MaterialName,Specification,Model,Unit,Property,UnitStandardCost,UnitStandardTime,FixedLeadTime,VariableLeadTime,VariableBatch,Status,ProcessRouteNO,ProductionVolume,IncreaseAmount from vw_JC_Material ");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
			};

			Demo.Model.vw_JC_Material model=new Demo.Model.vw_JC_Material();
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
		public Demo.Model.vw_JC_Material DataRowToModel(DataRow row)
		{
			Demo.Model.vw_JC_Material model=new Demo.Model.vw_JC_Material();
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
				if(row["MaterialName"]!=null)
				{
					model.MaterialName=row["MaterialName"].ToString();
				}
				if(row["Specification"]!=null)
				{
					model.Specification=row["Specification"].ToString();
				}
				if(row["Model"]!=null)
				{
					model.Model=row["Model"].ToString();
				}
				if(row["Unit"]!=null)
				{
					model.Unit=row["Unit"].ToString();
				}
				if(row["Property"]!=null)
				{
					model.Property=row["Property"].ToString();
				}
				if(row["UnitStandardCost"]!=null && row["UnitStandardCost"].ToString()!="")
				{
					model.UnitStandardCost=decimal.Parse(row["UnitStandardCost"].ToString());
				}
				if(row["UnitStandardTime"]!=null && row["UnitStandardTime"].ToString()!="")
				{
					model.UnitStandardTime=decimal.Parse(row["UnitStandardTime"].ToString());
				}
				if(row["FixedLeadTime"]!=null && row["FixedLeadTime"].ToString()!="")
				{
					model.FixedLeadTime=int.Parse(row["FixedLeadTime"].ToString());
				}
				if(row["VariableLeadTime"]!=null && row["VariableLeadTime"].ToString()!="")
				{
					model.VariableLeadTime=int.Parse(row["VariableLeadTime"].ToString());
				}
				if(row["VariableBatch"]!=null && row["VariableBatch"].ToString()!="")
				{
					model.VariableBatch=decimal.Parse(row["VariableBatch"].ToString());
				}
				if(row["Status"]!=null)
				{
					model.Status=row["Status"].ToString();
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
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,MaterialNO,MaterialName,Specification,Model,Unit,Property,UnitStandardCost,UnitStandardTime,FixedLeadTime,VariableLeadTime,VariableBatch,Status,ProcessRouteNO,ProductionVolume,IncreaseAmount ");
			strSql.Append(" FROM vw_JC_Material ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataSet GetListByPage(string strWhere, string order, int pageSize, int pageIndex, out long record)
        {
            Common common = new Common();
            DataSet ds = common.getDataPage("vw_JC_Material", "*", strWhere, order, pageSize, pageIndex, out record);
            return ds;
        }

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}


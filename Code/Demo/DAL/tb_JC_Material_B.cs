/**  版本信息模板在安装目录下，可自行修改。
* tb_JC_Material_B.cs
*
* 功 能： N/A
* 类 名： tb_JC_Material_B
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/5/23 12:10:29   N/A    初版
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
	/// 数据访问类:tb_JC_Material_B
	/// </summary>
	public partial class tb_JC_Material_B
	{
		public tb_JC_Material_B()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tb_JC_Material_B");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,64)			};
			parameters[0].Value = ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Demo.Model.tb_JC_Material_B model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_JC_Material_B(");
			strSql.Append("ID,MaterialNO,MaterialName,Specification,Model,Unit,Property,UnitStandardCost,FixedLeadTime,VariableLeadTime,VariableBatch,Status)");
			strSql.Append(" values (");
			strSql.Append("@ID,@MaterialNO,@MaterialName,@Specification,@Model,@Unit,@Property,@UnitStandardCost,@FixedLeadTime,@VariableLeadTime,@VariableBatch,@Status)");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,64),
					new SqlParameter("@MaterialNO", SqlDbType.NVarChar,64),
					new SqlParameter("@MaterialName", SqlDbType.NVarChar,64),
					new SqlParameter("@Specification", SqlDbType.NVarChar,64),
					new SqlParameter("@Model", SqlDbType.NVarChar,64),
					new SqlParameter("@Unit", SqlDbType.NVarChar,64),
					new SqlParameter("@Property", SqlDbType.NVarChar,1),
					new SqlParameter("@UnitStandardCost", SqlDbType.Decimal,9),
					new SqlParameter("@FixedLeadTime", SqlDbType.Int,4),
					new SqlParameter("@VariableLeadTime", SqlDbType.Int,4),
					new SqlParameter("@VariableBatch", SqlDbType.Decimal,9),
					new SqlParameter("@Status", SqlDbType.NVarChar,1)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.MaterialNO;
			parameters[2].Value = model.MaterialName;
			parameters[3].Value = model.Specification;
			parameters[4].Value = model.Model;
			parameters[5].Value = model.Unit;
			parameters[6].Value = model.Property;
			parameters[7].Value = model.UnitStandardCost;
			parameters[8].Value = model.FixedLeadTime;
			parameters[9].Value = model.VariableLeadTime;
			parameters[10].Value = model.VariableBatch;
			parameters[11].Value = model.Status;

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
		public bool Update(Demo.Model.tb_JC_Material_B model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_JC_Material_B set ");
			strSql.Append("MaterialNO=@MaterialNO,");
			strSql.Append("MaterialName=@MaterialName,");
			strSql.Append("Specification=@Specification,");
			strSql.Append("Model=@Model,");
			strSql.Append("Unit=@Unit,");
			strSql.Append("Property=@Property,");
			strSql.Append("UnitStandardCost=@UnitStandardCost,");
			strSql.Append("FixedLeadTime=@FixedLeadTime,");
			strSql.Append("VariableLeadTime=@VariableLeadTime,");
			strSql.Append("VariableBatch=@VariableBatch,");
			strSql.Append("Status=@Status");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@MaterialNO", SqlDbType.NVarChar,64),
					new SqlParameter("@MaterialName", SqlDbType.NVarChar,64),
					new SqlParameter("@Specification", SqlDbType.NVarChar,64),
					new SqlParameter("@Model", SqlDbType.NVarChar,64),
					new SqlParameter("@Unit", SqlDbType.NVarChar,64),
					new SqlParameter("@Property", SqlDbType.NVarChar,1),
					new SqlParameter("@UnitStandardCost", SqlDbType.Decimal,9),
					new SqlParameter("@FixedLeadTime", SqlDbType.Int,4),
					new SqlParameter("@VariableLeadTime", SqlDbType.Int,4),
					new SqlParameter("@VariableBatch", SqlDbType.Decimal,9),
					new SqlParameter("@Status", SqlDbType.NVarChar,1),
					new SqlParameter("@ID", SqlDbType.NVarChar,64)};
			parameters[0].Value = model.MaterialNO;
			parameters[1].Value = model.MaterialName;
			parameters[2].Value = model.Specification;
			parameters[3].Value = model.Model;
			parameters[4].Value = model.Unit;
			parameters[5].Value = model.Property;
			parameters[6].Value = model.UnitStandardCost;
			parameters[7].Value = model.FixedLeadTime;
			parameters[8].Value = model.VariableLeadTime;
			parameters[9].Value = model.VariableBatch;
			parameters[10].Value = model.Status;
			parameters[11].Value = model.ID;

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
			strSql.Append("delete from tb_JC_Material_B ");
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
			strSql.Append("delete from tb_JC_Material_B ");
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
		public Demo.Model.tb_JC_Material_B GetModel(string ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,MaterialNO,MaterialName,Specification,Model,Unit,Property,UnitStandardCost,FixedLeadTime,VariableLeadTime,VariableBatch,Status from tb_JC_Material_B ");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,64)			};
			parameters[0].Value = ID;

			Demo.Model.tb_JC_Material_B model=new Demo.Model.tb_JC_Material_B();
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
		public Demo.Model.tb_JC_Material_B DataRowToModel(DataRow row)
		{
			Demo.Model.tb_JC_Material_B model=new Demo.Model.tb_JC_Material_B();
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
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,MaterialNO,MaterialName,Specification,Model,Unit,Property,UnitStandardCost,FixedLeadTime,VariableLeadTime,VariableBatch,Status ");
			strSql.Append(" FROM tb_JC_Material_B ");
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
            DataSet ds = pageData.getDataPage("tb_JC_Material_B", "*", sqlWhere, order, pageSize, pageIndex, out totalRecord);
            return ds;
		}

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}


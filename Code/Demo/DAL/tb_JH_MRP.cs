/**  版本信息模板在安装目录下，可自行修改。
* tb_JH_MRP.cs
*
* 功 能： N/A
* 类 名： tb_JH_MRP
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/5/14 16:38:35   N/A    初版
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
	/// 数据访问类:tb_JH_MRP
	/// </summary>
	public partial class tb_JH_MRP
	{
		public tb_JH_MRP()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tb_JH_MRP");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,64)			};
			parameters[0].Value = ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Demo.Model.tb_JH_MRP model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_JH_MRP(");
			strSql.Append("ID,PlanNO,MPSID,MaterialNO,NeedAmount,NeedDate,Status)");
			strSql.Append(" values (");
			strSql.Append("@ID,@PlanNO,@MPSID,@MaterialNO,@NeedAmount,@NeedDate,@Status)");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,64),
					new SqlParameter("@PlanNO", SqlDbType.NVarChar,64),
					new SqlParameter("@MPSID", SqlDbType.NVarChar,64),
					new SqlParameter("@MaterialNO", SqlDbType.NVarChar,64),
					new SqlParameter("@NeedAmount", SqlDbType.Decimal,9),
					new SqlParameter("@NeedDate", SqlDbType.DateTime),
					new SqlParameter("@Status", SqlDbType.NVarChar,1)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.PlanNO;
			parameters[2].Value = model.MPSID;
			parameters[3].Value = model.MaterialNO;
			parameters[4].Value = model.NeedAmount;
			parameters[5].Value = model.NeedDate;
			parameters[6].Value = model.Status;

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
		public bool Update(Demo.Model.tb_JH_MRP model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_JH_MRP set ");
			strSql.Append("PlanNO=@PlanNO,");
			strSql.Append("MPSID=@MPSID,");
			strSql.Append("MaterialNO=@MaterialNO,");
			strSql.Append("NeedAmount=@NeedAmount,");
			strSql.Append("NeedDate=@NeedDate,");
			strSql.Append("Status=@Status");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@PlanNO", SqlDbType.NVarChar,64),
					new SqlParameter("@MPSID", SqlDbType.NVarChar,64),
					new SqlParameter("@MaterialNO", SqlDbType.NVarChar,64),
					new SqlParameter("@NeedAmount", SqlDbType.Decimal,9),
					new SqlParameter("@NeedDate", SqlDbType.DateTime),
					new SqlParameter("@Status", SqlDbType.NVarChar,1),
					new SqlParameter("@ID", SqlDbType.NVarChar,64)};
			parameters[0].Value = model.PlanNO;
			parameters[1].Value = model.MPSID;
			parameters[2].Value = model.MaterialNO;
			parameters[3].Value = model.NeedAmount;
			parameters[4].Value = model.NeedDate;
			parameters[5].Value = model.Status;
			parameters[6].Value = model.ID;

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
			strSql.Append("delete from tb_JH_MRP ");
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
			strSql.Append("delete from tb_JH_MRP ");
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
		public Demo.Model.tb_JH_MRP GetModel(string ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,PlanNO,MPSID,MaterialNO,NeedAmount,NeedDate,Status from tb_JH_MRP ");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,64)			};
			parameters[0].Value = ID;

			Demo.Model.tb_JH_MRP model=new Demo.Model.tb_JH_MRP();
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
		public Demo.Model.tb_JH_MRP DataRowToModel(DataRow row)
		{
			Demo.Model.tb_JH_MRP model=new Demo.Model.tb_JH_MRP();
			if (row != null)
			{
				if(row["ID"]!=null)
				{
					model.ID=row["ID"].ToString();
				}
				if(row["PlanNO"]!=null)
				{
					model.PlanNO=row["PlanNO"].ToString();
				}
				if(row["MPSID"]!=null)
				{
					model.MPSID=row["MPSID"].ToString();
				}
				if(row["MaterialNO"]!=null)
				{
					model.MaterialNO=row["MaterialNO"].ToString();
				}
				if(row["NeedAmount"]!=null && row["NeedAmount"].ToString()!="")
				{
					model.NeedAmount=decimal.Parse(row["NeedAmount"].ToString());
				}
				if(row["NeedDate"]!=null && row["NeedDate"].ToString()!="")
				{
					model.NeedDate=DateTime.Parse(row["NeedDate"].ToString());
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,PlanNO,MPSID,MaterialNO,NeedAmount,NeedDate,Status ");
            strSql.Append(" FROM tb_JH_MRP ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
        public DataSet GetListByPage(string strWhere, string order, int pageSize, int pageIndex, out long record)
        {
            Common common = new Common();
            DataSet ds = common.getDataPage("tb_JC_MRP", "*", strWhere, order, pageSize, pageIndex, out record);
            return ds;
        }

		#endregion  BasicMethod
		#region  ExtensionMethod

        /// <summary>
        /// MRP分解
        /// </summary>
        /// <param name="ID">MPS的ID</param>
        /// <returns></returns>
        public int ResolveMRP(string ID)
        {
            SqlParameter[] parameters = {			 
			 			 new SqlParameter("@ID", SqlDbType.NVarChar,64), 
			 			 new SqlParameter("@result", SqlDbType.Int) 
			 			 };
            parameters[0].Value = ID;
            parameters[1].Direction = ParameterDirection.Output;
            DbHelperSQL.RunProcedure("proc_resolve_MRP", parameters).Close();
            return (int)parameters[1].Value;
        }
		#endregion  ExtensionMethod
	}
}


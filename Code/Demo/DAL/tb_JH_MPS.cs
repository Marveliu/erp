/**  版本信息模板在安装目录下，可自行修改。
* tb_JH_MPS.cs
*
* 功 能： N/A
* 类 名： tb_JH_MPS
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
	/// 数据访问类:tb_JH_MPS
	/// </summary>
	public partial class tb_JH_MPS
	{
		public tb_JH_MPS()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tb_JH_MPS");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,64)			};
			parameters[0].Value = ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Demo.Model.tb_JH_MPS model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_JH_MPS(");
			strSql.Append("ID,PlanNO,PlannedSourceID,MaterialNO,PlanAmount,ResolveAmount,EndDate,Status)");
			strSql.Append(" values (");
			strSql.Append("@ID,@PlanNO,@PlannedSourceID,@MaterialNO,@PlanAmount,@ResolveAmount,@EndDate,@Status)");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,64),
					new SqlParameter("@PlanNO", SqlDbType.NVarChar,64),
					new SqlParameter("@PlannedSourceID", SqlDbType.NVarChar,64),
					new SqlParameter("@MaterialNO", SqlDbType.NVarChar,64),
					new SqlParameter("@PlanAmount", SqlDbType.Decimal,9),
					new SqlParameter("@ResolveAmount", SqlDbType.Decimal,9),
					new SqlParameter("@EndDate", SqlDbType.DateTime),
					new SqlParameter("@Status", SqlDbType.NVarChar,1)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.PlanNO;
			parameters[2].Value = model.PlannedSourceID;
			parameters[3].Value = model.MaterialNO;
			parameters[4].Value = model.PlanAmount;
			parameters[5].Value = model.ResolveAmount;
			parameters[6].Value = model.EndDate;
			parameters[7].Value = model.Status;

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
		public bool Update(Demo.Model.tb_JH_MPS model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_JH_MPS set ");
			strSql.Append("PlanNO=@PlanNO,");
			strSql.Append("PlannedSourceID=@PlannedSourceID,");
			strSql.Append("MaterialNO=@MaterialNO,");
			strSql.Append("PlanAmount=@PlanAmount,");
			strSql.Append("ResolveAmount=@ResolveAmount,");
			strSql.Append("EndDate=@EndDate,");
			strSql.Append("Status=@Status");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@PlanNO", SqlDbType.NVarChar,64),
					new SqlParameter("@PlannedSourceID", SqlDbType.NVarChar,64),
					new SqlParameter("@MaterialNO", SqlDbType.NVarChar,64),
					new SqlParameter("@PlanAmount", SqlDbType.Decimal,9),
					new SqlParameter("@ResolveAmount", SqlDbType.Decimal,9),
					new SqlParameter("@EndDate", SqlDbType.DateTime),
					new SqlParameter("@Status", SqlDbType.NVarChar,1),
					new SqlParameter("@ID", SqlDbType.NVarChar,64)};
			parameters[0].Value = model.PlanNO;
			parameters[1].Value = model.PlannedSourceID;
			parameters[2].Value = model.MaterialNO;
			parameters[3].Value = model.PlanAmount;
			parameters[4].Value = model.ResolveAmount;
			parameters[5].Value = model.EndDate;
			parameters[6].Value = model.Status;
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
		/// 删除一条数据
		/// </summary>
		public bool Delete(string ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_JH_MPS ");
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
			strSql.Append("delete from tb_JH_MPS ");
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
		public Demo.Model.tb_JH_MPS GetModel(string ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,PlanNO,PlannedSourceID,MaterialNO,PlanAmount,ResolveAmount,EndDate,Status from tb_JH_MPS ");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,64)			};
			parameters[0].Value = ID;

			Demo.Model.tb_JH_MPS model=new Demo.Model.tb_JH_MPS();
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
        public Demo.Model.tb_JH_MPS DataRowToModel(DataRow row)
        {
            Demo.Model.tb_JH_MPS model = new Demo.Model.tb_JH_MPS();
            if (row != null)
            {
                if (row["ID"] != null)
                {
                    model.ID = row["ID"].ToString();
                }
                if (row["PlanNO"] != null)
                {
                    model.PlanNO = row["PlanNO"].ToString();
                }
                if (row["PlannedSourceID"] != null)
                {
                    model.PlannedSourceID = row["PlannedSourceID"].ToString();
                }
                if (row["MaterialNO"] != null)
                {
                    model.MaterialNO = row["MaterialNO"].ToString();
                }
                if (row["PlanAmount"] != null && row["PlanAmount"].ToString() != "")
                {
                    model.PlanAmount = decimal.Parse(row["PlanAmount"].ToString());
                }
                if (row["ResolveAmount"] != null && row["ResolveAmount"].ToString() != "")
                {
                    model.ResolveAmount = decimal.Parse(row["ResolveAmount"].ToString());
                }
                if (row["EndDate"] != null && row["EndDate"].ToString() != "")
                {
                    model.EndDate = DateTime.Parse(row["EndDate"].ToString());
                }
                if (row["Status"] != null)
                {
                    model.Status = row["Status"].ToString();
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
            strSql.Append("select ID,PlanNO,PlannedSourceID,MaterialNO,PlanAmount,ResolveAmount,EndDate,Status ");
            strSql.Append(" FROM tb_JH_MPS ");
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
            DataSet ds = common.getDataPage("tb_JC_MPS", "*", strWhere, order, pageSize, pageIndex,out record);
            return ds;
		}

		#endregion  BasicMethod
		#region  ExtensionMethod
        public int DownMPS(string ID)
        {
            SqlParameter[] parameters = {			 
			 			 new SqlParameter("@ID", SqlDbType.NVarChar,64), 
			 			 new SqlParameter("@result", SqlDbType.Int) 
			 			 };
            parameters[0].Value = ID;
            parameters[1].Direction = ParameterDirection.Output;
            DbHelperSQL.RunProcedure("proc_down_MPS", parameters).Close();
            return (int)parameters[1].Value;
        }

        public bool DeleteMPS(string ID, string materialNO)
        {
            int rowsAffected;
            SqlParameter[] parameters = {			 
			 			 new SqlParameter("@ID", SqlDbType.NVarChar,64), 
			 			 new SqlParameter("@materialNO", SqlDbType.NVarChar,64) 
			 			 };
            parameters[0].Value = ID;
            parameters[1].Value = materialNO;
            DbHelperSQL.RunProcedure("proc_delete_MPS", parameters, out rowsAffected);
            if (rowsAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int InsertMPS(string ID, string planNO, string plannedSourceID, string materialNO, decimal? planAmount, DateTime? date)
        {
            SqlParameter[] parameters = {			 
			 			 new SqlParameter("@ID", SqlDbType.NVarChar,64), 
			 			 new SqlParameter("@planNO", SqlDbType.NVarChar,64), 
			 			 new SqlParameter("@plannedSourceID", SqlDbType.NVarChar,64), 
			 			 new SqlParameter("@materialNO", SqlDbType.NVarChar,64), 
			 			 new SqlParameter("@planAmount", SqlDbType.Decimal), 
			 			 new SqlParameter("@date", SqlDbType.DateTime), 
			 			 new SqlParameter("@result", SqlDbType.Int) 
			 			 };
            parameters[0].Value = ID;
            parameters[1].Value = planNO;
            parameters[2].Value = plannedSourceID;
            parameters[3].Value = materialNO;
            parameters[4].Value = planAmount;
            parameters[5].Value = date;
            parameters[6].Direction = ParameterDirection.Output;
            DbHelperSQL.RunProcedure("proc_insert_MPS", parameters).Close();
            return (int)parameters[6].Value;
        }

        public bool UpdateMPS(string ID, string planNO)
        {
            int rowsAffected;
            SqlParameter[] parameters = {			 
			 			 new SqlParameter("@ID", SqlDbType.NVarChar,64), 
			 			 new SqlParameter("@planNO", SqlDbType.NVarChar,64) 
			 			 };
            parameters[0].Value = ID;
            parameters[1].Value = planNO;
            DbHelperSQL.RunProcedure("proc_update_MPS", parameters, out rowsAffected);
            if (rowsAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

		#endregion  ExtensionMethod
	}
}


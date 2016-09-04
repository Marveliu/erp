/**  版本信息模板在安装目录下，可自行修改。
* vw_JC_Employee.cs
*
* 功 能： N/A
* 类 名： vw_JC_Employee
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/5/23 14:29:53   N/A    初版
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
	/// 数据访问类:vw_JC_Employee
	/// </summary>
	public partial class vw_JC_Employee
	{
		public vw_JC_Employee()
		{}
		#region  BasicMethod



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Demo.Model.vw_JC_Employee model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into vw_JC_Employee(");
			strSql.Append("ID,EmployeeNO,EmployeeName,Age,Sex,EntryDate,LeaveDate,IDNumber,DepartmentNO,PositionNO,NativePlace,MobileNumber,Email,Nation,PoliticalStatus,MaritialStatus,Status,DepartmentName,PositionName)");
			strSql.Append(" values (");
			strSql.Append("@ID,@EmployeeNO,@EmployeeName,@Age,@Sex,@EntryDate,@LeaveDate,@IDNumber,@DepartmentNO,@PositionNO,@NativePlace,@MobileNumber,@Email,@Nation,@PoliticalStatus,@MaritialStatus,@Status,@DepartmentName,@PositionName)");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,64),
					new SqlParameter("@EmployeeNO", SqlDbType.NVarChar,64),
					new SqlParameter("@EmployeeName", SqlDbType.NVarChar,64),
					new SqlParameter("@Age", SqlDbType.Int,4),
					new SqlParameter("@Sex", SqlDbType.NVarChar,1),
					new SqlParameter("@EntryDate", SqlDbType.DateTime),
					new SqlParameter("@LeaveDate", SqlDbType.DateTime),
					new SqlParameter("@IDNumber", SqlDbType.NVarChar,64),
					new SqlParameter("@DepartmentNO", SqlDbType.NVarChar,64),
					new SqlParameter("@PositionNO", SqlDbType.NVarChar,64),
					new SqlParameter("@NativePlace", SqlDbType.NVarChar,64),
					new SqlParameter("@MobileNumber", SqlDbType.NVarChar,64),
					new SqlParameter("@Email", SqlDbType.NVarChar,64),
					new SqlParameter("@Nation", SqlDbType.NVarChar,64),
					new SqlParameter("@PoliticalStatus", SqlDbType.NVarChar,1),
					new SqlParameter("@MaritialStatus", SqlDbType.NVarChar,1),
					new SqlParameter("@Status", SqlDbType.NVarChar,1),
					new SqlParameter("@DepartmentName", SqlDbType.NVarChar,64),
					new SqlParameter("@PositionName", SqlDbType.NVarChar,64)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.EmployeeNO;
			parameters[2].Value = model.EmployeeName;
			parameters[3].Value = model.Age;
			parameters[4].Value = model.Sex;
			parameters[5].Value = model.EntryDate;
			parameters[6].Value = model.LeaveDate;
			parameters[7].Value = model.IDNumber;
			parameters[8].Value = model.DepartmentNO;
			parameters[9].Value = model.PositionNO;
			parameters[10].Value = model.NativePlace;
			parameters[11].Value = model.MobileNumber;
			parameters[12].Value = model.Email;
			parameters[13].Value = model.Nation;
			parameters[14].Value = model.PoliticalStatus;
			parameters[15].Value = model.MaritialStatus;
			parameters[16].Value = model.Status;
			parameters[17].Value = model.DepartmentName;
			parameters[18].Value = model.PositionName;

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
		public bool Update(Demo.Model.vw_JC_Employee model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update vw_JC_Employee set ");
			strSql.Append("ID=@ID,");
			strSql.Append("EmployeeNO=@EmployeeNO,");
			strSql.Append("EmployeeName=@EmployeeName,");
			strSql.Append("Age=@Age,");
			strSql.Append("Sex=@Sex,");
			strSql.Append("EntryDate=@EntryDate,");
			strSql.Append("LeaveDate=@LeaveDate,");
			strSql.Append("IDNumber=@IDNumber,");
			strSql.Append("DepartmentNO=@DepartmentNO,");
			strSql.Append("PositionNO=@PositionNO,");
			strSql.Append("NativePlace=@NativePlace,");
			strSql.Append("MobileNumber=@MobileNumber,");
			strSql.Append("Email=@Email,");
			strSql.Append("Nation=@Nation,");
			strSql.Append("PoliticalStatus=@PoliticalStatus,");
			strSql.Append("MaritialStatus=@MaritialStatus,");
			strSql.Append("Status=@Status,");
			strSql.Append("DepartmentName=@DepartmentName,");
			strSql.Append("PositionName=@PositionName");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,64),
					new SqlParameter("@EmployeeNO", SqlDbType.NVarChar,64),
					new SqlParameter("@EmployeeName", SqlDbType.NVarChar,64),
					new SqlParameter("@Age", SqlDbType.Int,4),
					new SqlParameter("@Sex", SqlDbType.NVarChar,1),
					new SqlParameter("@EntryDate", SqlDbType.DateTime),
					new SqlParameter("@LeaveDate", SqlDbType.DateTime),
					new SqlParameter("@IDNumber", SqlDbType.NVarChar,64),
					new SqlParameter("@DepartmentNO", SqlDbType.NVarChar,64),
					new SqlParameter("@PositionNO", SqlDbType.NVarChar,64),
					new SqlParameter("@NativePlace", SqlDbType.NVarChar,64),
					new SqlParameter("@MobileNumber", SqlDbType.NVarChar,64),
					new SqlParameter("@Email", SqlDbType.NVarChar,64),
					new SqlParameter("@Nation", SqlDbType.NVarChar,64),
					new SqlParameter("@PoliticalStatus", SqlDbType.NVarChar,1),
					new SqlParameter("@MaritialStatus", SqlDbType.NVarChar,1),
					new SqlParameter("@Status", SqlDbType.NVarChar,1),
					new SqlParameter("@DepartmentName", SqlDbType.NVarChar,64),
					new SqlParameter("@PositionName", SqlDbType.NVarChar,64)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.EmployeeNO;
			parameters[2].Value = model.EmployeeName;
			parameters[3].Value = model.Age;
			parameters[4].Value = model.Sex;
			parameters[5].Value = model.EntryDate;
			parameters[6].Value = model.LeaveDate;
			parameters[7].Value = model.IDNumber;
			parameters[8].Value = model.DepartmentNO;
			parameters[9].Value = model.PositionNO;
			parameters[10].Value = model.NativePlace;
			parameters[11].Value = model.MobileNumber;
			parameters[12].Value = model.Email;
			parameters[13].Value = model.Nation;
			parameters[14].Value = model.PoliticalStatus;
			parameters[15].Value = model.MaritialStatus;
			parameters[16].Value = model.Status;
			parameters[17].Value = model.DepartmentName;
			parameters[18].Value = model.PositionName;

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
			strSql.Append("delete from vw_JC_Employee ");
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
		public Demo.Model.vw_JC_Employee GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,EmployeeNO,EmployeeName,Age,Sex,EntryDate,LeaveDate,IDNumber,DepartmentNO,PositionNO,NativePlace,MobileNumber,Email,Nation,PoliticalStatus,MaritialStatus,Status,DepartmentName,PositionName from vw_JC_Employee ");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
			};

			Demo.Model.vw_JC_Employee model=new Demo.Model.vw_JC_Employee();
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
		public Demo.Model.vw_JC_Employee DataRowToModel(DataRow row)
		{
			Demo.Model.vw_JC_Employee model=new Demo.Model.vw_JC_Employee();
			if (row != null)
			{
				if(row["ID"]!=null)
				{
					model.ID=row["ID"].ToString();
				}
				if(row["EmployeeNO"]!=null)
				{
					model.EmployeeNO=row["EmployeeNO"].ToString();
				}
				if(row["EmployeeName"]!=null)
				{
					model.EmployeeName=row["EmployeeName"].ToString();
				}
				if(row["Age"]!=null && row["Age"].ToString()!="")
				{
					model.Age=int.Parse(row["Age"].ToString());
				}
				if(row["Sex"]!=null)
				{
					model.Sex=row["Sex"].ToString();
				}
				if(row["EntryDate"]!=null && row["EntryDate"].ToString()!="")
				{
					model.EntryDate=DateTime.Parse(row["EntryDate"].ToString());
				}
				if(row["LeaveDate"]!=null && row["LeaveDate"].ToString()!="")
				{
					model.LeaveDate=DateTime.Parse(row["LeaveDate"].ToString());
				}
				if(row["IDNumber"]!=null)
				{
					model.IDNumber=row["IDNumber"].ToString();
				}
				if(row["DepartmentNO"]!=null)
				{
					model.DepartmentNO=row["DepartmentNO"].ToString();
				}
				if(row["PositionNO"]!=null)
				{
					model.PositionNO=row["PositionNO"].ToString();
				}
				if(row["NativePlace"]!=null)
				{
					model.NativePlace=row["NativePlace"].ToString();
				}
				if(row["MobileNumber"]!=null)
				{
					model.MobileNumber=row["MobileNumber"].ToString();
				}
				if(row["Email"]!=null)
				{
					model.Email=row["Email"].ToString();
				}
				if(row["Nation"]!=null)
				{
					model.Nation=row["Nation"].ToString();
				}
				if(row["PoliticalStatus"]!=null)
				{
					model.PoliticalStatus=row["PoliticalStatus"].ToString();
				}
				if(row["MaritialStatus"]!=null)
				{
					model.MaritialStatus=row["MaritialStatus"].ToString();
				}
				if(row["Status"]!=null)
				{
					model.Status=row["Status"].ToString();
				}
				if(row["DepartmentName"]!=null)
				{
					model.DepartmentName=row["DepartmentName"].ToString();
				}
				if(row["PositionName"]!=null)
				{
					model.PositionName=row["PositionName"].ToString();
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
			strSql.Append("select ID,EmployeeNO,EmployeeName,Age,Sex,EntryDate,LeaveDate,IDNumber,DepartmentNO,PositionNO,NativePlace,MobileNumber,Email,Nation,PoliticalStatus,MaritialStatus,Status,DepartmentName,PositionName ");
			strSql.Append(" FROM vw_JC_Employee ");
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
            DataSet ds = pageData.getDataPage("vw_JC_Employee", "*", sqlWhere, order, pageSize, pageIndex, out totalRecord);
            return ds;
		}

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}


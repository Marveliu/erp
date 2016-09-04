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
namespace Demo.Model
{
	/// <summary>
	/// vw_JC_Employee:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class vw_JC_Employee
	{
		public vw_JC_Employee()
		{}
		#region Model
		private string _id;
		private string _employeeno;
		private string _employeename;
		private int? _age;
		private string _sex;
		private DateTime? _entrydate;
		private DateTime? _leavedate;
		private string _idnumber;
		private string _departmentno;
		private string _positionno;
		private string _nativeplace;
		private string _mobilenumber;
		private string _email;
		private string _nation;
		private string _politicalstatus;
		private string _maritialstatus;
		private string _status;
		private string _departmentname;
		private string _positionname;
		/// <summary>
		/// 
		/// </summary>
		public string ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string EmployeeNO
		{
			set{ _employeeno=value;}
			get{return _employeeno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string EmployeeName
		{
			set{ _employeename=value;}
			get{return _employeename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Age
		{
			set{ _age=value;}
			get{return _age;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Sex
		{
			set{ _sex=value;}
			get{return _sex;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? EntryDate
		{
			set{ _entrydate=value;}
			get{return _entrydate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? LeaveDate
		{
			set{ _leavedate=value;}
			get{return _leavedate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string IDNumber
		{
			set{ _idnumber=value;}
			get{return _idnumber;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DepartmentNO
		{
			set{ _departmentno=value;}
			get{return _departmentno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PositionNO
		{
			set{ _positionno=value;}
			get{return _positionno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string NativePlace
		{
			set{ _nativeplace=value;}
			get{return _nativeplace;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MobileNumber
		{
			set{ _mobilenumber=value;}
			get{return _mobilenumber;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Email
		{
			set{ _email=value;}
			get{return _email;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Nation
		{
			set{ _nation=value;}
			get{return _nation;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PoliticalStatus
		{
			set{ _politicalstatus=value;}
			get{return _politicalstatus;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MaritialStatus
		{
			set{ _maritialstatus=value;}
			get{return _maritialstatus;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Status
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DepartmentName
		{
			set{ _departmentname=value;}
			get{return _departmentname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PositionName
		{
			set{ _positionname=value;}
			get{return _positionname;}
		}
		#endregion Model

	}
}


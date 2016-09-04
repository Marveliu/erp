/**  版本信息模板在安装目录下，可自行修改。
* vw_JC_BOMParent.cs
*
* 功 能： N/A
* 类 名： vw_JC_BOMParent
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/5/16 16:36:22   N/A    初版
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
	/// vw_JC_BOMParent:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class vw_JC_BOMParent
	{
		public vw_JC_BOMParent()
		{}
		#region Model
		private string _id;
		private string _materialno;
		private string _materialtype;
		private string _checkno;
		private string _checkstatus;
		private DateTime? _checkdate;
		private string _status;
		private string _materialname;
		private string _specification;
		private string _model;
		private string _unit;
		private string _checkname;
		private string _propertyname;
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
		public string MaterialNO
		{
			set{ _materialno=value;}
			get{return _materialno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MaterialType
		{
			set{ _materialtype=value;}
			get{return _materialtype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CheckNO
		{
			set{ _checkno=value;}
			get{return _checkno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CheckStatus
		{
			set{ _checkstatus=value;}
			get{return _checkstatus;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? CheckDate
		{
			set{ _checkdate=value;}
			get{return _checkdate;}
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
		public string MaterialName
		{
			set{ _materialname=value;}
			get{return _materialname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Specification
		{
			set{ _specification=value;}
			get{return _specification;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Model
		{
			set{ _model=value;}
			get{return _model;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Unit
		{
			set{ _unit=value;}
			get{return _unit;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CheckName
		{
			set{ _checkname=value;}
			get{return _checkname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PropertyName
		{
			set{ _propertyname=value;}
			get{return _propertyname;}
		}
		#endregion Model

	}
}


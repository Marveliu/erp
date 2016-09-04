/**  版本信息模板在安装目录下，可自行修改。
* vw_JH_MPS.cs
*
* 功 能： N/A
* 类 名： vw_JH_MPS
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/6/6 14:30:19   N/A    初版
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
	/// vw_JH_MPS:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class vw_JH_MPS
	{
		public vw_JH_MPS()
		{}
		#region Model
		private string _id;
		private string _planno;
		private string _plannedsourceid;
		private string _materialno;
		private decimal? _planamount;
		private decimal? _resolveamount;
		private DateTime? _enddate;
		private string _status;
		private string _materialname;
		private string _unit;
		private string _plannedsourceno;
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
		public string PlanNO
		{
			set{ _planno=value;}
			get{return _planno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PlannedSourceID
		{
			set{ _plannedsourceid=value;}
			get{return _plannedsourceid;}
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
		public decimal? PlanAmount
		{
			set{ _planamount=value;}
			get{return _planamount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? ResolveAmount
		{
			set{ _resolveamount=value;}
			get{return _resolveamount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? EndDate
		{
			set{ _enddate=value;}
			get{return _enddate;}
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
		public string Unit
		{
			set{ _unit=value;}
			get{return _unit;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PlannedSourceNO
		{
			set{ _plannedsourceno=value;}
			get{return _plannedsourceno;}
		}
		#endregion Model

	}
}


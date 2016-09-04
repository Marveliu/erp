/**  版本信息模板在安装目录下，可自行修改。
* vw_JC_RoutingSub.cs
*
* 功 能： N/A
* 类 名： vw_JC_RoutingSub
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/6/3 17:33:32   N/A    初版
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
	/// vw_JC_RoutingSub:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class vw_JC_RoutingSub
	{
		public vw_JC_RoutingSub()
		{}
		#region Model
		private string _id;
		private string _procedureno;
		private int? _procedureorder;
		private string _routingid;
		private string _procedurename;
		private string _workcenterno;
		private string _workcentername;
		private string _routingno;
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
		public string ProcedureNO
		{
			set{ _procedureno=value;}
			get{return _procedureno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ProcedureOrder
		{
			set{ _procedureorder=value;}
			get{return _procedureorder;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string RoutingID
		{
			set{ _routingid=value;}
			get{return _routingid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ProcedureName
		{
			set{ _procedurename=value;}
			get{return _procedurename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string WorkCenterNO
		{
			set{ _workcenterno=value;}
			get{return _workcenterno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string WorkCenterName
		{
			set{ _workcentername=value;}
			get{return _workcentername;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string RoutingNO
		{
			set{ _routingno=value;}
			get{return _routingno;}
		}
		#endregion Model

	}
}


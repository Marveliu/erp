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
namespace Demo.Model
{
	/// <summary>
	/// vw_JC_Material:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class vw_JC_Material
	{
		public vw_JC_Material()
		{}
		#region Model
		private string _id;
		private string _materialno;
		private string _materialname;
		private string _specification;
		private string _model;
		private string _unit;
		private string _property;
		private decimal? _unitstandardcost;
		private decimal? _unitstandardtime;
		private int? _fixedleadtime;
		private int? _variableleadtime;
		private decimal? _variablebatch;
		private string _status;
		private string _processrouteno;
		private decimal? _productionvolume;
		private decimal? _increaseamount;
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
		public string Property
		{
			set{ _property=value;}
			get{return _property;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? UnitStandardCost
		{
			set{ _unitstandardcost=value;}
			get{return _unitstandardcost;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? UnitStandardTime
		{
			set{ _unitstandardtime=value;}
			get{return _unitstandardtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? FixedLeadTime
		{
			set{ _fixedleadtime=value;}
			get{return _fixedleadtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? VariableLeadTime
		{
			set{ _variableleadtime=value;}
			get{return _variableleadtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? VariableBatch
		{
			set{ _variablebatch=value;}
			get{return _variablebatch;}
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
		public string ProcessRouteNO
		{
			set{ _processrouteno=value;}
			get{return _processrouteno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? ProductionVolume
		{
			set{ _productionvolume=value;}
			get{return _productionvolume;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? IncreaseAmount
		{
			set{ _increaseamount=value;}
			get{return _increaseamount;}
		}
		#endregion Model

	}
}


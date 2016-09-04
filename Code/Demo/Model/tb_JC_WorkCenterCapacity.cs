/**  版本信息模板在安装目录下，可自行修改。
* tb_JC_WorkCenterCapacity.cs
*
* 功 能： N/A
* 类 名： tb_JC_WorkCenterCapacity
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/5/14 16:38:34   N/A    初版
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
	/// tb_JC_WorkCenterCapacity:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tb_JC_WorkCenterCapacity
	{
		public tb_JC_WorkCenterCapacity()
		{}
		#region Model
		private string _id;
		private string _workcenterno;
		private string _materialno;
		private string _capacitytype;
		private decimal? _unitcapacity;
		private string _capacityunit;
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
		public string WorkCenterNO
		{
			set{ _workcenterno=value;}
			get{return _workcenterno;}
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
		public string CapacityType
		{
			set{ _capacitytype=value;}
			get{return _capacitytype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? UnitCapacity
		{
			set{ _unitcapacity=value;}
			get{return _unitcapacity;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CapacityUnit
		{
			set{ _capacityunit=value;}
			get{return _capacityunit;}
		}
		#endregion Model

	}
}


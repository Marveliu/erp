/**  版本信息模板在安装目录下，可自行修改。
* tb_JC_Material_P.cs
*
* 功 能： N/A
* 类 名： tb_JC_Material_P
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/5/23 12:10:30   N/A    初版
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
	/// tb_JC_Material_P:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tb_JC_Material_P
	{
		public tb_JC_Material_P()
		{}
		#region Model
		private string _id;
		private string _materialno;
		private string _processrouteno;
		private decimal? _productionvolume;
		private decimal? _increaseamount;
		private decimal? _unitstandardtime;
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
		/// <summary>
		/// 
		/// </summary>
		public decimal? UnitStandardTime
		{
			set{ _unitstandardtime=value;}
			get{return _unitstandardtime;}
		}
		#endregion Model

	}
}


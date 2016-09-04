/**  版本信息模板在安装目录下，可自行修改。
* tb_JC_BOMSub.cs
*
* 功 能： N/A
* 类 名： tb_JC_BOMSub
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/5/14 16:38:31   N/A    初版
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
	/// tb_JC_BOMSub:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tb_JC_BOMSub
	{
		public tb_JC_BOMSub()
		{}
		#region Model
		private string _id;
		private string _materialno;
		private string _materialtype;
		private string _parentno;
		private decimal? _amount;
		private decimal? _leadtimeoffset;
		private string _backflush;
		private string _status;
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
		public string ParentNO
		{
			set{ _parentno=value;}
			get{return _parentno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? Amount
		{
			set{ _amount=value;}
			get{return _amount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? LeadTimeOffset
		{
			set{ _leadtimeoffset=value;}
			get{return _leadtimeoffset;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string BackFlush
		{
			set{ _backflush=value;}
			get{return _backflush;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Status
		{
			set{ _status=value;}
			get{return _status;}
		}
		#endregion Model

	}
}


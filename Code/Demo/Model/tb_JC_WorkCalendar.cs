/**  版本信息模板在安装目录下，可自行修改。
* tb_JC_WorkCalendar.cs
*
* 功 能： N/A
* 类 名： tb_JC_WorkCalendar
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/6/1 23:27:14   N/A    初版
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
	/// tb_JC_WorkCalendar:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tb_JC_WorkCalendar
	{
		public tb_JC_WorkCalendar()
		{}
		#region Model
		private int _id;
		private DateTime? _date;
		/// <summary>
		/// 
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? Date
		{
			set{ _date=value;}
			get{return _date;}
		}
		#endregion Model

	}
}


/**  版本信息模板在安装目录下，可自行修改。
* tb_JC_WorkCalendarRule.cs
*
* 功 能： N/A
* 类 名： tb_JC_WorkCalendarRule
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/6/1 23:27:15   N/A    初版
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
	/// tb_JC_WorkCalendarRule:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tb_JC_WorkCalendarRule
	{
		public tb_JC_WorkCalendarRule()
		{}
		#region Model
		private string _id;
		private string _exceptiontype;
		private string _exceptiontime;
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
		public string ExceptionType
		{
			set{ _exceptiontype=value;}
			get{return _exceptiontype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ExceptionTime
		{
			set{ _exceptiontime=value;}
			get{return _exceptiontime;}
		}
		#endregion Model

	}
}


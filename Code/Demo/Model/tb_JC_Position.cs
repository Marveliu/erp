﻿/**  版本信息模板在安装目录下，可自行修改。
* tb_JC_Position.cs
*
* 功 能： N/A
* 类 名： tb_JC_Position
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/5/23 14:17:52   N/A    初版
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
	/// tb_JC_Position:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tb_JC_Position
	{
		public tb_JC_Position()
		{}
		#region Model
		private string _id;
		private string _positionno;
		private string _positionname;
		private string _departmentno;
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
		public string PositionNO
		{
			set{ _positionno=value;}
			get{return _positionno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PositionName
		{
			set{ _positionname=value;}
			get{return _positionname;}
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
		public string Status
		{
			set{ _status=value;}
			get{return _status;}
		}
		#endregion Model

	}
}


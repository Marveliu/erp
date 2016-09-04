﻿/**  版本信息模板在安装目录下，可自行修改。
* tb_JC_MaterialProperty.cs
*
* 功 能： N/A
* 类 名： tb_JC_MaterialProperty
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/5/16 0:11:18   N/A    初版
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
	/// tb_JC_MaterialProperty:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tb_JC_MaterialProperty
	{
		public tb_JC_MaterialProperty()
		{}
		#region Model
		private string _id;
		private string _propertyno;
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
		public string PropertyNO
		{
			set{ _propertyno=value;}
			get{return _propertyno;}
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


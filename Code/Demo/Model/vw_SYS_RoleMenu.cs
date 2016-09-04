/**  版本信息模板在安装目录下，可自行修改。
* vw_SYS_RoleMenu.cs
*
* 功 能： N/A
* 类 名： vw_SYS_RoleMenu
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/3/1 10:18:16   N/A    初版
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
	/// vw_SYS_RoleMenu:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class vw_SYS_RoleMenu
	{
		public vw_SYS_RoleMenu()
		{}
		#region Model
		private string _menuid;
		private string _roleid;
		private string _menuno;
		private string _menuname;
		private string _menuurl;
		private string _parentname;
		/// <summary>
		/// 
		/// </summary>
		public string MenuID
		{
			set{ _menuid=value;}
			get{return _menuid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string RoleID
		{
			set{ _roleid=value;}
			get{return _roleid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MenuNO
		{
			set{ _menuno=value;}
			get{return _menuno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MenuName
		{
			set{ _menuname=value;}
			get{return _menuname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MenuUrl
		{
			set{ _menuurl=value;}
			get{return _menuurl;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ParentName
		{
			set{ _parentname=value;}
			get{return _parentname;}
		}
		#endregion Model

	}
}


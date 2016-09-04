/**  版本信息模板在安装目录下，可自行修改。
* tb_SYS_RoleMenu.cs
*
* 功 能： N/A
* 类 名： tb_SYS_RoleMenu
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/2/25 14:00:51   N/A    初版
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
	/// tb_SYS_RoleMenu:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tb_SYS_RoleMenu
	{
		public tb_SYS_RoleMenu()
		{}
		#region Model
		private string _id;
		private string _menuid;
		private string _roleid;
		private string _authorizationdelete;
		private string _authorizationupdate;
		private string _authorizationinsert;
		private string _state;
		private string _createid;
		private DateTime? _createtime;
		private string _updateid;
		private DateTime? _updatetime;
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
		public string AuthorizationDelete
		{
			set{ _authorizationdelete=value;}
			get{return _authorizationdelete;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string AuthorizationUpdate
		{
			set{ _authorizationupdate=value;}
			get{return _authorizationupdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string AuthorizationInsert
		{
			set{ _authorizationinsert=value;}
			get{return _authorizationinsert;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string State
		{
			set{ _state=value;}
			get{return _state;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CreateID
		{
			set{ _createid=value;}
			get{return _createid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? CreateTime
		{
			set{ _createtime=value;}
			get{return _createtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UpdateID
		{
			set{ _updateid=value;}
			get{return _updateid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? UpdateTime
		{
			set{ _updatetime=value;}
			get{return _updatetime;}
		}
		#endregion Model

	}
}


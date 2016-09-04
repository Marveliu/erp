/**  版本信息模板在安装目录下，可自行修改。
* tb_SYS_Menu.cs
*
* 功 能： N/A
* 类 名： tb_SYS_Menu
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/1/17 15:38:34   N/A    初版
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
	/// tb_SYS_Menu:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tb_SYS_Menu
	{
		public tb_SYS_Menu()
		{}
		#region Model
		private string _id;
		private string _menuno;
		private string _menuname;
		private string _parentid;
		private string _menuurl;
		private string _imageurl;
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
		public string ParentID
		{
			set{ _parentid=value;}
			get{return _parentid;}
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
		public string ImageUrl
		{
			set{ _imageurl=value;}
			get{return _imageurl;}
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


/**  版本信息模板在安装目录下，可自行修改。
* tb_JC_Procedure.cs
*
* 功 能： N/A
* 类 名： tb_JC_Procedure
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/5/23 14:44:21   N/A    初版
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
	/// tb_JC_Procedure:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tb_JC_Procedure
	{
		public tb_JC_Procedure()
		{}
		#region Model
		private string _id;
		private string _procedureno;
		private string _procedurename;
		private string _workcenterno;
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
		public string ProcedureNO
		{
			set{ _procedureno=value;}
			get{return _procedureno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ProcedureName
		{
			set{ _procedurename=value;}
			get{return _procedurename;}
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
		public string Status
		{
			set{ _status=value;}
			get{return _status;}
		}
		#endregion Model

	}
}


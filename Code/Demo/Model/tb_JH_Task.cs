/**  版本信息模板在安装目录下，可自行修改。
* tb_JH_Task.cs
*
* 功 能： N/A
* 类 名： tb_JH_Task
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/6/5 22:38:26   N/A    初版
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
	/// tb_JH_Task:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tb_JH_Task
	{
		public tb_JH_Task()
		{}
		#region Model
		private string _id;
		private string _sourceid;
		private string _mrpid;
		private string _billtype;
		private string _billno;
		private DateTime? _date;
		private decimal? _amount;
		private decimal? _executedamount;
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
		public string SourceID
		{
			set{ _sourceid=value;}
			get{return _sourceid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MRPID
		{
			set{ _mrpid=value;}
			get{return _mrpid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string BillType
		{
			set{ _billtype=value;}
			get{return _billtype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string BillNO
		{
			set{ _billno=value;}
			get{return _billno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? Date
		{
			set{ _date=value;}
			get{return _date;}
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
		public decimal? ExecutedAmount
		{
			set{ _executedamount=value;}
			get{return _executedamount;}
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


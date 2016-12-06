using System;
namespace DentalMedical.Model
{
	/// <summary>
	/// sys_logs:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class sys_logs
	{
		public sys_logs()
		{}
		#region Model
		private Guid _id;
		private Guid _doctor_id;
		private int _logstype;
		private string _entity;
		private string _incident;
		private string _ip;
		private string _clientinfo;
		private string _logmessage;
		private int _orderid;
		private DateTime _createdate;
		private Guid _createid;
		private DateTime? _modifydate;
		private Guid _modifyid;
		private int _flag;
		/// <summary>
		/// id,建议创建时为guid
		/// </summary>
		public Guid Id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public Guid doctor_Id
		{
			set{ _doctor_id=value;}
			get{return _doctor_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int LogsType
		{
			set{ _logstype=value;}
			get{return _logstype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Entity
		{
			set{ _entity=value;}
			get{return _entity;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string incident
		{
			set{ _incident=value;}
			get{return _incident;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string IP
		{
			set{ _ip=value;}
			get{return _ip;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string clientInfo
		{
			set{ _clientinfo=value;}
			get{return _clientinfo;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string logmessage
		{
			set{ _logmessage=value;}
			get{return _logmessage;}
		}
		/// <summary>
		/// 排序
		/// </summary>
		public int orderId
		{
			set{ _orderid=value;}
			get{return _orderid;}
		}
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime createDate
		{
			set{ _createdate=value;}
			get{return _createdate;}
		}
		/// <summary>
		/// 创建人
		/// </summary>
		public Guid createId
		{
			set{ _createid=value;}
			get{return _createid;}
		}
		/// <summary>
		/// 修改时间
		/// </summary>
		public DateTime? modifyDate
		{
			set{ _modifydate=value;}
			get{return _modifydate;}
		}
		/// <summary>
		/// 修改人
		/// </summary>
		public Guid modifyId
		{
			set{ _modifyid=value;}
			get{return _modifyid;}
		}
		/// <summary>
		/// 是否有效
		/// </summary>
		public int flag
		{
			set{ _flag=value;}
			get{return _flag;}
		}
		#endregion Model

	}
}


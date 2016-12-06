using System;
namespace DentalMedical.Model
{
	/// <summary>
	/// invoice_open:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class invoice_open
	{
		public invoice_open()
		{}
		#region Model
		private Guid _id;
		private Guid _factoryid;
		private string _invoice_title;
		private string _invoice_opentype;
		private string _invoice_type;
		private bool _isdefault;
		private int? _orderid;
		private DateTime _createdate;
		private Guid _createid;
		private DateTime? _modifydate;
		private Guid _modifyid;
		private int _flag;
		/// <summary>
		/// 
		/// </summary>
		public Guid Id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public Guid factoryId
		{
			set{ _factoryid=value;}
			get{return _factoryid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string invoice_title
		{
			set{ _invoice_title=value;}
			get{return _invoice_title;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string invoice_openType
		{
			set{ _invoice_opentype=value;}
			get{return _invoice_opentype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string invoice_type
		{
			set{ _invoice_type=value;}
			get{return _invoice_type;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool isdefault
		{
			set{ _isdefault=value;}
			get{return _isdefault;}
		}
		/// <summary>
		/// 序号
		/// </summary>
		public int? orderId
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


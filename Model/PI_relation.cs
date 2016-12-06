using System;
namespace DentalMedical.Model
{
	/// <summary>
	/// PI_relation:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class PI_relation
	{
		public PI_relation()
		{}
		#region Model
		private Guid _id;
		private Guid _paymentid;
		private Guid _invoiceid;
		private string _cremark;
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
		public Guid paymentId
		{
			set{ _paymentid=value;}
			get{return _paymentid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public Guid invoiceId
		{
			set{ _invoiceid=value;}
			get{return _invoiceid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cRemark
		{
			set{ _cremark=value;}
			get{return _cremark;}
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


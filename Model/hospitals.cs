using System;
namespace DentalMedical.Model
{
	/// <summary>
	/// hospitals:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class hospitals
	{
		public hospitals()
		{}
		#region Model
		private Guid _id;
		private string _hospitalname;
		private string _hospitalename;
		private string _hospitalcode;
		private string _hospitaladdress;
		private string _hospitaltel;
		private string _hospitalweb;
		private string _hospitalintroduction;
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
		public string hospitalName
		{
			set{ _hospitalname=value;}
			get{return _hospitalname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string hospitalEName
		{
			set{ _hospitalename=value;}
			get{return _hospitalename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string hospitalCode
		{
			set{ _hospitalcode=value;}
			get{return _hospitalcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string hospitalAddress
		{
			set{ _hospitaladdress=value;}
			get{return _hospitaladdress;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string hospitalTel
		{
			set{ _hospitaltel=value;}
			get{return _hospitaltel;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string hospitalWeb
		{
			set{ _hospitalweb=value;}
			get{return _hospitalweb;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string hospitalIntroduction
		{
			set{ _hospitalintroduction=value;}
			get{return _hospitalintroduction;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? orderId
		{
			set{ _orderid=value;}
			get{return _orderid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime createDate
		{
			set{ _createdate=value;}
			get{return _createdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public Guid createId
		{
			set{ _createid=value;}
			get{return _createid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? modifyDate
		{
			set{ _modifydate=value;}
			get{return _modifydate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public Guid modifyId
		{
			set{ _modifyid=value;}
			get{return _modifyid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int flag
		{
			set{ _flag=value;}
			get{return _flag;}
		}
		#endregion Model

	}
}


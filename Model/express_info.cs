using System;
namespace DentalMedical.Model
{
	/// <summary>
	/// express_info:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class express_info
	{
		public express_info()
		{}
		#region Model
		private Guid _id;
		private string _companyname;
		private string _companycode;
		private string _companyapi;
		private string _coderole;
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
		public string companyName
		{
			set{ _companyname=value;}
			get{return _companyname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string companyCode
		{
			set{ _companycode=value;}
			get{return _companycode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string companyApi
		{
			set{ _companyapi=value;}
			get{return _companyapi;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string codeRole
		{
			set{ _coderole=value;}
			get{return _coderole;}
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


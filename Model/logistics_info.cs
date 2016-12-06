using System;
namespace DentalMedical.Model
{
	/// <summary>
	/// logistics_info:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class logistics_info
	{
		public logistics_info()
		{}
		#region Model
		private Guid _id;
		private Guid _factory_id;
		private string _emr_code;
		private Guid _dsid;
		private string _expressname;
		private string _express_billcode;
		private string _cremark;
		private int? _orderid;
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
		/// 工厂ID
		/// </summary>
		public Guid factory_Id
		{
			set{ _factory_id=value;}
			get{return _factory_id;}
		}
		/// <summary>
		/// 病历编号
		/// </summary>
		public string EMR_Code
		{
			set{ _emr_code=value;}
			get{return _emr_code;}
		}
		/// <summary>
		/// 设计方案ID
		/// </summary>
		public Guid dsId
		{
			set{ _dsid=value;}
			get{return _dsid;}
		}
		/// <summary>
		/// 快递公司
		/// </summary>
		public string expressName
		{
			set{ _expressname=value;}
			get{return _expressname;}
		}
		/// <summary>
		/// 快递编号
		/// </summary>
		public string express_billCode
		{
			set{ _express_billcode=value;}
			get{return _express_billcode;}
		}
		/// <summary>
		/// 备注
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


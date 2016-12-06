using System;
namespace DentalMedical.Model
{
	/// <summary>
	/// invoice_info:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class invoice_info
	{
		public invoice_info()
		{}
		#region Model
		private Guid _id;
		private string _expressname;
		private string _expresscode;
		private decimal _total_amount;
		private Guid _ioid;
        private Guid _mdId;
		private string _cremark;
		private DateTime _createdate;
		private Guid _createid;
		private DateTime? _modifydate;
		private Guid _modifyid;
		private int _flag;
		/// <summary>
		/// 主键
		/// </summary>
		public Guid Id
		{
			set{ _id=value;}
			get{return _id;}
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
		/// 快递号
		/// </summary>
		public string expressCode
		{
			set{ _expresscode=value;}
			get{return _expresscode;}
		}
		/// <summary>
		/// 总金额
		/// </summary>
		public decimal total_amount
		{
			set{ _total_amount=value;}
			get{return _total_amount;}
		}
		/// <summary>
		/// 发票信息Id
		/// </summary>
		public Guid ioId
		{
			set{ _ioid=value;}
			get{return _ioid;}
		}
        /// <summary>
        /// 邮寄地址Id
        /// </summary>
        public Guid mdId
        {
            set { _mdId = value; }
            get { return _mdId; }
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


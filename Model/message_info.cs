using System;
namespace DentalMedical.Model
{
	/// <summary>
	/// message_info:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class message_info
	{
		public message_info()
		{}
		#region Model
		private Guid _id;
		private string _mobilephone;
		private int _mtype;
		private string _validation_code;
		private int? _orderid;
		private DateTime _createdate;
		private Guid _createid;
		private DateTime? _modifydate;
		private Guid _modifyid;
		private int _flag;
        private string _message;
        private string _cRemark;
        private string _smsstauts;
        private string _smsIP;      
      
      
      
		/// <summary>
		/// id,建议创建时为guid
		/// </summary>
		public Guid Id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 手机号
		/// </summary>
        public string mobilePhone
		{
			set{ _mobilephone=value;}
			get{return _mobilephone;}
		}
		/// <summary>
		/// 短信类型
		/// </summary>
		public int mtype
		{
			set{ _mtype=value;}
			get{return _mtype;}
		}
		/// <summary>
		/// 手机短信验证号
		/// </summary>
		public string validation_Code
		{
			set{ _validation_code=value;}
			get{return _validation_code;}
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

        /// <summary>
        /// 短信内容
        /// </summary>
        public string message
        {
            get { return _message; }
            set { _message = value; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string cRemark
        {
            get { return _cRemark; }
            set { _cRemark = value; }
        }
        /// <summary>
        /// 短信回执状态
        /// </summary>
        public string smsstauts
        {
            get { return _smsstauts; }
            set { _smsstauts = value; }
        }
        /// <summary>
        /// 发送短信IP
        /// </summary>
        public string smsIP
        {
            get { return _smsIP; }
            set { _smsIP = value; }
        }
		#endregion Model

	}
}


using System;
namespace DentalMedical.Model
{
	/// <summary>
	/// factory:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class factory
	{
		public factory()
		{}
		#region Model
		private Guid _id;
		private string _factorycode;
		private string _factorytel;
		private string _factorypwd;
		private string _factoryemail;
		private int _factorykey;
		private string _factorylogo;
		private int _onlinestatus;
		private string _factoryname;
		private decimal _fee;
		private string _invit_code;
		private int? _orderid;
		private string _factoryremark;
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
		/// 账户，目前为手机号注册
		/// </summary>
		public string factoryCode
		{
			set{ _factorycode=value;}
			get{return _factorycode;}
		}
		/// <summary>
		/// 电话
		/// </summary>
		public string factoryTel
		{
			set{ _factorytel=value;}
			get{return _factorytel;}
		}
		/// <summary>
		/// 密码
		/// </summary>
		public string factoryPwd
		{
			set{ _factorypwd=value;}
			get{return _factorypwd;}
		}
		/// <summary>
		/// 邮箱
		/// </summary>
		public string factoryEmail
		{
			set{ _factoryemail=value;}
			get{return _factoryemail;}
		}
		/// <summary>
		/// 验证号
		/// </summary>
		public int factoryKey
		{
			set{ _factorykey=value;}
			get{return _factorykey;}
		}
		/// <summary>
		/// 厂家logo
		/// </summary>
		public string factoryLogo
		{
			set{ _factorylogo=value;}
			get{return _factorylogo;}
		}
		/// <summary>
		/// 在线状态
		/// </summary>
		public int onlineStatus
		{
			set{ _onlinestatus=value;}
			get{return _onlinestatus;}
		}
		/// <summary>
		/// 厂家名字
		/// </summary>
		public string factoryName
		{
			set{ _factoryname=value;}
			get{return _factoryname;}
		}
		/// <summary>
		/// 厂家服务费
		/// </summary>
		public decimal fee
		{
			set{ _fee=value;}
			get{return _fee;}
		}
		/// <summary>
		/// 邀请码
		/// </summary>
		public string invit_code
		{
			set{ _invit_code=value;}
			get{return _invit_code;}
		}
		/// <summary>
		/// 排序号
		/// </summary>
		public int? orderId
		{
			set{ _orderid=value;}
			get{return _orderid;}
		}
		/// <summary>
		/// 备注
		/// </summary>
		public string factoryRemark
		{
			set{ _factoryremark=value;}
			get{return _factoryremark;}
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


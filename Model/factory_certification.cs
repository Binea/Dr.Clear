using System;
namespace DentalMedical.Model
{
	/// <summary>
	/// factory_certification:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class factory_certification
	{
		public factory_certification()
		{}
		#region Model
		private Guid _id;
		private Guid _factory_id;
		private string _legal_person;
		private string _organization_code;
		private string _main_person;
		private string _main_tel;
		private string _business_license;
		private string _legal_id;
		private string _factory_address;
		private string _medical_license;
		private string _instrument_license;
		private int _status;
		private int? _orderid;
		private DateTime _createdate;
		private Guid _createid;
		private DateTime? _modifydate;
		private Guid _modifyid;
		private int _flag;
        private int _main_Sex;
        private string _main_Email;
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
		/// 法人
		/// </summary>
		public string legal_Person
		{
			set{ _legal_person=value;}
			get{return _legal_person;}
		}
		/// <summary>
		/// 组织机构代码
		/// </summary>
		public string organization_Code
		{
			set{ _organization_code=value;}
			get{return _organization_code;}
		}
		/// <summary>
		/// 主要联系人
		/// </summary>
		public string main_Person
		{
			set{ _main_person=value;}
			get{return _main_person;}
		}
		/// <summary>
		/// 联系人电话
		/// </summary>
		public string main_Tel
		{
			set{ _main_tel=value;}
			get{return _main_tel;}
		}
		/// <summary>
		/// 营业执照
		/// </summary>
		public string business_license
		{
			set{ _business_license=value;}
			get{return _business_license;}
		}
		/// <summary>
		/// 法人身份证
		/// </summary>
		public string Legal_ID
		{
			set{ _legal_id=value;}
			get{return _legal_id;}
		}
		/// <summary>
		/// 地址
		/// </summary>
		public string factory_Address
		{
			set{ _factory_address=value;}
			get{return _factory_address;}
		}
		/// <summary>
		/// 医疗企业生产许可证
		/// </summary>
		public string medical_license
		{
			set{ _medical_license=value;}
			get{return _medical_license;}
		}
		/// <summary>
		/// 医疗器械产品注册证
		/// </summary>
		public string instrument_license
		{
			set{ _instrument_license=value;}
			get{return _instrument_license;}
		}
		/// <summary>
		/// 状态
		/// </summary>
		public int status
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		/// 排序
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

        public int main_Sex
        {
            set { _main_Sex = value; }
            get { return _main_Sex; }
        }

        public string main_Email
        {
            set { _main_Email = value; }
            get { return _main_Email; }
        }
		#endregion Model

	}
}


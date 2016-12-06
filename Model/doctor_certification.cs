using System;
namespace DentalMedical.Model
{
	/// <summary>
	/// doctor_certification:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class doctor_certification
	{
		public doctor_certification()
		{}
		#region Model
		private Guid _id;
		private Guid _doctor_id;
		private Guid _userhospital;
		private Guid _userdepartment;
		private Guid _usertitle;
		private string _work_card;
		private int _status;
		private string _dh_logo;
		private bool _isdefault;
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
		/// 医生Id
		/// </summary>
		public Guid doctor_Id
		{
			set{ _doctor_id=value;}
			get{return _doctor_id;}
		}
		/// <summary>
		/// 医院
		/// </summary>
		public Guid userHospital
		{
			set{ _userhospital=value;}
			get{return _userhospital;}
		}
		/// <summary>
		/// 科室
		/// </summary>
		public Guid userDepartment
		{
			set{ _userdepartment=value;}
			get{return _userdepartment;}
		}
		/// <summary>
		/// 职称
		/// </summary>
		public Guid userTitle
		{
			set{ _usertitle=value;}
			get{return _usertitle;}
		}
		/// <summary>
		/// 工牌
		/// </summary>
		public string work_Card
		{
			set{ _work_card=value;}
			get{return _work_card;}
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
		/// 二维码
		/// </summary>
		public string dh_logo
		{
			set{ _dh_logo=value;}
			get{return _dh_logo;}
		}
		/// <summary>
		/// 是否默认
	///
		/// </summary>
		public bool isdefault
		{
			set{ _isdefault=value;}
			get{return _isdefault;}
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


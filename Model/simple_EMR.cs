using System;
namespace DentalMedical.Model
{
	/// <summary>
	/// simple_EMR:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class simple_EMR
	{
		public simple_EMR()
		{}
		#region Model
		private Guid _id;
		private string _emr_code;
		private string _patient_name;
		private string _patient_age;
		private int _patient_sex;
		private string _patient_tel;
		private string _patient_wechatcode;
		private string _main_suit;
		private string _allergy_history;
		private string _medical_history;
		private string _therapeutic_schedule;
		private string _doctorremark;
		private string _cremark;
		private int _emr_status;
        private int _treatment_status;
		private DateTime? _confirm_time;
		private DateTime? _processing_time;
		private string _processing_requirement;
		private DateTime? _order_time;
		private DateTime? _pay_time;
		private DateTime? _production_time;
		private DateTime? _delivery_time;
		private DateTime? _end_time;
		private DateTime _createdate;
		private Guid _createid;
		private DateTime? _modifydate;
		private Guid _modifyid;
		private int _flag;
        private string _doctorRemarkDate;

      
		/// <summary>
		/// id,建议创建时为guid
		/// </summary>
		public Guid Id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 病历号
		/// </summary>
		public string EMR_Code
		{
			set{ _emr_code=value;}
			get{return _emr_code;}
		}
		/// <summary>
		/// 名字
		/// </summary>
		public string patient_Name
		{
			set{ _patient_name=value;}
			get{return _patient_name;}
		}
		/// <summary>
		/// 年龄
		/// </summary>
		public string patient_Age
		{
			set{ _patient_age=value;}
			get{return _patient_age;}
		}
		/// <summary>
		/// 性别
		/// </summary>
		public int patient_Sex
		{
			set{ _patient_sex=value;}
			get{return _patient_sex;}
		}
		/// <summary>
		/// 电话
		/// </summary>
		public string patient_Tel
		{
			set{ _patient_tel=value;}
			get{return _patient_tel;}
		}
		/// <summary>
		/// 微信（暂时无法得知是否能够获取微信号）
		/// </summary>
		public string patient_WeChatCode
		{
			set{ _patient_wechatcode=value;}
			get{return _patient_wechatcode;}
		}
		/// <summary>
		/// 主诉
		/// </summary>
		public string main_suit
		{
			set{ _main_suit=value;}
			get{return _main_suit;}
		}
		/// <summary>
		/// 过敏史
		/// </summary>
		public string allergy_history
		{
			set{ _allergy_history=value;}
			get{return _allergy_history;}
		}
		/// <summary>
		/// 治疗史
		/// </summary>
		public string Medical_history
		{
			set{ _medical_history=value;}
			get{return _medical_history;}
		}
		/// <summary>
		/// 治疗方案
		/// </summary>
		public string therapeutic_schedule
		{
			set{ _therapeutic_schedule=value;}
			get{return _therapeutic_schedule;}
		}
		/// <summary>
		/// 医生随笔
		/// </summary>
		public string doctorRemark
		{
			set{ _doctorremark=value;}
			get{return _doctorremark;}
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
		/// 订单状态
		/// </summary>
		public int emr_status
		{
			set{ _emr_status=value;}
			get{return _emr_status;}
		}
        /// <summary>
        /// 就诊状态
        /// </summary>
        public int treatment_status
        {
            set { _treatment_status = value; }
            get { return _treatment_status; }
        }
		/// <summary>
		/// 确定时间
		/// </summary>
		public DateTime? confirm_time
		{
			set{ _confirm_time=value;}
			get{return _confirm_time;}
		}
		/// <summary>
		/// 加工时间
		/// </summary>
		public DateTime? processing_time
		{
			set{ _processing_time=value;}
			get{return _processing_time;}
		}
		/// <summary>
		/// 加工描述
	///
		/// </summary>
		public string processing_requirement
		{
			set{ _processing_requirement=value;}
			get{return _processing_requirement;}
		}
		/// <summary>
		/// 接单时间
		/// </summary>
		public DateTime? order_time
		{
			set{ _order_time=value;}
			get{return _order_time;}
		}
		/// <summary>
		/// 付款时间
		/// </summary>
		public DateTime? pay_time
		{
			set{ _pay_time=value;}
			get{return _pay_time;}
		}
		/// <summary>
		/// 排产时间
		/// </summary>
		public DateTime? production_time
		{
			set{ _production_time=value;}
			get{return _production_time;}
		}
		/// <summary>
		/// 发货时间
	///
		/// </summary>
		public DateTime? delivery_time
		{
			set{ _delivery_time=value;}
			get{return _delivery_time;}
		}
		/// <summary>
		/// 结束时间
		/// </summary>
		public DateTime? end_time
		{
			set{ _end_time=value;}
			get{return _end_time;}
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
        /// 医生随笔时间
        /// </summary>
        public string doctorRemarkDate
        {
            get { return _doctorRemarkDate; }
            set { _doctorRemarkDate = value; }
        }
		#endregion Model

	}
}


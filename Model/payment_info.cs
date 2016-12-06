using System;
namespace DentalMedical.Model
{
	/// <summary>
	/// payment_info:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class payment_info
	{
		
        public payment_info()
        { }
        #region Model
        private Guid _id;
        private string _emr_code;
        private Guid _factory_id;
        private string _channel;
        private string _type;
        private decimal _money;
        private string _bill_code;
        private bool _isinvoice;
        private string _cremark;
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
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 病历编号
        /// </summary>
        public string EMR_Code
        {
            set { _emr_code = value; }
            get { return _emr_code; }
        }
        /// <summary>
        /// 工厂ID
        /// </summary>
        public Guid factory_Id
        {
            set { _factory_id = value; }
            get { return _factory_id; }
        }
        /// <summary>
        /// 渠道 支付宝等
        /// </summary>
        public string channel
        {
            set { _channel = value; }
            get { return _channel; }
        }
        /// <summary>
        /// 付款，退款
        /// </summary>
        public string type
        {
            set { _type = value; }
            get { return _type; }
        }
        /// <summary>
        /// 金额
        /// </summary>
        public decimal money
        {
            set { _money = value; }
            get { return _money; }
        }
        /// <summary>
        /// 单号
        /// </summary>
        public string bill_code
        {
            set { _bill_code = value; }
            get { return _bill_code; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool isInvoice
        {
            set { _isinvoice = value; }
            get { return _isinvoice; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string cRemark
        {
            set { _cremark = value; }
            get { return _cremark; }
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime createDate
        {
            set { _createdate = value; }
            get { return _createdate; }
        }
        /// <summary>
        /// 创建人
        /// </summary>
        public Guid createId
        {
            set { _createid = value; }
            get { return _createid; }
        }
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime? modifyDate
        {
            set { _modifydate = value; }
            get { return _modifydate; }
        }
        /// <summary>
        /// 修改人
        /// </summary>
        public Guid modifyId
        {
            set { _modifyid = value; }
            get { return _modifyid; }
        }
        /// <summary>
        /// 是否有效
        /// </summary>
        public int flag
        {
            set { _flag = value; }
            get { return _flag; }
        }
        #endregion Model

	}
}


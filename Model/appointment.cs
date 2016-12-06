using System;
namespace DentalMedical.Model
{
    /// <summary>
    /// appointment:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class appointment
    {
        public appointment()
        { }
        #region Model
        private Guid _id;
        private string _patientname;
        private string _patienttel;
        private string _appointment_add;
        private string _appointment_demand;
        private string _appointment_date;
        private int? _orderid;
        private DateTime? _createdate;
        private Guid _createid;
        private DateTime? _modifydate;
        private Guid _modifyid;
        private int _flag;
        /// <summary>
        /// 
        /// </summary>
        public Guid Id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string patientName
        {
            set { _patientname = value; }
            get { return _patientname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string patientTel
        {
            set { _patienttel = value; }
            get { return _patienttel; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string appointment_Add
        {
            set { _appointment_add = value; }
            get { return _appointment_add; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string appointment_demand
        {
            set { _appointment_demand = value; }
            get { return _appointment_demand; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string appointment_Date
        {
            set { _appointment_date = value; }
            get { return _appointment_date; }
        }
        /// <summary>
        /// 排序
        /// </summary>
        public int? orderId
        {
            set { _orderid = value; }
            get { return _orderid; }
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? createDate
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


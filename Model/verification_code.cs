using System;
namespace DentalMedical.Model
{
    /// <summary>
    /// verification_code:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class verification_code
    {
        public verification_code()
        { }
        #region Model
        private Guid _id;
        private string _v_code;
        private int? _code_type;
        private int? _orderid;
        private DateTime? _createdate;
        private Guid _createid;
        private DateTime? _modifydate;
        private Guid _modifyid;
        private int _flag = 1;
        /// <summary>
        /// 
        /// </summary>
        public Guid id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string v_code
        {
            set { _v_code = value; }
            get { return _v_code; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? code_type
        {
            set { _code_type = value; }
            get { return _code_type; }
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


using System;
namespace DentalMedical.Model
{
    /// <summary>
    /// authorize_technician:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class authorize_technician
    {
        public authorize_technician()
        { }
        #region Model
        private Guid _id;
        private Guid _doctorid;
        private Guid _dcid;
        private Guid _mechanicid;
        private int? _orderid;
        private string _userremark;
        private DateTime _createdate = DateTime.Now;
        private Guid _createid;
        private DateTime? _modifydate;
        private Guid _modifyid;
        private int _flag = 1;
        /// <summary>
        /// id,建议创建时为guid
        /// </summary>
        public Guid Id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 医生Id
        /// </summary>
        public Guid doctorId
        {
            set { _doctorid = value; }
            get { return _doctorid; }
        }
        /// <summary>
        /// 医生认证Id
        /// </summary>
        public Guid dcId
        {
            set { _dcid = value; }
            get { return _dcid; }
        }
        /// <summary>
        /// 技师Id
        /// </summary>
        public Guid mechanicId
        {
            set { _mechanicid = value; }
            get { return _mechanicid; }
        }
        /// <summary>
        /// 排序号
        /// </summary>
        public int? orderId
        {
            set { _orderid = value; }
            get { return _orderid; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string userRemark
        {
            set { _userremark = value; }
            get { return _userremark; }
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


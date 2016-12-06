using System;
namespace DentalMedical.Model
{
    /// <summary>
    /// doctor_essays:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class doctor_essays
    {
        public doctor_essays()
        { }
        #region Model
        private Guid _id;
        private string _emr_code;
        private string _doctorremarkdate;
        private string _doctorremark;
        private DateTime _createdate ;
        private Guid _createid;
        private DateTime? _modifydate;
        private Guid _modifyid;
        private int _flag ;
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
        public string EMR_Code
        {
            set { _emr_code = value; }
            get { return _emr_code; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string doctorRemarkDate
        {
            set { _doctorremarkdate = value; }
            get { return _doctorremarkdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string doctorRemark
        {
            set { _doctorremark = value; }
            get { return _doctorremark; }
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


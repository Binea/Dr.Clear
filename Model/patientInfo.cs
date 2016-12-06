using System;
namespace DentalMedical.Model
{
    /// <summary>
    /// patientInfo:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class patientInfo
    {
        public patientInfo()
        { }
        #region Model
        private Guid _id;
        private string _weixin;
        private string _patientcode;
        private string _patientpwd;
        private string _patientname;
        private int? _patientsex;
        private string _patienttel;
        private string _patientemail;
        private DateTime? _patientbirthday;
        private string _patientaddress;
        private string _patientvocation;
        private string _patientlogo;
        private string _nickname;
        private string _headimgurl;
        private int? _onlinestatus;
        private string _cremark;
        private DateTime _createdate;
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
        /// 电话号码唯一
        /// </summary>
        public string weixin
        {
            set { _weixin = value; }
            get { return _weixin; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string patientCode
        {
            set { _patientcode = value; }
            get { return _patientcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string patientPwd
        {
            set { _patientpwd = value; }
            get { return _patientpwd; }
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
        public int? patientSex
        {
            set { _patientsex = value; }
            get { return _patientsex; }
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
        public string patientEmail
        {
            set { _patientemail = value; }
            get { return _patientemail; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? patientBirthday
        {
            set { _patientbirthday = value; }
            get { return _patientbirthday; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string patientAddress
        {
            set { _patientaddress = value; }
            get { return _patientaddress; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string patientVocation
        {
            set { _patientvocation = value; }
            get { return _patientvocation; }
        }
        /// <summary>
        /// 用户头像
        /// </summary>
        public string patientLogo
        {
            set { _patientlogo = value; }
            get { return _patientlogo; }
        }
        /// <summary>
        /// 微信昵称
        /// </summary>
        public string nickname
        {
            set { _nickname = value; }
            get { return _nickname; }
        }
        /// <summary>
        /// 微信头像
        /// </summary>
        public string HeadImgUrl
        {
            set { _headimgurl = value; }
            get { return _headimgurl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? onlineStatus
        {
            set { _onlinestatus = value; }
            get { return _onlinestatus; }
        }
        /// <summary>
        /// 
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


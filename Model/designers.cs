using System;
namespace DentalMedical.Model
{
    /// <summary>
    /// designers:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class designers
    {
        public designers()
        { }
        #region Model
        private Guid _id;
        private string _usercode;
        private string _usertel;
        private string _userpwd;
        private string _useremail;
        private int _userkey;
        private string _userpetname;
        private string _userlogo;
        private string _userrealname;
        private int? _usersex;
        private DateTime? _userbirthday;
        private string _useraddress;
        private int? _userworkyears;
        private int? _userschool;
        private string _userblog;
        private int _onlinestatus = 0;
        private string _f_invit_code;
        private Guid _doctor_id;
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
        /// 用户账户，目前为手机号注册
        /// </summary>
        public string userCode
        {
            set { _usercode = value; }
            get { return _usercode; }
        }
        /// <summary>
        /// 电话
        /// </summary>
        public string userTel
        {
            set { _usertel = value; }
            get { return _usertel; }
        }
        /// <summary>
        /// 密码
        /// </summary>
        public string userPwd
        {
            set { _userpwd = value; }
            get { return _userpwd; }
        }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string userEmail
        {
            set { _useremail = value; }
            get { return _useremail; }
        }
        /// <summary>
        /// 验证号
        ///
        /// </summary>
        public int userKey
        {
            set { _userkey = value; }
            get { return _userkey; }
        }
        /// <summary>
        /// 昵称
        /// </summary>
        public string userPetName
        {
            set { _userpetname = value; }
            get { return _userpetname; }
        }
        /// <summary>
        /// 头像
        /// </summary>
        public string userLogo
        {
            set { _userlogo = value; }
            get { return _userlogo; }
        }
        /// <summary>
        /// 真名
        /// </summary>
        public string userRealName
        {
            set { _userrealname = value; }
            get { return _userrealname; }
        }
        /// <summary>
        /// 性别
        /// </summary>
        public int? userSex
        {
            set { _usersex = value; }
            get { return _usersex; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? userBirthday
        {
            set { _userbirthday = value; }
            get { return _userbirthday; }
        }
        /// <summary>
        /// 联系地址
        /// </summary>
        public string userAddress
        {
            set { _useraddress = value; }
            get { return _useraddress; }
        }
        /// <summary>
        /// 工作年限
        /// </summary>
        public int? userWorkYears
        {
            set { _userworkyears = value; }
            get { return _userworkyears; }
        }
        /// <summary>
        /// 毕业院校
        /// </summary>
        public int? userSchool
        {
            set { _userschool = value; }
            get { return _userschool; }
        }
        /// <summary>
        /// 博客
        /// </summary>
        public string userBlog
        {
            set { _userblog = value; }
            get { return _userblog; }
        }
        /// <summary>
        /// 在线状态
        /// </summary>
        public int onlineStatus
        {
            set { _onlinestatus = value; }
            get { return _onlinestatus; }
        }
        /// <summary>
        /// 厂房邀请码
        /// </summary>
        public string f_invit_code
        {
            set { _f_invit_code = value; }
            get { return _f_invit_code; }
        }
        /// <summary>
        /// 用户号
        /// </summary>
        public Guid doctor_Id
        {
            set { _doctor_id = value; }
            get { return _doctor_id; }
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


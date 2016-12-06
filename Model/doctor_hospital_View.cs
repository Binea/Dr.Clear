using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalMedical.Model
{
    /// <summary>
    /// doctor_hospital_View视图实体类
    /// </summary>
    [Serializable]
    public partial class doctor_hospital_View
    {
        public doctor_hospital_View()
        { }
        #region Model
        private Guid _id;
        private Guid _dcid;
        private string _userrealname;
        private string _dename;
        private Guid _deid;
        private string _titlename;
        private Guid _titleid;
        private Guid _hospitalid;
        private string _hospitalname;
        private int? _dcStatus;
        private string _work_Card;

        public string work_Card
        {
            get { return _work_Card; }
            set { _work_Card = value; }
        }
        public int? dcStatus
        {
            get { return _dcStatus; }
            set { _dcStatus = value; }
        }
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
        public Guid dcId
        {
            set { _dcid = value; }
            get { return _dcid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string userRealName
        {
            set { _userrealname = value; }
            get { return _userrealname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string deName
        {
            set { _dename = value; }
            get { return _dename; }
        }
        /// <summary>
        /// 
        /// </summary>
        public Guid deId
        {
            set { _deid = value; }
            get { return _deid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string titleName
        {
            set { _titlename = value; }
            get { return _titlename; }
        }
        /// <summary>
        /// 
        /// </summary>
        public Guid titleId
        {
            set { _titleid = value; }
            get { return _titleid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public Guid hospitalId
        {
            set { _hospitalid = value; }
            get { return _hospitalid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string hospitalName
        {
            set { _hospitalname = value; }
            get { return _hospitalname; }
        }
        #endregion Model

    }
}

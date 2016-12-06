using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalMedical.Model
{
    /// <summary>
    /// EMR_stream:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class EMR_stream
    {
        public EMR_stream()
        { }
        #region Model
        private Guid _id;
        private string _emr_code;
        private string _message;
        private int? _orderid;
        private string _factoryremark;
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
        public string message
        {
            set { _message = value; }
            get { return _message; }
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
        public string factoryRemark
        {
            set { _factoryremark = value; }
            get { return _factoryremark; }
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

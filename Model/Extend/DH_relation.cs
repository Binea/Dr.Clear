using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalMedical.Model.Extend
{
    public partial class DH_relation
    {
        private string _hospitalName;
        /// <summary>
        /// 医院名称
        /// </summary>
        public string hospitalName
        {
            get { return _hospitalName; }
            set { _hospitalName = value; }
        }
        private string _deName;
        /// <summary>
        /// 科室名称
        /// </summary>
        public string deName
        {
            get { return _deName; }
            set { _deName = value; }
        }
        private string _hospitalCode;

        /// <summary>
        /// 医院所在城市代码
        /// </summary>
        public string hospitalCode
        {
            get { return _hospitalCode; }
            set { _hospitalCode = value; }
        }
    }
}

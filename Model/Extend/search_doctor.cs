using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalMedical.Model
{
    public class search_doctor
    {
       
            private Guid _hospitalId;
            public Guid hospitalId
            {
                get { return _hospitalId; }
                set { _hospitalId = value; }
            }

            private string _hospitalName;
            public string hospitalName
            {
                get { return _hospitalName; }
                set { _hospitalName = value; }
            }

            private string _hospitalAddress;
            public string hospitalAddress
            {
                get { return _hospitalAddress; }
                set { _hospitalAddress = value; }
            }

            private string _hospitalTel;
            public string hospitalTel
            {
                get { return _hospitalTel; }
                set { _hospitalTel = value; }
            }

            private Guid _doctorId;
            public Guid doctorId
            {
                get { return _doctorId; }
                set { _doctorId = value; }
            }

            private string _userRealName;
            public string userRealName
            {
                get { return _userRealName; }
                set { _userRealName = value; }
            }

            private string _userTel;
            public string userTel
            {
                get { return _userTel; }
                set { _userTel = value; }
            }

            private string _userLogo;
            public string userLogo
            {
                get { return _userLogo; }
                set { _userLogo = value; }
            }

        }

    
}

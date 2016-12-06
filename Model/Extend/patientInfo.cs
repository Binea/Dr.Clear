using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalMedical.Model
{
    public partial class patientInfo
    {
        private string sPatientbirthday;

        public string SPatientbirthday
        {
            get { return sPatientbirthday; }
            set { sPatientbirthday = value; }
        }
    }
}

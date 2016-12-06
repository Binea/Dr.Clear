using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalMedical.Model
{
    public partial class EMR_stream
    {
        private string _doctorName;

        public string doctorName
        {
            get { return _doctorName; }
            set { _doctorName = value; }
        }
        private string _factoryName;

        public string factoryName
        {
            get { return _factoryName; }
            set { _factoryName = value; }
        }

        private string _patient_department;

        public string patient_department
        {
            get { return _patient_department; }
            set { _patient_department = value; }
        }
        private string _patientName;

        public string patientName
        {
            get { return _patientName; }
            set { _patientName = value; }
        }
        private string _patientSex;

        public string patientSex
        {
            get { return _patientSex; }
            set { _patientSex = value; }
        }
        private string _patientage;

        public string patientage
        {
            get { return _patientage; }
            set { _patientage = value; }
        }
        private string _patientTel;

        public string patientTel
        {
            get { return _patientTel; }
            set { _patientTel = value; }
        }

        private string sCreateDate;

        public string SCreateDate
        {
            get { return sCreateDate; }
            set { sCreateDate = value; }
        }
    }
}

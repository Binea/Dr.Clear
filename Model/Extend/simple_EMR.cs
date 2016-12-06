using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalMedical.Model
{
    public partial class simple_EMR
    {
        public Guid doctor_Id { get; set; }
        public string doctor_Name { get; set; }
        public string doctor_tel { get; set; }
        public Guid hospital_Id { get; set; }
        public string hospital_Name { get; set; }
        public Guid de_Id { get; set; }
        public string de_Name { get; set; }        
        public IList<dental_model> dental_model { get; set; }
        public IList<design_scheme> design_scheme { get; set; }
        public IList<FaceImage> FaceImage { get; set; }
        public IList<DCImage> DCImage { get; set; }
        public IList<rootImage> rootImage { get; set; }
        public IList<archiving_model> archiving_model { get; set; }

        public string expressName { get; set; }
        public string express_billCode { get; set; }
        public IList<doctor_essays> doctor_essays { get; set; }

        public IList<stl_d_data> stl_d_data { get; set; }
    }
}

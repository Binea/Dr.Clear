using System;
using System.Collections.Generic;
namespace DentalMedical.Model
{
	/// <summary>
	/// doctors:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
    public partial class doctors
    {
        public IList<doctor_hospital_View> doctor_hospital_View { get; set; }
    }
}


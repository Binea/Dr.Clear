using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalMedical.Model
{
    public class WX_simple_emr
    {
        /// <summary>
        /// 病例编号
        /// </summary>
        public string EMR_code { get; set; }
        /// <summary>
        /// 诊前时间
        /// </summary>
        public string pre_time { get; set; }
        /// <summary>
        /// 诊前信息
        /// </summary>
        public string pre_info { get; set; }
        /// <summary>
        /// 诊中时间
        /// </summary>
        public string middle_time { get; set; }
        /// <summary>
        /// 诊中信息
        /// </summary>
        public string middle_info { get; set; }
        /// <summary>
        /// 诊后时间
        /// </summary>
        public string end_time { get; set; }
        /// <summary>
        /// 诊后信息
        /// </summary>
        public string end_info { get; set; }
        /// <summary>
        /// 病人电话
        /// </summary>
        public string patient_tel { get; set; }
        /// <summary>
        /// 病人头像
        /// </summary>
        public string patient_logo { get; set; }
        /// <summary>
        /// 病人姓名
        /// </summary>
        public string patient_name { get; set; }
        /// <summary>
        /// 病人年龄
        /// </summary>
        public int? patient_age { get; set; }
        /// <summary>
        /// 病人性别
        /// </summary>
        public int? patient_sex { get; set; }
        /// <summary>
        /// 病人科目
        /// </summary>
        public string patient_department { get; set; }
        /// <summary>
        /// 提示时间
        /// </summary>
        public string cue_time { get; set; }
        /// <summary>
        /// 提示地址
        /// </summary>
        public string cue_add { get; set; }
        /// <summary>
        /// 提示提醒
        /// </summary>
        public string cue_tip{ get; set; }

        /// <summary>
        /// 病例状态
        /// </summary>
        public int status { get; set; }

        public IList<dental_model> dental_model { get; set; }
        public IList<design_scheme> design_scheme { get; set; }
        public IList<FaceImage> FaceImage { get; set; }
        public IList<DCImage> DCImage { get; set; }
        public IList<rootImage> rootImage { get; set; }
        public IList<archiving_model> archiving_model { get; set; }
    }
}

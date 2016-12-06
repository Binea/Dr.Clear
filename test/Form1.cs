using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using DentalMedical.DALFactory;
using DentalMedical.SQLServerDAL;
using DentalMedical.Common;
using System.Collections;

namespace test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private static readonly string AssemblyPath = ConfigurationManager.AppSettings["DAL"];       
        private void button1_Click(object sender, EventArgs e)
        {
            string a= StringUtil.StripSQLInjection(@"SELECT  emr.Id ,
                            emr.EMR_Code ,
                            patient_Name ,
                            patient_Age ,
                            patient_Sex ,
                            patient_Tel ,
                            patient_WeChatCode ,
                            main_suit ,
                            allergy_history ,
                            Medical_history ,
                            therapeutic_schedule ,
                            doctorRemarkDate,
                            doctorRemark ,
                            emr.cRemark ,
                            emr_status ,
                            treatment_status,
                            confirm_time ,
                            processing_time ,
                            processing_requirement ,
                            order_time ,
                            pay_time ,
                            production_time ,
                            delivery_time ,
                            end_time ,
                            emr.createDate ,
                            emr.createId ,
                            emr.modifyDate ,
                            emr.modifyId ,
                            emr.flag
                             FROM    [dbo].[simple_EMR] emr
        LEFT JOIN dbo.HDE_relation hde ON hde.EMR_Code = emr.EMR_Code
                                          AND hde.flag = 1
                            WHERE   emr.flag = 1
                                AND hde.hospital_Id = 'asdasd'
                                AND hde.doctor_Id = 'asdasd'  ORDER BY emr.createDate DESC
                                ");
            //DentalMedical.BLL.doctors dc = new DentalMedical.BLL.doctors();

            //DentalMedical.SQLServerDAL.doctors dca = new doctors();
            //dca.Login_doctor("13636661623", "12312312");
            //MessageBox.Show(AssemblyPath);

            //dc.Login_D("13636661623","12312312");
            //textBox1.Text= StringUtil.MakeRndInt(6).ToString();
            //textBox2.Text = StringUtil.RandNum(6).ToString();
            //textBox3.Text = StringUtil.GetRandomString(5).ToString();
            //string a =null;
            //textBox3.Text = "a" + a;
            //Hashtable hashTable = new Hashtable();
            //hashTable.Add(1, "wuyi");
            //hashTable.Add(2, "sky");
            //Hashtable ht = new Hashtable();
            //ht.Add("测试", "测试");
            ////第一种方法遍历  
            //foreach(DictionaryEntry de in hashTable)  
            //{  
            // ht.Add(de.Key,de.Value);
            //}  
        }
        //private  object CreateObject123(string AssemblyPath, string classNamespace)
        //{
        //    object objType = DataCache.GetCache(classNamespace);
        //    if (objType == null)
        //    {
        //        try
        //        {
        //            objType = Assembly.Load(AssemblyPath).CreateInstance(classNamespace);
        //            DataCache.SetCache(classNamespace, objType);// 写入缓存
        //        }
        //        catch(Exception ex)
        //        {
        //            string str=ex.Message;// 记录错误日志
        //        }
        //    }
        //    return objType;
        //}


        ///// <summary>
        ///// 创建doctors数据层接口。
        ///// </summary>
        //public  DentalMedical.IDAL.Idoctors Createdoctors123()
        //{

        //    string ClassNamespace = AssemblyPath + ".doctors";
        //    object objType = CreateObject123(AssemblyPath, ClassNamespace);
        //    return (DentalMedical.IDAL.Idoctors)objType;
        //}
    }
}

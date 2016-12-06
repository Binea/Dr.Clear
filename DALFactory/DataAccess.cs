using System;
using System.Reflection;
using System.Configuration;
namespace DentalMedical.DALFactory
{
    /// <summary>
    /// Abstract Factory pattern to create the DAL。
    /// 如果在这里创建对象报错，请检查web.config里是否修改了<add key="DAL" value="DentalMedical.SQLServerDAL" />。
    /// </summary>
    public sealed class DataAccess
    {
        private static readonly string AssemblyPath = ConfigurationManager.AppSettings["DAL"];
        public DataAccess()
        { }

        #region CreateObject

        //不使用缓存
        private static object CreateObjectNoCache(string AssemblyPath, string classNamespace)
        {
            try
            {
                object objType = Assembly.Load(AssemblyPath).CreateInstance(classNamespace);
                return objType;
            }
            catch//(System.Exception ex)
            {
                //string str=ex.Message;// 记录错误日志
                return null;
            }

        }
        //使用缓存
        private static object CreateObject(string AssemblyPath, string classNamespace)
        {
            object objType = DataCache.GetCache(classNamespace);
            if (objType == null)
            {
                try
                {
                    objType = Assembly.Load(AssemblyPath).CreateInstance(classNamespace);
                    DataCache.SetCache(classNamespace, objType);// 写入缓存
                }
                catch//(System.Exception ex)
                {
                    //string str=ex.Message;// 记录错误日志
                }
            }
            return objType;
        }
        #endregion

        #region 泛型生成
        ///// <summary>
        ///// 创建数据层接口。
        ///// </summary>
        //public static t Create(string ClassName)
        //{

        //    string ClassNamespace = AssemblyPath +"."+ ClassName;
        //    object objType = CreateObject(AssemblyPath, ClassNamespace);
        //    return (t)objType;
        //}
        #endregion

        #region CreateSysManage
        public static DentalMedical.IDAL.ISysManage CreateSysManage()
        {
            //方式1			
            //return (DentalMedical.IDAL.ISysManage)Assembly.Load(AssemblyPath).CreateInstance(AssemblyPath+".SysManage");

            //方式2 			
            string classNamespace = AssemblyPath + ".SysManage";
            object objType = CreateObject(AssemblyPath, classNamespace);
            return (DentalMedical.IDAL.ISysManage)objType;
        }
        #endregion



        /// <summary>
        /// 创建base_data数据层接口。
        /// </summary>
        public static DentalMedical.IDAL.Ibase_data Createbase_data()
        {

            string ClassNamespace = AssemblyPath + ".base_data";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (DentalMedical.IDAL.Ibase_data)objType;
        }


        /// <summary>
        /// 创建DCImage数据层接口。
        /// </summary>
        public static DentalMedical.IDAL.IDCImage CreateDCImage()
        {

            string ClassNamespace = AssemblyPath + ".DCImage";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (DentalMedical.IDAL.IDCImage)objType;
        }


        /// <summary>
        /// 创建dental_model数据层接口。
        /// </summary>
        public static DentalMedical.IDAL.Idental_model Createdental_model()
        {

            string ClassNamespace = AssemblyPath + ".dental_model";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (DentalMedical.IDAL.Idental_model)objType;
        }


        /// <summary>
        /// 创建departments数据层接口。
        /// </summary>
        public static DentalMedical.IDAL.Idepartments Createdepartments()
        {

            string ClassNamespace = AssemblyPath + ".departments";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (DentalMedical.IDAL.Idepartments)objType;
        }


        /// <summary>
        /// 创建design_scheme数据层接口。
        /// </summary>
        public static DentalMedical.IDAL.Idesign_scheme Createdesign_scheme()
        {

            string ClassNamespace = AssemblyPath + ".design_scheme";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (DentalMedical.IDAL.Idesign_scheme)objType;
        }


        /// <summary>
        /// 创建DH_relation数据层接口。
        /// </summary>
        public static DentalMedical.IDAL.IDH_relation CreateDH_relation()
        {

            string ClassNamespace = AssemblyPath + ".DH_relation";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (DentalMedical.IDAL.IDH_relation)objType;
        }


        /// <summary>
        /// 创建doctor_certification数据层接口。
        /// </summary>
        public static DentalMedical.IDAL.Idoctor_certification Createdoctor_certification()
        {

            string ClassNamespace = AssemblyPath + ".doctor_certification";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (DentalMedical.IDAL.Idoctor_certification)objType;
        }


        /// <summary>
        /// 创建doctors数据层接口。
        /// </summary>
        public static DentalMedical.IDAL.Idoctors Createdoctors()
        {

            string ClassNamespace = AssemblyPath + ".doctors";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (DentalMedical.IDAL.Idoctors)objType;
        }


        /// <summary>
        /// 创建express_info数据层接口。
        /// </summary>
        public static DentalMedical.IDAL.Iexpress_info Createexpress_info()
        {

            string ClassNamespace = AssemblyPath + ".express_info";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (DentalMedical.IDAL.Iexpress_info)objType;
        }


        /// <summary>
        /// 创建FaceImage数据层接口。
        /// </summary>
        public static DentalMedical.IDAL.IFaceImage CreateFaceImage()
        {

            string ClassNamespace = AssemblyPath + ".FaceImage";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (DentalMedical.IDAL.IFaceImage)objType;
        }


        /// <summary>
        /// 创建factory数据层接口。
        /// </summary>
        public static DentalMedical.IDAL.Ifactory Createfactory()
        {

            string ClassNamespace = AssemblyPath + ".factory";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (DentalMedical.IDAL.Ifactory)objType;
        }


        /// <summary>
        /// 创建factory_certification数据层接口。
        /// </summary>
        public static DentalMedical.IDAL.Ifactory_certification Createfactory_certification()
        {

            string ClassNamespace = AssemblyPath + ".factory_certification";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (DentalMedical.IDAL.Ifactory_certification)objType;
        }


        /// <summary>
        /// 创建FE_relation数据层接口。
        /// </summary>
        public static DentalMedical.IDAL.IFE_relation CreateFE_relation()
        {

            string ClassNamespace = AssemblyPath + ".FE_relation";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (DentalMedical.IDAL.IFE_relation)objType;
        }


        /// <summary>
        /// 创建FD_relation数据层接口。
        /// </summary>
        public static DentalMedical.IDAL.IFD_relation CreateFD_relation()
        {

            string ClassNamespace = AssemblyPath + ".FD_relation";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (DentalMedical.IDAL.IFD_relation)objType;
        }


        /// <summary>
        /// 创建HDE_relation数据层接口。
        /// </summary>
        public static DentalMedical.IDAL.IHDE_relation CreateHDE_relation()
        {

            string ClassNamespace = AssemblyPath + ".HDE_relation";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (DentalMedical.IDAL.IHDE_relation)objType;
        }


        /// <summary>
        /// 创建hospitals数据层接口。
        /// </summary>
        public static DentalMedical.IDAL.Ihospitals Createhospitals()
        {

            string ClassNamespace = AssemblyPath + ".hospitals";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (DentalMedical.IDAL.Ihospitals)objType;
        }


        /// <summary>
        /// 创建logistics_info数据层接口。
        /// </summary>
        public static DentalMedical.IDAL.Ilogistics_info Createlogistics_info()
        {

            string ClassNamespace = AssemblyPath + ".logistics_info";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (DentalMedical.IDAL.Ilogistics_info)objType;
        }


        /// <summary>
        /// 创建message_info数据层接口。
        /// </summary>
        public static DentalMedical.IDAL.Imessage_info Createmessage_info()
        {

            string ClassNamespace = AssemblyPath + ".message_info";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (DentalMedical.IDAL.Imessage_info)objType;
        }


        /// <summary>
        /// 创建paitentGif数据层接口。
        /// </summary>
        public static DentalMedical.IDAL.IpaitentGif CreatepaitentGif()
        {

            string ClassNamespace = AssemblyPath + ".paitentGif";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (DentalMedical.IDAL.IpaitentGif)objType;
        }


        /// <summary>
        /// 创建payment_info数据层接口。
        /// </summary>
        public static DentalMedical.IDAL.Ipayment_info Createpayment_info()
        {

            string ClassNamespace = AssemblyPath + ".payment_info";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (DentalMedical.IDAL.Ipayment_info)objType;
        }


        /// <summary>
        /// 创建rootImage数据层接口。
        /// </summary>
        public static DentalMedical.IDAL.IrootImage CreaterootImage()
        {

            string ClassNamespace = AssemblyPath + ".rootImage";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (DentalMedical.IDAL.IrootImage)objType;
        }


        /// <summary>
        /// 创建simple_EMR数据层接口。
        /// </summary>
        public static DentalMedical.IDAL.Isimple_EMR Createsimple_EMR()
        {

            string ClassNamespace = AssemblyPath + ".simple_EMR";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (DentalMedical.IDAL.Isimple_EMR)objType;
        }


        /// <summary>
        /// 创建sys_logs数据层接口。
        /// </summary>
        public static DentalMedical.IDAL.Isys_logs Createsys_logs()
        {

            string ClassNamespace = AssemblyPath + ".sys_logs";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (DentalMedical.IDAL.Isys_logs)objType;
        }


        /// <summary>
        /// 创建titles数据层接口。
        /// </summary>
        public static DentalMedical.IDAL.Ititles Createtitles()
        {

            string ClassNamespace = AssemblyPath + ".titles";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (DentalMedical.IDAL.Ititles)objType;
        }
        /// <summary>
        /// 创建invoice_open数据层接口。
        /// </summary>
        public static DentalMedical.IDAL.Iinvoice_open Createinvoice_open()
        {

            string ClassNamespace = AssemblyPath + ".invoice_open";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (DentalMedical.IDAL.Iinvoice_open)objType;
        }


        /// <summary>
        /// 创建invoice_info数据层接口。
        /// </summary>
        public static DentalMedical.IDAL.Iinvoice_info Createinvoice_info()
        {

            string ClassNamespace = AssemblyPath + ".invoice_info";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (DentalMedical.IDAL.Iinvoice_info)objType;
        }


        /// <summary>
        /// 创建area_BaseData数据层接口。
        /// </summary>
        public static DentalMedical.IDAL.Iarea_BaseData Createarea_BaseData()
        {

            string ClassNamespace = AssemblyPath + ".area_BaseData";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (DentalMedical.IDAL.Iarea_BaseData)objType;
        }
        /// <summary>
        /// 创建PI_relation数据层接口。
        /// </summary>
        public static DentalMedical.IDAL.IPI_relation CreatePI_relation()
        {

            string ClassNamespace = AssemblyPath + ".PI_relation";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (DentalMedical.IDAL.IPI_relation)objType;
        }


        /// <summary>
        /// 创建weixin_tel_relation数据层接口。
        /// </summary>
        public static DentalMedical.IDAL.Iweixin_tel_relation Createweixin_tel_relation()
        {

            string ClassNamespace = AssemblyPath + ".weixin_tel_relation";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (DentalMedical.IDAL.Iweixin_tel_relation)objType;
        }

        /// <summary>
        /// 创建EMR_stream数据层接口。
        /// </summary>
        public static DentalMedical.IDAL.IEMR_stream CreateEMR_stream()
        {

            string ClassNamespace = AssemblyPath + ".EMR_stream";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (DentalMedical.IDAL.IEMR_stream)objType;
        }
        /// <summary>
        /// 创建patientInfo数据层接口。
        /// </summary>
        public static DentalMedical.IDAL.IpatientInfo CreatepatientInfo()
        {

            string ClassNamespace = AssemblyPath + ".patientInfo";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (DentalMedical.IDAL.IpatientInfo)objType;
        }

        /// <summary>
        /// 创建archiving_model数据层接口。
        /// </summary>
        public static DentalMedical.IDAL.Iarchiving_model Createarchiving_model()
        {

            string ClassNamespace = AssemblyPath + ".archiving_model";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (DentalMedical.IDAL.Iarchiving_model)objType;
        }

        /// <summary>
        /// 创建appointment数据层接口。
        /// </summary>
        public static DentalMedical.IDAL.Iappointment Createappointment()
        {

            string ClassNamespace = AssemblyPath + ".appointment";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (DentalMedical.IDAL.Iappointment)objType;
        }

        /// <summary>
        /// 创建authorize_technician数据层接口。
        /// </summary>
        public static DentalMedical.IDAL.Iauthorize_technician Createauthorize_technician()
        {

            string ClassNamespace = AssemblyPath + ".authorize_technician";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (DentalMedical.IDAL.Iauthorize_technician)objType;
        }

        /// <summary>
        /// 创建designers数据层接口。
        /// </summary>
        public static DentalMedical.IDAL.Idesigners Createdesigners()
        {

            string ClassNamespace = AssemblyPath + ".designers";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (DentalMedical.IDAL.Idesigners)objType;
        }

        /// <summary>
        /// 创建stl_d_data数据层接口。
        /// </summary>
        public static DentalMedical.IDAL.Istl_d_data Createstl_d_data()
        {

            string ClassNamespace = AssemblyPath + ".stl_d_data";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (DentalMedical.IDAL.Istl_d_data)objType;
        }

        /// <summary>
        /// 创建verification_code数据层接口。
        /// </summary>
        public static DentalMedical.IDAL.Iverification_code Createverification_code()
        {

            string ClassNamespace = AssemblyPath + ".verification_code";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (DentalMedical.IDAL.Iverification_code)objType;
        }
    }
}
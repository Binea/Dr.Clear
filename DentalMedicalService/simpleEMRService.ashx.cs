using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using DentalMedical.Common;
using DentalMedical.DentalEnumeration;
namespace DentalMedicalService
{
    /// <summary>
    /// simpleEMRService 的摘要说明
    /// 2016-11-24 By Binea 改api接口用于病例的各种数据
    /// </summary>
    public class simpleEMRService : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string callback = context.Request["callback"];
            string type = context.Request["operationType"];
            string strJson = string.Empty;
            string ip = context.Request.UserHostAddress;
            string action = context.Request.CurrentExecutionFilePath;
            string browser = context.Request.Browser.Platform + "-" + context.Request.Browser.Type + "(" + context.Request.Browser.Version + ")";
            DentalMedical.BLL.sys_logs sl = new DentalMedical.BLL.sys_logs();
            DentalMedical.Model.sys_logs sl_model = new DentalMedical.Model.sys_logs();
            sl_model.clientInfo = browser;
            sl_model.IP = ip;
            sl_model.incident = action;
            DentalMedical.Model.JsData js = new DentalMedical.Model.JsData();
            try
            {

                #region 医生端列表


                if (type.Equals("d_list"))
                {
                    string dId = context.Request["doctorId"];
                    string hId = context.Request["hospitalId"];
                    string treatmentstatus = context.Request["treatmentstatus"];
                    DentalMedical.BLL.simple_EMR semr = new DentalMedical.BLL.simple_EMR();
                    List<DentalMedical.Model.simple_EMR> list = semr.EMR_D_list(dId, hId, int.Parse(treatmentstatus));
                    if (list != null)
                    {
                        js.code = "200";
                        js.message = "请求成功！";
                        js.data = list;
                        strJson = JsonHelper.SerializeObject(js);
                    }
                    else
                    {
                        js.code = "201";
                        js.message = "请求失败！";
                        js.data = "";
                        strJson = JsonHelper.SerializeObject(js);
                    }
                }
                #endregion
                #region 工厂端列表

                else if (type.Equals("f_list"))
                {
                    string fId = context.Request["factoryId"];
                    string status = context.Request["status"];
                    DentalMedical.BLL.simple_EMR semr = new DentalMedical.BLL.simple_EMR();
                    List<DentalMedical.Model.simple_EMR> list = semr.EMR_F_list(fId, int.Parse(status));
                    if (list != null)
                    {
                        js.code = "200";
                        js.message = "请求成功！";
                        js.data = list;
                        strJson = JsonHelper.SerializeObject(js);
                    }
                    else
                    {
                        js.code = "201";
                        js.message = "请求失败！";
                        js.data = "";
                        strJson = JsonHelper.SerializeObject(js);
                    }
                }
                #endregion
                #region 更新病例状态

                else if (type.Equals("update_emr_status"))
                {
                    string operationId = context.Request["Id"];
                    string emrcode = context.Request["emrcode"];
                    string status = context.Request["status"];
                    string processing_requirement = context.Request["processing_requirement"];
                    DentalMedical.BLL.simple_EMR semr = new DentalMedical.BLL.simple_EMR();
                    int result = semr.update_Emr_Status(int.Parse(status), emrcode, operationId, processing_requirement);
                    if (result > 0)
                    {
                        js.code = "200";
                        js.message = "请求成功！";
                        DentalMedical.Model.JsBool jsbool = new DentalMedical.Model.JsBool();
                        jsbool.result = true;
                        js.data = jsbool;
                        strJson = JsonHelper.SerializeObject(js);
                    }
                    else
                    {
                        js.code = "201";
                        js.message = "请求失败！";
                        js.data = "";
                        strJson = JsonHelper.SerializeObject(js);
                    }
                }
                #endregion
                #region 新增病例


                else if (type.Equals("New"))
                {
                    //using (TransactionScope ts = new TransactionScope())
                    //{
                    //新增病例
                    DentalMedical.BLL.simple_EMR semr = new DentalMedical.BLL.simple_EMR();
                    DentalMedical.Model.simple_EMR simple_emr_modle = new DentalMedical.Model.simple_EMR();
                    string patientName = context.Request["patientName"];
                    string patientSex = context.Request["patientSex"];
                    //string patientBirthday = context.Request["patientBirthday"];
                    string patientTel = context.Request["patientTel"];
                    string patientAge = context.Request["patientAge"];
                    string main_suit = context.Request["main_suit"];
                    string allergy_history = context.Request["allergy_history"];
                    string Medical_history = context.Request["Medical_history"];
                    string therapeutic_schedule = context.Request["therapeutic_schedule"];
                    string doctorId = context.Request["doctorId"];
                    string hospitalId = context.Request["hospitalId"];
                    string emrCode = context.Request["emrCode"];
                    string mailing = context.Request["mailing"];
                    if (string.IsNullOrEmpty(emrCode))
                        emrCode = StringUtil.DayOrderBillNo();
                    bool isermcode = true;
                    while (isermcode)
                    {
                        simple_emr_modle = semr.get_emr_byCode(emrCode);
                        if (simple_emr_modle != null)
                        {
                            emrCode = StringUtil.DayOrderBillNo();
                        }
                        else
                        {
                            isermcode = false;
                            simple_emr_modle = new DentalMedical.Model.simple_EMR();
                        }
                    }
                    Guid mainGuid = Guid.NewGuid();
                    simple_emr_modle.Id = mainGuid;
                    simple_emr_modle.patient_Name = ReplaceSQLChar(patientName);
                    simple_emr_modle.patient_Age = patientAge;
                    simple_emr_modle.patient_Sex = int.Parse(patientSex);
                    simple_emr_modle.patient_Tel = patientTel;
                    simple_emr_modle.EMR_Code = emrCode;
                    simple_emr_modle.emr_status = 0;
                    simple_emr_modle.createId = mainGuid;
                    simple_emr_modle.main_suit = ReplaceSQLChar(main_suit);
                    simple_emr_modle.allergy_history =  ReplaceSQLChar(allergy_history);
                    simple_emr_modle.Medical_history =  ReplaceSQLChar(Medical_history);
                    simple_emr_modle.therapeutic_schedule =  ReplaceSQLChar(therapeutic_schedule);
                    simple_emr_modle.flag = 1;
                    simple_emr_modle.cRemark =  ReplaceSQLChar(mailing);
                    //形象照集合
                    DentalMedical.BLL.FaceImage face = new DentalMedical.BLL.FaceImage();
                    DentalMedical.Model.FaceImage faceImage_Modle = new DentalMedical.Model.FaceImage();
                    faceImage_Modle.EMR_Code = emrCode;
                    faceImage_Modle.createId = mainGuid;
                    faceImage_Modle.flag = 1;
                    string f0 = context.Request["f0"];
                    faceImage_Modle.imagePath = f0;
                    faceImage_Modle.orderId = 0;
                    //face.Add(faceImage_Modle);
                    Hashtable facehash1 = face.Add_hash(faceImage_Modle);

                    string f1 = context.Request["f1"];
                    faceImage_Modle.imagePath = f1;
                    faceImage_Modle.orderId = 1;
                    //face.Add(faceImage_Modle);
                    Hashtable facehash2 = face.Add_hash(faceImage_Modle);
                    string f2 = context.Request["f2"];
                    faceImage_Modle.imagePath = f2;
                    faceImage_Modle.orderId = 2;
                    //face.Add(faceImage_Modle);
                    Hashtable facehash3 = face.Add_hash(faceImage_Modle);

                    string f3 = context.Request["f3"];
                    faceImage_Modle.imagePath = f3;
                    faceImage_Modle.orderId = 3;
                    //face.Add(faceImage_Modle);
                    Hashtable facehash4 = face.Add_hash(faceImage_Modle);
                    //牙冠照集合
                    DentalMedical.BLL.DCImage dcimage = new DentalMedical.BLL.DCImage();
                    DentalMedical.Model.DCImage dcImage_model = new DentalMedical.Model.DCImage();
                    dcImage_model.EMR_Code = emrCode;
                    dcImage_model.createId = mainGuid;
                    string d0 = context.Request["d0"];
                    dcImage_model.imagePath = d0;
                    dcImage_model.orderId = 0;
                    //dcimage.Add(dcImage_model);
                    Hashtable dchash0 = dcimage.Add_hash(dcImage_model);
                    string d1 = context.Request["d1"];
                    dcImage_model.imagePath = d1;
                    dcImage_model.orderId = 1;
                    //dcimage.Add(dcImage_model);
                    Hashtable dchash1 = dcimage.Add_hash(dcImage_model);
                    string d2 = context.Request["d2"];
                    dcImage_model.imagePath = d2;
                    dcImage_model.orderId = 2;
                    //dcimage.Add(dcImage_model);
                    Hashtable dchash2 = dcimage.Add_hash(dcImage_model);
                    string d3 = context.Request["d3"];
                    dcImage_model.imagePath = d3;
                    dcImage_model.orderId = 3;
                    //dcimage.Add(dcImage_model);
                    Hashtable dchash3 = dcimage.Add_hash(dcImage_model);
                    string d4 = context.Request["d4"];
                    dcImage_model.imagePath = d4;
                    dcImage_model.orderId = 4;
                    //dcimage.Add(dcImage_model);
                    Hashtable dchash4 = dcimage.Add_hash(dcImage_model);
                    //牙根照集合
                    DentalMedical.BLL.rootImage rootimage = new DentalMedical.BLL.rootImage();
                    DentalMedical.Model.rootImage rootImage_model = new DentalMedical.Model.rootImage();
                    rootImage_model.EMR_Code = emrCode;
                    rootImage_model.createId = mainGuid;
                    string r0 = context.Request["r0"];
                    rootImage_model.imagePath = r0;
                    rootImage_model.orderId = 0;
                    //rootimage.Add(rootImage_model);
                    Hashtable rthash0 = rootimage.Add_hash(rootImage_model);
                    string r1 = context.Request["r1"];
                    rootImage_model.imagePath = r1;
                    rootImage_model.orderId = 1;
                    //rootimage.Add(rootImage_model);
                    Hashtable rthash1 = rootimage.Add_hash(rootImage_model);
                    //bool result = semr.Add(simple_emr_modle);
                    Hashtable htsemr = semr.Add_hash(simple_emr_modle);
                    DentalMedical.BLL.HDE_relation hde = new DentalMedical.BLL.HDE_relation();
                    DentalMedical.Model.HDE_relation h = new DentalMedical.Model.HDE_relation();
                    h.EMR_Code = emrCode;
                    h.doctor_Id = new Guid(doctorId);
                    h.hospital_Id = new Guid(hospitalId);
                    h.createId = new Guid(doctorId);
                    //bool b = hde.Add(h);
                    Hashtable hdehash = hde.Add_hash(h);

                    DentalMedical.BLL.EMR_stream emrs = new DentalMedical.BLL.EMR_stream();
                    DentalMedical.Model.EMR_stream emr_stream = new DentalMedical.Model.EMR_stream();
                    emr_stream.message = "病例：" + emrCode + "创建！";
                    emr_stream.EMR_Code = emrCode;
                    emr_stream.createId = new Guid(doctorId);
                    Hashtable streamHash = emrs.Add_hash(emr_stream);

                    Hashtable ht = new Hashtable();

                    foreach (DictionaryEntry de in facehash1)
                    {
                        ht.Add(de.Key, de.Value);
                    }
                    foreach (DictionaryEntry de in facehash2)
                    {
                        ht.Add(de.Key, de.Value);
                    }
                    foreach (DictionaryEntry de in facehash3)
                    {
                        ht.Add(de.Key, de.Value);
                    }
                    foreach (DictionaryEntry de in facehash4)
                    {
                        ht.Add(de.Key, de.Value);
                    }
                    foreach (DictionaryEntry de in dchash0)
                    {
                        ht.Add(de.Key, de.Value);
                    }
                    foreach (DictionaryEntry de in dchash1)
                    {
                        ht.Add(de.Key, de.Value);
                    }
                    foreach (DictionaryEntry de in dchash2)
                    {
                        ht.Add(de.Key, de.Value);
                    }
                    foreach (DictionaryEntry de in dchash3)
                    {
                        ht.Add(de.Key, de.Value);
                    }
                    foreach (DictionaryEntry de in dchash4)
                    {
                        ht.Add(de.Key, de.Value);
                    }
                    foreach (DictionaryEntry de in rthash0)
                    {
                        ht.Add(de.Key, de.Value);
                    }
                    foreach (DictionaryEntry de in rthash1)
                    {
                        ht.Add(de.Key, de.Value);
                    }
                    foreach (DictionaryEntry de in htsemr)
                    {
                        ht.Add(de.Key, de.Value);
                    }
                    foreach (DictionaryEntry de in hdehash)
                    {
                        ht.Add(de.Key, de.Value);
                    }
                    foreach (DictionaryEntry de in streamHash)
                    {
                        ht.Add(de.Key, de.Value);
                    }
                    bool result = true;
                    simple_emr_modle = semr.simple_add_hash(ht, emrCode);
                    if (simple_emr_modle != null && !string.IsNullOrEmpty(simple_emr_modle.EMR_Code))
                    {
                        result = true;
                    }
                    else
                    {
                        result = false;
                    }
                    if (result)
                    {
                        js.code = "200";
                        js.message = "新建成功！";
                        DentalMedical.Model.JsBool jsbool = new DentalMedical.Model.JsBool();
                        jsbool.result = true;
                        js.data = jsbool;
                        strJson = JsonHelper.SerializeObject(js);
                    }
                    else
                    {
                        js.code = "201";
                        js.message = "新建失败！";
                        js.data = "";
                        strJson = JsonHelper.SerializeObject(js);
                    }
                    //    ts.Complete();  
                    //}
                }
                #endregion
                #region 更新医生随笔

                else if (type.Equals("update_doctorRemark"))
                {
                    DentalMedical.BLL.simple_EMR semr = new DentalMedical.BLL.simple_EMR();
                    string emrCode = context.Request["emrCode"];
                    string doctorRemark = context.Request["doctorRemark"];
                    doctorRemark = ReplaceSQLChar(doctorRemark);
                    string doctorRemarkDate = context.Request["doctorRemarkDate"];
                    string doctorId = context.Request["doctorId"];
                    if (string.IsNullOrEmpty(doctorId))
                    {
                        doctorId = Guid.Empty.ToString();
                    }
                    int result = semr.update_doctorRemark(emrCode, doctorRemark, doctorRemarkDate, doctorId);
                    if (result > 0)
                    {
                        js.code = "200";
                        js.message = "更新随笔成功！";
                        DentalMedical.Model.JsString JsId = new DentalMedical.Model.JsString();
                        JsId.jsString = emrCode;
                        js.data = JsId;
                        strJson = JsonHelper.SerializeObject(js);
                    }
                    else
                    {
                        js.code = "201";
                        js.message = "更新随笔失败！";
                        js.data = "";
                        strJson = JsonHelper.SerializeObject(js);
                    }
                }

                #endregion
                #region 获取病例详细信息

                else if (type.Equals("simple_emr"))
                {
                    DentalMedical.BLL.simple_EMR semr = new DentalMedical.BLL.simple_EMR();
                    string emrCode = context.Request["emrCode"];
                    DentalMedical.Model.simple_EMR simple_emr = semr.get_emr_byCode(emrCode);
                    if (simple_emr != null)
                    {
                        js.code = "200";
                        js.message = "请求成功！";
                        js.data = simple_emr;
                        strJson = JsonHelper.SerializeObject(js);
                    }
                    else
                    {
                        js.code = "201";
                        js.message = "请求失败！";
                        js.data = "";
                        strJson = JsonHelper.SerializeObject(js);
                    }
                }

                #endregion
                #region 获取病例流程

                else if (type.Equals("simple_stream"))
                {
                    string emrCode = context.Request["emrCode"];
                    List<DentalMedical.Model.EMR_stream> list = new List<DentalMedical.Model.EMR_stream>();
                    DentalMedical.BLL.simple_EMR semr = new DentalMedical.BLL.simple_EMR();
                    list = semr.get_stream(emrCode);
                    if (list != null && list.Count > 0)
                    {
                        js.code = "200";
                        js.message = "请求成功！";
                        js.data = list;
                        strJson = JsonHelper.SerializeObject(js);
                    }
                    else
                    {
                        js.code = "201";
                        js.message = "请求失败！";
                        js.data = "";
                        strJson = JsonHelper.SerializeObject(js);
                    }
                }

                #endregion
                #region 工厂端搜索

                else if (type.Equals("find_Emr_f"))
                {
                    string fId = context.Request["factoryId"];
                    string status = context.Request["status"];
                    string strwhere = context.Request["strwhere"];
                    strwhere = ReplaceSQLChar(strwhere);
                    DentalMedical.BLL.simple_EMR semr = new DentalMedical.BLL.simple_EMR();
                    List<DentalMedical.Model.simple_EMR> list = semr.find_Emr_f(fId, int.Parse(status), strwhere);
                    if (list != null)
                    {
                        js.code = "200";
                        js.message = "请求成功！";
                        js.data = list;
                        strJson = JsonHelper.SerializeObject(js);
                    }
                    else
                    {
                        js.code = "201";
                        js.message = "请求失败！";
                        js.data = "";
                        strJson = JsonHelper.SerializeObject(js);
                    }
                }

                #endregion
                #region 医生端搜索

                else if (type.Equals("find_Emr_d"))
                {
                    string dId = context.Request["doctorId"];
                    string hId = context.Request["hospitalId"];
                    string treatmentstatus = context.Request["treatmentstatus"];
                    string strwhere = context.Request["strwhere"];
                    strwhere = ReplaceSQLChar(strwhere);
                    DentalMedical.BLL.simple_EMR semr = new DentalMedical.BLL.simple_EMR();
                    List<DentalMedical.Model.simple_EMR> list = semr.find_Emr_d(dId, hId, int.Parse(treatmentstatus), strwhere);
                    if (list != null)
                    {
                        js.code = "200";
                        js.message = "请求成功！";
                        js.data = list;
                        strJson = JsonHelper.SerializeObject(js);
                    }
                    else
                    {
                        js.code = "201";
                        js.message = "请求失败！";
                        js.data = "";
                        strJson = JsonHelper.SerializeObject(js);
                    }
                }

                #endregion
                #region 发货

                else if (type.Equals("express"))
                {
                    string EMR_Code = context.Request["EMR_Code"];
                    string factory_Id = context.Request["factory_Id"];
                    string dsId = context.Request["design_scheme_Id"];
                    string expressName = context.Request["expressName"];
                    string express_billCode = context.Request["express_billCode"];
                    string cRemark = "方案设计模型发货";
                    DentalMedical.Model.logistics_info li = new DentalMedical.Model.logistics_info();
                    li.factory_Id = new Guid(factory_Id);
                    li.EMR_Code = EMR_Code;
                    li.dsId = new Guid(dsId);
                    li.expressName = expressName;
                    li.express_billCode = express_billCode;
                    li.createId = new Guid(factory_Id);
                    li.cRemark = cRemark;
                    DentalMedical.BLL.logistics_info li_bll = new DentalMedical.BLL.logistics_info();
                    bool result = li_bll.Add(li);
                    if (result)
                    {

                        DentalMedical.BLL.simple_EMR semr = new DentalMedical.BLL.simple_EMR();
                        int result2 = semr.update_Emr_Status(11, EMR_Code, factory_Id);
                        js.code = "200";
                        js.message = "请求成功！";
                        DentalMedical.Model.JsBool jsbool = new DentalMedical.Model.JsBool();
                        jsbool.result = true;
                        js.data = jsbool;
                        strJson = JsonHelper.SerializeObject(js);
                    }
                    else
                    {
                        js.code = "201";
                        js.message = "请求失败！";
                        js.data = "";
                        strJson = JsonHelper.SerializeObject(js);
                    }

                    sl_model.doctor_Id = new Guid(factory_Id);
                    sl_model.createId = new Guid(factory_Id);
                    sl_model.Entity = "simple_EMR";
                    sl_model.LogsType = (int)LogsType.动作;
                    sl_model.logmessage = "工厂：" + factory_Id + "  对病例号：" + EMR_Code + " 设计方案模型发货。 物流公司: " + expressName + "单号:" + express_billCode;
                    sl.Add(sl_model);
                }

                #endregion
                #region 文件是否更改

                else if (type.Equals("isFileChange"))
                {
                    string EMR_Code = context.Request["EMR_Code"];
                    string fileId = context.Request["fileId"];
                    string filetype = context.Request["filetype"];
                    string doctorId = context.Request["doctorId"];
                    DentalMedical.BLL.simple_EMR simple_EMR = new DentalMedical.BLL.simple_EMR();
                    bool result = simple_EMR.isChangeFile(EMR_Code, fileId, int.Parse(filetype));
                    if (result)
                    {
                        js.code = "200";
                        js.message = "请求成功！";
                        DentalMedical.Model.JsBool jsbool = new DentalMedical.Model.JsBool();
                        jsbool.result = true;
                        js.data = jsbool;
                        strJson = JsonHelper.SerializeObject(js);
                    }
                    else
                    {
                        js.code = "201";
                        js.message = "请求失败！";
                        js.data = "";
                        strJson = JsonHelper.SerializeObject(js);
                    }

                    sl_model.doctor_Id = new Guid(doctorId);
                    sl_model.createId = new Guid(doctorId);
                    sl_model.Entity = "simple_EMR";
                    sl_model.LogsType = (int)LogsType.动作;
                    sl_model.logmessage = "针对病例:" + EMR_Code + ",轮询是否有最新文件";
                    sl.Add(sl_model);
                }

                #endregion
                #region 获取新的病例编号

                else if (type.Equals("newermcode"))
                {
                    string doctorId = context.Request["doctorId"];
                    DentalMedical.BLL.simple_EMR semr = new DentalMedical.BLL.simple_EMR();
                    DentalMedical.Model.simple_EMR simple_emr_modle = new DentalMedical.Model.simple_EMR();
                    bool isermcode = true;
                    string emrCode = StringUtil.DayOrderBillNo();
                    int i = 0;
                    while (isermcode)
                    {
                        simple_emr_modle = semr.get_emr_byCode(emrCode);
                        if (simple_emr_modle != null)
                        {
                            emrCode = StringUtil.DayOrderBillNo();
                            i++;
                            if (i == 100)
                                break;
                        }
                        else
                        {
                            isermcode = false;
                        }

                    }
                    if (i == 100)
                    {
                        js.code = "201";
                        js.message = "病例号申请失败，请重新申请！";
                        js.data = emrCode;
                        strJson = JsonHelper.SerializeObject(js);
                        sl_model.doctor_Id = Guid.Empty;
                        sl_model.createId = Guid.Empty;
                        sl_model.Entity = "simple_EMR";
                        sl_model.LogsType = (int)LogsType.动作;
                        sl_model.logmessage = "生成新的病例号失败";
                        sl.Add(sl_model);
                    }
                    else
                    {
                        js.code = "200";
                        js.message = "请求成功！";
                        js.data = emrCode;
                        strJson = JsonHelper.SerializeObject(js);
                        sl_model.doctor_Id = Guid.Empty;
                        sl_model.createId = Guid.Empty;
                        sl_model.Entity = "simple_EMR";
                        sl_model.LogsType = (int)LogsType.动作;
                        sl_model.logmessage = "生成新的病例号：" + emrCode;
                        sl.Add(sl_model);
                    }

                }

                #endregion
                #region 设计端搜索

                else if (type.Equals("find_Emr_design"))
                {
                    string treatmentstatus = context.Request["treatmentstatus"];
                    string strwhere = context.Request["strwhere"];
                    strwhere = ReplaceSQLChar(strwhere);
                    DentalMedical.BLL.simple_EMR semr = new DentalMedical.BLL.simple_EMR();
                    List<DentalMedical.Model.simple_EMR> list = semr.find_Emr_design(int.Parse(treatmentstatus), strwhere);
                    if (list != null)
                    {
                        js.code = "200";
                        js.message = "请求成功！";
                        js.data = list;
                        strJson = JsonHelper.SerializeObject(js);
                    }
                    else
                    {
                        js.code = "201";
                        js.message = "请求失败！";
                        js.data = "";
                        strJson = JsonHelper.SerializeObject(js);
                    }
                }

                #endregion
                #region 设计端列表

                else
                    if (type.Equals("design_list"))
                    {
                        string treatmentstatus = context.Request["treatmentstatus"];
                        DentalMedical.BLL.simple_EMR semr = new DentalMedical.BLL.simple_EMR();
                        List<DentalMedical.Model.simple_EMR> list = semr.EMR_design_list(int.Parse(treatmentstatus));
                        if (list != null)
                        {
                            js.code = "200";
                            js.message = "请求成功！";
                            js.data = list;
                            strJson = JsonHelper.SerializeObject(js);
                        }
                        else
                        {
                            js.code = "201";
                            js.message = "请求失败！";
                            js.data = "";
                            strJson = JsonHelper.SerializeObject(js);
                        }
                    }
                #endregion
                #region 根据emrcode获取stl文件数据
                  
                    else if (type.Equals("get_stl"))
                    {
                        string emrCode = context.Request["emrCode"];
                        DentalMedical.BLL.stl_d_data stlbll = new DentalMedical.BLL.stl_d_data();
                        DentalMedical.Model.stl_d_data stl = new DentalMedical.Model.stl_d_data();
                        stl = stlbll.get_stl(emrCode);
                        if (stl != null)
                        {
                            js.code = "200";
                            js.message = "请求成功！";
                            js.data = stl;
                            strJson = JsonHelper.SerializeObject(js);
                        }
                        else
                        {
                            js.code = "201";
                            js.message = "请求失败！";
                            js.data = "";
                            strJson = JsonHelper.SerializeObject(js);
                        }
                    }

                    #endregion
                    else
                    {
                        js.code = "101";
                        js.message = "系统错误：没有该操作！type:" + type;
                        js.data = "";
                        strJson = JsonHelper.SerializeObject(js);
                        sl_model.doctor_Id = Guid.Empty;
                        sl_model.createId = Guid.Empty;
                        sl_model.Entity = "simple_EMR";
                        sl_model.LogsType = (int)LogsType.错误;
                        sl_model.logmessage = "错误操作！";
                        sl.Add(sl_model);
                        //string url = "http://doctor.clearbos.com/error.html";
                        //context.Response.Redirect(url);
                    }
            }
            catch (Exception ex)
            {
                js.code = "202";
                js.message = "系统错误：捕获到异常！";
                js.data = JsonHelper.SerializeObject(ex.Message);
                strJson = JsonHelper.SerializeObject(js);
                sl_model.doctor_Id = Guid.Empty;
                sl_model.createId = Guid.Empty;
                sl_model.Entity = "simple_EMR";
                sl_model.LogsType = (int)LogsType.错误;
                sl_model.logmessage = "方法：" + type + ",错误原因：" + ex.Message;
                sl.Add(sl_model);
                //string url = "http://doctor.clearbos.com/yichang.html";
                //context.Response.Redirect(url);
            }
            context.Response.ContentType = "text/plain";
            context.Response.Write(callback + "(" + strJson + ")");

        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }



        private string ReplaceSQLChar(string str)
        {
            if (str == string.Empty)
            {
                return string.Empty;
            }
            str = str.Replace("'", "‘");
            str = str.Replace(";", "；");
            str = str.Replace(",", ",");
            str = str.Replace("?", "?");
            str = str.Replace("<", "＜");
            str = str.Replace(">", "＞");
            str = str.Replace("(", "(");
            str = str.Replace(")", ")");
            str = str.Replace("@", "＠");
            str = str.Replace("=", "＝");
            str = str.Replace("+", "＋");
            str = str.Replace("*", "＊");
            str = str.Replace("&", "＆");
            str = str.Replace("#", "＃");
            str = str.Replace("%", "％");
            str = str.Replace("$", "￥");
            return str;
        }
    }
}
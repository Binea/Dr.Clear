using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DentalMedical.Common;
using DentalMedical.DentalEnumeration;

namespace DentalMedicalService
{
    /// <summary>
    /// FileService 的摘要说明
    /// </summary>
    public class FileService : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string strJson = string.Empty;
            string callback = context.Request["callback"];
            string orderId = context.Request["operationphase"];
            string fileType = string.Empty;
            string emrCode = context.Request["patientnum"];
            string operationfilemodel = context.Request["operationfilemodel"];
            string operationfilescheme = context.Request["operationfilescheme"];
            string ip = context.Request.UserHostAddress;
            string action = context.Request.CurrentExecutionFilePath;
            string browser = context.Request.Browser.Platform + "-" + context.Request.Browser.Type + "(" + context.Request.Browser.Version + ")";
            DentalMedical.BLL.sys_logs sl = new DentalMedical.BLL.sys_logs();
            DentalMedical.Model.sys_logs sl_model = new DentalMedical.Model.sys_logs();
            sl_model.clientInfo = browser;
            sl_model.IP = ip;
            sl_model.incident = action;
            sl_model.doctor_Id = Guid.Empty;
            sl_model.createId = Guid.Empty;
            sl_model.Entity = "文件服务";
            int status = 0;
            try
            {
                //判断该病例是否存在
                if (!string.IsNullOrEmpty(emrCode))
                {
                    DentalMedical.BLL.simple_EMR simpleemr = new DentalMedical.BLL.simple_EMR();
                    DentalMedical.Model.simple_EMR simple_emr = new DentalMedical.Model.simple_EMR();
                    simple_emr = simpleemr.get_emr_byCode(emrCode);
                    if (simple_emr != null)
                    {
                        if (simple_emr.emr_status > 10)
                        {
                            status = 1;
                        }
                    }
                    else
                    {
                        sl_model.LogsType = (int)LogsType.动作;
                        sl_model.logmessage = "病例:" + emrCode + ",该病例不存在！";
                        sl.Add(sl_model);
                        return;
                    }
                }
                else
                {
                    sl_model.LogsType = (int)LogsType.模型上传失败;
                    sl_model.logmessage = "专业软件post接口参数报错：patientnum：值为空";
                    sl.Add(sl_model);
                    return;
                }
                //判断operationphase值是否存在
                if (string.IsNullOrEmpty(orderId))
                {                   
                    sl_model.LogsType = (int)LogsType.模型上传失败;
                    sl_model.logmessage = "专业软件post接口参数报错：operationphase：值为空";
                    sl.Add(sl_model);
                    return;
                }
                orderId = orderId.Substring(1);//获取病例阶段“数据库只存了数字”
                string filepath = string.Empty;

                //判断operationfilemodel是否有值，若有值
                if (!string.IsNullOrEmpty(operationfilemodel))
                {
                    if (status == 12)
                    { fileType = "3"; }
                    else
                    { fileType = "1"; }
                    filepath = operationfilemodel;
                   
                }
                //判断operationfilemodel是否有值，若有值
                if (!string.IsNullOrEmpty(operationfilescheme))
                {
                    filepath = operationfilescheme;
                    fileType = "2";
                }
              
                if (fileType.Equals("1"))
                {
                    DentalMedical.Model.dental_model dental_model = new DentalMedical.Model.dental_model();
                    dental_model.EMR_Code = emrCode;
                    dental_model.imagePath = filepath;
                    dental_model.model_status = 1;
                    dental_model.orderId = int.Parse(orderId);
                    dental_model.createId = Guid.Empty;
                    dental_model.flag = 1;
                    DentalMedical.BLL.dental_model dental_bll = new DentalMedical.BLL.dental_model();
                    bool r= dental_bll.Add(dental_model);
                    if (r)
                    {
                        DentalMedical.BLL.simple_EMR sb = new DentalMedical.BLL.simple_EMR();
                        int res = sb.update_Emr_Status((int)EMRStatusEnum.口腔模型, emrCode, Guid.Empty.ToString());
                        if (res > 0)
                        {
                            sl_model.LogsType = (int)LogsType.动作;
                            sl_model.logmessage = "病例:" + emrCode + ",口腔模型建模完成！";
                            sl.Add(sl_model);
                        }
                        else
                        {
                            sl_model.LogsType = (int)LogsType.动作;
                            sl_model.logmessage = "病例:" + emrCode + ",口腔模型建模完成！更新病例状态失败";
                            sl.Add(sl_model);
                        }
                    }
                    else
                    {
                        sl_model.LogsType = (int)LogsType.动作;
                        sl_model.logmessage = "病例:" + emrCode + ",口腔模型建模完成！数据插入失败！";
                        sl.Add(sl_model);
                    }                  
                }
                else if (fileType.Equals("2"))
                {
                    DentalMedical.Model.design_scheme desgin_scheme = new DentalMedical.Model.design_scheme();
                    desgin_scheme.EMR_Code = emrCode;
                    desgin_scheme.imagePath = filepath;
                    desgin_scheme.orderId = int.Parse(orderId);
                    desgin_scheme.createId = Guid.Empty;
                    desgin_scheme.flag = 1;
                    DentalMedical.BLL.design_scheme design_scheme_bll = new DentalMedical.BLL.design_scheme();
                    bool r=design_scheme_bll.Add(desgin_scheme);
                    if (r)
                    {
                        DentalMedical.BLL.simple_EMR sb = new DentalMedical.BLL.simple_EMR();
                        int res = sb.update_Emr_Status((int)EMRStatusEnum.设计方案, emrCode, Guid.Empty.ToString());
                        if (res > 0)
                        {
                            sl_model.LogsType = (int)LogsType.动作;
                            sl_model.logmessage = "病例:" + emrCode + ",设计方案完成！";
                            sl.Add(sl_model);
                        }
                        else
                        {
                            sl_model.LogsType = (int)LogsType.动作;
                            sl_model.logmessage = "病例:" + emrCode + ",设计方案完成！更新病例状态失败";
                            sl.Add(sl_model);
                        }
                    }
                    else
                    {
                        sl_model.LogsType = (int)LogsType.动作;
                        sl_model.logmessage = "病例:" + emrCode + ",设计方案完成！数据插入失败！";
                        sl.Add(sl_model);
                    }              
                }
                else if (fileType.Equals("3"))
                {
                    DentalMedical.Model.archiving_model archiving_model = new DentalMedical.Model.archiving_model();
                    archiving_model.EMR_Code = emrCode;
                    archiving_model.imagePath = filepath;
                    archiving_model.orderId = int.Parse(orderId);
                    archiving_model.createId = Guid.Empty;
                    archiving_model.flag = 1;
                    DentalMedical.BLL.archiving_model archiving_model_bll = new DentalMedical.BLL.archiving_model();
                    bool r= archiving_model_bll.Add(archiving_model);
                    if (r)
                    {
                        DentalMedical.BLL.simple_EMR sb = new DentalMedical.BLL.simple_EMR();
                        int res = sb.update_Emr_Status((int)EMRStatusEnum.病例归档, emrCode, Guid.Empty.ToString());
                        if (res > 0)
                        {
                            sl_model.LogsType = (int)LogsType.动作;
                            sl_model.logmessage = "病例:" + emrCode + ",归档模型完成！";
                            sl.Add(sl_model);
                        }
                        else
                        {
                            sl_model.LogsType = (int)LogsType.动作;
                            sl_model.logmessage = "病例:" + emrCode + ",归档模型完成！更新病例状态失败";
                            sl.Add(sl_model);
                        }
                    }
                    else
                    {
                        sl_model.LogsType = (int)LogsType.动作;
                        sl_model.logmessage = "病例:" + emrCode + ",归档模型完成！数据插入失败！";
                        sl.Add(sl_model);
                    }              
                 
                }
                else
                {
                    sl_model.LogsType = (int)LogsType.动作;
                    sl_model.logmessage = "专业软件post接口参数报错：operationfilemodel" + operationfilemodel + ",operationfilescheme" + operationfilescheme + " 值为空";
                    sl.Add(sl_model);
                    return;
                }
            }
            catch (Exception ex)
            {
                
                sl_model.LogsType = (int)LogsType.动作;
                sl_model.logmessage = "专业软件post接口报错：" + ex.Message + "operationphase:" + orderId + ",patientnum:" + emrCode + ",operationfilemodel:" + operationfilemodel + ",operationfilescheme:" + operationfilescheme;
                sl.Add(sl_model);
                strJson = JsonHelper.SerializeObject(ex.Message);
            }
            context.Response.ContentType = "text/plain";
            context.Response.Write("");
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
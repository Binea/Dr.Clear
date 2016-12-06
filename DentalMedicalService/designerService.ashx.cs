using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DentalMedical.Common;
using DentalMedical.DentalEnumeration;

namespace DentalMedicalService
{
    /// <summary>
    /// doctorService 的摘要说明
    /// </summary>
    public class designerService : IHttpHandler
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
                #region 设计端登录

                if (type.Equals("Login_desgin"))
                {
                    string designCode = context.Request["doctorCode"];
                    string designpwd = context.Request["doctorPwd"];
                    DentalMedical.BLL.designers des = new DentalMedical.BLL.designers();
                    DentalMedical.Model.designers doctors = new DentalMedical.Model.designers();
                    doctors = des.Login_Des(designCode, designpwd);
                    if (doctors != null && doctors.Id != null)
                    {
                        int onlineStauts = doctors.onlineStatus;
                        //if (onlineStauts == 1)
                        //{

                        //    js.code = "201";
                        //    js.message = "该账号处于登录状态";
                        //    js.data = "";//登录返回是3的话 说明该账号处于登录状态      
                        //    strJson = JsonHelper.SerializeObject(js);
                        //    sl_model.doctor_Id = Guid.Empty;
                        //    sl_model.createId = Guid.Empty;
                        //    sl_model.Entity = "doctors";
                        //    sl_model.LogsType = (int)LogsType.登录失败;
                        //    sl_model.logmessage = "账户："+DrCode+"   已经登录！";
                        //    sl.Add(sl_model);

                        //}
                        //else
                        //{
                        doctors = des.judge_Pwd(doctors, designpwd);
                        if (doctors != null && doctors.Id != null)
                        {
                            //      dc.update_doctor_status(doctors.Id, 1);
                            js.code = "200";
                            js.message = "登陆成功";
                            js.data = doctors;//正常返回医生明细      
                            strJson = JsonHelper.SerializeObject(js);
                            sl_model.doctor_Id = Guid.Empty;
                            sl_model.createId = Guid.Empty;
                            sl_model.Entity = "doctors";
                            sl_model.LogsType = (int)LogsType.登录失败;
                            sl_model.logmessage = "账户：" + designCode + "   登录成功！";
                            sl.Add(sl_model);
                        }
                        else
                        {
                            js.code = "201";
                            js.message = "用户名或密码错误，请重新输入";
                            js.data = "";//返回4 说明密码错误    
                            strJson = JsonHelper.SerializeObject(js);
                            sl_model.doctor_Id = Guid.Empty;
                            sl_model.createId = Guid.Empty;
                            sl_model.Entity = "doctors";
                            sl_model.LogsType = (int)LogsType.登录失败;
                            sl_model.logmessage = "账户：" + designCode + "   密码错误！";
                            sl.Add(sl_model);
                        }
                        //}
                    }
                    else
                    {
                        js.code = "201";
                        js.message = "用户名或密码错误，请重新输入";
                        js.data = "";//返回4 说明账户错误    
                        strJson = JsonHelper.SerializeObject(js);
                        sl_model.doctor_Id = Guid.Empty;
                        sl_model.createId = Guid.Empty;
                        sl_model.Entity = "doctors";
                        sl_model.LogsType = (int)LogsType.登录失败;
                        sl_model.logmessage = "账户：" + designCode + " 该用户不存在！";
                        sl.Add(sl_model);
                    }

                }
                #endregion
                #region 更新设计组信息

                else if (type.Equals("update_designer_info"))
                {
                    string doctorName = context.Request["RealName"];
                    string dId = context.Request["designerId"];
                    string sex = context.Request["sex"];
                    string email = context.Request["email"];
                    string logo = context.Request["logo"];
                    DentalMedical.BLL.designers dc = new DentalMedical.BLL.designers();
                    bool result = dc.update_designer_Info(dId, doctorName, int.Parse(sex), email, logo);
                    if (result)
                    {
                        js.code = "200";
                        js.message = "更新个人信息成功！";
                        DentalMedical.Model.JsBool jsbool = new DentalMedical.Model.JsBool();
                        jsbool.result = result;
                        js.data = jsbool;
                    }
                    else
                    {
                        js.code = "201";
                        js.message = "更新个人信息失败！";
                        js.data = "";
                    }

                    strJson = JsonHelper.SerializeObject(js);
                    sl_model.doctor_Id = new Guid(dId);
                    sl_model.createId = new Guid(dId);
                    sl_model.Entity = "doctors";
                    sl_model.LogsType = (int)LogsType.注册;
                    sl_model.logmessage = "医生：" + dId + "  姓名：" + doctorName + ",更新个人信息！";
                    sl.Add(sl_model);
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
                    sl_model.Entity = "doctors";
                    sl_model.LogsType = (int)LogsType.错误;
                    sl_model.logmessage = "错误操作！";
                    sl.Add(sl_model);
                }
            }
            catch (Exception ex)
            {
                js.code = "202";
                js.message = "系统错误：捕捉到异常,设计端！";
                js.data = JsonHelper.SerializeObject(ex.Message);
                strJson = JsonHelper.SerializeObject(js);
                sl_model.doctor_Id = Guid.Empty;
                sl_model.createId = Guid.Empty;
                sl_model.Entity = "doctors";
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
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using DentalMedical.Common;
using DentalMedical.DentalEnumeration;

namespace DentalMedicalService
{
    /// <summary>
    /// userService 的摘要说明
    /// </summary>
    public class userService : IHttpHandler
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
                DentalMedical.BLL.patientInfo patientInfo_bll;
                DentalMedical.Model.patientInfo patientInfo;
                bool reslt = false;

                if (type.Equals("Login_P"))
                {
                    string PCode = context.Request["PCode"];
                    string PPwd = context.Request["PPwd"];
                    patientInfo_bll = new DentalMedical.BLL.patientInfo();
                    patientInfo = new DentalMedical.Model.patientInfo();
                    patientInfo = patientInfo_bll.Query_Code(PCode, PPwd);                   
                    if (patientInfo != null && patientInfo.Id != null)
                    {
                        //int onlineStauts = doctors.onlineStatus;
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
                        patientInfo = patientInfo_bll.judge_Pwd(patientInfo, PPwd);
                        if (patientInfo.patientBirthday != null)
                        {
                            // string aaa= string.Format("yyyy-MM-dd",DateTime.Now);
                            //string bbbb=  string.Format("{0:d}", DateTime.Now);
                            //string bbbb2 = DateTime.Now.ToString("yyy-MM-dd");
                            patientInfo.SPatientbirthday = DateTime.Parse(patientInfo.patientBirthday.ToString()).ToString("yyy-MM-dd"); ;
                        }
                        if (patientInfo != null && patientInfo.Id != null)
                        {
                            //dc.update_doctor_status(doctors.Id, 1);
                            js.code = "200";
                            js.message = "登陆成功";
                            js.data = patientInfo;//正常返回医生明细      
                            strJson = JsonHelper.SerializeObject(js);
                            sl_model.doctor_Id = Guid.Empty;
                            sl_model.createId = Guid.Empty;
                            sl_model.Entity = "patientInfo";
                            sl_model.LogsType = (int)LogsType.登录失败;
                            sl_model.logmessage = "账户：" + PCode + "   登录成功！";
                            sl.Add(sl_model);
                        }
                        else
                        {
                            js.code = "201";
                            js.message = "密码错误！";
                            js.data = "";//返回4 说明密码错误    
                            strJson = JsonHelper.SerializeObject(js);
                            sl_model.doctor_Id = Guid.Empty;
                            sl_model.createId = Guid.Empty;
                            sl_model.Entity = "patientInfo";
                            sl_model.LogsType = (int)LogsType.登录失败;
                            sl_model.logmessage = "账户：" + PCode + "   密码错误！";
                            sl.Add(sl_model);
                        }
                        //}
                    }
                    else
                    {
                        js.code = "201";
                        js.message = "该用户不存在！";
                        js.data = "";//返回4 说明账户错误    
                        strJson = JsonHelper.SerializeObject(js);
                        sl_model.doctor_Id = Guid.Empty;
                        sl_model.createId = Guid.Empty;
                        sl_model.Entity = "patientInfo";
                        sl_model.LogsType = (int)LogsType.登录失败;
                        sl_model.logmessage = "账户：" + PCode + "  账号或者密码错误";
                        sl.Add(sl_model);
                    }
                }

                else if (type.Equals("Register_P"))
                {
                    string DrCode = context.Request["PCode"];
                    string Drpwd = context.Request["PPwd"];
                    string key = context.Request["Key"];
                    string openId=context.Request["openId"];
                    patientInfo_bll = new DentalMedical.BLL.patientInfo();
                    reslt = patientInfo_bll.Exists(DrCode);
                    if (!reslt)
                    {
                        DentalMedical.BLL.message_info mi = new DentalMedical.BLL.message_info();
                        int re = mi.validate_code(DrCode, key, "3");
                        if (re == 1)
                        {

                            patientInfo = new DentalMedical.Model.patientInfo();
                            patientInfo.patientCode = DrCode;
                            patientInfo.weixin = openId;
                            patientInfo.patientPwd = Drpwd;
                            string result = patientInfo_bll.Add(patientInfo);
                            if (!string.IsNullOrEmpty(result))
                            {
                                js.code = "200";
                                js.message = "注册成功！";
                                DentalMedical.Model.JsId jsid = new DentalMedical.Model.JsId();
                                jsid.Id = new Guid(result);
                                js.data = jsid;
                                strJson = JsonHelper.SerializeObject(js);
                                sl_model.doctor_Id = Guid.Empty;
                                sl_model.createId = Guid.Empty;
                                sl_model.Entity = "patientInfo";
                                sl_model.LogsType = (int)LogsType.注册;
                                sl_model.logmessage = "账户：" + DrCode + "  注册成功";
                                sl.Add(sl_model);
                            }
                            else
                            {
                                js.code = "201";
                                js.message = "注册失败！";
                                js.data = "";
                                strJson = JsonHelper.SerializeObject(js);
                                sl_model.doctor_Id = Guid.Empty;
                                sl_model.createId = Guid.Empty;
                                sl_model.Entity = "patientInfo";
                                sl_model.LogsType = (int)LogsType.注册;
                                sl_model.logmessage = "账户：" + DrCode + "  注册失败，数据插入失败";
                                sl.Add(sl_model);
                            }
                        }
                        else
                        {
                            js.code = "201";
                            js.message = "验证码错误！";
                            js.data = "";
                            strJson = JsonHelper.SerializeObject(js);
                            sl_model.doctor_Id = Guid.Empty;
                            sl_model.createId = Guid.Empty;
                            sl_model.Entity = "patientInfo";
                            sl_model.LogsType = (int)LogsType.注册;
                            sl_model.logmessage = "账户：" + DrCode + "  注册失败，验证码错误";
                            sl.Add(sl_model);
                        }
                    }
                    else
                    {
                        js.code = "201";
                        js.message = "此手机号已被注册！";
                        js.data = "";
                        strJson = JsonHelper.SerializeObject(js);
                        sl_model.doctor_Id = Guid.Empty;
                        sl_model.createId = Guid.Empty;
                        sl_model.Entity = "patientInfo";
                        sl_model.LogsType = (int)LogsType.注册;
                        sl_model.logmessage = "账户：" + DrCode + "  注册失败，手机号已被注册！";
                        sl.Add(sl_model);
                    }
                }

                else if (type.Equals("update_P"))
                {
                    string patientCode = context.Request["patientCode"];
                    string patientId = context.Request["patientId"];
                    string patientName = context.Request["patientName"];
                    string patientSex = context.Request["patientSex"];
                    string patientBirthDay = context.Request["patientBirthDay"];
                    string patientVocation = context.Request["patientVocation"];
                    string patientEmail = context.Request["patientEmail"];
                    DentalMedical.BLL.patientInfo pi = new DentalMedical.BLL.patientInfo();
                    DentalMedical.Model.patientInfo patient = new DentalMedical.Model.patientInfo();
                    patient.Id = new Guid(patientId);
                    patient.patientName = patientName;
                    patient.patientSex = int.Parse(patientSex);
                    patient.patientVocation = patientVocation;
                    patient.patientEmail = patientEmail;
                    patient.patientBirthday = DateTime.Parse(patientBirthDay);
                    patient.modifyId = new Guid(patientId);
                    reslt = pi.Update_patientInfo(patient);
                    if (reslt)
                    {

                        js.code = "200";
                        js.message = "更新账户信息成功！";
                        DentalMedical.Model.JsBool JsBool = new DentalMedical.Model.JsBool();
                        JsBool.result = reslt;
                        js.data = JsBool;
                        strJson = JsonHelper.SerializeObject(js);
                        sl_model.doctor_Id = Guid.Empty;
                        sl_model.createId = Guid.Empty;
                        sl_model.Entity = "patientInfo";
                        sl_model.LogsType = (int)LogsType.注册;
                        sl_model.logmessage = "账户：" + patientCode + "  更新账户信息成功~！";
                        sl.Add(sl_model);

                    }
                    else
                    {
                        js.code = "201";
                        js.message = "更新账户信息失败~~！";
                        js.data = "";
                        strJson = JsonHelper.SerializeObject(js);
                        sl_model.doctor_Id = Guid.Empty;
                        sl_model.createId = Guid.Empty;
                        sl_model.Entity = "patientInfo";
                        sl_model.LogsType = (int)LogsType.注册;
                        sl_model.logmessage = "账户：" + patientCode + "  注册失败，手机号已被注册！";
                        sl.Add(sl_model);
                    }
                }

                else if (type.Equals("appointment"))
                {
                    string appointment_Add = context.Request["appointment_Add"];
                    string appointment_patientTel = context.Request["patientTel"];
                    string appointment_patientName = context.Request["patientName"];
                    string appointment_demand = context.Request["appointment_demand"];
                    string appointment_Date = context.Request["appointment_Date"];
                    string paitentId = context.Request["paitentId"];
                    DentalMedical.BLL.appointment a = new DentalMedical.BLL.appointment();
                    DentalMedical.Model.appointment appointment = new DentalMedical.Model.appointment();
                    appointment.patientName = appointment_patientName;
                    appointment.patientTel = appointment_patientTel;
                    appointment.appointment_Add = appointment_Add;
                    appointment.appointment_Date = appointment_Date;
                    appointment.appointment_demand = appointment_demand;
                    appointment.createId = new Guid(paitentId);
                    string r = a.Add(appointment);
                    if (!string.IsNullOrEmpty(r))
                    {

                        js.code = "200";
                        js.message = "您好，您的预约已成功！";
                        DentalMedical.Model.JsId JsId = new DentalMedical.Model.JsId();
                        JsId.Id = new Guid(r);
                        js.data = JsId;
                        strJson = JsonHelper.SerializeObject(js);
                        sl_model.doctor_Id = Guid.Empty;
                        sl_model.createId = Guid.Empty;
                        sl_model.Entity = "appointment";
                        sl_model.LogsType = (int)LogsType.用户预约;
                        sl_model.logmessage = "用户预约成功！";
                        sl.Add(sl_model);

                    }
                    else
                    {
                        js.code = "201";
                        js.message = "预约失败！";
                        js.data = "";
                        strJson = JsonHelper.SerializeObject(js);
                        sl_model.doctor_Id = Guid.Empty;
                        sl_model.createId = Guid.Empty;
                        sl_model.Entity = "appointment";
                        sl_model.LogsType = (int)LogsType.用户预约;
                        sl_model.logmessage = "用户预约失败";
                        sl.Add(sl_model);
                    }
                }

                else if (type.Equals("appoitmentList"))
                {
                    string pId = context.Request["Id"];
                    DentalMedical.BLL.appointment a2 = new DentalMedical.BLL.appointment();
                    List<DentalMedical.Model.appointment> al = a2.get_appointmentList(new Guid(pId));
                    if (al != null)
                    {
                        js.code = "200";
                        js.message = "获取列表成！";
                        js.data = al;
                        strJson = JsonHelper.SerializeObject(js);
                        sl_model.doctor_Id = Guid.Empty;
                        sl_model.createId = Guid.Empty;
                        sl_model.Entity = "appointment";
                        sl_model.LogsType = (int)LogsType.预约列表;
                        sl_model.logmessage = "获取列表成功！";
                        sl.Add(sl_model);
                    }
                    else
                    {
                        js.code = "201";
                        js.message = "获取预约列表失败！";
                        js.data = "";
                        strJson = JsonHelper.SerializeObject(js);
                        sl_model.doctor_Id = Guid.Empty;
                        sl_model.createId = Guid.Empty;
                        sl_model.Entity = "appointment";
                        sl_model.LogsType = (int)LogsType.预约列表;
                        sl_model.logmessage = "用户预约失败";
                        sl.Add(sl_model);
                    }
                }

                else if (type.Equals("emrList"))
                {
                    string patientcode = context.Request["patientcode"];
                    DentalMedical.BLL.simple_EMR smer = new DentalMedical.BLL.simple_EMR();
                    List<DentalMedical.Model.simple_EMR> ls = smer.get_emrCode(patientcode);
                    if (ls != null)
                    {
                        js.code = "200";
                        js.message = "获取病例列表成功！";
                        js.data = ls;
                        strJson = JsonHelper.SerializeObject(js);
                        sl_model.doctor_Id = Guid.Empty;
                        sl_model.createId = Guid.Empty;
                        sl_model.Entity = "appointment";
                        sl_model.LogsType = (int)LogsType.预约列表;
                        sl_model.logmessage = "获取列表成功！";
                        sl.Add(sl_model);
                    }
                    else
                    {
                        js.code = "201";
                        js.message = "获取预约列表失败！";
                        js.data = "";
                        strJson = JsonHelper.SerializeObject(js);
                        sl_model.doctor_Id = Guid.Empty;
                        sl_model.createId = Guid.Empty;
                        sl_model.Entity = "appointment";
                        sl_model.LogsType = (int)LogsType.预约列表;
                        sl_model.logmessage = "用户预约失败";
                        sl.Add(sl_model);
                    }
                }

                else if (type.Equals("streamList"))
                {
                    string patientcode2 = context.Request["patientcode"];
                    DentalMedical.BLL.simple_EMR streamList = new DentalMedical.BLL.simple_EMR();
                    List<DentalMedical.Model.EMR_stream> streaml = streamList.get_stream_byTel(patientcode2);
                    if (streaml != null)
                    {
                        foreach (var st in streaml)
                        {
                            st.SCreateDate = st.createDate.ToLongDateString();
                        }
                        js.code = "200";
                        js.message = "获取病例列表成功！";
                        js.data = streaml;
                        strJson = JsonHelper.SerializeObject(js);
                        sl_model.doctor_Id = Guid.Empty;
                        sl_model.createId = Guid.Empty;
                        sl_model.Entity = "appointment";
                        sl_model.LogsType = (int)LogsType.预约列表;
                        sl_model.logmessage = "获取列表成功！";
                        sl.Add(sl_model);
                    }
                    else
                    {
                        js.code = "201";
                        js.message = "获取预约列表失败！";
                        js.data = "";
                        strJson = JsonHelper.SerializeObject(js);
                        sl_model.doctor_Id = Guid.Empty;
                        sl_model.createId = Guid.Empty;
                        sl_model.Entity = "appointment";
                        sl_model.LogsType = (int)LogsType.预约列表;
                        sl_model.logmessage = "用户预约失败";
                        sl.Add(sl_model);
                    }
                }


                else if (type.Equals("get_patientInfo"))
                {
                    string patientcode3 = context.Request["patientcode"];
                    patientInfo_bll = new DentalMedical.BLL.patientInfo();
                    patientInfo = new DentalMedical.Model.patientInfo();
                    patientInfo = patientInfo_bll.Query_Code(patientcode3, null);
                    if (patientInfo != null && patientInfo.Id != null)
                    {
                        //dc.update_doctor_status(doctors.Id, 1);
                        js.code = "200";
                        js.message = "登陆成功";
                        js.data = patientInfo;//正常返回医生明细      
                        strJson = JsonHelper.SerializeObject(js);
                        sl_model.doctor_Id = Guid.Empty;
                        sl_model.createId = Guid.Empty;
                        sl_model.Entity = "patientInfo";
                        sl_model.LogsType = (int)LogsType.登录;
                        sl_model.logmessage = "账户：" + patientcode3 + "   获取数据！";
                        sl.Add(sl_model);
                    }
                    else
                    {
                        js.code = "201";
                        js.message = "密码错误！";
                        js.data = "";//返回4 说明密码错误    
                        strJson = JsonHelper.SerializeObject(js);
                        sl_model.doctor_Id = Guid.Empty;
                        sl_model.createId = Guid.Empty;
                        sl_model.Entity = "patientInfo";
                        sl_model.LogsType = (int)LogsType.登录失败;
                        sl_model.logmessage = "账户：" + patientcode3 + "   获取数据失败！";
                        sl.Add(sl_model);
                    }
                }
                else if (type.Equals("update_weixin_patient"))
                {
                    string patientcode = context.Request["patientcode"];
                    string openId = context.Request["openId"];
                    string nickName = context.Request["nickName"];
                    string headImgUrl = context.Request["headImgUrl"];
                    DentalMedical.BLL.patientInfo pibll = new DentalMedical.BLL.patientInfo();
                    DentalMedical.Model.patientInfo pi = new DentalMedical.Model.patientInfo();
                    pi = pibll.Query_Code(patientcode);
                    if (pi != null && pi.Id != null)
                    {
                        string key = context.Request["Key"];
                        DentalMedical.BLL.message_info mi = new DentalMedical.BLL.message_info();
                        int re = mi.validate_code(patientcode, key, "3");
                        if (re == 1)
                        {
                            pi.weixin = openId;
                            pi.nickname = nickName;
                            pi.HeadImgUrl = headImgUrl;
                            bool r = pibll.Update_weixin_patientinfo(openId, nickName, headImgUrl, patientcode);
                            if (r)
                            {

                                js.code = "200";
                                js.message = "绑定PID成功！";
                                DentalMedical.Model.JsBool JsBool = new DentalMedical.Model.JsBool();
                                JsBool.result = reslt;
                                js.data = JsBool;
                                strJson = JsonHelper.SerializeObject(js);
                                sl_model.doctor_Id = Guid.Empty;
                                sl_model.createId = Guid.Empty;
                                sl_model.Entity = "patientInfo";
                                sl_model.LogsType = (int)LogsType.登录;
                                sl_model.logmessage = "账户：" + patientcode + "  绑定微信成功！！";
                                sl.Add(sl_model);

                            }
                            else
                            {
                                js.code = "201";
                                js.message = "绑定PID失败~~！";
                                js.data = "";
                                strJson = JsonHelper.SerializeObject(js);
                                sl_model.doctor_Id = Guid.Empty;
                                sl_model.createId = Guid.Empty;
                                sl_model.Entity = "patientInfo";
                                sl_model.LogsType = (int)LogsType.登录失败;
                                sl_model.logmessage = "账户：" + patientcode + "  绑定微信失败！！";
                                sl.Add(sl_model);
                            }
                        }
                        else
                        {
                            js.code = "201";
                            js.message = "验证码错误！";
                            js.data = "";
                            strJson = JsonHelper.SerializeObject(js);
                            sl_model.doctor_Id = Guid.Empty;
                            sl_model.createId = Guid.Empty;
                            sl_model.Entity = "patientInfo";
                            sl_model.LogsType = (int)LogsType.注册;
                            sl_model.logmessage = "账户：" + patientcode + "   绑定微信失败，验证码错误";
                            sl.Add(sl_model);
                        }
                    }
                    else
                    {
                        js.code = "201";
                        js.message = "该用户不存在！";
                        js.data = "";//返回4 说明账户错误    
                        strJson = JsonHelper.SerializeObject(js);
                        sl_model.doctor_Id = Guid.Empty;
                        sl_model.createId = Guid.Empty;
                        sl_model.Entity = "patientInfo";
                        sl_model.LogsType = (int)LogsType.登录失败;
                        sl_model.logmessage = "账户：" + patientcode + "  绑定微信失败！";
                        sl.Add(sl_model);
                    }
                }
                else if (type.Equals("getInfo_weixin"))
                {
                    string openId = context.Request["openId"];
                    DentalMedical.BLL.patientInfo pi = new DentalMedical.BLL.patientInfo();
                    DentalMedical.Model.patientInfo pinfo = pi.Query_weixin(openId);
                    if (pinfo != null)
                    {
                        List<object> o = new List<object>();
                        //DentalMedical.BLL.simple_EMR se = new DentalMedical.BLL.simple_EMR();
                        //List<DentalMedical.Model.EMR_stream> list = se.get_stream_byWeixin(openId);
                        js.code = "200";
                        js.message = "微信号已录入！";
                        o.Add(pinfo);
                        //o.Add(list);
                        js.data = o;
                        strJson = JsonHelper.SerializeObject(js);
                        sl_model.doctor_Id = Guid.Empty;
                        sl_model.createId = Guid.Empty;
                        sl_model.Entity = "patientInfo";
                        sl_model.LogsType = (int)LogsType.登录;
                        sl_model.logmessage = "微信openId：" + openId + "  获取用户信息成功~";
                        sl.Add(sl_model);
                    }
                    else
                    {
                        js.code = "201";
                        js.message = "账号未登录，请绑定微信号~";
                        js.data = "";
                        strJson = JsonHelper.SerializeObject(js);
                        //string url = "http://" + Utils.GetCurrentFullHost() + @"/Dental/weixin/login.html";
                        //context.Response.Redirect(url);
                        sl_model.doctor_Id = Guid.Empty;
                        sl_model.createId = Guid.Empty;
                        sl_model.Entity = "patientInfo";
                        sl_model.LogsType = (int)LogsType.登录;
                        sl_model.logmessage = "微信openId：" + openId + "  未绑定！";
                        sl.Add(sl_model);
                    }
                }
                else if (type.Equals("getstream_weixin"))
                {
 
                }
                else
                {
                    js.code = "101";
                    js.message = "系统错误：没有该操作！";
                    js.data = "";
                    strJson = JsonHelper.SerializeObject(js);
                    sl_model.doctor_Id = Guid.Empty;
                    sl_model.createId = Guid.Empty;
                    sl_model.Entity = "doctors";
                    sl_model.LogsType = (int)LogsType.错误;
                    sl_model.logmessage = "错误操作！";
                    sl.Add(sl_model);
                    //string url = "http://doctor.clearbos.com/error.html";
                    //context.Response.Redirect(url);
                }

            }
            #region 之前的if-else逻辑代码


            //if (type.Equals("Login_P"))
            //{
            //    string PCode = context.Request["PCode"];
            //    string PPwd = context.Request["PPwd"];
            //    DentalMedical.BLL.patientInfo pi = new DentalMedical.BLL.patientInfo();
            //    DentalMedical.Model.patientInfo patientInfo = new DentalMedical.Model.patientInfo();
            //    patientInfo = pi.Query_Code(PCode, PPwd);
            //    if (patientInfo != null && patientInfo.Id != null)
            //    {
            //        //int onlineStauts = doctors.onlineStatus;
            //        //if (onlineStauts == 1)
            //        //{

                //        //    js.code = "201";
            //        //    js.message = "该账号处于登录状态";
            //        //    js.data = "";//登录返回是3的话 说明该账号处于登录状态      
            //        //    strJson = JsonHelper.SerializeObject(js);
            //        //    sl_model.doctor_Id = Guid.Empty;
            //        //    sl_model.createId = Guid.Empty;
            //        //    sl_model.Entity = "doctors";
            //        //    sl_model.LogsType = (int)LogsType.登录失败;
            //        //    sl_model.logmessage = "账户："+DrCode+"   已经登录！";
            //        //    sl.Add(sl_model);

                //        //}
            //        //else
            //        //{
            //        patientInfo = pi.judge_Pwd(patientInfo, PPwd);
            //        if (patientInfo != null && patientInfo.Id != null)
            //        {
            //            //dc.update_doctor_status(doctors.Id, 1);
            //            js.code = "200";
            //            js.message = "登陆成功";
            //            js.data = patientInfo;//正常返回医生明细      
            //            strJson = JsonHelper.SerializeObject(js);
            //            sl_model.doctor_Id = Guid.Empty;
            //            sl_model.createId = Guid.Empty;
            //            sl_model.Entity = "patientInfo";
            //            sl_model.LogsType = (int)LogsType.登录失败;
            //            sl_model.logmessage = "账户：" + PCode + "   登录成功！";
            //            sl.Add(sl_model);
            //        }
            //        else
            //        {
            //            js.code = "201";
            //            js.message = "密码错误！";
            //            js.data = "";//返回4 说明密码错误    
            //            strJson = JsonHelper.SerializeObject(js);
            //            sl_model.doctor_Id = Guid.Empty;
            //            sl_model.createId = Guid.Empty;
            //            sl_model.Entity = "patientInfo";
            //            sl_model.LogsType = (int)LogsType.登录失败;
            //            sl_model.logmessage = "账户：" + PCode + "   密码错误！";
            //            sl.Add(sl_model);
            //        }
            //        //}
            //    }
            //    else
            //    {
            //        js.code = "201";
            //        js.message = "该用户不存在！";
            //        js.data = "";//返回4 说明账户错误    
            //        strJson = JsonHelper.SerializeObject(js);
            //        sl_model.doctor_Id = Guid.Empty;
            //        sl_model.createId = Guid.Empty;
            //        sl_model.Entity = "patientInfo";
            //        sl_model.LogsType = (int)LogsType.登录失败;
            //        sl_model.logmessage = "账户：" + PCode + "  账号或者密码错误";
            //        sl.Add(sl_model);
            //    }

                //}
            //else if (type.Equals("Register_P"))
            //{
            //    string DrCode = context.Request["PCode"];
            //    string Drpwd = context.Request["PPwd"];
            //    string key = context.Request["Key"];
            //    DentalMedical.BLL.patientInfo pi = new DentalMedical.BLL.patientInfo();
            //    bool r = pi.Exists(DrCode);
            //    if (!r)
            //    {
            //        DentalMedical.BLL.message_info mi = new DentalMedical.BLL.message_info();
            //        int re = mi.validate_code(DrCode, key, "3");
            //        if (re == 1)
            //        {

                //            DentalMedical.Model.patientInfo patientInfo = new DentalMedical.Model.patientInfo();
            //            patientInfo.patientCode = DrCode;
            //            patientInfo.weixin = null;
            //            patientInfo.patientPwd = Drpwd;
            //            string result = pi.Add(patientInfo);
            //            if (!string.IsNullOrEmpty(result))
            //            {
            //                js.code = "200";
            //                js.message = "注册成功！";
            //                DentalMedical.Model.JsId jsid = new DentalMedical.Model.JsId();
            //                jsid.Id = new Guid(result);
            //                js.data = jsid;
            //                strJson = JsonHelper.SerializeObject(js);
            //                sl_model.doctor_Id = Guid.Empty;
            //                sl_model.createId = Guid.Empty;
            //                sl_model.Entity = "patientInfo";
            //                sl_model.LogsType = (int)LogsType.注册;
            //                sl_model.logmessage = "账户：" + DrCode + "  注册成功";
            //                sl.Add(sl_model);
            //            }
            //            else
            //            {
            //                js.code = "201";
            //                js.message = "注册失败！";
            //                js.data = "";
            //                strJson = JsonHelper.SerializeObject(js);
            //                sl_model.doctor_Id = Guid.Empty;
            //                sl_model.createId = Guid.Empty;
            //                sl_model.Entity = "patientInfo";
            //                sl_model.LogsType = (int)LogsType.注册;
            //                sl_model.logmessage = "账户：" + DrCode + "  注册失败，数据插入失败";
            //                sl.Add(sl_model);
            //            }
            //        }
            //        else
            //        {
            //            js.code = "201";
            //            js.message = "验证码错误！";
            //            js.data = "";
            //            strJson = JsonHelper.SerializeObject(js);
            //            sl_model.doctor_Id = Guid.Empty;
            //            sl_model.createId = Guid.Empty;
            //            sl_model.Entity = "patientInfo";
            //            sl_model.LogsType = (int)LogsType.注册;
            //            sl_model.logmessage = "账户：" + DrCode + "  注册失败，验证码错误";
            //            sl.Add(sl_model);
            //        }
            //    }
            //    else
            //    {
            //        js.code = "201";
            //        js.message = "此手机号已被注册！";
            //        js.data = "";
            //        strJson = JsonHelper.SerializeObject(js);
            //        sl_model.doctor_Id = Guid.Empty;
            //        sl_model.createId = Guid.Empty;
            //        sl_model.Entity = "patientInfo";
            //        sl_model.LogsType = (int)LogsType.注册;
            //        sl_model.logmessage = "账户：" + DrCode + "  注册失败，手机号已被注册！";
            //        sl.Add(sl_model);
            //    }

                //}
            //else if (type.Equals("update_P"))
            //{
            //    string patientCode = context.Request["patientCode"];
            //    string patientId = context.Request["patientId"];
            //    string patientName = context.Request["patientName"];
            //    string patientSex = context.Request["patientSex"];
            //    string patientBirthDay = context.Request["patientBirthDay"];
            //    string patientVocation = context.Request["patientVocation"];
            //    string patientEmail = context.Request["patientEmail"];
            //    DentalMedical.BLL.patientInfo pi = new DentalMedical.BLL.patientInfo();
            //    DentalMedical.Model.patientInfo patient = new DentalMedical.Model.patientInfo();
            //    patient.Id = new Guid(patientId);
            //    patient.patientName = patientName;
            //    patient.patientSex = int.Parse(patientSex);
            //    patient.patientVocation = patientVocation;
            //    patient.patientEmail = patientEmail;
            //    patient.patientBirthday = DateTime.Parse(patientBirthDay);
            //    patient.modifyId = new Guid(patientId);
            //    bool r = pi.Update_patientInfo(patient);
            //    if (r)
            //    {

                //        js.code = "200";
            //        js.message = "更新账户信息成功！";
            //        DentalMedical.Model.JsBool JsBool = new DentalMedical.Model.JsBool();
            //        JsBool.result = r;
            //        js.data = JsBool;
            //        strJson = JsonHelper.SerializeObject(js);
            //        sl_model.doctor_Id = Guid.Empty;
            //        sl_model.createId = Guid.Empty;
            //        sl_model.Entity = "patientInfo";
            //        sl_model.LogsType = (int)LogsType.注册;
            //        sl_model.logmessage = "账户：" + patientCode + "  更新账户信息成功~！";
            //        sl.Add(sl_model);

                //    }
            //    else
            //    {
            //        js.code = "201";
            //        js.message = "更新账户信息失败~~！";
            //        js.data = "";
            //        strJson = JsonHelper.SerializeObject(js);
            //        sl_model.doctor_Id = Guid.Empty;
            //        sl_model.createId = Guid.Empty;
            //        sl_model.Entity = "patientInfo";
            //        sl_model.LogsType = (int)LogsType.注册;
            //        sl_model.logmessage = "账户：" + patientCode + "  注册失败，手机号已被注册！";
            //        sl.Add(sl_model);
            //    }

                //}
            //else if (type.Equals("appointment"))
            //{
            //    string appointment_Add = context.Request["appointment_Add"];
            //    string patientTel = context.Request["patientTel"];
            //    string patientName = context.Request["patientName"];
            //    string appointment_demand = context.Request["appointment_demand"];
            //    string appointment_Date = context.Request["appointment_Date"];
            //    DentalMedical.BLL.appointment a = new DentalMedical.BLL.appointment();
            //    DentalMedical.Model.appointment appointment = new DentalMedical.Model.appointment();
            //    appointment.patientName = patientName;
            //    appointment.patientTel = patientTel;
            //    appointment.appointment_Add = appointment_Add;
            //    appointment.appointment_Date = DateTime.Parse(appointment_Date);
            //    appointment.appointment_demand = appointment_demand;
            //    string r = a.Add(appointment);
            //    if (!string.IsNullOrEmpty(r))
            //    {

                //        js.code = "200";
            //        js.message = "您好，您的预约已成功！";
            //        DentalMedical.Model.JsId JsId = new DentalMedical.Model.JsId();
            //        JsId.Id = new Guid(r);
            //        js.data = JsId;
            //        strJson = JsonHelper.SerializeObject(js);
            //        sl_model.doctor_Id = Guid.Empty;
            //        sl_model.createId = Guid.Empty;
            //        sl_model.Entity = "appointment";
            //        sl_model.LogsType = (int)LogsType.注册;
            //        sl_model.logmessage = "用户预约成功！";
            //        sl.Add(sl_model);

                //    }
            //    else
            //    {
            //        js.code = "201";
            //        js.message = "预约失败！";
            //        js.data = "";
            //        strJson = JsonHelper.SerializeObject(js);
            //        sl_model.doctor_Id = Guid.Empty;
            //        sl_model.createId = Guid.Empty;
            //        sl_model.Entity = "patientInfo";
            //        sl_model.LogsType = (int)LogsType.注册;
            //        sl_model.logmessage = "用户预约失败";
            //        sl.Add(sl_model);
            //    }

                //}
            #endregion

            catch (Exception ex)
            {
                js.code = "202";
                js.message = "系统错误：捕捉到异常";
                js.data = JsonHelper.SerializeObject(ex.Message);
                strJson = JsonHelper.SerializeObject(js);
                sl_model.doctor_Id = Guid.Empty;
                sl_model.createId = Guid.Empty;
                sl_model.Entity = "patientInfo";
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
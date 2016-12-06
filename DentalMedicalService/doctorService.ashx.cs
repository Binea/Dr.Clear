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
    public class doctorService : IHttpHandler
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
                #region 医生登录

                if (type.Equals("Login_D"))
                {
                    string DrCode = context.Request["doctorCode"];
                    string Drpwd = context.Request["doctorPwd"];
                    DentalMedical.BLL.doctors dc = new DentalMedical.BLL.doctors();
                    DentalMedical.Model.doctors doctors = new DentalMedical.Model.doctors();
                    doctors = dc.Login_D(DrCode, Drpwd);
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
                        doctors = dc.judge_Pwd(doctors, Drpwd);
                        if (doctors != null && doctors.Id != null)
                        {
                            dc.update_doctor_status(doctors.Id, 1);
                            js.code = "200";
                            js.message = "登陆成功";
                            js.data = doctors;//正常返回医生明细      
                            strJson = JsonHelper.SerializeObject(js);
                            sl_model.doctor_Id = Guid.Empty;
                            sl_model.createId = Guid.Empty;
                            sl_model.Entity = "doctors";
                            sl_model.LogsType = (int)LogsType.登录失败;
                            sl_model.logmessage = "账户：" + DrCode + "   登录成功！";
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
                            sl_model.logmessage = "账户：" + DrCode + "   密码错误！";
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
                        sl_model.logmessage = "账户：" + DrCode + " 该用户不存在!";
                        sl.Add(sl_model);
                    }

                }

                #endregion
                #region 医生自动登录

                else if (type.Equals("login_auto_D"))
                {
                    string doctorId = context.Request["Id"];
                    DentalMedical.BLL.doctors doc = new DentalMedical.BLL.doctors();
                    DentalMedical.Model.doctors doctors = doc.login_auto(new Guid(doctorId));
                    if (doctors != null || doctors.Id != null)
                    {
                        js.code = "200";
                        js.message = "自动登录成功！";
                        js.data = doctors;
                        strJson = JsonHelper.SerializeObject(js);
                        sl_model.doctor_Id = new Guid(doctorId);
                        sl_model.createId = new Guid(doctorId);
                        sl_model.Entity = "doctors";
                        sl_model.LogsType = (int)LogsType.登录;
                        sl_model.logmessage = "账户：" + doctorId + "  自动登录！";
                        sl.Add(sl_model);
                    }
                    else
                    {
                        js.code = "201";
                        js.message = "登录失败！";
                        js.data = "";
                        strJson = JsonHelper.SerializeObject(js);
                        sl_model.doctor_Id = new Guid(doctorId);
                        sl_model.createId = new Guid(doctorId);
                        sl_model.Entity = "doctors";
                        sl_model.LogsType = (int)LogsType.登录失败;
                        sl_model.logmessage = "账户：" + doctorId + "  自动登录失败！";
                        sl.Add(sl_model);
                    }
                }

                #endregion
                #region 医生注册
                else if (type.Equals("Register_D"))
                {
                    string DrCode = context.Request["doctorCode"];
                    string Drpwd = context.Request["doctorPwd"];
                    string key = context.Request["Key"];
                    DentalMedical.BLL.doctors dc = new DentalMedical.BLL.doctors();
                    bool r = dc.Exists(DrCode);
                    if (!r)
                    {
                        DentalMedical.BLL.message_info mi = new DentalMedical.BLL.message_info();
                        int re = mi.validate_code(DrCode, key, "0");
                        if (re == 1)
                        {

                            DentalMedical.Model.doctors doctor_model = new DentalMedical.Model.doctors();
                            doctor_model.userTel = DrCode;
                            doctor_model.userCode = DrCode;
                            doctor_model.userPwd = Drpwd;
                            doctor_model.userKey = int.Parse(key);
                            string result = dc.Add(doctor_model);
                            if (!result.Equals(string.Empty))
                            {
                                js.code = "200";
                                js.message = "注册成功！";
                                DentalMedical.Model.JsId jsid = new DentalMedical.Model.JsId();
                                jsid.Id = new Guid(result);
                                js.data = jsid;
                                strJson = JsonHelper.SerializeObject(js);
                                sl_model.doctor_Id = Guid.Empty;
                                sl_model.createId = Guid.Empty;
                                sl_model.Entity = "doctors";
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
                                sl_model.Entity = "doctors";
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
                            sl_model.Entity = "doctors";
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
                        sl_model.Entity = "doctors";
                        sl_model.LogsType = (int)LogsType.注册;
                        sl_model.logmessage = "账户：" + DrCode + "  注册失败，手机号已被注册！";
                        sl.Add(sl_model);
                    }

                }

                #endregion
                #region 医生认证

                else if (type.Equals("certification_D"))
                {
                    string doctorName = context.Request["RealName"];
                    string hId = context.Request["hospitalId"];
                    string departmentId = context.Request["departmentId"];
                    string titleId = context.Request["titleId"];
                    string workcard = context.Request["work_card"];
                    string dId = context.Request["doctorId"];
                    string certType = context.Request["certType"];
                    doctorName = ReplaceSQLChar(doctorName);
                    if (certType.Equals("New"))
                    {
                        DentalMedical.BLL.doctors dc = new DentalMedical.BLL.doctors();
                        dc.update_doctor_Info(dId, doctorName);
                    }
                    DentalMedical.BLL.doctor_certification dcer = new DentalMedical.BLL.doctor_certification();
                    DentalMedical.Model.doctor_certification dcer_model = new DentalMedical.Model.doctor_certification();
                    dcer_model.doctor_Id = new Guid(dId);
                    dcer_model.createId = new Guid(dId);
                    dcer_model.userHospital = new Guid(hId);
                    dcer_model.userDepartment = new Guid(departmentId);
                    dcer_model.userTitle = new Guid(titleId);
                    dcer_model.work_Card = workcard;
                    string result = dcer.Add(dcer_model);
                    if (result != null && !result.Equals(""))
                    {
                        js.code = "200";
                        js.message = "认证成功！";
                        DentalMedical.Model.JsId JsId = new DentalMedical.Model.JsId();
                        JsId.Id = new Guid(result);
                        js.data = JsId;
                    }
                    else
                    {
                        js.code = "201";
                        js.message = "认证失败！";
                        js.data = "";
                    }

                    strJson = JsonHelper.SerializeObject(js);

                    sl_model.doctor_Id = new Guid(dId);
                    sl_model.createId = new Guid(dId);
                    sl_model.Entity = "doctor_certification";
                    sl_model.LogsType = (int)LogsType.认证;
                    if (result != null && !result.Equals(""))
                    {
                        sl_model.logmessage = "医生：" + dId + "  姓名：" + doctorName + ",认证成功！";
                    }
                    else
                    {
                        sl_model.logmessage = "医生：" + dId + "  姓名：" + doctorName + ",认证失败！";
                    }
                    sl.Add(sl_model);

                }

                #endregion
                #region 医生登出

                else if (type.Equals("login_out"))
                {
                    string dId = context.Request["doctorId"];
                    DentalMedical.BLL.doctors dc = new DentalMedical.BLL.doctors();
                    bool result = dc.update_doctor_status(new Guid(dId), 0);
                    if (result)
                    {
                        js.code = "200";
                        js.message = "退出登录成功！";
                        DentalMedical.Model.JsBool jsbool = new DentalMedical.Model.JsBool();
                        jsbool.result = result;
                        js.data = jsbool;

                    }
                    else
                    {
                        js.code = "201";
                        js.message = "退出登录失败！";
                        js.data = "";
                    }
                    strJson = JsonHelper.SerializeObject(js);
                    sl_model.doctor_Id = new Guid(dId);
                    sl_model.createId = new Guid(dId);
                    sl_model.Entity = "doctors";
                    sl_model.LogsType = (int)LogsType.登出;
                    sl_model.logmessage = "医生：" + dId + "  ，退出登录！";
                    sl.Add(sl_model);
                }

                #endregion
                #region 更新医生信息

                else if (type.Equals("update_info"))
                {
                    string doctorName = context.Request["RealName"];
                    string dId = context.Request["doctorId"];
                    string sex = context.Request["sex"];
                    string email = context.Request["email"];
                    string logo = context.Request["logo"];
                    DentalMedical.BLL.doctors dc = new DentalMedical.BLL.doctors();
                    bool result = dc.update_doctor_Info(dId, doctorName, int.Parse(sex), email, logo);
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
                #region 更新医生认证信息

                else if (type.Equals("update_d_certification"))
                {
                    string hospitalId = context.Request["hospitalId"];
                    string deId = context.Request["departmentId"];
                    string titleId = context.Request["titleId"];
                    string dcId = context.Request["dcId"];
                    string workCard = context.Request["work_card"];
                    string doctorId = context.Request["doctorId"];
                    DentalMedical.BLL.doctor_certification dc_bll = new DentalMedical.BLL.doctor_certification();
                    DentalMedical.Model.doctor_certification dc = new DentalMedical.Model.doctor_certification();
                    dc.userHospital = new Guid(hospitalId);
                    dc.userDepartment = new Guid(deId);
                    dc.userTitle = new Guid(titleId);
                    dc.work_Card = workCard;
                    dc.Id = new Guid(dcId);
                    dc.modifyId = new Guid(doctorId);

                    bool result = dc_bll.Update_d_certification(dc);
                    if (result)
                    {
                        js.code = "200";
                        js.message = "更新认证信息成功！";
                        DentalMedical.Model.JsBool jsbool = new DentalMedical.Model.JsBool();
                        jsbool.result = result;
                        js.data = jsbool;
                    }
                    else
                    {
                        js.code = "201";
                        js.message = "更新认证信息失败！";
                        js.data = "";
                    }

                    strJson = JsonHelper.SerializeObject(js);
                    sl_model.doctor_Id = new Guid(doctorId);
                    sl_model.createId = new Guid(doctorId);
                    sl_model.Entity = "doctors";
                    sl_model.LogsType = (int)LogsType.注册;
                    sl_model.logmessage = "医生：" + doctorId + ",更新认证信息！";
                    sl.Add(sl_model);
                }

                #endregion
                #region 删除医生认证信息

                else if (type.Equals("delete_d_certification"))
                {
                    string doctorId = context.Request["doctorId"];
                    string dcId = context.Request["dcId"];
                    DentalMedical.BLL.doctor_certification dc_bll = new DentalMedical.BLL.doctor_certification();


                    bool result = dc_bll.delete_d_certification(new Guid(dcId), new Guid(doctorId));
                    if (result)
                    {
                        js.code = "200";
                        js.message = "删除认证信息成功！";
                        DentalMedical.Model.JsBool jsbool = new DentalMedical.Model.JsBool();
                        jsbool.result = result;
                        js.data = jsbool;
                    }
                    else
                    {
                        js.code = "201";
                        js.message = "删除认证信息失败！";
                        js.data = "";
                    }

                    strJson = JsonHelper.SerializeObject(js);
                    sl_model.doctor_Id = new Guid(doctorId);
                    sl_model.createId = new Guid(doctorId);
                    sl_model.Entity = "doctors_certification";
                    sl_model.LogsType = (int)LogsType.认证;
                    sl_model.logmessage = "医生：" + doctorId + ",删除认证信息！" + result.ToString();
                    sl.Add(sl_model);
                }

                #endregion
                #region 确定工厂码

                else if (type.Equals("F_Code"))
                {
                    string dId = context.Request["doctorId"];
                    string F_Code = context.Request["factoryCode"];
                    DentalMedical.BLL.doctors dc = new DentalMedical.BLL.doctors();
                    int result = dc.update_F_Code(dId, F_Code);
                    if (result > 0)
                    {

                        js.code = "200";
                        js.message = "工厂F码更新成功！";
                        DentalMedical.Model.JsBool jsbool = new DentalMedical.Model.JsBool();
                        jsbool.result = true;
                        js.data = jsbool;
                    }
                    else
                    {
                        js.message = "工厂F嘛更新失败！";
                        if (result == -1)
                        {
                            js.message = "F码不存在！请确定厂商提供的F码是否正确！";
                        }
                        js.code = "201";
                        js.data = "";
                    }

                    strJson = JsonHelper.SerializeObject(js);

                    sl_model.doctor_Id = new Guid(dId);
                    sl_model.createId = new Guid(dId);
                    sl_model.Entity = "doctors";
                    sl_model.LogsType = (int)LogsType.注册;
                    sl_model.logmessage = "医生：" + dId + ",填写工厂邀请码！";
                    sl.Add(sl_model);
                }

                #endregion
                #region 医生授权--暂废


                else if (type.Equals("authorize_technician"))
                {
                    string Drcode = context.Request["Drcode"];
                    string Drpwd = context.Request["Drpwd"];
                    string Key = context.Request["Key"];
                    string Pid = context.Request["Pid"];
                    string certId = context.Request["certId"];
                    string dt_Name = context.Request["dtName"];
                    DentalMedical.BLL.doctors dc = new DentalMedical.BLL.doctors();
                    DentalMedical.Model.doctors doctors = new DentalMedical.Model.doctors();
                    bool r = dc.Exists(Drcode);
                    if (!r)
                    {
                        DentalMedical.BLL.message_info mi = new DentalMedical.BLL.message_info();
                        int re = mi.validate_code(Drcode, Key, "0");
                        if (re > 0)
                        {

                            doctors.userCode = Drcode;
                            doctors.userPwd = Drpwd;
                            doctors.userTel = Drcode;
                            doctors.userKey = int.Parse(Key);
                            doctors.doctor_Id = new Guid(Pid);
                            doctors.userSchool = 2;
                            doctors.userRealName = dt_Name;
                            string mechanicId = dc.Add(doctors);
                            if (!mechanicId.Equals(string.Empty))
                            {
                                DentalMedical.BLL.authorize_technician atbll = new DentalMedical.BLL.authorize_technician();
                                bool result_de = atbll.delete_exauthorize(new Guid(Pid), new Guid(certId));
                                DentalMedical.Model.authorize_technician at = new DentalMedical.Model.authorize_technician();
                                at.dcId = new Guid(certId);
                                at.mechanicId = new Guid(mechanicId);
                                at.doctorId = new Guid(Pid);
                                at.createId = new Guid(Pid);
                                at.orderId = 1;
                                at.userRemark = "授权";
                                //int result = dc.authorize_technician(new Guid(certId), new Guid(doctorId), new Guid(Pid));


                                string result = atbll.Add(at);
                                if (!string.IsNullOrEmpty(result))
                                {
                                    dc.update_dcStatus(new Guid(certId));
                                    js.code = "200";
                                    js.message = "授权成功！";
                                    DentalMedical.Model.JsBool jsbool = new DentalMedical.Model.JsBool();
                                    jsbool.result = true;
                                    js.data = jsbool;
                                    sl_model.doctor_Id = new Guid(Pid);
                                    sl_model.createId = new Guid(Pid);
                                    sl_model.Entity = "doctors";
                                    sl_model.LogsType = (int)LogsType.动作;
                                    sl_model.logmessage = "医生：" + Pid + ",授权给技师：" + Drcode + " 成功";
                                    sl.Add(sl_model);
                                }
                                else
                                {
                                    js.code = "201";
                                    js.message = "授权失败！";
                                    js.data = "";
                                    sl_model.doctor_Id = new Guid(Pid);
                                    sl_model.createId = new Guid(Pid);
                                    sl_model.Entity = "doctors";
                                    sl_model.LogsType = (int)LogsType.错误;
                                    sl_model.logmessage = "医生：" + Pid + ",授权给技师：" + Drcode + " 失败";
                                    sl.Add(sl_model);
                                }


                            }
                            else
                            {
                                js.code = "201";
                                js.message = "授权失败！";
                                js.data = "";
                                sl_model.doctor_Id = new Guid(Pid);
                                sl_model.createId = new Guid(Pid);
                                sl_model.Entity = "doctors";
                                sl_model.LogsType = (int)LogsType.错误;
                                sl_model.logmessage = "授权给账户：" + Drcode + "  授权失败！";
                                sl.Add(sl_model);
                            }

                        }
                        else
                        {
                            js.code = "201";
                            js.message = "验证码错误！";
                            js.data = "";

                            sl_model.doctor_Id = Guid.Empty;
                            sl_model.createId = Guid.Empty;
                            sl_model.Entity = "doctors";
                            sl_model.LogsType = (int)LogsType.注册;
                            sl_model.logmessage = "账户：" + Drcode + "  授权失败，验证码错误";
                            sl.Add(sl_model);
                        }
                    }
                    else
                    {
                        DentalMedical.BLL.message_info mi = new DentalMedical.BLL.message_info();
                        int re = mi.validate_code(Drcode, Key, "0");
                        if (re > 0)
                        {
                            doctors = dc.Login_D(Drcode, Drpwd);
                            if (doctors != null && doctors.Id != null)
                            {
                                doctors = dc.judge_Pwd(doctors, Drpwd);
                                if (doctors != null && doctors.Id != null)
                                {
                                    DentalMedical.BLL.authorize_technician atbll = new DentalMedical.BLL.authorize_technician();
                                    bool res = atbll.Exists(new Guid(Pid), new Guid(certId), doctors.Id);
                                    if (res)
                                    {
                                        js.code = "201";
                                        js.message = "该账户已被授权！！";
                                        js.data = "";
                                        sl_model.doctor_Id = Guid.Empty;
                                        sl_model.createId = Guid.Empty;
                                        sl_model.Entity = "doctors";
                                        sl_model.LogsType = (int)LogsType.注册;
                                        sl_model.logmessage = "账户：" + Drcode + "  授权失败，已被授权";
                                        sl.Add(sl_model);
                                        strJson = JsonHelper.SerializeObject(js);
                                    }
                                    else
                                    {
                                        DentalMedical.Model.authorize_technician at = new DentalMedical.Model.authorize_technician();
                                        at.mechanicId = doctors.Id;
                                        at.doctorId = new Guid(Pid);
                                        at.dcId = new Guid(certId);
                                        at.orderId = 1;
                                        at.userRemark = "授权";
                                        at.createId = new Guid(Pid);
                                        string result = atbll.Add(at);
                                        if (!string.IsNullOrEmpty(result))
                                        {

                                            dc.update_dcStatus(new Guid(certId));
                                            js.code = "200";
                                            js.message = "授权成功！";
                                            DentalMedical.Model.JsBool jsbool = new DentalMedical.Model.JsBool();
                                            jsbool.result = true;
                                            js.data = jsbool;
                                            sl_model.doctor_Id = new Guid(Pid);
                                            sl_model.createId = new Guid(Pid);
                                            sl_model.Entity = "doctors";
                                            sl_model.LogsType = (int)LogsType.动作;
                                            sl_model.logmessage = "医生：" + Pid + ",授权给技师：" + Drcode + " 成功";
                                            sl.Add(sl_model);
                                        }
                                        else
                                        {
                                            js.code = "201";
                                            js.message = "授权失败！";
                                            js.data = "";
                                            sl_model.doctor_Id = new Guid(Pid);
                                            sl_model.createId = new Guid(Pid);
                                            sl_model.Entity = "doctors";
                                            sl_model.LogsType = (int)LogsType.错误;
                                            sl_model.logmessage = "医生：" + Pid + ",授权给技师：" + Drcode + " 失败";
                                            sl.Add(sl_model);
                                        }
                                    }
                                }
                                else
                                {
                                    js.code = "201";
                                    js.message = "此账户已注册，密码错误！";
                                    js.data = "";//返回4 说明密码错误    
                                    strJson = JsonHelper.SerializeObject(js);
                                    sl_model.doctor_Id = Guid.Empty;
                                    sl_model.createId = Guid.Empty;
                                    sl_model.Entity = "doctors";
                                    sl_model.LogsType = (int)LogsType.登录失败;
                                    sl_model.logmessage = "账户：" + Drcode + "   被授权技师密码错误！";
                                    sl.Add(sl_model);
                                }
                            }
                            else
                            {
                                js.code = "201";
                                js.message = "授权出现错误，请重新授权！";
                                js.data = "";//返回4 说明密码错误    
                                strJson = JsonHelper.SerializeObject(js);
                                sl_model.doctor_Id = Guid.Empty;
                                sl_model.createId = Guid.Empty;
                                sl_model.Entity = "doctors";
                                sl_model.LogsType = (int)LogsType.登录失败;
                                sl_model.logmessage = "账户：" + Drcode + "   授权时，查询出现问题！";
                                sl.Add(sl_model);
                            }

                        }
                        else
                        {
                            js.code = "201";
                            js.message = "验证码错误！";
                            js.data = "";

                            sl_model.doctor_Id = Guid.Empty;
                            sl_model.createId = Guid.Empty;
                            sl_model.Entity = "doctors";
                            sl_model.LogsType = (int)LogsType.注册;
                            sl_model.logmessage = "账户：" + Drcode + "  授权失败，验证码错误";
                            sl.Add(sl_model);
                        }

                    }
                }
                #endregion
                #region 医生注册数量

                else if (type.Equals("doctorNum"))
                {
                    DentalMedical.BLL.doctors dc = new DentalMedical.BLL.doctors();
                    int num = dc.get_doctor_num();
                    if (num > 0)
                    {
                        js.code = "200";
                        js.message = "请求成功！";
                        DentalMedical.Model.JsInt jsint = new DentalMedical.Model.JsInt();
                        jsint.num = num;
                        js.data = jsint;
                    }
                    else
                    {
                        js.code = "201";
                        js.message = "请求失败！";
                        js.data = "";
                    }
                    strJson = JsonHelper.SerializeObject(js);
                }

                #endregion
                #region 搜索医生
                          
                else if (type.Equals("searchdoctor"))
                {
                    string codeid=context.Request["codeid"];
                    DentalMedical.BLL.doctors doctor = new DentalMedical.BLL.doctors();
                    List<DentalMedical.Model.search_doctor> searchdoctor = new List<DentalMedical.Model.search_doctor>();
                    searchdoctor=doctor.search_doctor(codeid);
                    if (searchdoctor != null)
                    {
                        js.code = "200";
                        js.message = "请求成功！";
                        js.data = searchdoctor;
                        strJson = JsonHelper.SerializeObject(js);
                    }
                    else
                    {
                        js.code = "201";
                        js.message = "请求服务器失败！";
                        js.data = "";
                        strJson = JsonHelper.SerializeObject(js);
                    }
                }
                #endregion               
                #region 医生绑定微信
             
                else if (type.Equals("update_doctor_weixin"))
                {
                    string DrCode = context.Request["doctorCode"];
                    string openId = context.Request["openId"];
                    string key = context.Request["Key"];
                    DentalMedical.BLL.doctors dcbll = new DentalMedical.BLL.doctors();
                    bool r = dcbll.Exists(DrCode);
                    if (r)
                    {
                        DentalMedical.BLL.message_info mi = new DentalMedical.BLL.message_info();
                        int re = mi.validate_code(DrCode, key, "0");
                        if (re == 1)
                        {
                            bool result = dcbll.update_doctor_weixin(DrCode, openId);

                            if (result)
                            {
                                js.code = "200";
                                js.message = "注册成功！";
                                DentalMedical.Model.JsBool JsBool = new DentalMedical.Model.JsBool();
                                JsBool.result = result;
                                js.data = JsBool;
                                strJson = JsonHelper.SerializeObject(js);
                                sl_model.doctor_Id = Guid.Empty;
                                sl_model.createId = Guid.Empty;
                                sl_model.Entity = "doctors";
                                sl_model.LogsType = (int)LogsType.注册;
                                sl_model.logmessage = "微信openId：" + openId + "  绑定PID：" + DrCode + "成功";
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
                                sl_model.Entity = "doctors";
                                sl_model.LogsType = (int)LogsType.注册;
                                sl_model.logmessage = "微信openId：" + openId + "  绑定PID：" + DrCode + "失败";
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
                            sl_model.Entity = "doctors";
                            sl_model.LogsType = (int)LogsType.注册;
                            sl_model.logmessage = "账户：" + DrCode + "  注册失败，验证码错误";
                            sl.Add(sl_model);
                        }
                    }
                    else
                    {
                        js.code = "201";
                        js.message = "此手机号未注册！请联系可丽尔！";
                        js.data = "";
                        strJson = JsonHelper.SerializeObject(js);
                        sl_model.doctor_Id = Guid.Empty;
                        sl_model.createId = Guid.Empty;
                        sl_model.Entity = "doctors";
                        sl_model.LogsType = (int)LogsType.注册;
                        sl_model.logmessage = "账户：" + DrCode + "  注册失败，手机号已被注册！";
                        sl.Add(sl_model);
                    }
                }

                #endregion
                #region 通过微信查询信息
              
                else if (type.Equals("Query_Code_weixin"))
                {
                    string openId = context.Request["openId"];
                    DentalMedical.BLL.doctors dcbll = new DentalMedical.BLL.doctors();
                    DentalMedical.Model.doctors dc = new DentalMedical.Model.doctors();
                    dc= dcbll.Query_Code_weixin(openId);
                    if (dc != null && dc.Id != null)
                    {
                        js.code = "200";
                        js.message = "获取信息成功";
                        js.data = dc;//正常返回医生明细      
                        strJson = JsonHelper.SerializeObject(js);
                        sl_model.doctor_Id = dc.Id;
                        sl_model.createId = dc.Id;
                        sl_model.Entity = "doctors";
                        sl_model.LogsType = (int)LogsType.登录失败;
                        sl_model.logmessage = "微信：" + openId + "   查询信息成功！";
                        sl.Add(sl_model);
                    }
                    else
                    {
                        js.code = "201";
                        js.message = "还未绑定PID！";
                        js.data = "";//返回4 说明密码错误    
                        strJson = JsonHelper.SerializeObject(js);
                        sl_model.doctor_Id = Guid.Empty;
                        sl_model.createId = Guid.Empty;
                        sl_model.Entity = "doctors";
                        sl_model.LogsType = (int)LogsType.登录失败;
                        sl_model.logmessage = "微信：" + openId + "   查询信息失败！";
                        sl.Add(sl_model);
                    }
                }

                #endregion
                #region 上传模型
                
                else if (type.Equals("uploadmodel"))
                {
                    DentalMedical.BLL.stl_d_data stlbll = new DentalMedical.BLL.stl_d_data();
                    DentalMedical.Model.stl_d_data stl = new DentalMedical.Model.stl_d_data();
                    string imageType = context.Request["imageType"];
                    string emrcode = context.Request["emrcode"];
                    string doctorId = context.Request["doctorId"];
                    string filepath = context.Request["filepath"];
                    stl = new DentalMedical.Model.stl_d_data();
                    stl.createId = new Guid(doctorId);
                    stl.model_type = int.Parse(imageType);
                    stl.status = 1;
                    stl.EMR_Code = emrcode;
                    stl.filePath = filepath;
                    string id = stlbll.Add(stl);
                    DentalMedical.BLL.simple_EMR sebll = new DentalMedical.BLL.simple_EMR();
                    DentalMedical.Model.simple_EMR se = new DentalMedical.Model.simple_EMR();
                    sebll.update_Emr_Status((int)EMRStatusEnum.提交, emrcode, doctorId);//将状态置为1
                    if (!id.Equals(string.Empty))
                    {
                        js.code = "200";
                        js.message = "提交模型数据成功！！";
                        DentalMedical.Model.JsId jsid = new DentalMedical.Model.JsId();
                        jsid.Id = new Guid(id);
                        js.data = jsid;
                        strJson = JsonHelper.SerializeObject(js);
                        sl_model.doctor_Id = Guid.Empty;
                        sl_model.createId = Guid.Empty;
                        sl_model.Entity = "doctors";
                        sl_model.LogsType = (int)LogsType.动作;
                        sl_model.logmessage = "医生：" + doctorId + "  提交模型数据成功！";
                        sl.Add(sl_model);
                    }
                    else
                    {
                        js.code = "201";
                        js.message = "提交模型数据失败！";
                        js.data = "";
                        strJson = JsonHelper.SerializeObject(js);
                        sl_model.doctor_Id = Guid.Empty;
                        sl_model.createId = Guid.Empty;
                        sl_model.Entity = "doctors";
                        sl_model.LogsType = (int)LogsType.动作;
                        sl_model.logmessage = "医生：" + doctorId + "  提交模型数据失败！";
                        sl.Add(sl_model);
                    }
                }
                #endregion
                #region 重置密码为123456
               
                else if (type.Equals("reset_pwd"))
                {
                    string DrCode = context.Request["doctorCode"];
                    DentalMedical.BLL.doctors d = new DentalMedical.BLL.doctors();
                    bool result = d.reset_pwd(DrCode);
                    if (result)
                    {
                        js.code = "200";
                        js.message = "重置密码成功!";
                        DentalMedical.Model.JsBool JsBool = new DentalMedical.Model.JsBool();
                        JsBool.result = true;
                        js.data = JsBool;
                        strJson = JsonHelper.SerializeObject(js);
                        sl_model.doctor_Id = Guid.Empty;
                        sl_model.createId = Guid.Empty;
                        sl_model.Entity = "doctors";
                        sl_model.LogsType = (int)LogsType.动作;
                        sl_model.logmessage = "后台重置医生：" + DrCode + "  密码成功！";
                        sl.Add(sl_model);
                    }
                    else
                    {
                        js.code = "201";
                        js.message = "重置密码失败，若多次失败请联系管理员!";
                        DentalMedical.Model.JsBool JsBool = new DentalMedical.Model.JsBool();
                        JsBool.result = true;
                        js.data = JsBool;
                        strJson = JsonHelper.SerializeObject(js);
                        sl_model.doctor_Id = Guid.Empty;
                        sl_model.createId = Guid.Empty;
                        sl_model.Entity = "doctors";
                        sl_model.LogsType = (int)LogsType.动作;
                        sl_model.logmessage = "后台重置医生：" + DrCode + "  密码失败！";
                        sl.Add(sl_model);
                    }
                }

                #endregion
                #region 修改密码
             
                else if (type.Equals("modify_pwd"))
                {
                    string DrCode = context.Request["doctorCode"];
                    string Drpwd = context.Request["doctorPwd"];
                    string key = context.Request["Key"];
                     DentalMedical.BLL.message_info mi = new DentalMedical.BLL.message_info();
                        int re = mi.validate_code(DrCode, key, "7");
                        if (re == 1)
                        {
                            DentalMedical.BLL.doctors d = new DentalMedical.BLL.doctors();
                            bool result = d.modify_pwd(DrCode, Drpwd);
                            if (result)
                            {
                                js.code = "200";
                                js.message = "修改密码成功!";
                                DentalMedical.Model.JsBool JsBool = new DentalMedical.Model.JsBool();
                                JsBool.result = true;
                                js.data = JsBool;
                                strJson = JsonHelper.SerializeObject(js);
                                sl_model.doctor_Id = Guid.Empty;
                                sl_model.createId = Guid.Empty;
                                sl_model.Entity = "doctors";
                                sl_model.LogsType = (int)LogsType.动作;
                                sl_model.logmessage = "医生：" + DrCode + "  修改密码成功！";
                                sl.Add(sl_model);
                            }
                            else
                            {
                                js.code = "201";
                                js.message = "修改密码失败，若多次失败请联系管理员!";
                                DentalMedical.Model.JsBool JsBool = new DentalMedical.Model.JsBool();
                                JsBool.result = true;
                                js.data = JsBool;
                                strJson = JsonHelper.SerializeObject(js);
                                sl_model.doctor_Id = Guid.Empty;
                                sl_model.createId = Guid.Empty;
                                sl_model.Entity = "doctors";
                                sl_model.LogsType = (int)LogsType.动作;
                                sl_model.logmessage = "医生：" + DrCode + "  修改密码失败！";
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
                            sl_model.Entity = "doctors";
                            sl_model.LogsType = (int)LogsType.注册;
                            sl_model.logmessage = "账户：" + DrCode + "  注册失败，验证码错误";
                            sl.Add(sl_model);
                        }
                }

                #endregion
                #region 查询账户是否存在
            
                else if (type.Equals("query_code"))
                {
                    string DrCode = context.Request["doctorCode"];
                    DentalMedical.BLL.doctors dc = new DentalMedical.BLL.doctors();
                    DentalMedical.Model.doctors doctors = new DentalMedical.Model.doctors();
                    doctors = dc.Login_D(DrCode, null);
                    if (doctors != null && doctors.Id != null)
                    {
                        js.code = "200";
                        js.message = "该用户存在！";
                        js.data = doctors;//正常返回医生明细      
                        strJson = JsonHelper.SerializeObject(js);
                        sl_model.doctor_Id = Guid.Empty;
                        sl_model.createId = Guid.Empty;
                        sl_model.Entity = "doctors";
                        sl_model.LogsType = (int)LogsType.登录失败;
                        sl_model.logmessage = "账户：" + DrCode + "   用户存在！";
                        sl.Add(sl_model);
                    }
                    else
                    {
                        js.code = "201";
                        js.message = "该用户不存在！";
                        js.data = "";//返回4 说明密码错误    
                        strJson = JsonHelper.SerializeObject(js);
                        sl_model.doctor_Id = Guid.Empty;
                        sl_model.createId = Guid.Empty;
                        sl_model.Entity = "doctors";
                        sl_model.LogsType = (int)LogsType.登录失败;
                        sl_model.logmessage = "账户：" + DrCode + " 用户不存在！";
                        sl.Add(sl_model);
                    }
                }

                #endregion
                else
                {
                    js.code = "101";
                    js.message = "系统错误：没有该操作！type：" + type;
                    js.data = "";
                    strJson = JsonHelper.SerializeObject(js);
                    sl_model.doctor_Id = Guid.Empty;
                    sl_model.createId = Guid.Empty;
                    sl_model.Entity = "doctors";
                    sl_model.LogsType = (int)LogsType.错误;
                    sl_model.logmessage = "错误操作！";
                    sl.Add(sl_model);
                    //string url = "http://www.clearbos.com/clear.html";
                    //context.Response.Redirect(url);
                    //return;
                }
            }
            catch (Exception ex)
            {
                js.code = "202";
                js.message = "系统错误：捕捉到异常";
                js.data = JsonHelper.SerializeObject(ex.Message);
                strJson = JsonHelper.SerializeObject(js);
                sl_model.doctor_Id = Guid.Empty;
                sl_model.createId = Guid.Empty;
                sl_model.Entity = "doctors";
                sl_model.LogsType = (int)LogsType.错误;
                sl_model.logmessage ="方法："+type+",错误原因："+ ex.Message;
                sl.Add(sl_model);
                //string url = "http://www.clearbos.com/clear.html";
                //context.Response.Redirect(url);
                //return;
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
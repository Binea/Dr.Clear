using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DentalMedical.Common;
using DentalMedical.DentalEnumeration;
using System.Data;

namespace DentalMedicalService
{
    /// <summary>
    /// factoryService 的摘要说明
    /// </summary>
    public class factoryService : IHttpHandler
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

                #region 工厂登录
             
                if (type.Equals("Login"))
                {
                    string factoryCode = context.Request["factoryCode"];
                    string pwd = context.Request["fatcoryPwd"];
                    DentalMedical.BLL.factory fa = new DentalMedical.BLL.factory();
                    DentalMedical.Model.factory factory = fa.Login_F(factoryCode, pwd);
                    if (factory != null && factory.Id != null)
                    {
                        int onlineStauts = factory.onlineStatus;
                        //if (onlineStauts == 1)
                        //{
                        //    js.code = "201";
                        //    js.message = "该账号处于登录状态!";
                        //    js.data = "";//登录返回是3的话 说明该账号处于登录状态      
                        //    strJson = JsonHelper.SerializeObject(js);
                        //    sl_model.doctor_Id = Guid.Empty;
                        //    sl_model.createId = Guid.Empty;
                        //    sl_model.Entity = "factory";
                        //    sl_model.LogsType = (int)LogsType.登录失败;
                        //    sl_model.logmessage = "账户：" + factoryCode + "   已经登录！";
                        //    sl.Add(sl_model);

                        //}
                        //else
                        //{
                            factory = fa.judge_pwd(factory, pwd);
                            if (factory != null)
                            {
                                fa.update_F_status(factory.Id, 1);
                                js.code = "200";
                                js.message = "登陆成功";
                                js.data = factory;//正常返回工厂明细      
                                strJson = JsonHelper.SerializeObject(js);
                                sl_model.doctor_Id = Guid.Empty;
                                sl_model.createId = Guid.Empty;
                                sl_model.Entity = "factory";
                                sl_model.LogsType = (int)LogsType.登录失败;
                                sl_model.logmessage = "账户：" + factoryCode + "   登录成功！";
                                sl.Add(sl_model);
                            }
                            else
                            {
                                js.code = "201";
                                js.message = "密用户名或密码错误，请重新输入";
                                js.data = "";//返回4 说明密码错误    
                                strJson = JsonHelper.SerializeObject(js);
                                sl_model.doctor_Id = Guid.Empty;
                                sl_model.createId = Guid.Empty;
                                sl_model.Entity = "factory";
                                sl_model.LogsType = (int)LogsType.登录失败;
                                sl_model.logmessage = "账户：" + factoryCode + " 密码错误";
                                sl.Add(sl_model);
                            }
                        //}
                    }

                    else
                    {
                        js.code = "201";
                        js.message = "用户名或密码错误，请重新输入";
                        js.data = "";//返回4    
                        strJson = JsonHelper.SerializeObject(js);
                        sl_model.doctor_Id = Guid.Empty;
                        sl_model.createId = Guid.Empty;
                        sl_model.Entity = "factory";
                        sl_model.LogsType = (int)LogsType.登录失败;
                        sl_model.logmessage = "账户：" + factoryCode + "  该用户不存在！";
                        sl.Add(sl_model);
                    }


                }

                #endregion
                #region 自动登录
           
                else if (type.Equals("Login_auto"))
                {
                    string id = context.Request["factory_Id"];
                    DentalMedical.BLL.factory fa = new DentalMedical.BLL.factory();
                    DentalMedical.Model.factory factory = fa.Login_F_Auto(new Guid(id));
                    if (factory != null || factory.Id != null)
                    {
                        js.code = "200";
                        js.message = "自动登录成功！";
                        js.data = factory;
                        strJson = JsonHelper.SerializeObject(js);
                        sl_model.doctor_Id = new Guid(id);
                        sl_model.createId = new Guid(id);
                        sl_model.Entity = "factory";
                        sl_model.LogsType = (int)LogsType.登录;
                        sl_model.logmessage = "账户：" + id + "  自动登录！";
                        sl.Add(sl_model);
                    }
                    else
                    {
                        js.code = "201";
                        js.message = "该用户不存在，或已失效，登录失败！";
                        js.data = "";
                        strJson = JsonHelper.SerializeObject(js);
                        sl_model.doctor_Id = new Guid(id);
                        sl_model.createId = new Guid(id);
                        sl_model.Entity = "factory";
                        sl_model.LogsType = (int)LogsType.登录失败;
                        sl_model.logmessage = "账户：" + id + "  自动登录失败！";
                        sl.Add(sl_model);
                    }
                    strJson = JsonHelper.SerializeObject(factory);//正常返回医生明细
                }

                #endregion
                #region 登出
             
                else if (type.Equals("Login_out"))
                {
                    string Id = context.Request["Id"];
                    DentalMedical.BLL.factory fa = new DentalMedical.BLL.factory();
                    bool result = fa.update_F_status(new Guid(Id), 0);
                    if (result)
                    {
                        js.code = "200";
                        js.message = "退出登录成功！";
                        DentalMedical.Model.JsBool jsbool = new DentalMedical.Model.JsBool();
                        jsbool.result = true;
                        js.data = jsbool;
                    }
                    else
                    {
                        js.code = "201";
                        js.message = "退出登录失败！";
                        js.data = "";
                    }
                    strJson = JsonHelper.SerializeObject(js);
                    sl_model.doctor_Id = new Guid(Id);
                    sl_model.createId = new Guid(Id);
                    sl_model.Entity = "factory";
                    sl_model.LogsType = (int)LogsType.登出;
                    sl_model.logmessage = "工厂：" + Id + "  ，登出！" + result;
                    sl.Add(sl_model);
                }

                #endregion
                #region 工厂注册
              
                else if (type.Equals("Register_F"))
                {
                    string factoryCode = context.Request["factoryCode"];
                    string factoryPwd = context.Request["factoryPwd"];
                    string key = context.Request["Key"];
                    DentalMedical.BLL.factory fc = new DentalMedical.BLL.factory();
                    bool r = fc.Exists(factoryCode);
                    if (!r)
                    {
                        DentalMedical.BLL.message_info mi = new DentalMedical.BLL.message_info();
                        int re = mi.validate_code(factoryCode, key, "1");
                        if (re == 1)
                        {

                            DentalMedical.Model.factory factory_model = new DentalMedical.Model.factory();                          
                            factory_model.factoryCode = factoryCode;
                            factory_model.factoryPwd = factoryPwd;
                            factory_model.factoryKey = int.Parse(key);
                            factory_model.factoryTel = factoryCode;
                            factory_model.invit_code = StringUtil.GetRandomString(5);
                            string result = fc.Add(factory_model);
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
                                sl_model.Entity = "factory";
                                sl_model.LogsType = (int)LogsType.注册;
                                sl_model.logmessage = "工厂：" + factoryCode + "  注册";
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
                                sl_model.Entity = "factory";
                                sl_model.LogsType = (int)LogsType.注册;
                                sl_model.logmessage = "工厂：" + factoryCode + "  注册失败，数据插入不成功！";
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
                            sl_model.logmessage = "工厂账户：" + factoryCode + "  注册失败，验证码错误";
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
                        sl_model.logmessage = "工厂账户：" + factoryCode + "  注册失败，此手机号已被注册！";
                        sl.Add(sl_model);
                    }
                }

                #endregion
                #region 工厂认证
            
                else if (type.Equals("certification_F"))
                {
                    string factoryName = context.Request["factoryName"];
                    string fId = context.Request["factoryId"];
                    string legal_Person = context.Request["legal_Person"];
                    string organization_Code = context.Request["organization_Code"];
                    string main_Person = context.Request["main_Person"];
                    string main_Tel = context.Request["main_Tel"];
                    string business_license = context.Request["business_license"];
                    string Legal_ID = context.Request["Legal_ID"];
                    string medical_license = context.Request["medical_license"];
                    string instrument_license = context.Request["instrument_license"];
                    DentalMedical.BLL.factory fc = new DentalMedical.BLL.factory();
                    fc.update_F_name(new Guid(fId), factoryName);
                    DentalMedical.BLL.factory_certification fcc = new DentalMedical.BLL.factory_certification();
                    DentalMedical.Model.factory_certification fcc_model = new DentalMedical.Model.factory_certification();
                    fcc_model.factory_Id = new Guid(fId);
                    fcc_model.legal_Person = legal_Person;
                    fcc_model.organization_Code = organization_Code;
                    fcc_model.main_Person = main_Person;
                    fcc_model.main_Tel = main_Tel;
                    fcc_model.business_license = business_license;
                    fcc_model.Legal_ID = Legal_ID;
                    fcc_model.medical_license = medical_license;
                    fcc_model.instrument_license = instrument_license;
                    bool result = fcc.Add(fcc_model);
                    if (result)
                    {
                        js.code = "200";
                        js.message = "认证成功！";
                        DentalMedical.Model.JsBool jsbool = new DentalMedical.Model.JsBool();
                        jsbool.result = true;
                        js.data = jsbool;
                    }
                    else
                    {
                        js.code = "201";
                        js.message = "认证失败！";
                        js.data = "";
                    }
                    strJson = JsonHelper.SerializeObject(js);
                    if (result)
                    {
                        sl_model.doctor_Id = new Guid(fId);
                        sl_model.createId = new Guid(fId);
                        sl_model.Entity = "factory_certification";
                        sl_model.LogsType = (int)LogsType.认证;
                        sl_model.logmessage = "工厂：" + fId + "  工厂名：" + factoryName + ",认证成功！";
                        sl.Add(sl_model);
                    }
                    else
                    {
                        sl_model.doctor_Id = new Guid(fId);
                        sl_model.createId = new Guid(fId);
                        sl_model.Entity = "factory_certification";
                        sl_model.LogsType = (int)LogsType.认证;
                        sl_model.logmessage = "工厂：" + fId + "  工厂名：" + factoryName + ",认证失败！";
                        sl.Add(sl_model);
                    }
                }

                #endregion
                #region 付款
                
         
                else if (type.Equals("payment"))
                {
                    string EMR_Code = context.Request["EMR_Code"];
                    string factory_Id = context.Request["factory_Id"];
                    string channel = context.Request["channel"];
                    string Paytype = context.Request["Paytype"];
                    string bill_code = context.Request["bill_code"];
                    DentalMedical.BLL.payment_info pi = new DentalMedical.BLL.payment_info();
                    DentalMedical.Model.payment_info pi_model = new DentalMedical.Model.payment_info();
                    pi_model.factory_Id = new Guid(factory_Id);
                    pi_model.EMR_Code = EMR_Code;
                    pi_model.channel = channel;
                    pi_model.bill_code = bill_code;
                    bool result = pi.Add(pi_model);
                    strJson = JsonHelper.SerializeObject(result);

                    sl_model.doctor_Id = Guid.Empty;
                    sl_model.createId = Guid.Empty;
                    sl_model.Entity = "payment_info";
                    sl_model.LogsType = (int)LogsType.动作;
                    sl_model.logmessage = "工厂：" + factory_Id + " 付款";
                    sl.Add(sl_model);
                }
                #endregion
                #region 开票
           
                else if (type.Equals("Open_Invoice"))
                {
                    string pmId = context.Request["paymentId"];
                    string maId = context.Request["maillingAddressId"];
                    string total_amount = context.Request["total_amount"];
                    string ioid = context.Request["InvoiceOpen_Id"];
                    string factory_Id = context.Request["factory_Id"];
                    string[] pmids = pmId.Split(';');
                }

                #endregion
                #region 工厂注册数量
                
             
                else if (type.Equals("GetNum"))
                {
                    DentalMedical.BLL.factory fa = new DentalMedical.BLL.factory();
                    int num = fa.get_factory_num();
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
                #region 快递公司
            
                else if (type.Equals("expressCompany"))
                {
                    DentalMedical.BLL.express_info ei = new DentalMedical.BLL.express_info();
                    List<DentalMedical.Model.express_info> express = ei.get_express();
                    if (express != null && express.Count > 0)
                    {
                        js.code = "200";
                        js.message = "请求成功！";
                        js.data = express;
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
                #region 更新工厂信息
           
                else if (type.Equals("setInfo"))
                {

                    string factory_Id = context.Request["factory_Id"];
                    string main_Person = context.Request["main_Person"];
                    string sex = context.Request["sex"];
                    string main_Email = context.Request["main_Email"];
                    string logo = context.Request["logo"];
                    DentalMedical.BLL.factory fac = new DentalMedical.BLL.factory();
                    bool result = fac.update_setInfo(main_Person, main_Email, int.Parse(sex), logo, new Guid(factory_Id));
                    if (result)
                    {
                        js.code = "200";
                        js.message = "更新个人信息成功！";
                        DentalMedical.Model.JsBool jsbool = new DentalMedical.Model.JsBool();
                        jsbool.result = true;
                        js.data = jsbool;
                    }
                    else
                    {
                        js.code = "201";
                        js.message = "更新个人信息失败！";
                        js.data = "";
                    }
                 
                    strJson = JsonHelper.SerializeObject(js);

                    sl_model.doctor_Id = new Guid(factory_Id);
                    sl_model.createId = new Guid(factory_Id);
                    sl_model.Entity = "factory_certification,factory";
                    sl_model.LogsType = (int)LogsType.动作;
                    sl_model.logmessage = "工厂：" + factory_Id + "   注册信息修改" + result.ToString();
                    sl.Add(sl_model);
                }

                #endregion
                #region 销售数据
               
                else if (type.Equals("deal"))
                {
                    string factory_Id = context.Request["factory_Id"];
                    DentalMedical.BLL.factory fac = new DentalMedical.BLL.factory();
                    DataTable dt = fac.get_D_F_num(new Guid(factory_Id));
                    if (dt != null)
                    {
                        js.code = "200";
                        js.message = "请求成功！";
                        js.data = dt;
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
                    sl_model.Entity = "factory";
                    sl_model.LogsType = (int)LogsType.动作;
                    sl_model.logmessage = "工厂：" + factory_Id + "   查看交易记录";
                    sl.Add(sl_model);
                }

                #endregion
                else
                {
                    js.code = "101";
                    js.message = "系统错误：没有该操作！";
                    js.data = "";
                    strJson = JsonHelper.SerializeObject(js);
                    sl_model.doctor_Id = Guid.Empty;
                    sl_model.createId = Guid.Empty;
                    sl_model.Entity = "factory";
                    sl_model.LogsType = (int)LogsType.错误;
                    sl_model.logmessage = "错误操作！";
                    sl.Add(sl_model);
                }
            }
            catch (Exception ex)
            {

                js.code = "202";
                js.message = "系统错误：捕捉到异常！";
                js.data = JsonHelper.SerializeObject(ex.Message);
                strJson = JsonHelper.SerializeObject(js);
                sl_model.doctor_Id = Guid.Empty;
                sl_model.createId = Guid.Empty;
                sl_model.Entity = "factory";
                sl_model.LogsType = (int)LogsType.错误;
                sl_model.logmessage = "方法：" + type + ",错误原因：" + ex.Message;
                sl.Add(sl_model);
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using WxApi;
using WxApi.ReceiveEntity;
using WxApi.UserManager;
using DentalMedical.Common;
using DentalMedical.DentalEnumeration;

namespace DentalMedicalService
{
    /// <summary>
    /// weixin 的摘要说明
    /// </summary>
    public class weixin : IHttpHandler,IRequiresSessionState 
    {
        public const string appid = "wxca781a6bcfe0eee1";
        public const string appsecret = "227a9b6b5e119b8872d0a8c4d05166bc";
        public string currenthost = Utils.GetCurrentFullHost();
        /// <summary>
        /// 用户信息
        /// </summary>
        public UserInfo currentinfo
        {
            get { return (UserInfo)HttpContext.Current.Session["userinfo"]; }
        }
        public OAuthToken AuthToken
        {
            get { return (OAuthToken)HttpContext.Current.Session["AuthToken"]; }
        }
        public string accessToken
        {
            get { return AccessTokenBox.GetTokenValue(appid, appsecret); }
        }     
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
            string openId= string.Empty;
            if (string.IsNullOrEmpty(type))
            {
                if (context.Session["userinfo"] == null)
                {
                    var code = context.Request.QueryString["code"];
                    if (string.IsNullOrEmpty(code))
                    {
                        context.Response.Redirect(OAuth.GetAuthUrl(appid, GetRawUrl(), "1", AuthType.snsapi_userinfo));
                    }
                    else
                    {
                        context.Session["AuthToken"] = OAuth.GetAuthToken(appid, appsecret, code);
                        context.Session["userinfo"] = OAuth.GetUserInfo(AuthToken.access_token, AuthToken.openid);
                    }
                }
                UserInfo ui = (UserInfo)context.Session["userinfo"];
                openId = currentinfo.openid;
                string url = "http://" + Utils.GetCurrentFullHost() + @"/jk_phone_index_treat.html";
                context.Response.Redirect(url);
            }
            else
            {
                if (type.Equals("weixin"))
                {
                    UserInfo ui = (UserInfo)context.Session["userinfo"];
                    if (ui != null)
                    {
                        openId = ui.openid;
                        //openId = "qwer1234";
                        DentalMedical.BLL.patientInfo pi = new DentalMedical.BLL.patientInfo();
                        if (string.IsNullOrEmpty(openId))
                        {
                            string url = "http://" + Utils.GetCurrentFullHost() + @"/weixin.ashx";
                            context.Response.Redirect(url);
                        }
                        DentalMedical.Model.patientInfo pinfo= pi.Query_weixin(openId);
                        if (pinfo!=null)
                        {
                            List<object> o = new List<object>();
                            DentalMedical.BLL.simple_EMR se = new DentalMedical.BLL.simple_EMR();
                            List<DentalMedical.Model.EMR_stream> list = se.get_stream_byWeixin(openId);
                            js.code = "200";
                            js.message = "微信号已录入！";
                            o.Add(pinfo);
                            o.Add(list);
                            js.data = o;
                            strJson = JsonHelper.SerializeObject(js);
                            sl_model.doctor_Id = Guid.Empty;
                            sl_model.createId = Guid.Empty;
                            sl_model.Entity = "patientInfo";
                            sl_model.LogsType = (int)LogsType.登录;
                            sl_model.logmessage = "微信openId：" + openId + "  获取流程列表成功~";
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
                    else
                    {
                        js.code = "404";
                        js.message = "微信错误，关闭页面重新打开~";
                        js.data = "";//返回4 说明账户错误    
                        strJson = JsonHelper.SerializeObject(js);
                        sl_model.doctor_Id = Guid.Empty;
                        sl_model.createId = Guid.Empty;
                        sl_model.Entity = "patientInfo";
                        sl_model.LogsType = (int)LogsType.登录失败;
                        sl_model.logmessage = "微信错误openid获取出错，关闭页面重新打开~";
                        sl.Add(sl_model);
                    }

                }
                else if (type.Equals("Addweixin"))
                {
                    UserInfo ui = (UserInfo)context.Session["userinfo"];
                    if (ui != null && ui.openid != null)
                    {
                        openId = ui.openid;
                        string PCode = context.Request["PCode"];
                        string PPwd = context.Request["PPwd"];
                        DentalMedical.BLL.patientInfo patientInfo_bll = new DentalMedical.BLL.patientInfo();
                        DentalMedical.Model.patientInfo patientInfo = new DentalMedical.Model.patientInfo();
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
                            if (patientInfo != null && patientInfo.Id != null)
                            {
                                bool result = patientInfo_bll.Update_weixin(openId, PCode);
                                if (result)
                                {                                  
                                    js.code = "200";
                                    js.message = "登陆成功，微信号绑定成功！";
                                    js.data = patientInfo;
                                    strJson = JsonHelper.SerializeObject(js);
                                    sl_model.doctor_Id = Guid.Empty;
                                    sl_model.createId = Guid.Empty;
                                    sl_model.Entity = "patientInfo";
                                    sl_model.LogsType = (int)LogsType.登录;
                                    sl_model.logmessage = "账户：" + PCode + "   登录成功！微信绑定成功！";
                                    sl.Add(sl_model);
                                }
                                else
                                {
                                    js.code = "201";
                                    js.message = "登陆失败，微信号绑定失败！";
                                    js.data = "";
                                    strJson = JsonHelper.SerializeObject(js);
                                    sl_model.doctor_Id = Guid.Empty;
                                    sl_model.createId = Guid.Empty;
                                    sl_model.Entity = "patientInfo";
                                    sl_model.LogsType = (int)LogsType.登录失败;
                                    sl_model.logmessage = "账户：" + PCode + "   登录成功！微信绑定失败！";
                                    sl.Add(sl_model);
                                }                                                         
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
                        #region 2016-5-19 之前的逻辑
                        
                  
                        //string tel = context.Request["tel"];
                        //DentalMedical.BLL.patientInfo pi = new DentalMedical.BLL.patientInfo();
                        //DentalMedical.Model.patientInfo pim = new DentalMedical.Model.patientInfo();
                        //pim.patientCode = tel;
                        //pim.weixin = openId;
                        //bool r = pi.Exists(tel);
                        //if (!r)
                        //{
                        //    string result = pi.Add(pim);
                        //    if (!string.IsNullOrEmpty(result))
                        //    {
                        //        DentalMedical.BLL.simple_EMR se = new DentalMedical.BLL.simple_EMR();
                        //        List<DentalMedical.Model.WX_simple_emr> list = se.Get_list_by_weixin(openId);
                        //        js.code = "200";
                        //        js.message = "微信号添加成功！";
                        //        js.data = list;
                        //        strJson = JsonHelper.SerializeObject(js);
                        //    }
                        //    else
                        //    {
                        //        js.code = "201";
                        //        js.message = "微信号添加失败！";
                        //        js.data = "";
                        //        strJson = JsonHelper.SerializeObject(js);
                        //    }
                        //}
                        //else
                        //{
                        //    bool result = pi.Update_weixin(openId, tel);
                        //    if (result)
                        //    {
                        //        DentalMedical.BLL.simple_EMR se = new DentalMedical.BLL.simple_EMR();
                        //        List<DentalMedical.Model.WX_simple_emr> list = se.Get_list_by_weixin(openId);
                        //        js.code = "200";
                        //        js.message = "微信号添加成功！";
                        //        js.data = list;
                        //        strJson = JsonHelper.SerializeObject(js);
                        //    }
                        //    else
                        //    {
                        //        js.code = "201";
                        //        js.message = "微信号添加失败！";
                        //        js.data = "";
                        //        strJson = JsonHelper.SerializeObject(js);
                        //    }
                        //}
                        #endregion
                    }
                    else
                    {
                        js.code = "404";
                        js.message = "微信错误，关闭页面重新打开~";
                        js.data = "";//返回4 说明账户错误    
                        strJson = JsonHelper.SerializeObject(js);
                        sl_model.doctor_Id = Guid.Empty;
                        sl_model.createId = Guid.Empty;
                        sl_model.Entity = "patientInfo";
                        sl_model.LogsType = (int)LogsType.登录失败;
                        sl_model.logmessage = "微信错误openid获取出错，关闭页面重新打开~";
                        sl.Add(sl_model);
                    }
                }
            }
        
            context.Response.ContentType = "text/plain";
            //context.Response.Write("www.baidu.com");
            context.Response.Write(callback + "(" + strJson + ")");
        }
        /// <summary>
        /// 获取当前请求的url
        /// </summary>
        /// <returns></returns>
        public string GetRawUrl()
        {
            return string.Format("http://{0}{1}", Utils.GetCurrentFullHost(), HttpContext.Current.Request.RawUrl);
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
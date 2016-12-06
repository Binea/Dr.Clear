using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DentalMedical.Common;
using DentalMedical.DentalEnumeration;
using DentalMedicalService.sopSendSmsService;
using System.Configuration;
using System.Drawing;

namespace DentalMedicalService
{
    /// <summary>
    /// BaseService 的摘要说明
    /// </summary>
    public class BaseService : IHttpHandler
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
                #region 获取地址基础信息
             
                if (type.Equals("BaseData"))
                {
                    DentalMedical.BLL.area_BaseData area = new DentalMedical.BLL.area_BaseData();
                    List<DentalMedical.Model.area_BaseData> arealist = area.Get_Arealist();
                    if (arealist != null)
                    {
                        js.code = "200";
                        js.message = "请求成功！";
                        js.data = arealist;
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
                #region 获取医院和科室
              
                else if (type.Equals("HD"))
                {
                    string citycode = context.Request["cityCode"];
                    DentalMedical.BLL.DH_relation dh = new DentalMedical.BLL.DH_relation();
                    List<DentalMedical.Model.DH_relation> dhList = dh.Get_HDList();
                    if (dhList != null)
                    {
                        js.code = "200";
                        js.message = "请求成功！";
                        js.data = dhList;
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
                #region 获取职称
            
                else if (type.Equals("titles"))
                {
                    DentalMedical.BLL.titles tt = new DentalMedical.BLL.titles();
                    List<DentalMedical.Model.titles> tList = tt.Get_titleList();
                    if (tList != null)
                    {
                        js.code = "200";
                        js.message = "请求成功！";
                        js.data = tList;
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
                #region 发送注册手机验证码          
                else if (type.Equals("message"))
                {
                    string tel = context.Request["tel"];
                    string mtype = context.Request["mtype"];
                    string validation_Code = StringUtil.MakeRndInt(6).ToString();
                    //string validation_Code = "12345";
                    DentalMedical.BLL.message_info mi = new DentalMedical.BLL.message_info();
                    DentalMedical.Model.message_info message = new DentalMedical.Model.message_info();
                    message.mobilePhone = tel;
                    message.mtype = int.Parse(mtype);
                    message.validation_Code = validation_Code;
                    message.createId = Guid.Empty;
                    message.smsIP = ip;
                    message.smsstauts = "1";
                    message.message = "测试";
                    message.cRemark = "";
                    if (mtype.Equals("0"))
                    {
                        DentalMedical.BLL.doctors dcbll = new DentalMedical.BLL.doctors();
                        DentalMedical.Model.doctors d= dcbll.Login_D(tel,null);
                        if (d != null && d.Id != null)
                        {
                            js.code = "201";
                            js.message = "该手机号已被注册！";
                            DentalMedical.Model.JsBool jsbool = new DentalMedical.Model.JsBool();
                            jsbool.result = false;
                            js.data = jsbool;
                            strJson = JsonHelper.SerializeObject(js);
                        }
                        else
                        {

                            DentalMedical.BLL.message_info mibll = new DentalMedical.BLL.message_info();
                            int num = mibll.count_tel_ip(tel, ip);
                            if (num >= 3)
                            {
                                js.code = "201";
                                js.message = "该手机号或IP已发送多次验证码！";
                                DentalMedical.Model.JsBool jsbool = new DentalMedical.Model.JsBool();
                                jsbool.result = false;
                                js.data = jsbool;
                                strJson = JsonHelper.SerializeObject(js);
                                sl_model.doctor_Id = Guid.Empty;
                                sl_model.createId = Guid.Empty;
                                sl_model.Entity = "message_info";
                                sl_model.LogsType = (int)LogsType.错误;
                                sl_model.logmessage = "手机号：" + tel + "或ip：" + ip + ",发送次数过多！";
                                sl.Add(sl_model);
                            }
                            else
                            {
                                message = sendSms(message);
                                bool result = mi.Add(message);
                                if (result && message.smsstauts.Equals("1"))
                                {
                                    js.code = "200";
                                    js.message = "信息发送成功！";
                                    DentalMedical.Model.JsBool jsbool = new DentalMedical.Model.JsBool();
                                    jsbool.result = true;
                                    js.data = jsbool;
                                    strJson = JsonHelper.SerializeObject(js);
                                    sl_model.doctor_Id = Guid.Empty;
                                    sl_model.createId = Guid.Empty;
                                    sl_model.Entity = "message_info";
                                    sl_model.LogsType = (int)LogsType.动作;
                                    sl_model.logmessage = "手机号：" + tel + "发送验证码：" + validation_Code + "成功！";
                                    sl.Add(sl_model);
                                }
                                else
                                {
                                    js.code = "201";
                                    js.message = "信息发送失败！";
                                    js.data = "";
                                    strJson = JsonHelper.SerializeObject(js);
                                    sl_model.doctor_Id = Guid.Empty;
                                    sl_model.createId = Guid.Empty;
                                    sl_model.Entity = "message_info";
                                    sl_model.LogsType = (int)LogsType.错误;
                                    sl_model.logmessage = "手机号：" + tel + "发送验证码：" + validation_Code + "失败！";
                                    sl.Add(sl_model);
                                }
                            }
                        }
                    }
                    else if (mtype.Equals("1"))
                    {
 
                    }
                    else if (mtype.Equals("3"))
                    {
                        DentalMedical.BLL.patientInfo dcbll = new DentalMedical.BLL.patientInfo();
                        DentalMedical.Model.patientInfo d = dcbll.Query_Code(tel, null);
                        if (d != null && d.Id != null)
                        {
                            js.code = "201";
                            js.message = "该手机号已被注册！";
                            DentalMedical.Model.JsBool jsbool = new DentalMedical.Model.JsBool();
                            jsbool.result = false;
                            js.data = jsbool;
                            strJson = JsonHelper.SerializeObject(js);
                        }
                        else
                        {
                            DentalMedical.BLL.message_info mibll = new DentalMedical.BLL.message_info();
                            int num = mibll.count_tel_ip(tel, ip);
                            if (num >= 3)
                            {
                                js.code = "201";
                                js.message = "该手机号或IP已发送多次验证码！";
                                DentalMedical.Model.JsBool jsbool = new DentalMedical.Model.JsBool();
                                jsbool.result = false;
                                js.data = jsbool;
                                strJson = JsonHelper.SerializeObject(js);
                                sl_model.doctor_Id = Guid.Empty;
                                sl_model.createId = Guid.Empty;
                                sl_model.Entity = "message_info";
                                sl_model.LogsType = (int)LogsType.错误;
                                sl_model.logmessage = "手机号：" + tel + "或ip：" + ip + ",发送次数过多！";
                                sl.Add(sl_model);
                            }
                            else
                            {
                                message = sendSms(message);
                                bool result = mi.Add(message);
                                if (result && message.smsstauts.Equals("1"))
                                {
                                    js.code = "200";
                                    js.message = "信息发送成功！";
                                    DentalMedical.Model.JsBool jsbool = new DentalMedical.Model.JsBool();
                                    jsbool.result = true;
                                    js.data = jsbool;
                                    strJson = JsonHelper.SerializeObject(js);
                                    sl_model.doctor_Id = Guid.Empty;
                                    sl_model.createId = Guid.Empty;
                                    sl_model.Entity = "message_info";
                                    sl_model.LogsType = (int)LogsType.错误;
                                    sl_model.logmessage = "手机号：" + tel + "发送验证码：" + validation_Code + "成功！";
                                    sl.Add(sl_model);
                                }
                                else
                                {
                                    js.code = "201";
                                    js.message = "信息发送失败！";
                                    js.data = "";
                                    strJson = JsonHelper.SerializeObject(js);
                                    sl_model.doctor_Id = Guid.Empty;
                                    sl_model.createId = Guid.Empty;
                                    sl_model.Entity = "message_info";
                                    sl_model.LogsType = (int)LogsType.错误;
                                    sl_model.logmessage = "手机号：" + tel + "发送验证码：" + validation_Code + "失败！";
                                    sl.Add(sl_model);
                                }
                            }
                        }
                    }
                    else
                    {
                        js.code = "201";
                        js.message = "信息发送失败！";
                        js.data = "";
                        strJson = JsonHelper.SerializeObject(js);
                    }             
                 
                }
                #endregion
                #region 省市区三级数据
             
                else if (type.Equals("area"))
                {
                    DentalMedical.BLL.area_BaseData area = new DentalMedical.BLL.area_BaseData();
                    List<DentalMedical.Model.area_BaseData> arealist = area.Get_Area();
                    if (arealist != null)
                    {
                        js.code = "200";
                        js.message = "请求成功！";
                        js.data = arealist;
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
                else if (type.Equals("addhospital"))
                {
                    DentalMedical.BLL.hospitals bllhospital = new DentalMedical.BLL.hospitals();
                    DentalMedical.Model.hospitals hospital = new DentalMedical.Model.hospitals();
                    string hname=context.Request["hospitalName"];//医院名称
                    string hcode=context.Request["hospitalCode"];//医院所在区域编码
                    string hadd=context.Request["hospitalAdd"];//医院地址
                    Guid id=Guid.NewGuid();
                    hospital.Id = id;
                    hospital.hospitalName = hname;
                    hospital.hospitalAddress = hadd;
                    hospital.hospitalCode = hcode;
                    bool r = bllhospital.Add(hospital);
                }
                else if (type.Equals("adddepartment"))
                {
                    DentalMedical.BLL.departments bllhospital = new DentalMedical.BLL.departments();
                    DentalMedical.Model.departments hospital = new DentalMedical.Model.departments();
                    string dname = context.Request["deName"];//部门名称
                    Guid id = Guid.NewGuid();

                }
                else if (type.Equals("hospital_bycode"))
                {
                }
                #region 生成登录验证码
               
                else if (type.Equals("v_code"))
                {
                    string codetype= context.Request["codetype"];
                    DentalMedical.Model.verification_code vc = new DentalMedical.Model.verification_code();
                    DentalMedical.BLL.verification_code vcbll = new DentalMedical.BLL.verification_code();
                    string code = DentalMedical.Common.StringUtil.GetRandomString(5);
                    vc.v_code = code;
                    vc.createId = Guid.Empty;
                    vc.code_type = int.Parse(codetype);
                    vc.flag = 1;
                    string id = vcbll.Add(vc);
                    vc.id =new Guid(id);
                    //CreateCheckCodeImage(code, context);
                    if (id != null)
                    {
                        //"data:image/gif;base64,"
                        byte[] ms = CreateCheckCodeImage(code, context);
                        vc.imagestram = "data:image/gif;base64," + System.Convert.ToBase64String(ms);                       
                        vc.v_code =DentalMedical.Common.DEncrypt.DESEncrypt.Encrypt(vc.v_code);
                        js.code = "200";
                        js.message = "请求成功！";
                        js.data = vc;
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
                #region 校验登录验证码
               
                else if (type.Equals("is_v_code"))
                {
                    string code = context.Request["code"];
                    string encode = context.Request["encode"];
                    string a = code.ToUpperInvariant();
                    string decode = DentalMedical.Common.DEncrypt.DESEncrypt.Encrypt(code.ToUpperInvariant()); 
                    //CreateCheckCodeImage(code, context);
                    if (decode.Equals(encode))
                    {
                        js.code = "200";
                        js.message = "验证码匹配！";
                        DentalMedical.Model.JsBool jsbool = new DentalMedical.Model.JsBool();
                        jsbool.result = true;
                        js.data = jsbool;
                        strJson = JsonHelper.SerializeObject(js);
                    }
                    else
                    {
                        js.code = "201";
                        js.message = "验证码不匹配！";
                        DentalMedical.Model.JsBool jsbool = new DentalMedical.Model.JsBool();
                        jsbool.result = false;
                        js.data = jsbool;
                        strJson = JsonHelper.SerializeObject(js);
                    }
                }

                #endregion

                #region 发送修改密码验证码
                else if (type.Equals("message_modify"))
                {
                    string tel = context.Request["tel"];
                    string mtype = context.Request["mtype"];//7:医生  8：患者  9：设计 10：生产
                    string validation_Code = StringUtil.MakeRndInt(6).ToString();
                    //string validation_Code = "12345";
                    DentalMedical.BLL.message_info mi = new DentalMedical.BLL.message_info();
                    DentalMedical.Model.message_info message = new DentalMedical.Model.message_info();
                    message.mobilePhone = tel;
                    message.mtype = int.Parse(mtype);
                    message.validation_Code = validation_Code;
                    message.createId = Guid.Empty;
                    message.smsIP = ip;
                    message.smsstauts = "1";
                    message.message = "测试";
                    message.cRemark = "";
                    DentalMedical.BLL.message_info mibll = new DentalMedical.BLL.message_info();
                    int num = mibll.count_tel_ip(tel, ip);
                    if (num >= 3)
                    {
                        js.code = "201";
                        js.message = "该手机号或IP已发送多次验证码，请半小时后再试！";
                        DentalMedical.Model.JsBool jsbool = new DentalMedical.Model.JsBool();
                        jsbool.result = false;
                        js.data = jsbool;
                        strJson = JsonHelper.SerializeObject(js);
                        sl_model.doctor_Id = Guid.Empty;
                        sl_model.createId = Guid.Empty;
                        sl_model.Entity = "message_info";
                        sl_model.LogsType = (int)LogsType.错误;
                        sl_model.logmessage = "手机号：" + tel + "或ip：" + ip + ",发送次数过多！";
                        sl.Add(sl_model);
                    }
                    else
                    {
                        message = sendSms(message);
                        bool result = mi.Add(message);
                        if (result && message.smsstauts.Equals("1"))
                        {
                            js.code = "200";
                            js.message = "信息发送成功！";
                            DentalMedical.Model.JsBool jsbool = new DentalMedical.Model.JsBool();
                            jsbool.result = true;
                            js.data = jsbool;
                            strJson = JsonHelper.SerializeObject(js);
                            sl_model.doctor_Id = Guid.Empty;
                            sl_model.createId = Guid.Empty;
                            sl_model.Entity = "message_info";
                            sl_model.LogsType = (int)LogsType.动作;
                            sl_model.logmessage = "手机号：" + tel + "发送修改密码验证码：" + validation_Code + "成功！";
                            sl.Add(sl_model);
                        }
                        else
                        {
                            js.code = "201";
                            js.message = "信息发送失败！";
                            js.data = "";
                            strJson = JsonHelper.SerializeObject(js);
                            sl_model.doctor_Id = Guid.Empty;
                            sl_model.createId = Guid.Empty;
                            sl_model.Entity = "message_info";
                            sl_model.LogsType = (int)LogsType.错误;
                            sl_model.logmessage = "手机号：" + tel + "发送修改密码验证码：" + validation_Code + "失败！";
                            sl.Add(sl_model);
                        }
                    }




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
                    sl_model.Entity = "Base";
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
                js.message = "系统错误：捕获到异常！";
                js.data = JsonHelper.SerializeObject(ex.Message);
                strJson = JsonHelper.SerializeObject(js);
                sl_model.doctor_Id = Guid.Empty;
                sl_model.createId = Guid.Empty;
                sl_model.Entity = "Base";
                sl_model.LogsType = (int)LogsType.错误;
                sl_model.logmessage = "方法：" + type + ",错误原因：" + ex.Message;
                sl.Add(sl_model);
                //string url = "http://www.clearbos.com/clear.html";
                //context.Response.Redirect(url);
                ////context.Response.ContentType = "text/html";
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



        public DentalMedical.Model.message_info sendSms(DentalMedical.Model.message_info message)
        {

            //获取配置文件
            string account = new System.Configuration.AppSettingsReader().GetValue("account", typeof(string)).ToString();
            string password = new System.Configuration.AppSettingsReader().GetValue("password", typeof(string)).ToString();
            string userid = new System.Configuration.AppSettingsReader().GetValue("userid", typeof(string)).ToString();
            string HX_TITLE = new System.Configuration.AppSettingsReader().GetValue("HX_TITLE", typeof(string)).ToString();
            string content = ConfigurationManager.AppSettings["validationContext"].ToString();
            //string HX_URL = new System.Configuration.AppSettingsReader().GetValue("HX_URL", typeof(string)).ToString();
            content = string.Format(content,message.validation_Code);
            content = content + "【" + HX_TITLE + "】";
            WebServiceSoapClient soap = new WebServiceSoapClient();
            SmsObject smsObj = new SmsObject();
            smsObj.Msisdns = message.mobilePhone;
            smsObj.SMSContent = content;
            SendResult sendRes = null;
            sendRes = soap.SendSms(account, password, smsObj);//发送消息          
            if (sendRes.StatusCode.ToString() == "OK")
            {
                message.smsstauts = "1";
            }
            else
            {
                message.smsstauts = "2";
            }
            string messageContent = "发送号码：" + message.mobilePhone +"\n" + "发送内容：" + content + "返回结果：";
            ResultCode resCode = new ResultCode();
            resCode = sendRes.StatusCode;
            message.message = messageContent + "短信服务器代码：" + sendRes.StatusCode.ToString();
            return message;
        }

        private byte[] CreateCheckCodeImage(string checkCode, HttpContext context)
        {

            if (checkCode == null || checkCode.Trim() == String.Empty)

                return null;

            System.Drawing.Bitmap image = new System.Drawing.Bitmap((int)Math.Ceiling((checkCode.Length * 12.5)), 22);

            Graphics g = Graphics.FromImage(image);

            try
            {

                //生成随机生成器

                Random random = new Random();

                //清空图片背景色

                g.Clear(Color.White);

                //画图片的背景噪音线

                for (int i = 0; i < 25; i++)
                {

                    int x1 = random.Next(image.Width);

                    int x2 = random.Next(image.Width);

                    int y1 = random.Next(image.Height);

                    int y2 = random.Next(image.Height);

                    g.DrawLine(new Pen(Color.Silver), x1, y1, x2, y2);

                }

                Font font = new System.Drawing.Font("Arial", 12, (System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic));

                System.Drawing.Drawing2D.LinearGradientBrush brush = new System.Drawing.Drawing2D.LinearGradientBrush(new Rectangle(0, 0, image.Width, image.Height), Color.Blue, Color.DarkRed, 1.2f, true);

                g.DrawString(checkCode, font, brush, 2, 2);

                //画图片的前景噪音点

                for (int i = 0; i < 100; i++)
                {

                    int x = random.Next(image.Width);

                    int y = random.Next(image.Height);

                    image.SetPixel(x, y, Color.FromArgb(random.Next()));

                }

                //画图片的边框线

                g.DrawRectangle(new Pen(Color.Silver), 0, 0, image.Width - 1, image.Height - 1);

                System.IO.MemoryStream ms = new System.IO.MemoryStream();

                image.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);

               
                //context.Response.ClearContent();

                //context.Response.ContentType = "image/Gif";

                //context.Response.BinaryWrite(ms.ToArray());
                return ms.ToArray();
            }

            finally
            {

                g.Dispose();

                image.Dispose();

            }

        }
    


    }
}
<%@ WebHandler Language="C#" Class="_fileUpload" %>

using System;
using System.Web;

public class _fileUpload : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        string callback = context.Request["callback"];
        string dirname = context.Request["emrcode"];
        string doctorId = context.Request["doctorId"];
        string ip = context.Request.UserHostAddress;
        string action = context.Request.CurrentExecutionFilePath;
        string browser = context.Request.Browser.Platform + "-" + context.Request.Browser.Type + "(" + context.Request.Browser.Version + ")";    
        DentalMedical.BLL.dental_model dmbll = new DentalMedical.BLL.dental_model();
        DentalMedical.Model.dental_model dm = dmbll.GetModel(dirname);
        int phase = 1;
        if (dm != null)
        {
            phase = dm.orderId;
        }
        string fileWeb = System.Configuration.ConfigurationManager.AppSettings["filewebsite"];
        string filedir = System.Configuration.ConfigurationManager.AppSettings["filePath"];
        string filetempdir = System.Configuration.ConfigurationManager.AppSettings["filetempPath"];
        string linuxsimperPath = System.Configuration.ConfigurationManager.AppSettings["linuxsimperPath"];
        filedir += "/STL/" + dirname + "/P" + phase + "/";
        filetempdir += "/STL/" + dirname + "/P" + phase + "/";
        fileWeb += "/STL/" + dirname + "/P" + phase + "/";
        linuxsimperPath += "/" + dirname + "/P" + phase + "/";
        HttpFileCollection files = context.Request.Files;
        string msg = string.Empty;
        string error = string.Empty;
        string imgurl = string.Empty;
        if (files.Count > 0)
        {
            if (!System.IO.Directory.Exists(filedir))
            {
                System.IO.Directory.CreateDirectory(filedir);
            }
            files[0].SaveAs(filedir + System.IO.Path.GetFileName(files[0].FileName));
            if (!System.IO.Directory.Exists(linuxsimperPath))
            {
                System.IO.Directory.CreateDirectory(linuxsimperPath);
            }          
            files[0].SaveAs(linuxsimperPath + System.IO.Path.GetFileName(files[0].FileName));
            msg = " 成功! 文件大小为:" + files[0].ContentLength;
            imgurl = System.IO.Path.GetFileName(files[0].FileName);
            string res = "{ error:'" + error + "', msg:'" + imgurl + "',imgurl:'" + imgurl + "'}";
            //context.Response.Write(res);
            //context.Response.End();
            //context.Response.ContentType = "text/plain";
            context.Response.Write(res);
            context.Response.End();
        }
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}
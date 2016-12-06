using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using DentalMedical.BLL;
using DentalMedical.Model;
using DentalMedical.Common;
using DentalMedical.DentalEnumeration;
namespace DentalMedicalService
{
    /// <summary>
    /// uploadFiles 的摘要说明
    /// </summary>
    public class uploadSTL : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
        
            string callback = context.Request["callback"];
            string type = context.Request["operationType"];
            string dirname = context.Request["emrcode"];
            string doctorId = context.Request["doctorId"];
            string filepath = context.Request["billno"];
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
            //linuxfile+="/other/" + dirname;
            string fullname = UploadFile(context, filedir, filetempdir, linuxsimperPath, type, dirname);

            //context.Response.ContentType = "text/plain";
            //context.Response.Write(callback + "(" + strJson + ")");

            if ((!fullname.Equals(string.Empty)) && fullname != null)
            {
                DentalMedical.Model.JsString jss = new DentalMedical.Model.JsString();
                jss.jsString = fullname;
                js.code = "200";
                js.message = "上传成功";
                js.data = jss;
                strJson = DentalMedical.Common.JsonHelper.SerializeObject(js);
            }
            else
            {
                js.code = "201";
                js.message = "上传失败";
                js.data = "";
                strJson = DentalMedical.Common.JsonHelper.SerializeObject(js);
            }
            context.Response.ContentType = "text/plain";
            //context.Response.Write(callback + "(" + strJson + ")");
            context.Response.Write(strJson);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        public string UploadFile(HttpContext context,string filepath,string filetemppath,string linuxPath,string type,string billNo)
        {
            context.Response.CacheControl = "no-cache";
            string updir = filepath;
            string extname = string.Empty;
            string fullname = string.Empty;
            string filename = string.Empty;
            string unextfilename = string.Empty;
            string maxName = string.Empty;
            if (context.Request.Files.Count > 0)
            {
                try
                {
                    string filefullname=string.Empty;
                    HttpFileCollection files = context.Request.Files;
                    for (int i = 0; i < files.Count; i++)
                    {
                        if (files[i].ContentLength > 0)
                        {
                           

                            HttpPostedFile uploadFile = files[i];
                            //MemoryStream ms = new MemoryStream();
                            //uploadFile.InputStream.CopyTo(ms);
                            //ms.Seek(0, SeekOrigin.Begin); 
                            //if (!IsPicture(ms))
                            //{
                            //    continue;
                            //}
                         
                            int offset = Convert.ToInt32(context.Request["chunk"]);
                            int total = Convert.ToInt32(context.Request["chunks"]);
                            string name = context.Request["name"];

                            //文件没有分块
                            if (total == 0)
                            {
                                if (uploadFile.ContentLength > 0)
                                {
                                    if (!Directory.Exists(updir))
                                    {
                                        Directory.CreateDirectory(updir);
                                    }
                                    extname = Path.GetExtension(uploadFile.FileName);
                                    unextfilename = Path.GetFileNameWithoutExtension(uploadFile.FileName);
                                    filename = Path.GetFileName(uploadFile.FileName);
                                    unextfilename =billNo+"_"+ DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();
                                    filename = unextfilename + extname;
                                    string linuxfullname = string.Format("{0}\\{1}", linuxPath, filename);
                                    if (!Directory.Exists(linuxPath))
                                    {
                                        Directory.CreateDirectory(linuxPath);
                                    }
                                    uploadFile.SaveAs(linuxfullname);
                                    filefullname = string.Format("{0}\\{1}", updir, filename);
                                    uploadFile.SaveAs(filefullname);
                                }


                            }
                            else
                            {
                                //文件 分成多块上传
                                fullname = WriteTempFile(uploadFile, offset, filetemppath);
                                if (total - offset == 1)
                                {
                                    //如果是最后一个分块文件 ，则把文件从临时文件夹中移到上传文件 夹中
                                    System.IO.FileInfo fi = new System.IO.FileInfo(fullname);
                                    string oldFullName = string.Format("{0}\\{1}", updir, uploadFile.FileName);
                                    FileInfo oldFi = new FileInfo(oldFullName);
                                    if (oldFi.Exists)
                                    {
                                        //文件名存在则删除旧文件 
                                        oldFi.Delete();
                                    }
                                    fi.MoveTo(oldFullName);
                                    filefullname = oldFullName;
                                }
                            }
                            //maxName += filename + ";";
                        }
                    }

                    return filefullname;
                }
                catch (Exception ex)
                {
                    context.Response.Write("Message" + ex.ToString());
                }



            }
            return null;
        }
        /// <summary>
        /// 保存临时文件 
        /// </summary>
        /// <param name="uploadFile"></param>
        /// <param name="chunk"></param>
        /// <param name="filePath"></param>
        /// <returns></returns>
        private string WriteTempFile(HttpPostedFile uploadFile, int chunk,string filetempPath)
        {

            string tempDir = filetempPath;
            if (!Directory.Exists(tempDir))
            {
                Directory.CreateDirectory(tempDir);
            }
            string fullName = string.Format("{0}\\{1}.part", tempDir, uploadFile.FileName);
            if (chunk == 0)
            {
                //如果是第一个分块，则直接保存
                uploadFile.SaveAs(fullName);
            }
            else
            {
                //如果是其他分块文件 ，则原来的分块文件，读取流，然后文件最后写入相应的字节
                FileStream fs = new FileStream(fullName, FileMode.Append);
                if (uploadFile.ContentLength > 0)
                {
                    int FileLen = uploadFile.ContentLength;
                    byte[] input = new byte[FileLen];

                    // Initialize the stream.
                    System.IO.Stream MyStream = uploadFile.InputStream;

                    // Read the file into the byte array.
                    MyStream.Read(input, 0, FileLen);

                    fs.Write(input, 0, FileLen);
                    fs.Close();
                }
            }


            return fullName;
        }

        /// <summary>
        /// 判断文件头
        /// </summary>
        /// <param name="filestream">上传文件流</param>
        /// <returns></returns>
        private bool IsPicture(Stream filestream)
        {
            try
            {
                //FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                BinaryReader reader = new BinaryReader(filestream);
                string fileClass;
                byte buffer;
                buffer = reader.ReadByte();
                fileClass = buffer.ToString();
                buffer = reader.ReadByte();
                fileClass += buffer.ToString();
                reader.Close();
                //fs.Close();
                if (fileClass == FileType.JPG.ToString() || fileClass == FileType.BMP.ToString() || fileClass == FileType.GIF.ToString() || fileClass == FileType.PNG.ToString())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;

[assembly:log4net.Config.XmlConfigurator(Watch=true)]
namespace DentalMedical.Common
{
    /// <summary>
    /// Log''s Type
    /// </summary>
    public enum LogType
    {
        Debug,
        Info,
        Warning,
        Error,
        Fatal
    }

    /// <summary>
    /// Log Output Helper,use log4net
    /// author:wz
    /// </summary>    
    public static class LogHelper
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Nomal Information Output
        /// LogType:Info
        /// </summary>
        /// <param name="message">message</param>
        public static void Write(string message)
        {
            WriteInner(LogType.Info, message, null);
        }

        /// <summary>
        /// Error Information Output
        /// LogType:Error
        /// </summary>
        /// <param name="message">message</param>
        /// <param name="ex">exception</param>
        public static void Write(string message, Exception ex)
        {
            WriteInner(LogType.Error, message, ex);
        }

        /// <summary>
        /// special LogType''s Information Output
        /// </summary>
        /// <param name="logType">LogType</param>
        /// <param name="message">message</param>
        /// <param name="ex">ex</param>
        public static void Write(LogType logType, string message, Exception ex)
        {
            WriteInner(logType, message, ex);
        }

        private static void WriteInner(LogType logType, string message, Exception ex)
        {
            switch (logType)
            {
                case LogType.Debug:
                    log.Debug(message, ex);
                    break;
                case LogType.Info:
                    log.Info(message, ex);
                    break;
                case LogType.Warning:
                    log.Warn(message, ex);
                    break;
                case LogType.Error:
                    log.Error(message, ex);
                    break;
                case LogType.Fatal:
                    log.Fatal(message, ex);
                    break;

            }
        }
    }
}
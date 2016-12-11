using log4net;
using log4net.Config;
using System;

namespace Infrastructure
{
    public class Logger
    {
        private const string LoggerName = "Admin_Logger";
        private static readonly ILog _logger;

        public static ILog FrameworkLogger
        {
            get { return _logger; }
        }

        static Logger()
        {
            XmlConfigurator.Configure();
            _logger = LogManager.GetLogger(LoggerName);
        }

        public static void Error(object msg)
        {
            FrameworkLogger.Error(msg);
        }

        public static void Error(object msg, Exception e)
        {
            FrameworkLogger.Error(msg, e);
        }

        public static void Info(object msg)
        {
            FrameworkLogger.Info(msg);
        }

        public static void Info(object msg, Exception e)
        {
            FrameworkLogger.Info(msg, e);
        }
    }
}

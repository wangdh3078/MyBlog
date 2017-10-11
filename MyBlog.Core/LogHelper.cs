using NLog;
using System;

namespace MyBlog.Core
{
    public class LogHelper
    {
        private Logger _logger;

        #region 构造函数
        private LogHelper(Logger logger)
        {
            _logger = logger;
        }

        public LogHelper()
            : this(LogManager.GetLogger("MyBlog"))
        {

        }

        static LogHelper()
        {
            Logger = new LogHelper(LogManager.GetCurrentClassLogger());
        }
        #endregion

        public static LogHelper Logger { get; private set; }

        public void Trace(string message)
        {
            _logger.Trace(message);
        }

        public void Debug(string message)
        {
            _logger.Debug(message);
        }

        public void Info(string message)
        {
            _logger.Info(message);
        }

        public void Warn(string message)
        {
            _logger.Warn(message);
        }

        public void Error(string message)
        {
            _logger.Error(message);

        }

        public void Fatal(string message)
        {
            _logger.Fatal(message);
        }

        public void Process(Log log)
        {
            var level = LogLevel.Info;
            if (log.LogLevel == ELogLevel.Trace)
                level = LogLevel.Trace;
            else if (log.LogLevel == ELogLevel.Debug)
                level = LogLevel.Debug;
            else if (log.LogLevel == ELogLevel.Info)
                level = LogLevel.Info;
            else if (log.LogLevel == ELogLevel.Warn)
                level = LogLevel.Warn;
            else if (log.LogLevel == ELogLevel.Error)
                level = LogLevel.Error;
            else if (log.LogLevel == ELogLevel.Fatal)
                level = LogLevel.Fatal;

            var theEvent = new LogEventInfo(level, _logger.Name, log.Message);
            theEvent.Properties["UserId"] = log.UserId;
            theEvent.Properties["UserName"] = log.UserName;
            theEvent.Properties["OperationType"] = log.OperationType;
            theEvent.Properties["Module"] = log.Module;
            theEvent.Properties["IP"] = log.IP;
            _logger.Log(theEvent);
        }

        public void Flush()
        {
            LogManager.Flush();
        }
    }
    public enum ELogLevel
    {
        Trace,
        Debug,
        Info,
        Warn,
        Error,
        Fatal
    }
}

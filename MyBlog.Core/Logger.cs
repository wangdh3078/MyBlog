using NLog;
using System;

namespace MyBlog.Core
{
    public class Logger
    {
        private readonly ILogger _logger = LogManager.GetCurrentClassLogger();

        public void Trace(string message)
        {
            _logger.Trace(message);
        }

        public void Trace(string id, string message)
        {
            throw new NotImplementedException();
        }

        public void Debug(string message)
        {
            _logger.Debug(message);
        }

        public void Debug(string id, string message)
        {
            throw new NotImplementedException();
        }

        public void Info(string message)
        {
            _logger.Info(message);
        }

        public void Info(string id, string message)
        {
            throw new NotImplementedException();
        }

        public void Warn(string message)
        {
            _logger.Warn(message);
        }

        public void Warn(string id, string message)
        {
            throw new NotImplementedException();
        }

        public void Error(string message)
        {
            _logger.Error(message);

        }

        public void Error(string id, string message)
        {
            throw new NotImplementedException();
        }

        public void Fatal(string message)
        {
            _logger.Fatal(message);
        }
        public void Fatal(string id, string message)
        {
            throw new NotImplementedException();
        }

        public void Process(string message, string operationType, string module)
        {
            LogEventInfo theEvent = new LogEventInfo(LogLevel.Fatal, _logger.Name, message);
            theEvent.Properties["OperationType"] = operationType;
            theEvent.Properties["Module"] = module;
            theEvent.Properties["message"]=message;
            _logger.Log(theEvent);
        }

        public void Flush()
        {
            LogManager.Flush();
        }
    }
}

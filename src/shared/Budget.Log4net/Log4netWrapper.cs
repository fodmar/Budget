using System;
using Budget.Utils.Log;
using log4net;

namespace Budget.Log4net
{
    public class Log4netWrapper : ILogger
    {
        private readonly ILog log4net;

        public Log4netWrapper() : this("default")
        {
        }

        public Log4netWrapper(string loggerName) 
        {
            this.log4net = LogManager.GetLogger(loggerName);
        }

        public void Error(string message, Exception ex)
        {
            this.log4net.Error(message, ex);
        }

        public void Debug(string message, Exception ex)
        {
            this.log4net.Debug(message, ex);
        }
    }
}

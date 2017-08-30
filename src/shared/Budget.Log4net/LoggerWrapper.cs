using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Budget.ObjectModel;
using log4net;

namespace Budget.Log4net
{
    public class LoggerWrapper : ILogger
    {
        private readonly ILog log4net;

        public LoggerWrapper() : this("default")
        {
        }

        public LoggerWrapper(string loggerName) 
        {
            this.log4net = LogManager.GetLogger(loggerName);
        }

        public void Error(string message, Exception ex)
        {
            this.log4net.Error(message, ex);
        }
    }
}

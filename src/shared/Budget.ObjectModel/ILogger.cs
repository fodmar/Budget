using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.ObjectModel
{
    public interface ILogger
    {
        void Error(string message, Exception ex);
        void Debug(string message, Exception ex);
    }
}

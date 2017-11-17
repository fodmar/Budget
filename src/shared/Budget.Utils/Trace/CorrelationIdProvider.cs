using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.Utils.Trace
{
    public class CorrelationIdProvider : ICorrelationIdProvider
    {
        public Guid CurrentId
        {
            get
            {
                return System.Diagnostics.Trace.CorrelationManager.ActivityId;
            }
            set
            {
                System.Diagnostics.Trace.CorrelationManager.ActivityId = value;
            }
        }
    }
}

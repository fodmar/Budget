using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using Budget.ObjectModel;

namespace Budget.WebApp.Utils
{
    public class CorrelationIdProvider : ICorrelationIdProvider
    {
        public Guid CurrentId
        {
            get
            {
                return Trace.CorrelationManager.ActivityId;
            }
        } 
    }
}
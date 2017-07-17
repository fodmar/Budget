using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Budget.WebApi.Client;

namespace Budget.WebApp.Utils
{
    public class BudgetApiHeadersProvider : IHeadersProvider
    {
        public int UserId
        {
            //// todo: implement session
            get { return 3; }//HttpContext.Current.Session["userId"]; }
        }

        public Guid CorrelationId
        {
            //// todo: use in different areas of app
            get { return Trace.CorrelationManager.ActivityId; }
        }
    }
}
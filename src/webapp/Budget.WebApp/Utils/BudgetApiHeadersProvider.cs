using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Budget.ObjectModel;
using Budget.WebApi.Client;

namespace Budget.WebApp.Utils
{
    public class BudgetApiHeadersProvider : IHeadersProvider
    {
        private ICorrelationIdProvider correlationIdProvider;

        public BudgetApiHeadersProvider(ICorrelationIdProvider correlationIdProvider)
        {
            this.correlationIdProvider = correlationIdProvider;
        }

        public int UserId
        {
            //// todo: implement session
            get { return 3; }//HttpContext.Current.Session["userId"]; }
        }

        public Guid CorrelationId
        {
            get { return this.correlationIdProvider.CurrentId; }
        }
    }
}
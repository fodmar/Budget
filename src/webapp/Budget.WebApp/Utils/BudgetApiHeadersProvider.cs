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
        private ISessionHelper sessionHelper;

        public BudgetApiHeadersProvider(
            ICorrelationIdProvider correlationIdProvider,
            ISessionHelper sessionHelper)
        {
            this.correlationIdProvider = correlationIdProvider;
            this.sessionHelper = sessionHelper;
        }

        public int UserId
        {
            get { return this.sessionHelper.User.Id; }
        }

        public Guid CorrelationId
        {
            get { return this.correlationIdProvider.CurrentId; }
        }
    }
}
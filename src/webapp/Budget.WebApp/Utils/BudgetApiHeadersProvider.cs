using System;
using Budget.Utils;
using Budget.Utils.Trace;
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
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Budget.WebApi.Client
{
    public abstract class ClientBase
    {
        protected IHeadersProvider headersProvider;

        private HttpClient httpClient;
        private string budgetApiUrl;
        
        public ClientBase(
            IConfigurationProvider configurationProvider,
            IHeadersProvider headersProvider)
        {
            this.budgetApiUrl = configurationProvider.BudgetApiUrl;
            this.headersProvider = headersProvider;
        }

        protected abstract string UriController { get; }

        protected HttpClient HttpClient
        {
            get
            {
                if (this.httpClient == null)
                {
                    this.httpClient = new HttpClient();
                }

                return this.httpClient;
            }
        }

        protected virtual void AddHeaders(ApiRequest request)
        {
            request.AddHeader("correlationId", this.headersProvider.CorrelationId);
        }

        protected ApiRequest CreateRequest()
        {
            ApiRequest request = new ApiRequest(this.budgetApiUrl + this.UriController, this.HttpClient);

            this.AddHeaders(request);

            return request;
        }
    }
}

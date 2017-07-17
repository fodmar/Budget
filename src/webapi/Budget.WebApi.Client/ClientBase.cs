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
        private IHeadersProvider headersProvider;

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

        protected ApiRequest CreateRequest()
        {
            return new ApiRequest(this.budgetApiUrl + this.UriController, this.headersProvider, this.HttpClient);
        }
    }
}

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
        private HttpClient httpClient;
        private string budgetApiUrl;

        public ClientBase(IConfigurationProvider configurationProvider)
        {
            this.budgetApiUrl = configurationProvider.BudgetApiUrl;
        }

        protected HttpClient HttpClient
        {
            get
            {
                if (this.httpClient == null)
                {
                    this.httpClient = new HttpClient();
                    this.httpClient.BaseAddress = new Uri(this.budgetApiUrl);
                    var acceptHeaders = this.httpClient.DefaultRequestHeaders.Accept;

                    acceptHeaders.Clear();
                    acceptHeaders.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                }

                return this.httpClient;
            }
        }
    }
}

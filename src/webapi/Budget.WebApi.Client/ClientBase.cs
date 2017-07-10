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
        protected HttpClient httpClient;

        public ClientBase(string baseUrl)
        {
            this.httpClient = new HttpClient();
            this.httpClient.BaseAddress = new Uri(baseUrl);
            var acceptHeaders = this.httpClient.DefaultRequestHeaders.Accept;

            acceptHeaders.Clear();
            acceptHeaders.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public ClientBase() : this(ConfigurationManager.AppSettings["BudgetApiUrl"])
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Budget.WebApi.Client
{
    public class ApiRequest
    {
        private HttpRequestMessage request;
        private HttpClient httpClient;
        private string uri;

        public ApiRequest(string uri, IHeadersProvider headersProvider, HttpClient httpClient)
        {
            this.httpClient = httpClient;
            this.uri = uri;
            this.request = new HttpRequestMessage();
            HttpRequestHeaders requestHeaders = this.request.Headers;

            requestHeaders.Accept.Clear();
            requestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            requestHeaders.Add("userId", headersProvider.UserId.ToString());
            requestHeaders.Add("correlationId", headersProvider.CorrelationId.ToString());
        }

        public ApiRequest ActionName(string name)
        {
            this.uri += name + "/";
            return this;
        }

        public ApiRequest AddUriParam<T>(T param)
        {
            this.uri += param.ToString() + "/";
            return this;
        }

        public ApiRequest AsGet()
        {
            this.request.Method = HttpMethod.Get;
            return this;
        }

        public async Task<T> Send<T>()
        {
            this.request.RequestUri = new Uri(uri);
            HttpResponseMessage response = await this.httpClient.SendAsync(this.request);
            T result = await response.Content.ReadAsAsync<T>();

            return result;
        }
    }
}

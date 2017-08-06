using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Budget.WebApi.Client
{
    public class ApiRequest
    {
        private HttpRequestMessage request;
        private HttpClient httpClient;
        private string uri;

        public ApiRequest(string uri, HttpClient httpClient)
        {
            this.httpClient = httpClient;
            this.uri = uri;
            this.request = new HttpRequestMessage();
            HttpRequestHeaders requestHeaders = this.request.Headers;

            requestHeaders.Accept.Clear();
            requestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public void AddHeader<T>(string name, T value)
        {
            this.request.Headers.Add(name, value.ToString());
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

        public ApiRequest AddBody<T>(T body)
        {
            string content = JsonConvert.SerializeObject(body);
            this.request.Content = new StringContent(content);
            this.request.Content.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");
            return this;
        }

        public ApiRequest AsGet()
        {
            this.request.Method = HttpMethod.Get;
            return this;
        }

        public ApiRequest AsPost()
        {
            this.request.Method = HttpMethod.Post;
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

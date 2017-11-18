using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Budget.Utils.Http
{
    public class ApiRequest
    {
        public ApiRequest(string url)
        {
            this.Request = new HttpRequestMessage();
            this.Request.RequestUri = new Uri(url);
            this.Request.Headers.Clear();
            this.Request.Content.Headers.Clear();

            AsGet().WithAcceptType("application/json");
        }

        public HttpRequestMessage Request { get; set; }

        public void AddHeader<T>(string name, T value)
        {
            this.Request.Headers.Add(name, value.ToString());
        }

        public ApiRequest AddUriParam<T>(T param)
        {
            Uri newUri = new Uri(this.Request.RequestUri.AbsolutePath + "/" + param);
            this.Request.RequestUri = newUri;
            return this;
        }

        public ApiRequest AddBody<T>(T body)
        {
            string content = JsonConvert.SerializeObject(body);
            this.Request.Content = new StringContent(content);
            this.Request.Content.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");
            return this;
        }

        public ApiRequest AsGet()
        {
            this.Request.Method = HttpMethod.Get;
            return this;
        }

        public ApiRequest AsPut()
        {
            this.Request.Method = HttpMethod.Put;
            return this;
        }

        public ApiRequest AsPost()
        {
            this.Request.Method = HttpMethod.Post;
            return this;
        }

        public ApiRequest AsDelete()
        {
            this.Request.Method = HttpMethod.Delete;
            return this;
        }

        public ApiRequest WithAcceptType(string acceptType)
        {
            this.Request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(acceptType));
            return this;
        }
    }
}

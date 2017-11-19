using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Budget.Utils.Http
{
    public class ApiResponse
    {
        public ApiResponse(HttpResponseMessage response)
        {
            this.Response = response;
        }

        public HttpResponseMessage Response { get; set; }

        public async Task<T> ReadAs<T>()
        {
            return JsonConvert.DeserializeObject<T>(await this.Response.Content.ReadAsStringAsync());
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace Budget.Utils.Http
{
    public class ApiClient : IApiClient
    {
        public async Task<ApiResponse> Send(ApiRequest request)
        {
            using (HttpMessageHandler handler = new HttpClientHandler())
            {
                using (HttpClient client = new HttpClient(handler))
                {
                    HttpResponseMessage response = await client.SendAsync(request.Request);
                    return new ApiResponse(response);
                }
            }
        }
    }
}

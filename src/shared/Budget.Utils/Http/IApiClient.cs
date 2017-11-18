using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.Utils.Http
{
    public interface IApiClient
    {
        Task<ApiResponse> Send(ApiRequest request);
    }
}

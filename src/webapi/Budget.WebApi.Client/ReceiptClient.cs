using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Budget.ObjectModel;

namespace Budget.WebApi.Client
{
    public class ReceiptClient : ClientBase, IReceiptProvider
    {
        public ReceiptClient() : base()
        {
        }

        public ReceiptClient(string url) : base(url)
        {
        }

        public async Task<Receipt> GetReceiptAsync(int id)
        {
            string uri = string.Format("api/Receipt/{0}", id);

            HttpResponseMessage response = await this.httpClient.GetAsync(uri);

            return await response.Content.ReadAsAsync<Receipt>();
        }

        public async Task<IEnumerable<Receipt>> GetReceiptsAsync()
        {
            string uri = "api/Receipt/";

            HttpResponseMessage response = await this.httpClient.GetAsync(uri);
            Receipt[] result = await response.Content.ReadAsAsync<Receipt[]>();

            return result;
        }

        public async Task<IEnumerable<Receipt>> GetReceiptsByDatesAsync(DateTime? from, DateTime? to)
        {
            //// todo: https://stackoverflow.com/questions/14359566/how-to-pass-a-datetime-parameter

            string fromString = from.HasValue ? from.Value.ToString("yyyyMMdd") : "null";
            string toString = to.HasValue ? to.Value.ToString("yyyyMMdd") : "null";

            string uri = string.Format("api/Receipt/{0}/{1}", fromString, toString);

            HttpResponseMessage response = await this.httpClient.GetAsync(uri);
            Receipt[] result = await response.Content.ReadAsAsync<Receipt[]>();

            return result;
        }
    }
}

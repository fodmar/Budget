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
        public ReceiptClient(IConfigurationProvider configurationProvider) : base(configurationProvider)
        {
        }

        public async Task<Receipt> GetReceiptAsync(int id)
        {
            string uri = string.Format("api/Receipt/{0}", id);

            HttpResponseMessage response = await this.HttpClient.GetAsync(uri);

            return await response.Content.ReadAsAsync<Receipt>();
        }

        public async Task<IEnumerable<Receipt>> GetReceiptsAsync()
        {
            string uri = "api/Receipt/";

            HttpResponseMessage response = await this.HttpClient.GetAsync(uri);
            Receipt[] result = await response.Content.ReadAsAsync<Receipt[]>();

            return result;
        }

        public async Task<IEnumerable<Receipt>> GetReceiptsByDatesAsync(DateTime? from, DateTime? to)
        {
            string uri = string.Format("api/Receipt/{0}/{1}", from.ToUriParamString(), to.ToUriParamString());

            HttpResponseMessage response = await this.HttpClient.GetAsync(uri);
            Receipt[] result = await response.Content.ReadAsAsync<Receipt[]>();

            return result;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Budget.ObjectModel;
using Budget.Utils.Extensions;
using Budget.Utils.Http;

namespace Budget.WebApi.Client
{
    public class ReceiptClient : ClientBase, IReceiptProvider, ISaver<Receipt>
    {
        protected override string UriController
        {
            get { return "receipt/"; }
        }

        public ReceiptClient(
            IApiClient client,
            IConfigurationProvider configurationProvider,
            IHeadersProvider headersProvider) 
            : base(client, configurationProvider, headersProvider)
        {
        }

        public async Task<Receipt> GetReceipt(int userId, int receiptId)
        {
            ApiRequest request = this.CreateRequest().AddUriParam(userId).AddUriParam(receiptId);
            ApiResponse response = await this.apiClient.Send(request);

            return await response.ReadAs<Receipt>();
        }

        public async Task<IEnumerable<Receipt>> GetReceipts(int userId)
        {
            ApiRequest request = this.CreateRequest().AddUriParam(userId);
            ApiResponse response = await this.apiClient.Send(request);

            return await response.ReadAs<Receipt[]>();
        }

        public async Task<IEnumerable<Receipt>> GetReceiptsByDates(int userId, DateTime? from, DateTime? to)
        {
            ApiRequest request = this.CreateRequest()
                    .AddUriParam(userId)
                    .AddUriParam(from.ToUriParamString())
                    .AddUriParam(to.ToUriParamString());

            ApiResponse response = await this.apiClient.Send(request);
            return await response.ReadAs<Receipt[]>();
        }

        public async Task<Receipt> Save(Receipt receipt)
        {
            ApiRequest request = this.CreateRequest().WithBody(receipt).AsPut();

            ApiResponse response = await this.apiClient.Send(request);
            return await response.ReadAs<Receipt>();
        }
    }
}

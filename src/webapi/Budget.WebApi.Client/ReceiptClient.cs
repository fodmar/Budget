using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Budget.ObjectModel;

namespace Budget.WebApi.Client
{
    public class ReceiptClient : ClientBase, IReceiptProvider, IReceiptSaver
    {
        protected override string UriController
        {
            get { return "api/receipt/"; }
        }

        public ReceiptClient(
            IConfigurationProvider configurationProvider,
            IHeadersProvider headersProvider) 
            : base(configurationProvider, headersProvider)
        {
        }

        public Task<Receipt> GetReceipt(int userId, int receiptId)
        {
            return
                this.CreateRequest()
                    .AddUriParam(userId)
                    .AddUriParam(receiptId)
                    .AsGet()
                    .Send<Receipt>();
        }

        public async Task<IEnumerable<Receipt>> GetReceipts(int userId)
        {
            return await
                this.CreateRequest()
                    .AddUriParam(userId)
                    .AsGet()
                    .Send<Receipt[]>();
        }

        public async Task<IEnumerable<Receipt>> GetReceiptsByDates(int userId, DateTime? from, DateTime? to)
        {
            return await
                this.CreateRequest()
                    .AddUriParam(userId)
                    .AddUriParam(from.ToUriParamString())
                    .AddUriParam(to.ToUriParamString())
                    .AsGet()
                    .Send<Receipt[]>();
        }

        public async Task<Receipt> Save(Receipt receipt)
        {
            return await
                this.CreateRequest()
                    .AddBody(receipt)
                    .AsPut()
                    .Send<Receipt>();
        }
    }
}

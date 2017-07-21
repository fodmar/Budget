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

        public Task<Receipt> GetReceiptAsync(int id)
        {
            return
                this.CreateRequest()
                    .AddUriParam(id)
                    .AsGet()
                    .Send<Receipt>();
        }

        public async Task<IEnumerable<Receipt>> GetReceiptsAsync()
        {
            return await
                this.CreateRequest()
                    .AsGet()
                    .Send<Receipt[]>() as IEnumerable<Receipt>;
        }

        public async Task<IEnumerable<Receipt>> GetReceiptsByDatesAsync(DateTime? from, DateTime? to)
        {
            return await
                this.CreateRequest()
                    .AddUriParam(from.ToUriParamString())
                    .AddUriParam(to.ToUriParamString())
                    .AsGet()
                    .Send<Receipt[]>() as IEnumerable<Receipt>;
        }
    }
}

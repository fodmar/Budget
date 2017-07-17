using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Budget.ObjectModel;
using Budget.WebApi.Client;
using NUnit.Framework;
using Rhino.Mocks;

namespace Budget.IntegrationTests.WebApi.Client
{
    [TestFixture]
    public class CallReceiptApi
    {
        [Test]
        public async void GetReceipt()
        {
            ReceiptClient client = this.CreateClient();
            Receipt result = await client.GetReceiptAsync(2);
        }

        [Test]
        public async void GetReceipts()
        {
            ReceiptClient client = this.CreateClient();
            IEnumerable<Receipt> result = await client.GetReceiptsAsync();
        }

        [Test]
        public async void GetReceiptByDateRange()
        {
            ReceiptClient client = this.CreateClient();
            IEnumerable<Receipt> result = await client.GetReceiptsByDatesAsync(null, DateTime.Now);
        }

        private ReceiptClient CreateClient()
        {
            var configurationProvider = MockRepository.GenerateStub<IConfigurationProvider>();
            configurationProvider.Stub(s => s.BudgetApiUrl).Return(@"http://marcin-lenovo/budget/");

            var headersProvider = MockRepository.GenerateStub<IHeadersProvider>();
            headersProvider.Stub(s => s.UserId).Return(123);
            headersProvider.Stub(s => s.CorrelationId).Return(Guid.Parse("AAAAFFFF-0000-0000-0000-000000000000"));

            return new ReceiptClient(configurationProvider, headersProvider);
        }
    }
}

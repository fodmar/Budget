using System;
using System.Collections.Generic;
using Budget.ObjectModel;
using Budget.Utils.Http;
using Budget.WebApi.Client;
using NUnit.Framework;
using Rhino.Mocks;

namespace Budget.IntegrationTests.WebApi.Client
{
    [TestFixture]
    [Ignore]
    public class CallReceiptApi
    {
        [Test]
        [Ignore]
        public async void GetReceipt()
        {
            ReceiptClient client = this.CreateClient();
            Receipt result = await client.GetReceipt(1, 2);
        }

        [Test]
        [Ignore]
        public async void GetReceipts()
        {
            ReceiptClient client = this.CreateClient();
            IEnumerable<Receipt> result = await client.GetReceipts(1);
        }

        [Test]
        [Ignore]
        public async void GetReceiptByDateRange()
        {
            ReceiptClient client = this.CreateClient();
            IEnumerable<Receipt> result = await client.GetReceiptsByDates(1, null, DateTime.Now);
        }

        [Test]
        [Ignore]
        public async void PostReceipt()
        {
            ReceiptClient client = this.CreateClient();

            Receipt receipt = new Receipt();
            receipt.Date = DateTime.Now;
            receipt.UserId = 1;

            ReceiptEntry entry = new ReceiptEntry();
            entry.Amount = 30m;

            receipt.Entries = new List<ReceiptEntry> { entry };

            Receipt saved = await client.Save(receipt);
        }

        private ReceiptClient CreateClient()
        {
            var configurationProvider = MockRepository.GenerateStub<IConfigurationProvider>();
            configurationProvider.Stub(s => s.BudgetApiUrl).Return(@"http://marcin-lenovo/api/");

            var headersProvider = MockRepository.GenerateStub<IHeadersProvider>();
            headersProvider.Stub(s => s.CorrelationId).Return(Guid.Parse("AAAAFFFF-0000-0000-0000-000000000000"));

            IApiClient client = new ApiClient();

            return new ReceiptClient(client, configurationProvider, headersProvider);
        }
    }
}

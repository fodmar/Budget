﻿using System;
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

        private ReceiptClient CreateClient()
        {
            var configurationProvider = MockRepository.GenerateStub<IConfigurationProvider>();
            configurationProvider.Stub(s => s.BudgetApiUrl).Return(@"http://localhost:19808/");

            var headersProvider = MockRepository.GenerateStub<IHeadersProvider>();
            headersProvider.Stub(s => s.CorrelationId).Return(Guid.Parse("AAAAFFFF-0000-0000-0000-000000000000"));

            return new ReceiptClient(configurationProvider, headersProvider);
        }
    }
}

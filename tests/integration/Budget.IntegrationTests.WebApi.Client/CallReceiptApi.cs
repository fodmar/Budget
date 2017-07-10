using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Budget.ObjectModel;
using Budget.WebApi.Client;
using NUnit.Framework;

namespace Budget.IntegrationTests.WebApi.Client
{
    [TestFixture]
    public class CallReceiptApi
    {
        private string apiUrl = @"http://localhost:16618/";

        [Test]
        [Ignore]
        public async void GetReceipt()
        {
            ReceiptClient client = new ReceiptClient(this.apiUrl);
            Receipt result = await client.GetReceiptAsync(2);
        }

        [Test]
        [Ignore]
        public async void GetReceipts()
        {
            ReceiptClient client = new ReceiptClient(this.apiUrl);
            IEnumerable<Receipt> result = await client.GetReceiptsAsync();
        }

        [Test]
        [Ignore]
        public async void GetReceiptByDateRange()
        {
            ReceiptClient client = new ReceiptClient(this.apiUrl);
            IEnumerable<Receipt> result = await client.GetReceiptsByDatesAsync(null, DateTime.Now);
        }
    }
}

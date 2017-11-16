using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Budget.EntityFramework;
using Budget.EntityFramework;
using Budget.ObjectModel;
using NUnit.Framework;

namespace Budget.IntegrationTests.DataAccess
{
    [TestFixture]
    [Ignore]
    class InsertReceiptIntegrationTest
    {
        [Test]
        [Ignore]
        public async void InsertReceipt()
        {
            Receipt receipt = new Receipt();
            receipt.Date = DateTime.Now;
            receipt.UserId = 1;

            ReceiptEntry entry = new ReceiptEntry();
            entry.Amount = 30m;

            receipt.Entries = new List<ReceiptEntry>();
            receipt.Entries.Add(entry);

            using (IBudgetDatabase database = new BudgetDatabase())
            {
                ReceiptRepository repository = new ReceiptRepository(database);

                await repository.Save(receipt);
            }

            Assert.AreNotEqual(0, receipt.Id);
            Assert.AreNotEqual(0, entry.Id);
            Assert.AreEqual(receipt.Id, entry.ReceiptId);
        }
    }
}

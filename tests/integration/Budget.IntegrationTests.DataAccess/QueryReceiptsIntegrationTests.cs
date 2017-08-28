using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Budget.DataAccess;
using Budget.DataAccess.Query;
using Budget.Database;
using Budget.ObjectModel;
using NUnit.Framework;

namespace Budget.IntegrationTests.DataAccess
{
    [TestFixture]
    [Category("IntegrationTests")]
    public class QueryReceiptsIntegrationTests
    {
        [Test]
        public async void QueryReceiptsByDateRange()
        {
            using (IBudgetDatabase database = new BudgetDatabase())
	        {
                ReceiptRepository facade = new ReceiptRepository(database);

                List<Receipt> result = (await facade.GetReceiptsByDates(1, null, DateTime.Now)).ToList();
	        }
        }

        [Test]
        [Ignore]
        public async void QueryReceiptsById()
        {
            using (IBudgetDatabase database = new BudgetDatabase())
            {
                ReceiptRepository facade = new ReceiptRepository(database);

                List<Receipt> result = (await facade.GetReceipts(1)).ToList();
            }
        }
    }
}

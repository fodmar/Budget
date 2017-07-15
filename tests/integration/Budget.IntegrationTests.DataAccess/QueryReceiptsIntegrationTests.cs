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
        [Ignore]
        public void QueryReceiptsByDateRange()
        {
            using (IBudgetDatabase database = new BudgetDatabase())
	        {
                ReceiptRepository facade = new ReceiptRepository(database);

                List<Receipt> result = facade.ReceiptsWithEntries.ByDateRange(null, DateTime.Now).ToList();
	        }
        }

        [Test]
        [Ignore]
        public void QueryReceiptsById()
        {
            using (IBudgetDatabase database = new BudgetDatabase())
            {
                ReceiptRepository facade = new ReceiptRepository(database);

                List<Receipt> result = facade.ReceiptsWithEntries.ById(1).ById(2).ToList();
            }
        }

        [Test]
        [Ignore]
        public void QueryReceiptsByValueInSet()
        {
            using (IBudgetDatabase database = new BudgetDatabase())
            {
                ReceiptRepository facade = new ReceiptRepository(database);

                List<Receipt> result = facade.ReceiptsWithEntries.ByValueInSet(r => r.Id, 1, 3, 5).ToList();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Budget.DataAccess;
using Budget.DataAccess.Query;
using Budget.Database;
using Budget.Domain;
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
                IDataAccessFacade facade = new DataAccessFacade(database);

                List<Receipt> result = facade.ReceiptsWithEntries.ByDateRange(null, DateTime.Now).ToList();
	        }
        }

        [Test]
        [Ignore]
        public void QueryReceiptsById()
        {
            using (IBudgetDatabase database = new BudgetDatabase())
            {
                IDataAccessFacade facade = new DataAccessFacade(database);

                List<Receipt> result = facade.ReceiptsWithEntries.ById(1).ById(2).ToList();
            }
        }
    }
}

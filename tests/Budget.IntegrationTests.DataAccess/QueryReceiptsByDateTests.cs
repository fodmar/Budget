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
    public class QueryReceiptsByDateTests
    {
        [Test]
        [Ignore]
        public void QueryReceiptsByDateIntegrationTest()
        {
            using (IBudgetDatabase database = new BudgetDatabase())
	        {
                IDataAccessFacade facade = new DataAccessFacade(database);

                List<Receipt> result = facade.Receipts.ByDateRange(null, DateTime.Now).ToList();
	        }
        }
    }
}

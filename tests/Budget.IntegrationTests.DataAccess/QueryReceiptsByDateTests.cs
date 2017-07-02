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
                IQueryByDate query = new QueryByDate();
                IDataAccessFacade facade = new DataAccessFacade(database, query);

                IQueryable<Receipt> receipts = facade.Receipts;
                receipts = facade.QueryByDate.Run(receipts, null, DateTime.Now);

                List<Receipt> result = receipts.ToList();
	        }
        }
    }
}

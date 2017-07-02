using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Budget.DataAccess.Query;
using Budget.Database;
using Budget.Domain;
using NUnit.Framework;

namespace Budget.IntegrationTests.DataAccess
{
    [TestFixture]
    public class GetReceiptsByDateTests
    {
        [Test]
        [Ignore]
        public void GetReceiptsByDateIntegrationTest()
        {
            using (IBudgetDatabase database = new BudgetDatabase())
	        {
                IGetReceiptsByDate query = new GetReceiptsByDate(database);

                List<Receipt> result = query.Run(null, DateTime.Now).ToList();
	        }
        }
    }
}

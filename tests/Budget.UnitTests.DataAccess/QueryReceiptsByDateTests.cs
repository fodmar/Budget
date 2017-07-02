using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Budget.DataAccess.Query;
using Budget.Database;
using Budget.Domain;
using NUnit.Framework;
using Rhino.Mocks;

namespace Budget.UnitTests.DataAccess
{
    [TestFixture]
    class QueryReceiptsByDateTests
    {
        [Test]
        [TestCaseSource("Generate")]
        public void QueryReceiptsByDateTest(Scenario scenario)
        {
            IEnumerable<Receipt> result = scenario.Receipts.ByDateRange(scenario.From, scenario.To);

            CollectionAssert.AreEquivalent(scenario.Result, result);
        }

        public class Scenario
        {
            public IQueryable<Receipt> Receipts { get; set; }

            public DateTime? From { get; set; }

            public DateTime? To { get; set; }

            public IEnumerable<Receipt> Result { get; set; }
        }

        private IEnumerable<Scenario> Generate()
        {
            Receipt first = new Receipt { Id = 1, Date = DateTime.Now.AddDays(5) };
            Receipt second = new Receipt { Id = 2, Date = DateTime.Now.AddDays(10) };
            Receipt third = new Receipt { Id = 3, Date = DateTime.Now.AddDays(15) };

            IQueryable<Receipt> receipts = new Receipt[] { first, second, third }.AsQueryable();

            yield return new Scenario
            {
                Receipts = receipts,
                From = DateTime.Now.AddDays(3),
                To = DateTime.Now.AddDays(6),
                Result = new Receipt[] { first }
            };

            yield return new Scenario
            {
                Receipts = receipts,
                From = null,
                To = DateTime.Now.AddDays(11),
                Result = new Receipt[] { first, second }
            };

            yield return new Scenario
            {
                Receipts = receipts,
                From = DateTime.Now.AddDays(6),
                To = null,
                Result = new Receipt[] { second, third }
            };

            yield return new Scenario
            {
                Receipts = receipts,
                From = null,
                To = null,
                Result = new Receipt[] { first, second, third }
            };
        }
    }
}

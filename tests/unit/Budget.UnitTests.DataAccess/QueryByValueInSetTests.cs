using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Budget.ObjectModel;
using Budget.EntityFramework.Query;
using NUnit.Framework;

namespace Budget.UnitTests.DataAccess
{
    [TestFixture]
    [Category("UnitTests")]
    class QueryByValueInSetTests
    {
        [Test]
        [TestCaseSource("Generate")]
        public void QueryByValueInSetId(IQueryable<Receipt> receipts)
        {
            int[] ids = new[] { 1, 3, 8 };
            Receipt[] result = receipts.ByValueInSet(r => r.Id, ids).ToArray();

            Assert.AreEqual(2, result.Length);
            Assert.AreEqual(1, result[0].Id);
            Assert.AreEqual(3, result[1].Id);
        }

        [Test]
        [TestCaseSource("Generate")]
        public void QueryByValueInSetDate(IQueryable<Receipt> receipts)
        {
            DateTime second = DateTime.Today.AddDays(2);

            Receipt[] result = receipts.ByValueInSet(r => r.Date, second, second.AddSeconds(1)).ToArray();

            Assert.AreEqual(1, result.Length);
            Assert.AreEqual(2, result[0].Id);
        }

        private IEnumerable<IQueryable<Receipt>> Generate()
        {
            yield return new[]
            {
                new Receipt { Id = 1, Date = DateTime.Today.AddDays(1) },
                new Receipt { Id = 2, Date = DateTime.Today.AddDays(2) },
                new Receipt { Id = 3, Date = DateTime.Today.AddDays(3) },
                new Receipt { Id = 4, Date = DateTime.Today.AddDays(4) },
            }
            .AsQueryable();
        }
    }
}

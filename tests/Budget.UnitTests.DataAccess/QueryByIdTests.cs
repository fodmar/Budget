using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Budget.ObjectModel;
using Budget.DataAccess.Query;
using NUnit.Framework;

namespace Budget.UnitTests.DataAccess
{
    [TestFixture]
    [Category("UnitTests")]
    class QueryByIdTests
    {
        [Test]
        [TestCaseSource("Generate")]
        public void QueryByIdTest_OneId(IQueryable<Receipt> receipts)
        {
            Receipt[] result = receipts.ById(2).ToArray();

            Assert.AreEqual(1, result.Length);
            Assert.AreEqual(2, result.First().Id);
        }

        [Test]
        [TestCaseSource("Generate")]
        public void QueryByIdTest_TwoIds(IQueryable<Receipt> receipts)
        {
            Receipt[] result = receipts.ById(1).ById(2).ToArray();

            Assert.AreEqual(0, result.Length);
        }

        private IEnumerable<IQueryable<Receipt>> Generate()
        {
            yield return new[]
            {
                new Receipt { Id = 1 },
                new Receipt { Id = 2 },
                new Receipt { Id = 3 },
            }
            .AsQueryable();
        }
    }
}

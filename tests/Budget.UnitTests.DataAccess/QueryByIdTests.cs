using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Budget.Domain;
using Budget.DataAccess.Query;
using NUnit.Framework;

namespace Budget.UnitTests.DataAccess
{
    [TestFixture]
    [Category("UnitTests")]
    class QueryByIdTests
    {
        [Test]
        public void QueryByIdTest_OneId()
        {
            IQueryable<Receipt> receipts = (new[]
            {
                new Receipt { Id = 1 },
                new Receipt { Id = 2 },
                new Receipt { Id = 3 },
            })
            .AsQueryable();

            Receipt[] result = receipts.ById(2).ToArray();

            Assert.AreEqual(1, result.Length);
            Assert.AreEqual(2, result.First().Id);
        }

        [Test]
        public void QueryByIdTest_TwoIds()
        {
            IQueryable<Receipt> receipts = (new[]
            {
                new Receipt { Id = 1 },
                new Receipt { Id = 2 },
                new Receipt { Id = 3 },
            })
            .AsQueryable();

            Receipt[] result = receipts.ById(1).ById(2).ToArray();

            Assert.AreEqual(0, result.Length);
        }
    }
}

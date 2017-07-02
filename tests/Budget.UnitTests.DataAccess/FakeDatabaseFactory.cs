using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Budget.Database;
using Budget.Domain;
using Rhino.Mocks;

namespace Budget.UnitTests.DataAccess
{
    static class FakeDatabaseFactory
    {
        public static IBudgetDatabase Create()
        {
            return MockRepository.GenerateMock<IBudgetDatabase>();
        }

        public static void SetReceipents(IBudgetDatabase database, params Receipt[] receipts)
        {
            IQueryable<Receipt> queryable = receipts.AsQueryable();
            IDbSet<Receipt> dbSet = MockRepository.GenerateMock<IDbSet<Receipt>, IQueryable>();

            dbSet.Stub(m => m.Provider).Return(queryable.Provider);
            dbSet.Stub(m => m.Expression).Return(queryable.Expression);
            dbSet.Stub(m => m.ElementType).Return(queryable.ElementType);
            dbSet.Stub(m => m.GetEnumerator()).Return(queryable.GetEnumerator());

            database.Stub(x => x.Receipts).PropertyBehavior();
            database.Receipts = dbSet;
        }
    }
}

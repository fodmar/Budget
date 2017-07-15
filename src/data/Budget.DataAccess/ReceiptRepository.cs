using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Budget.DataAccess.Query;
using Budget.Database;
using Budget.ObjectModel;

namespace Budget.DataAccess
{
    public class ReceiptRepository : IReceiptProvider
    {
        private readonly IBudgetDatabase budgetDatabase;

        public ReceiptRepository(IBudgetDatabase budgetDatabase)
        {
            this.budgetDatabase = budgetDatabase;
        }

        public IQueryable<Receipt> Receipts
        {
            get
            {
                return this.budgetDatabase.Receipts.AsQueryable();
            }
        }

        public IQueryable<Receipt> ReceiptsWithEntries
        {
            get
            {
                return this.budgetDatabase.Receipts.Include(r => r.Entries).AsQueryable();
            }
        }

        public Task<Receipt> GetReceiptAsync(int id)
        {
            return this.ReceiptsWithEntries.ById(id).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<Receipt>> GetReceiptsAsync()
        {
            return await this.ReceiptsWithEntries.ToListAsync();
        }

        public async Task<IEnumerable<Receipt>> GetReceiptsByDatesAsync(DateTime? from, DateTime? to)
        {
            return await this.ReceiptsWithEntries.ByDateRange(from, to).ToListAsync();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Budget.EntityFramework.Query;
using Budget.EntityFramework;
using Budget.ObjectModel;

namespace Budget.EntityFramework
{
    public class ReceiptRepository : IReceiptProvider, ISaver<Receipt>
    {
        private readonly IBudgetDatabase budgetDatabase;

        public ReceiptRepository(IBudgetDatabase budgetDatabase)
        {
            this.budgetDatabase = budgetDatabase;
        }

        private IQueryable<Receipt> Receipts
        {
            get
            {
                return this.budgetDatabase.Table<Receipt>(r => r.Entries);
            }
        }

        public Task<Receipt> GetReceipt(int userId, int receiptId)
        {
            return 
                this.Receipts
                    .ByUserId(userId)
                    .ById(receiptId)
                    .SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<Receipt>> GetReceipts(int userId)
        {
            return await
                this.Receipts
                    .ByUserId(userId)
                    .ToListAsync();
        }

        public async Task<IEnumerable<Receipt>> GetReceiptsByDates(int userId, DateTime? from, DateTime? to)
        {
            return await
                this.Receipts
                    .ByUserId(userId)
                    .ByDateRange(from, to)
                    .ToListAsync();
        }

        public Task<Receipt> Save(Receipt receipt)
        {
            return this.budgetDatabase.Insert(receipt);
        }
    }
}

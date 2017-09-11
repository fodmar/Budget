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
    public class ReceiptRepository : IReceiptProvider, IReceiptSaver
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
                return
                    this.budgetDatabase.Receipts
                        .Include(r => r.Entries)
                        .AsQueryable();
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

        public async Task<Receipt> Save(Receipt receipt)
        {
            this.budgetDatabase.Receipts.Add(receipt);
            this.budgetDatabase.ReceiptsEntries.AddRange(receipt.Entries);

            await this.budgetDatabase.SaveChangesAsync();

            return receipt;
        }
    }
}

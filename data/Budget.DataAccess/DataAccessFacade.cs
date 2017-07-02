using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Budget.DataAccess.Query;
using Budget.Database;
using Budget.Domain;

namespace Budget.DataAccess
{
    public class DataAccessFacade : IDataAccessFacade
    {
        private readonly IBudgetDatabase budgetDatabase;

        public DataAccessFacade(IBudgetDatabase budgetDatabase, IQueryByDate getReceiptsByDate)
        {
            this.budgetDatabase = budgetDatabase;
            this.QueryByDate = getReceiptsByDate;
        }

        public IQueryable<Receipt> Receipts
        {
            get
            {
                return this.budgetDatabase.Receipts.AsQueryable();
            }
        }

        public IQueryByDate QueryByDate { get; private set; }
    }
}

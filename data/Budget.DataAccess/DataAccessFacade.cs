﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Budget.DataAccess.Query;
using Budget.Database;
using Budget.ObjectModel;

namespace Budget.DataAccess
{
    public class DataAccessFacade : IReceiptProvider
    {
        private readonly IBudgetDatabase budgetDatabase;

        public DataAccessFacade(IBudgetDatabase budgetDatabase)
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

        public Receipt GetReceipt(int id)
        {
            return this.ReceiptsWithEntries.ById(id).SingleOrDefault();
        }

        public IEnumerable<Receipt> GetReceipts()
        {
            return this.ReceiptsWithEntries;
        }

        public IEnumerable<Receipt> GetReceiptsByDates(DateTime? from, DateTime? to)
        {
            return this.ReceiptsWithEntries.ByDateRange(from, to);
        }
    }
}

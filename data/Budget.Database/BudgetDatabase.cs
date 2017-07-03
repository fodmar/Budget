using System;
using System.Data.Entity;
using System.Linq;
using Budget.Domain;

namespace Budget.Database
{
    public class BudgetDatabase : DbContext, IBudgetDatabase
    {
        public BudgetDatabase() : base("name=Budget")
        {
        }

        public virtual DbSet<Receipt> Receipts { get; set; }
        public virtual DbSet<ReceiptEntry> ReceiptsEntries { get; set; }
    }
}
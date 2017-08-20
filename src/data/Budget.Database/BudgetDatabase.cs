using System;
using System.Data.Entity;
using System.Linq;
using Budget.Database.Configuration;
using Budget.ObjectModel;

namespace Budget.Database
{
    public class BudgetDatabase : DbContext, IBudgetDatabase
    {
        public BudgetDatabase() : base("name=Budget")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            ReceiptConfiguration.Configure(modelBuilder.Entity<Receipt>());
            UserConfiguration.Configure(modelBuilder.Entity<User>());
            UserPasswordConfiguration.Configure(modelBuilder.Entity<UserPassword>());
        }

        public virtual DbSet<Receipt> Receipts { get; set; }
        public virtual DbSet<ReceiptEntry> ReceiptsEntries { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserPassword> UsersPasswords { get; set; }
    }
}
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
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
            ReceiptEntryConfiguration.Configure(modelBuilder.Entity<ReceiptEntry>());
            UserConfiguration.Configure(modelBuilder.Entity<User>());
            ProductConfiguration.Configure(modelBuilder.Entity<Product>());
            UserPasswordConfiguration.Configure(modelBuilder.Entity<UserPassword>());
        }

        public virtual DbSet<Receipt> Receipts { get; set; }
        public virtual DbSet<ReceiptEntry> ReceiptsEntries { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserPassword> UsersPasswords { get; set; }
        public virtual DbSet<Product> Products { get; set; }
    }
}
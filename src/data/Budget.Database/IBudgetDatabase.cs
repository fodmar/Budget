﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Budget.ObjectModel;

namespace Budget.Database
{
    public interface IBudgetDatabase : IDisposable
    {
        Task<int> SaveChangesAsync();

        DbEntityEntry<T> Entry<T>(T entity) where T : class;

        DbSet<Receipt> Receipts { get; set;  }
        DbSet<ReceiptEntry> ReceiptsEntries { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<UserPassword> UsersPasswords { get; set; }
        DbSet<Product> Products { get; set; }
    }
}

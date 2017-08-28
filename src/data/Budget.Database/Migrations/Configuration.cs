using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Security.Cryptography;
using Budget.ObjectModel;

namespace Budget.Database.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<BudgetDatabase>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BudgetDatabase context)
        {
            context.Users.AddOrUpdate(
                new User { Id = 1, Name = "Marcin", Email = "a@a.a" });

            context.UsersPasswords.AddOrUpdate(
                new UserPassword { UserId = 1, UserLogin = "marcin", Hash = "0cc175b9c0f1b6a831c399e269772661" }); //password: a

            context.Receipts.AddOrUpdate(
                e => e.Id,
                new Receipt { Id = 1, UserId = 1, Date = DateTime.Now.AddDays(-5) },
                new Receipt { Id = 2, UserId = 1, Date = DateTime.Now.AddDays(-2) });

            var p1 = new Product { Id = 1, Name = "Apple" };
            var p2 = new Product { Id = 2, Name = "Orange" };

            context.Products.AddOrUpdate(
                e => e.Id,
                p1,
                p2);

            context.ReceiptsEntries.AddOrUpdate(
                e => e.Id,
                new ReceiptEntry { Id = 1, ReceiptId = 1, Amount = 20.2m, Product = p1 },
                new ReceiptEntry { Id = 2, ReceiptId = 1, Amount = 11.68m, Product = p1 },
                new ReceiptEntry { Id = 3, ReceiptId = 2, Amount = 9.21m, Product = p2 });
        }
    }
}

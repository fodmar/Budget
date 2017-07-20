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
                new UserPassword { UserId = 1, UserLogin = "marcin", Hash = "d5fad0cda8f1079681ec510bb20a586c" }); //password: a

            context.Receipts.AddOrUpdate(
                e => e.Id,
                new Receipt { Id = 1, UserId = 1, Date = DateTime.Now.AddDays(-5) },
                new Receipt { Id = 2, UserId = 1, Date = DateTime.Now.AddDays(-2) });

            context.ReceiptsEntries.AddOrUpdate(
                e => e.Id,
                new ReceiptEntry { Id = 1, ReceiptId = 1, Amount = 20.2m },
                new ReceiptEntry { Id = 2, ReceiptId = 1, Amount = 11.68m },
                new ReceiptEntry { Id = 3, ReceiptId = 2, Amount = 9.21m });
        }
    }
}

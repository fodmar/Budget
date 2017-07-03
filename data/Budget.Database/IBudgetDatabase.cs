using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Budget.Domain;

namespace Budget.Database
{
    public interface IBudgetDatabase : IDisposable
    {
        DbSet<Receipt> Receipts { get; set;  }
        DbSet<ReceiptEntry> ReceiptsEntries { get; set; }
    }
}

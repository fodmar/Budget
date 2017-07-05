using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Budget.DataAccess.Query;
using Budget.ObjectModel;

namespace Budget.DataAccess
{
    public interface IDataAccessFacade : IReceiptProvider
    {
        IQueryable<Receipt> Receipts { get; }

        IQueryable<Receipt> ReceiptsWithEntries { get; }
    }
}

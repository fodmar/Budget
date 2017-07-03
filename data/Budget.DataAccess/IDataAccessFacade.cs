using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Budget.DataAccess.Query;
using Budget.Domain;

namespace Budget.DataAccess
{
    public interface IDataAccessFacade
    {
        IQueryable<Receipt> Receipts { get; }

        IQueryable<Receipt> ReceiptsWithEntries { get; }
    }
}

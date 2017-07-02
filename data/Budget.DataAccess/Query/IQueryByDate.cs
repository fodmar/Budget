using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Budget.Domain;

namespace Budget.DataAccess.Query
{
    public interface IQueryByDate
    {
        IQueryable<Receipt> Run(IQueryable<Receipt> query, DateTime? fromDate, DateTime? toDate);
    }
}

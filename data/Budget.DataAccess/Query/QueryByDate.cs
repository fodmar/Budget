using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Budget.Database;
using Budget.Domain;

namespace Budget.DataAccess.Query
{
    public class QueryByDate : IQueryByDate
    {
        public IQueryable<Receipt> Run(IQueryable<Receipt> query, DateTime? fromDate, DateTime? toDate)
        {
            return query.Where(r => (!fromDate.HasValue || r.Date > fromDate.Value)
                                 && (!toDate.HasValue || r.Date < toDate.Value));
        }
    }
}

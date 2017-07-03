using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Budget.Domain;

namespace Budget.DataAccess.Query
{
    public static class QueryById
    {
        public static IQueryable<Receipt> ById(this IQueryable<Receipt> query, int id)
        {
            return query.Where(r => r.Id == id);
        }
    }
}

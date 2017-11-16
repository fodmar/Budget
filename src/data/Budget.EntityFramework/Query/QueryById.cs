using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Budget.ObjectModel;

namespace Budget.EntityFramework.Query
{
    public static class QueryById
    {
        public static IQueryable<Receipt> ById(this IQueryable<Receipt> query, int receiptId)
        {
            return query.Where(r => r.Id == receiptId);
        }

        public static IQueryable<Receipt> ByUserId(this IQueryable<Receipt> query, int userId)
        {
            return query.Where(r => r.UserId == userId);
        }
    }
}

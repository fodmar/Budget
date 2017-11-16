﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Budget.EntityFramework;
using Budget.ObjectModel;

namespace Budget.EntityFramework.Query
{
    public static class QueryByDateRange
    {
        public static IQueryable<Receipt> ByDateRange(this IQueryable<Receipt> query, DateTime? fromDate, DateTime? toDate)
        {
            return query.Where(r => (!fromDate.HasValue || r.Date > fromDate.Value)
                                 && (!toDate.HasValue || r.Date < toDate.Value));
        }
    }
}

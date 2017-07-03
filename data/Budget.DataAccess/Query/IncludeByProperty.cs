using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Budget.DataAccess.Query
{
    public static class IncludeByProperty
    {
        public static DbQuery<T> Include<T, P>(this DbQuery<T> dbset, Expression<Func<T, P>> expression) where T : class
        {
            MemberExpression memberExpression = expression.Body as MemberExpression;

            return dbset.Include(memberExpression.Member.Name);
        }
    }
}

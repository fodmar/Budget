using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Budget.DataAccess.Query
{
    public static class QueryByValueInSet
    {
        public static IQueryable<T> ByValueInSet<T, P>(
            this IQueryable<T> query,
            Expression<Func<T, P>> propertyExpression,
            params P[] valueSet)
        {
            // shorthand for query.Where(e => someValues.Contains(e.SomeProperty))
            // usage: query.ByValueInSet(e => e.SomeProperty, someValues)
            // based on: https://blogs.msdn.microsoft.com/alexj/2009/03/25/tip-8-how-to-write-where-in-style-queries-using-linq-to-entities/

            // Here we have IEnumerable<Expression> like: property == X1 , property == X2 , ... , where X is in valueSet
            var equals = valueSet.Select(v => Expression.Equal(propertyExpression.Body, Expression.Constant(v, typeof(P))));

            // We aggregate it with OR so its: (property == X1 || property == X2 || ...)
            var body = equals.Aggregate<Expression>((accumulate, equal) => Expression.Or(accumulate, equal)); 

            // Return lamba with ORs and our property value as parameter
            var final = Expression.Lambda<Func<T, bool>>(body, propertyExpression.Parameters.Single());

            return query.Where(final); 
        }
    }
}

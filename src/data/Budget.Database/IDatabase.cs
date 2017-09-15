using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Budget.Database
{
    public interface IDatabase : IDisposable
    {
        IQueryable<T> Table<T>() where T : class;
        IQueryable<T> Table<T>(params Expression<Func<T, object>>[] joins) where T : class;

        Task<T> Insert<T>(T entitity) where T : class;
        Task<IEnumerable<T>> Insert<T>(IEnumerable<T> entities) where T : class;

        Task Update<T>(T entitity) where T : class;
        Task Update<T>(IEnumerable<T> entities) where T : class;

        Task Delete<T>(T entitity) where T : class;
        Task Delete<T>(IEnumerable<T> entities) where T : class;
    }
}

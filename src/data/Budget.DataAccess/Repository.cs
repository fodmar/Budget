using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Budget.Database;
using Budget.ObjectModel;

namespace Budget.DataAccess
{
    public class Repository<T> : IRepository<T> where T : class, IIdentifiable
    {
        private readonly IDatabase database;

        public Repository(IDatabase database)
        {
            this.database = database;
        }

        public async Task<IEnumerable<T>> ReadAll()
        {
            return await this.database.Table<T>().ToListAsync();
        }

        public Task<T> Save(T item)
        {
            return this.database.Insert(item);
        }

        public Task Update(T item)
        {
            return this.database.Update(item);
        }

        public Task Remove(T item)
        {
            return this.database.Delete(item);
        }

        public Task<T> GetById(int id)
        {
            return this.database.Table<T>().SingleAsync();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Budget.ObjectModel;

namespace Budget.Caching
{
    public class RepositoryCache<T> : IRepository<T> where T : IIdentifiable
    {
        private readonly string key;

        private readonly ICache cache;
        private readonly IRepository<T> repository;

        public RepositoryCache(ICache cache, IRepository<T> repository)
        {
            this.key = typeof(T).Name;
            this.cache = cache;
            this.repository = repository;
        }

        public Task<IEnumerable<T>> ReadAll()
        {
            Func<Task<IEnumerable<T>>> func = async () => await this.repository.ReadAll();

            return this.cache.GetOrPut(key, func);
        }

        public async Task<T> Save(T obj)
        {
            T inserted = await this.repository.Save(obj);

            if (!this.cache.Contains(key))
            {
                return inserted;
            }

            List<T> objs = (await this.ReadAll()).ToList();
            objs.Add(inserted);
            this.cache.Put(key, Task<IEnumerable<T>>.FromResult(objs.AsEnumerable()));
            return inserted;
        }

        public async Task Update(T obj)
        {
            await this.repository.Update(obj);

            if (!this.cache.Contains(key))
            {
                return;
            }

            List<T> objs = (await this.ReadAll()).ToList();

            for (int i = 0; i < objs.Count; i++)
            {
                if (obj.Id == objs[i].Id)
                {
                    objs[i] = obj;
                    break;
                }
            }

            this.cache.Put(key, Task<IEnumerable<T>>.FromResult(objs.AsEnumerable()));
        }

        public async Task Remove(T obj)
        {
            await this.repository.Remove(obj);

            if (!this.cache.Contains(key))
            {
                return;
            }

            List<T> objs = (await this.ReadAll()).ToList();
            objs.Remove(objs.Find(p => p.Id == obj.Id));
            this.cache.Put(key, Task<IEnumerable<T>>.FromResult(objs.AsEnumerable()));
        }

        public Task<T> GetById(int id)
        {
            Func<Task<T>> func = async () => await this.repository.GetById(id);

            return this.cache.GetOrPut(key, func);
        }
    }
}

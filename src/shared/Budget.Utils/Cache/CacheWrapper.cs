using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace Budget.Utils.Cache
{
    public class CacheWrapper : ICache
    {
        private readonly ObjectCache cache;

        public CacheWrapper(ObjectCache cache)
        {
            this.cache = cache;
        }

        public T GetOrPut<T>(string key, Func<T> closure)
        {
            return this.GetOrPut<T>(key, TimeSpan.FromMinutes(60), closure);
        }

        public T GetOrPut<T>(string key, TimeSpan duration, Func<T> closure)
        {
            object cached = this.cache.Get(key);

            T result = (T)cached;
            if (result == null)
            {
                result = closure();
                this.Put(key, result, duration);
            }

            return result;
        }

        public void Put<T>(string key, T item)
        {
            this.Put<T>(key, item, TimeSpan.FromMinutes(60));
        }

        public void Put<T>(string key, T item, TimeSpan duration)
        {
            CacheItemPolicy policy = new CacheItemPolicy();
            policy.AbsoluteExpiration = DateTime.Now.Add(duration);

            this.cache.Set(key, item, policy);
        }

        public void Remove(string key)
        {
            this.cache.Remove(key);
        }

        public bool Contains(string key)
        {
            return this.cache.Contains(key);
        }
    }
}

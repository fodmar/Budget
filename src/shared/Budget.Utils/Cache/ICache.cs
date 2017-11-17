using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.Utils.Cache
{
    public interface ICache
    {
        T GetOrPut<T>(string key, Func<T> closure);
        T GetOrPut<T>(string key, TimeSpan duration, Func<T> closure);

        void Put<T>(string key, T item);
        void Put<T>(string key, T item, TimeSpan duration);

        void Remove(string key);
        bool Contains(string key);
    }
}

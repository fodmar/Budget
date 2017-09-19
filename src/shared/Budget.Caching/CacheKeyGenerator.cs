using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Budget.ObjectModel;

namespace Budget.Caching
{
    static class CacheKeyGenerator
    {
        public static string Generate(string baseKey, params object[] parameters)
        {
            parameters = parameters ?? new object[0];
            return string.Format("{0}_{1}", baseKey, string.Join("_", parameters));
        }
    }
}

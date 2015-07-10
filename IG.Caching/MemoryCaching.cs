using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;

namespace IG.Caching
{
    interface ICachable
    {
        T GetOrSet<T>(string key, Func<T> dataGetter, DateTimeOffset absoluteExpirationOffset) where T : class;
        T GetOrSet<T>(string key, Func<T> dataGetter, TimeSpan slidingExpirationOffset) where T : class;
        T GetOrSet<T>(string key, Func<T> dataGetter) where T : class;
    }

    public class MemoryCaching : ICachable
    {

        public T GetOrSet<T>(string key, Func<T> dataGetter, DateTimeOffset absoluteExpirationOffset) where T : class
        {
            T data = MemoryCache.Default.Get(key) as T;
            if (data == null)
            {
                data = dataGetter();

                CacheItemPolicy policy = new CacheItemPolicy();
                policy.AbsoluteExpiration = absoluteExpirationOffset;
                
                MemoryCache.Default.Add(key, data, policy);
            }
            return data;
        }

        public T GetOrSet<T>(string key, Func<T> dataGetter, TimeSpan slidingExpirationInterval) where T : class
        {
            T data = MemoryCache.Default.Get(key) as T;
            if (data == null)
            {
                data = dataGetter();

                CacheItemPolicy policy = new CacheItemPolicy();
                policy.SlidingExpiration = slidingExpirationInterval;
                
                MemoryCache.Default.Add(key, data, policy);
            }
            return data;
        }

        public T GetOrSet<T>(string key, Func<T> dataGetter) where T : class
        {
            return GetOrSet<T>(key, dataGetter, TimeSpan.FromMinutes(30d));
        }
    }
}

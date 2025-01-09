using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperPortal.DataAccess.Entity.Models.Helper
{
    public class ApplicationCache
    {
        public readonly IMemoryCache _cache;
        public ApplicationCache(IMemoryCache cache) { _cache = cache; }

        public void SetCacheValue(string cacheKey, string cacheValue)
        {
            if (!_cache.TryGetValue(cacheKey, out var cachedValue)) { 
                cachedValue = cacheValue;
                _cache.Set(cacheKey, cachedValue);
            }
        }

        public string? GetCacheValue(string cacheKey) {
            string? cacheValue = string.Empty;
            var retVal = _cache.Get(cacheKey);
            if (retVal != null) {
                cacheValue = retVal.ToString();
            }

            return cacheValue;
        }
    }
}

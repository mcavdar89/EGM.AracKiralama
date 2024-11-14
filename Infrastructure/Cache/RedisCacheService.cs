using Infrastructure.Extensions;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Cache
{
    public class RedisCacheService:ICacheService
    {
        private readonly IDistributedCache _distributedCache;
        public RedisCacheService(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;

        }

        public async Task SetStringAsync(string key, string value)
        {
           await _distributedCache.SetStringAsync(key, value);
        }

        public async Task<string> GetStringAsync(string key)
        {
            return await _distributedCache.GetStringAsync(key);
        }

        public async Task SetObjectAsync<T>(string key, T value)
        {
            await _distributedCache.SetAsync(key, value.ToByteArray());
        }

        public async Task<T> GetObjectAsync<T>(string key)
        {
            var result = await _distributedCache.GetAsync(key);
            return result.ToObject<T>();
        }








    }
}

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

        public async Task SetStringAsync(string key, string value, int? durationSeconds = -1)
        {
            if(durationSeconds == null||durationSeconds == -1)
                await _distributedCache.SetStringAsync(key, value);
            else
            {
                var expiration = TimeSpan.FromSeconds(durationSeconds.Value);
                await _distributedCache.SetStringAsync(key, value, new DistributedCacheEntryOptions() { AbsoluteExpirationRelativeToNow = expiration });
            }
            
        }

        public async Task<string> GetStringAsync(string key)
        {
            return await _distributedCache.GetStringAsync(key);
        }

        public async Task SetObjectAsync<T>(string key, T value, int? durationSeconds = -1)
        {
            if (durationSeconds == null || durationSeconds == -1)
                await _distributedCache.SetAsync(key, value.ToByteArray());
            else
            {
                var expiration = TimeSpan.FromSeconds(durationSeconds.Value);
                await _distributedCache.SetAsync(key, value.ToByteArray(), new DistributedCacheEntryOptions() { AbsoluteExpirationRelativeToNow = expiration });
            }
               
        }

        public async Task<T> GetObjectAsync<T>(string key)
        {
            var result = await _distributedCache.GetAsync(key);
            return result.ToObject<T>();
        }








    }
}

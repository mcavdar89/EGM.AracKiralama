using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Cache
{
    public class MemoryCacheService : ICacheService
    {
        private readonly IMemoryCache _memoryCache;
        public MemoryCacheService(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public Task<T> GetObjectAsync<T>(string key)
        {
            return Task.FromResult(_memoryCache.TryGetValue(key, out T value)?value :default);
        }

        public Task<string> GetStringAsync(string key)
        {
            return Task.FromResult(_memoryCache.TryGetValue(key, out string value) ? value : default);
        }

        public Task SetObjectAsync<T>(string key, T value, int? durationSeconds = -1)
        {
            if (durationSeconds == null || durationSeconds != -1)
            {
                _memoryCache.Set<T>(key, value);
            }
            else
            {
                var expiration = TimeSpan.FromSeconds(durationSeconds.Value);
                _memoryCache.Set<T>(key, value, new MemoryCacheEntryOptions { AbsoluteExpirationRelativeToNow = expiration });
            }
            return Task.CompletedTask;
        }

        public Task SetStringAsync(string key, string value, int? durationSeconds = -1)
        {

            if (durationSeconds == null || durationSeconds != -1)
            {
                _memoryCache.Set<string>(key, value);
            }
            else
            {
                var expiration = TimeSpan.FromSeconds(durationSeconds.Value);
                _memoryCache.Set<string>(key, value,new MemoryCacheEntryOptions { AbsoluteExpirationRelativeToNow = expiration});
            }
            return Task.CompletedTask;

        }
    }
}

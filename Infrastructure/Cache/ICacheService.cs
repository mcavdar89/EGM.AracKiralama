using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Cache
{
    public interface ICacheService
    {
        Task SetStringAsync(string key, string value, TimeSpan? expiration=null );
        Task<string> GetStringAsync(string key);
        Task SetObjectAsync<T>(string key, T value, TimeSpan? expiration = null);
        Task<T> GetObjectAsync<T>(string key);
    }
}

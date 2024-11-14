using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Cache
{
    public static class CacheExtensions
    {
        public static void AddRedisCache(this IServiceCollection services,RedisConfiguration redisConfiguration)
        {
            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = redisConfiguration.Configuration;
                options.InstanceName = redisConfiguration.InstanceName;
            });


            services.AddSingleton<ICacheService, RedisCacheService>();


        }

    }
}

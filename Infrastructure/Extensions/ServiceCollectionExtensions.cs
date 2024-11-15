
using Castle.DynamicProxy;
using Infra.BL.Abstracts;
using Infra.BL.Concretes;
using Infra.DAL.Abstracts;
using Infra.DAL.Concretes;
using Infra.DAL.Contexts;
using Infrastructure.Interceptors;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Extensions
{
    public static class ServiceCollectionExtensions
    {

        public static IServiceCollection AddEGMLog(this IServiceCollection services, string dbConettion)
        {
            services.AddDbContext<LogDBContext>(options =>
            {
                options.UseSqlServer(dbConettion);
            });

            services.AddScoped<ILogRepository, LogRepository>();
            services.AddScoped<ILogService, LogService>();

            return services;
        }


        public static IServiceCollection AddProxiedServices(this IServiceCollection services, ProxyGenerator proxyGenerator)
        {
            var list = services.Where(x => x.Lifetime == ServiceLifetime.Scoped && x.ServiceType.Name.EndsWith("Service") && !x.ServiceType.FullName.StartsWith("Infra.")&& !x.ServiceType.FullName.StartsWith("Microsoft")).ToList();

            foreach (var item in list)
            {
                var implementationType = item.ImplementationType;
                services.Remove(item);

                services.AddScoped(serviceProvider =>
                {
                    var target = ActivatorUtilities.CreateInstance(serviceProvider, implementationType);
                    var interceptor = serviceProvider.GetRequiredService<CachingInterceptor>();
                    return proxyGenerator.CreateClassProxyWithTarget(implementationType, target, interceptor);

                });

            }

            return services;




        }
    }
}

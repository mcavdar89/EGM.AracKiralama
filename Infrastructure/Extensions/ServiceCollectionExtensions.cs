using Infra.BL.Abstracts;
using Infra.BL.Concretes;
using Infra.DAL.Abstracts;
using Infra.DAL.Concretes;
using Infra.DAL.Contexts;
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

        public static IServiceCollection AddEGMLog(this IServiceCollection services,string dbConettion)
        {
            services.AddDbContext<LogDBContext>(options =>
            {
                options.UseSqlServer(dbConettion);
            });

            services.AddScoped<ILogRepository, LogRepository>();
            services.AddScoped<ILogService, LogService>();

            return services;
        }



    }
}

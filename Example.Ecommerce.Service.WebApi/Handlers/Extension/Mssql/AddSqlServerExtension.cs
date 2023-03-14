using Example.Ecommerce.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System;

namespace Example.Ecommerce.Service.WebApi.Handlers.Extension.Mssql
{
    public static class AddSqlServerExtension
    {
        public static IServiceCollection AddSqlServer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextPool<EfContext>(opt =>
            {
                //opt.UseInMemoryDatabase("NorthwindConnection-in-memory");
                opt.EnableSensitiveDataLogging(true);
                opt.UseSqlServer(configuration.GetConnectionString("NorthwindConnection")!, mssql =>
                {
                    mssql.EnableRetryOnFailure();
                    mssql.MigrationsAssembly(typeof(EfContext).Assembly.FullName);
                });
                //.LogTo(Console.WriteLine)
            });

            return services;
        }
    }
}

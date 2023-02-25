using Example.Ecommerce.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Example.Ecommerce.Service.WebApi.Handlers.Extension.Mssql
{
    public static class AddSqlServerExtension
    {
        public static IServiceCollection AddSqlServer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<EfContext, EfContext>(opt =>
            {
                opt.EnableSensitiveDataLogging(true);
                opt.UseSqlServer(configuration.GetConnectionString("NorthwindConnection")!, opt =>
                {
                    opt.EnableRetryOnFailure();
                    opt.MigrationsAssembly(typeof(EfContext).Assembly.FullName);
                }).LogTo(Console.WriteLine);
            }, ServiceLifetime.Scoped);

            return services;
        }
    }
}

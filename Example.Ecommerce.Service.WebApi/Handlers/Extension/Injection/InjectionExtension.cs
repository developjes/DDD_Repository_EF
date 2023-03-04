using Example.Ecommerce.Application.Interface;
using Example.Ecommerce.Application.Main;
using Example.Ecommerce.Domain.Core;
using Example.Ecommerce.Domain.Interface;
using Example.Ecommerce.Infrastructure.Data.Context;
using Example.Ecommerce.Infrastructure.Interface.Repository;
using Example.Ecommerce.Infrastructure.Interface.UnitOfWork;
using Example.Ecommerce.Infrastructure.Repository.Repository;
using Example.Ecommerce.Infrastructure.Repository.UnitOfWork;
using Example.Ecommerce.Service.WebApi.Handlers.Extension.AntiforgeryCookie;
using Example.Ecommerce.Transversal.Common.Interface;
using Example.Ecommerce.Transversal.Logging;

namespace Example.Ecommerce.Service.WebApi.Handlers.Extension.Injection
{
    public static class InjectionExtension
    {
        public static IServiceCollection AddInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(configuration);
            services.AddTransient<AntiforgeryCookieResultFilter>();
            services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<ICategoryApplication, CategoryApplication>();
            services.AddScoped<ICategoryDomain, CategoryDomain>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();

            services.AddScoped<IMessageDomain, MessageDomain>();
            services.AddScoped<IMessageRepository, MessageRepository>();

            return services;
        }
    }
}
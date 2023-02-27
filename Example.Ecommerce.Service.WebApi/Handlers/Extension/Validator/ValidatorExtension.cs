using Example.Ecommerce.Application.Validator.InputValidator;

namespace Example.Ecommerce.Service.WebApi.Handlers.Extension.Validator
{
    public static class ValidatorExtension
    {
        public static IServiceCollection AddValidator(this IServiceCollection services)
        {
            services.AddTransient<CategoryRequestDtoValidator>();

            return services;
        }
    }
}

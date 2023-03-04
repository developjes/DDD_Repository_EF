using Example.Ecommerce.Application.Validator;
using FluentValidation;
using FluentValidation.AspNetCore;
using MicroElements.Swashbuckle.FluentValidation.AspNetCore;

namespace Example.Ecommerce.Service.WebApi.Handlers.Extension.Validator
{
    public static class ValidatorExtension
    {
        public static IServiceCollection AddValidator(this IServiceCollection services)
        {
            services.AddTransient<CategoryRequestCreateDtoValidator>();
            services.AddTransient<CategoryRequestUpdateDtoValidator>();

            services.AddFluentValidationAutoValidation(x => x.DisableDataAnnotationsValidation = true);
            services.AddFluentValidationClientsideAdapters();
            services.AddFluentValidationRulesToSwagger(x =>
            {
                x.SetNotNullableIfMinLengthGreaterThenZero = true;
                x.UseAllOffForMultipleRules = true;
            });

            services.AddValidatorsFromAssemblyContaining<Program>(lifetime: ServiceLifetime.Scoped);

            return services;
        }
    }
}

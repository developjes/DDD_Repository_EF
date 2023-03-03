using Example.Ecommerce.Infrastructure.Data.IntegrationData;
using Microsoft.EntityFrameworkCore;

namespace Example.Ecommerce.Infrastructure.Data.Context
{
    public static class AllConfigurationDataExtension
    {
        public static ModelBuilder AddMoldelBuilderConfiguration(this ModelBuilder modelBuilder)
        {
            modelBuilder
                .ApplyConfiguration(new StateConfig())
                .ApplyConfiguration(new PlanConfig())
                .ApplyConfiguration(new CategoryConfig())
                .ApplyConfiguration(new MovieConfig())
                .ApplyConfiguration(new MovieCategoryConfig())
                .ApplyConfiguration(new MessageConfig());

            return modelBuilder;
        }
    }
}

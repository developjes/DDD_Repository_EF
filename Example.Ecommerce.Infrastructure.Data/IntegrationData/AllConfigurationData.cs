using Microsoft.EntityFrameworkCore;

namespace Example.Ecommerce.Infrastructure.Data.IntegrationData
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
                .ApplyConfiguration(new MovieCategoryConfig());

            return modelBuilder;
        }
    }
}

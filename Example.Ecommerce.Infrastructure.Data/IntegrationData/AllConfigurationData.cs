using Example.Ecommerce.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Example.Ecommerce.Infrastructure.Data.IntegrationData
{
    public static class AllConfigurationDataExtension
    {
        public static ModelBuilder AddMoldelBuilderConfiguration(this ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryConfig());

            return modelBuilder;
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Example.Ecommerce.Infrastructure.Data.IntegrationData.Common
{
    public static class AuditFiledsExtension
    {
        public static ModelBuilder AddAuditFieldsConfiguration(this ModelBuilder modelBuilder)
        {
            foreach (IMutableEntityType entityType in modelBuilder.Model.GetEntityTypes())
            {
                foreach (IMutableProperty property in entityType.GetProperties())
                {
                    switch (property.Name)
                    {
                        case "CreateAt":
                            property.SetColumnName("CreateAt");
                            property.SetComment("Fecha de creacion del registro");
                            property.IsNullable = false;

                            break;

                        case "UpdateAt":
                            property.SetColumnName("UpdateAt");
                            property.SetComment("Fecha de actualizacion del registro");
                            property.IsNullable = true;

                            break;
                    }
                }
            }

            return modelBuilder;
        }
    }
}

using Example.Ecommerce.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Example.Ecommerce.Infrastructure.Data.IntegrationData
{
    public class CategoryConfig: IEntityTypeConfiguration<CategoryEntity>
    {
        public void Configure(EntityTypeBuilder<CategoryEntity> builder)
        {
            //builder.HasChangeTrackingStrategy(ChangeTrackingStrategy.ChangedNotifications);

            #region Rule properties

            builder.ToTable(name: "Category", schema: "Parametrization")
                .HasKey(p => p.CategoryId);

            builder.Property(p => p.CategoryName)
                .IsRequired();

            builder.Property(p => p.Description)
                .IsRequired()
                .HasMaxLength(250);

            builder.Property(p => p.Picture)
                .IsRequired();

            #endregion

            #region Relationships

            #endregion
        }
    }
}

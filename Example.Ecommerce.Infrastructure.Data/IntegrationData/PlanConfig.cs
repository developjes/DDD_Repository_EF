using Example.Ecommerce.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Example.Ecommerce.Infrastructure.Data.IntegrationData
{
    public sealed class PlanConfig : IEntityTypeConfiguration<PlanEntity>
    {
        public void Configure(EntityTypeBuilder<PlanEntity> builder)
        {
            #region Rule properties

            #region General cofig

            builder.ToTable(name: "Plan", schema: "Parametrization");

            #endregion

            #region Fields

            builder.Property(s => s.PlanId)
                .HasColumnName("PlanId")
                .HasComment("Id tabla")
                .HasColumnOrder(1)
                .IsRequired(required: true);

            builder.Property(p => p.Name)
                .HasColumnOrder(2)
                .HasColumnName("Name")
                .HasComment("Nombre del plan")
                .IsRequired(required: true);

            #endregion

            #region Relationships

            builder.HasKey(p => p.PlanId);

            builder.HasMany(p => p.Categories)
                .WithOne(c => c.Plan)
                .HasForeignKey(c => c.PlanId)
                .OnDelete(DeleteBehavior.Restrict);

            #endregion

            #endregion
        }
    }
}

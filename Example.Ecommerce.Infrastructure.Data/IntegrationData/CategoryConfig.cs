using Example.Ecommerce.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Example.Ecommerce.Infrastructure.Data.IntegrationData
{
    public sealed class CategoryConfig: IEntityTypeConfiguration<CategoryEntity>
    {
        public void Configure(EntityTypeBuilder<CategoryEntity> builder)
        {
            #region Rule properties

            #region General cofig

            builder.ToTable(name: "Category", schema: "Parametrization");

            #endregion

            #region Fields

            builder.Property(c => c.CategoryId)
                .HasColumnName("CategoryId")
                .HasComment("Id tabla")
                .HasColumnOrder(1)
                .IsRequired(required: true);

            builder.Property(c => c.Name)
                .HasColumnOrder(2)
                .HasColumnName("Name")
                .HasComment("Nombre de la categoria")
                .IsRequired(required: true);

            builder.Property(c => c.Description)
                .HasColumnOrder(3)
                .HasColumnName("Description")
                .HasComment("Descripcion de la categoria")
                .HasMaxLength(250)
                .IsRequired(required: true);

            builder.Property(c => c.Picture)
                .HasColumnName("Picture")
                .HasColumnOrder(4)
                .HasComment("imagen de la categoria")
                .IsRequired(required: true);

            builder.Ignore(s => s.StateId)
                .Property<int>("_stateId")
                .HasColumnName("StateId")
                .HasComment("Id tabla foranea")
                .HasColumnOrder(5)
                .IsUnicode(unicode: false)
                .IsRequired(required: true);

            builder.Property(c => c.PlanId)
                .HasColumnName("PlanId")
                .HasComment("Id tabla foranea")
                .HasColumnOrder(6)
                .IsRequired(required: false);

            #endregion

            #region Relationships

            builder.HasKey(c => c.CategoryId);

            builder.HasOne(c => c.State)
                .WithMany(s => s.Categories)
                .HasForeignKey("_stateId")
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(c => c.Plan)
                .WithMany(s => s.Categories)
                .HasForeignKey(c => c.PlanId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(c => c.MoviesCategories)
                .WithOne(mc => mc.Category)
                .HasForeignKey(mc => mc.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            #endregion

            #endregion
        }
    }
}

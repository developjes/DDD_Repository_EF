using Example.Ecommerce.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Example.Ecommerce.Infrastructure.Data.IntegrationData
{
    public sealed class MovieCategoryConfig : IEntityTypeConfiguration<MovieCategoryEntity>
    {
        public void Configure(EntityTypeBuilder<MovieCategoryEntity> builder)
        {
            #region Rule properties

            #region General cofig

            builder.ToTable(name: "MovieCategory", schema: "Parametrization");

            #endregion

            #region Fields

            builder.Property(mc => mc.MovieCategoryId)
                .HasColumnName("MovieCategoryId")
                .HasComment("Id tabla")
                .HasColumnOrder(1)
                .IsRequired(required: true);

            builder.Property(mc => mc.MovieId)
                .HasColumnName("MovieId")
                .HasComment("Id tabla foranea")
                .HasColumnOrder(2)
                .IsRequired(required: true);

            builder.Property(mc => mc.CategoryId)
                .HasColumnName("CategoryId")
                .HasComment("Id tabla foranea")
                .HasColumnOrder(3)
                .IsRequired(required: true);

            #endregion

            #region Relationships

            builder.HasKey(mc => mc.MovieCategoryId);

            builder.HasOne(mc => mc.Movie)
                .WithMany(m => m.MoviesCategories)
                .HasForeignKey(mc => mc.MovieId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(mc => mc.Category)
                .WithMany(c => c.MoviesCategories)
                .HasForeignKey(c => c.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            #endregion

            #endregion
        }
    }
}

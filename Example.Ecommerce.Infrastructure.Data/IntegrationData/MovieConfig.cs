using Example.Ecommerce.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Example.Ecommerce.Infrastructure.Data.IntegrationData
{
    public class MovieConfig : IEntityTypeConfiguration<MovieEntity>
    {
        public void Configure(EntityTypeBuilder<MovieEntity> builder)
        {
            #region Rule properties

            #region General cofig

            builder.ToTable(name: "Movie", schema: "Parametrization");

            #endregion

            #region Fields

            builder.Property(c => c.MovieId)
                .HasColumnName("MovieId")
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

            builder.Property(c => c.CreateAt)
                .HasColumnName("CreateAt")
                .HasComment("Fecha de creacion del registro")
                .HasColumnOrder(4)
                .IsRequired(required: true);

            builder.Property(c => c.UpdateAt)
                .HasColumnName("UpdateAt")
                .HasComment("Fecha de actualizacion del registro")
                .HasColumnOrder(5)
                .IsRequired(required: false);

            #endregion

            #region Relationships

            builder.HasKey(m => m.MovieId);

            builder.HasMany(m => m.MoviesCategories)
                .WithOne(mc => mc.Movie)
                .HasForeignKey(mc => mc.MovieId)
                .OnDelete(DeleteBehavior.Restrict);

            #endregion

            #endregion
        }
    }
}

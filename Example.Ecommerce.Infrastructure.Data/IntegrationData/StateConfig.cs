using Example.Ecommerce.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Example.Ecommerce.Infrastructure.Data.IntegrationData
{
    public class StateConfig : IEntityTypeConfiguration<StateEntity>
    {
        public void Configure(EntityTypeBuilder<StateEntity> builder)
        {
            #region Rule properties

            #region General cofig

            builder.ToTable(name: "State", schema: "Parametrization");

            #endregion

            #region Fields

            builder.Property(s => s.StateId)
                .HasColumnName("StateId")
                .HasComment("Id tabla")
                .HasColumnOrder(1)
                .IsRequired(required: true);

            builder.Property(s => s.Name)
                .HasColumnOrder(2)
                .HasColumnName("Name")
                .HasComment("Nombre del estado")
                .IsRequired(required: true);

            builder.Property(s => s.Description)
                .HasColumnOrder(3)
                .HasColumnName("Description")
                .HasComment("Descripcion del estado")
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

            builder.HasKey(s => s.StateId);

            builder.HasMany(s => s.Categories)
                .WithOne(c => c.State)
                .HasForeignKey(c => c.StateId)
                .OnDelete(DeleteBehavior.Restrict);

            #endregion

            #endregion
        }
    }
}

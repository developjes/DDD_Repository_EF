using Example.Ecommerce.Domain.Entity;
using Example.Ecommerce.Infrastructure.Data.Seeder;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Example.Ecommerce.Infrastructure.Data.IntegrationData
{
    public sealed class StateConfig : IEntityTypeConfiguration<StateEntity>
    {
        public void Configure(EntityTypeBuilder<StateEntity> builder)
        {
            #region Rule properties

            #region General cofig

            builder.ToTable(name: "State", schema: "Parametrization");

            #endregion General cofig

            #region Fields

            builder.Property(s => s.StateId)
                .HasColumnName("StateId")
                .HasComment("Id tabla")
                .HasColumnOrder(1)
                .ValueGeneratedOnAdd()
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

            #endregion Fields

            #region Relationships

            //builder.HasCheckConstraint(
                //name: "constraint_gender",
                //sql: "`gender` = 'male' or `gender` = 'female'"
            //)

            builder.HasKey(s => s.StateId);

            builder.HasIndex(s => s.Name).IsUnique();

            builder.HasMany(s => s.Categories)
                .WithOne(c => c.State)
                .HasForeignKey("_stateId")
                .OnDelete(DeleteBehavior.Restrict);

            #endregion Relationships

            #region Seeder

            builder.AddSeeder();

            #endregion Seeder

            #endregion Rule properties
        }
    }
}
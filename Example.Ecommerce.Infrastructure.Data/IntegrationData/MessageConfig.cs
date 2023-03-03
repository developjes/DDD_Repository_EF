using Example.Ecommerce.Domain.Entity;
using Example.Ecommerce.Infrastructure.Data.Seeder;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Example.Ecommerce.Infrastructure.Data.IntegrationData
{
    public sealed class MessageConfig : IEntityTypeConfiguration<MessageEntity>
    {
        public void Configure(EntityTypeBuilder<MessageEntity> builder)
        {
            #region Rule properties

            #region General cofig

            builder.ToTable(name: "Message", schema: "Parametrization");

            #endregion General cofig

            #region Fields

            builder.Property(m => m.Key)
                .HasColumnName("Key")
                .HasComment("Key message")
                .HasColumnOrder(1)
                .IsRequired(required: true);

            builder.Property(m => m.Description)
                .HasColumnOrder(2)
                .HasColumnName("Description")
                .HasComment("Descripcion del mensaje");

            #endregion Fields

            #region Relationships

            builder.HasKey(m => m.Key);

            #endregion Relationships

            #region

            builder.AddSeeder();

            #endregion

            #endregion Rule properties
        }
    }
}

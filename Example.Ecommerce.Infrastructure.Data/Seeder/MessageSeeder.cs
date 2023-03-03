using Example.Ecommerce.Domain.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Example.Ecommerce.Infrastructure.Data.Seeder
{
    public static class MessageSeeder
    {
        public static EntityTypeBuilder<MessageEntity> AddSeeder(this EntityTypeBuilder<MessageEntity> entity)
        {
            List<MessageEntity> messageEntityList = new()
            {
                new MessageEntity
                {
                    Key = "NOT_FOUND",
                    Description = "Registro(s) no encontrado(s)"
                },
                new MessageEntity
                {
                    Key = "INSERT_SUCCESS",
                    Description = "Registro creado correctamente"
                },
                new MessageEntity
                {
                    Key = "UPDATE_SUCCESS",
                    Description = "Registro editado correctamente"
                },
                new MessageEntity
                {
                    Key = "DELETE_SUCCESS",
                    Description = "Registro removido correctamente"
                },
                new MessageEntity
                {
                    Key = "INSERT_ERROR",
                    Description = "Registro no pudo ser creado correctamente"
                },
                new MessageEntity
                {
                    Key = "UPDATE_ERROR",
                    Description = "Registro no pudo ser editado correctamente"
                },
                new MessageEntity
                {
                    Key = "DELETE_ERROR",
                    Description = "Registro no pudo ser removido correctamente"
                },
                new MessageEntity
                {
                    Key = "VALIDATION_ERROR",
                    Description = "Errores de validación"
                }
            };

            entity.HasData(messageEntityList);

            return entity;
        }
    }
}

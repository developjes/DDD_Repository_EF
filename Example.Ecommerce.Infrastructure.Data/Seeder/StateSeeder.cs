using Example.Ecommerce.Domain.Entity;
using Example.Ecommerce.Transversal.Common.Enum;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Example.Ecommerce.Infrastructure.Data.Seeder
{
    public static class StateSeeder
    {
        public static EntityTypeBuilder<StateEntity> AddSeeder(this EntityTypeBuilder<StateEntity> entity)
        {
            /*
               Feker package random Data

               Randomizer.Seed = new Random(1338)

                int id = 1
                Faker<StateEntity> states = new Faker<StateEntity>("es")
                    .StrictMode(true)
                    .RuleFor(u => u.Name, f => f.PickRandom<string[]>(stateNames))

                    .RuleFor(s => s.StateId, _ => id+)
                    .RuleFor(s => s.Name, f => f.Commerce.ProductName())
                    .RuleFor(s => s.Description, f => f.Commerce.ProductDescription())
                    .RuleFor(s => s.CreateAt, f => f.Date.Past())
                    .RuleFor(s => s.UpdateAt, f => f.Date.Past().OrNull(f))
                    .RuleFor(s => s.Categories, _ => null)

                List<StateEntity> stateEntityList = states.Generate(count: 4)
             */

            List<StateEntity> stateEntityList = new()
            {
                new StateEntity()
                {
                    StateId = (int)EnumState.Activo,
                    Name = "Activo",
                    Description = "Estado Activo"
                },
                new StateEntity()
                {
                    StateId = (int)EnumState.Inactivo,
                    Name = "Inactivo",
                    Description = "Estado Inactivo"
                },
                new StateEntity()
                {
                    StateId = (int)EnumState.Restaurado,
                    Name = "Restaurado",
                    Description = "Estado Restaurado"
                },
                new StateEntity()
                {
                    StateId = (int)EnumState.Expirado,
                    Name = "Expirado",
                    Description = "Estado Expirado"
                }
            };

            entity.HasData(stateEntityList);

            return entity;
        }
    }
}

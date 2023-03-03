using Example.Ecommerce.Domain.Entity.Common;

namespace Example.Ecommerce.Domain.Entity
{
    public class MovieCategoryEntity : AuditableEntity
    {
        public int MovieCategoryId { get; set; }

        public int MovieId { get; set; }
        public virtual MovieEntity? Movie { get; set; }

        public int CategoryId { get; set; }
        public virtual CategoryEntity? Category { get; set; }
    }
}
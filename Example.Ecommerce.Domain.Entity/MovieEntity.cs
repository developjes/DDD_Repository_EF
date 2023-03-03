using Example.Ecommerce.Domain.Entity.Common;

namespace Example.Ecommerce.Domain.Entity
{
    public class MovieEntity : AuditableEntity
    {
        public int MovieId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public virtual ICollection<MovieCategoryEntity>? MoviesCategories { get; set; }
    }
}

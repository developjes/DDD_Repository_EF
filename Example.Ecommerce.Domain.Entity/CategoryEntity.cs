using Example.Ecommerce.Domain.Entity.Common;

namespace Example.Ecommerce.Domain.Entity
{
    public class CategoryEntity: AuditableEntity
    {
        public int CategoryId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Picture { get; set; }
        public int StateId { get; set; }
        public int? PlanId { get; set; }

        public StateEntity? State { get; set; }
        public PlanEntity? Plan { get; set; }
        public ICollection<MovieCategoryEntity>? MoviesCategories { get; set; }
    }
}
using Example.Ecommerce.Domain.Entity.Common;

namespace Example.Ecommerce.Domain.Entity
{
    public class PlanEntity : AuditableEntity
    {
        public int PlanId { get; set; }
        public string? Name { get; set; }
        public virtual ICollection<CategoryEntity>? Categories { get; set; }
    }
}

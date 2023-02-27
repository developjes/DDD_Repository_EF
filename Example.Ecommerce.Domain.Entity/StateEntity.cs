using Example.Ecommerce.Domain.Entity.Common;

namespace Example.Ecommerce.Domain.Entity
{
    public class StateEntity : AuditableEntity
    {
        public int StateId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set;}
        public ICollection<CategoryEntity>? Categories { get; set; }
    }
}

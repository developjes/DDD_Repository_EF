using Example.Ecommerce.Domain.Entity.Common;

namespace Example.Ecommerce.Domain.Entity
{
    public class CategoryEntity: AuditableEntity
    {
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public string? Description { get; set; }
        public byte[]? Picture { get; set; }
    }
}
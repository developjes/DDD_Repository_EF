using Example.Ecommerce.Domain.Entity.Common;

namespace Example.Ecommerce.Domain.Entity
{
    public class MessageEntity: AuditableEntity
    {
        public string? Key { get; set; }
        public string? Description { get; set; }
    }
}

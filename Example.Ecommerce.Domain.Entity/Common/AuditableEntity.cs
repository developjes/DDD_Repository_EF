namespace Example.Ecommerce.Domain.Entity.Common
{
    public abstract class AuditableEntity
    {
        public DateTime CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }
    }
}

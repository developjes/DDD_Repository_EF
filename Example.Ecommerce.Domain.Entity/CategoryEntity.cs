using Example.Ecommerce.Domain.Entity.Common;
using Example.Ecommerce.Transversal.Common.Enum;

namespace Example.Ecommerce.Domain.Entity
{
    public class CategoryEntity: AuditableEntity
    {
        #region Fields

        public int CategoryId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Picture { get; set; }
        public int? PlanId { get; set; }
        public EnumState StateId { get => (EnumState)_stateId; set => _stateId = (int)value; }
        private int _stateId;

        #endregion Fields

        #region relationships

        public virtual StateEntity? State { get; set; }
        public virtual  PlanEntity? Plan { get; set; }
        public virtual ICollection<MovieCategoryEntity>? MoviesCategories { get; set; }

        #endregion relationships
    }
}
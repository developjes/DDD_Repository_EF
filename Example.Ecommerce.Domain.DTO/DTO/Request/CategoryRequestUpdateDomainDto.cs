using Example.Ecommerce.Transversal.Common.Enum;

namespace Example.Ecommerce.Domain.DTO.Request
{
    public class CategoryRequestUpdateDomainDto
    {
        public int CategoryId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Picture { get; set; }
        public int? PlanId { get; set; }
        public EnumState StateId { get => (EnumState)_stateId; set => _stateId = (int)value; }
        private int _stateId;
    }
}

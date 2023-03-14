using Example.Ecommerce.Transversal.Common.Enum;
using Microsoft.AspNetCore.Http;

namespace Example.Ecommerce.Application.DTO.Request
{
    public class CategoryRequestCreateDto
    {
        public string? Name { get => _name; set => _name = value!.Trim(); }
        private string? _name;
        public string? Description { get => _description; set => _description = value!.Trim(); }
        private string? _description;
        public string? Picture { get => _picture; set => _picture = value!.Trim(); }
        private string? _picture;
        public int? PlanId { get; set; } = null!;
        public EnumState StateId { get => (EnumState)_stateId; set => _stateId = (int)value; }
        private int _stateId;
    }
}

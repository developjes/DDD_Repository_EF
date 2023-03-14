using Example.Ecommerce.Transversal.Common.Enum;
using System.ComponentModel.DataAnnotations;

namespace Example.Ecommerce.Application.DTO.Request
{
    public class CategoryRequestUpdateDto
    {
        [Required]
        public string? Name { get => _name; set => _name = value is not null ? value!.Trim() : null; }
        private string? _name;
        [Required]
        public string? Description { get => _description; set => _description = value!.Trim(); }
        private string? _description;
        [Required]
        public string? Picture { get => _picture; set => _picture = value!.Trim(); }
        private string? _picture;
        public int? PlanId { get; set; }
        [Required]
        public EnumState StateId { get => (EnumState)_stateId; set => _stateId = (int)value; }
        private int _stateId;
    }
}

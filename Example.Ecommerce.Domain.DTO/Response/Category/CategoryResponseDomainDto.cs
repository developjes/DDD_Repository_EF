using Example.Ecommerce.Domain.Entity;

namespace Example.Ecommerce.Domain.DTO.Response.Category
{
    public class CategoryResponseDomainDto
    {
        public int CategoryId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Picture { get; set; }
        public int? PlanId { get; set; }
        public int StateId { get; set; }
    }
}
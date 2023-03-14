namespace Example.Ecommerce.Application.DTO.Response
{
    public class CategoryResponseDto
    {
        public int CategoryId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Picture { get; set; }
        public int? PlanId { get; set; }
        public int StateId { get; set; }
    }
}
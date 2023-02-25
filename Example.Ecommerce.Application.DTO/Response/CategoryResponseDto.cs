namespace Example.Ecommerce.Application.DTO.Response
{
    public class CategoryResponseDto
    {
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public string? Description { get; set; }
        public byte[]? Picture { get; set; }
    }
}
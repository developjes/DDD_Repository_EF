using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Example.Ecommerce.Application.DTO.Request
{
    public class CategoryRequestCreateFileUpload
    {
        public int MyId { get; set; }
        public string? CategoryName { get; set; }
        [Required]
        public IFormFile? Cedula { get; set; }
        [Required]
        public IEnumerable<IFormFile?>? Cartas { get; set; }
    }
}

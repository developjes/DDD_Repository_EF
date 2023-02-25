using Example.Ecommerce.Application.DTO.Request;
using Example.Ecommerce.Application.DTO.Response;
using Example.Ecommerce.Application.Interface;
using Example.Ecommerce.Transversal.Common.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Example.Ecommerce.Service.WebApi.Controllers.v1
{
    [Authorize]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0", Deprecated = false)]
    public class CategoryController : Controller
    {
        private readonly ICategoryApplication _categoryApplication;

        public CategoryController(ICategoryApplication categoryApplication) => _categoryApplication = categoryApplication;

        [HttpGet]
        [AllowAnonymous]
        [SwaggerOperation( Description = "Get categories", Tags = new[] { "Category" } )]
        [SwaggerResponse(StatusCodes.Status200OK, "Successful", Type = typeof(Response<IEnumerable<CategoryResponseDto>>))]
        [ProducesResponseType(500)]
        [Route("Get")]
        public async Task<IActionResult> GetAsync()
        {
            Response<IEnumerable<CategoryResponseDto>> response = await _categoryApplication.GetAsync();

            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response);
        }

        [HttpDelete]
        [AllowAnonymous]
        [SwaggerOperation(
            Description = "Delete a category",
            Tags = new[] { "Category" }
        )]
        [SwaggerResponse(StatusCodes.Status200OK, "Successful")]
        [ProducesResponseType(500)]
        [Route("Delete/{categoryId:int}")]
        public IActionResult Delete(int categoryId)
        {
            if (categoryId < 0)
                return BadRequest();

            Response<bool> response = _categoryApplication.Delete(categoryId);

            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response);
        }

        [HttpPost]
        [AllowAnonymous]
        [SwaggerOperation(
            Description = "Create a new category",
            Tags = new[] { "Category" }
        )]
        [SwaggerResponse(StatusCodes.Status200OK, "Successful")]
        [ProducesResponseType(500)]
        [Route("Insert")]
        public IActionResult Insert([FromBody] CategoryRequestDto category)
        {
            if (category is null)
                return BadRequest();

            Response<bool> response = _categoryApplication.Insert(category);

            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response);
        }
    }
}

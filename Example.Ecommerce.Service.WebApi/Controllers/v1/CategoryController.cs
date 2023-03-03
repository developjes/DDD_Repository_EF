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

        [HttpPost]
        [AllowAnonymous]
        [SwaggerOperation(
            Description = "Create a new category",
            Tags = new[] { "Category" }
        )]
        [SwaggerResponse(StatusCodes.Status200OK, "Successful")]
        [ProducesResponseType(500)]
        [Route("Create")]
        public async Task<IActionResult> Create([FromBody] CategoryRequestCreateDto category)
        {
            Response<bool> response = await _categoryApplication.Create(category);

            int statusCode = response.IsSuccess ? StatusCodes.Status201Created : StatusCodes.Status400BadRequest;

            return StatusCode(statusCode, response);
        }

        [HttpPost]
        [AllowAnonymous]
        [SwaggerOperation(
            Description = "Update a category",
            Tags = new[] { "Category" }
        )]
        [SwaggerResponse(StatusCodes.Status200OK, "Successful")]
        [ProducesResponseType(500)]
        [Route("Update")]
        public async Task<IActionResult> Update([FromBody] CategoryRequestUpdateDto category)
        {
            Response<bool> response = await _categoryApplication.Edit(category);

            int statusCode = response.IsSuccess ? StatusCodes.Status201Created : StatusCodes.Status400BadRequest;

            return StatusCode(statusCode, response);
        }
    }
}

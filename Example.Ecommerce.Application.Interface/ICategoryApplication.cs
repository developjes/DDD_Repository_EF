using Example.Ecommerce.Application.DTO.Request;
using Example.Ecommerce.Application.DTO.Response;
using Example.Ecommerce.Transversal.Common.Generic;

namespace Example.Ecommerce.Application.Interface
{
    public interface ICategoryApplication
    {
        Task<Response<IEnumerable<CategoryResponseDto>>> GetAsync();
        Response<bool> Delete(int categoryId);
        Response<bool> Insert(CategoryRequestDto categoryDto);
        Task<Response<bool>> InsertAsync(CategoryRequestDto categoryDto);
    }
}

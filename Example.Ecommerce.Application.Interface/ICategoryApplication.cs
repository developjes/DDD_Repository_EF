using Example.Ecommerce.Application.DTO.Request;
using Example.Ecommerce.Application.DTO.Response;
using Example.Ecommerce.Transversal.Common.Generic;

namespace Example.Ecommerce.Application.Interface
{
    public interface ICategoryApplication
    {
        Task<Response<bool>> Create(CategoryRequestCreateDto categoryDto);
        Task<Response<bool>> Edit(CategoryRequestUpdateDto categoryDto);
    }
}

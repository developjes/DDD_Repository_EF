using AutoMapper;
using Example.Ecommerce.Application.DTO.Request;
using Example.Ecommerce.Application.DTO.Response;
using Example.Ecommerce.Application.Interface;
using Example.Ecommerce.Domain.Entity;
using Example.Ecommerce.Domain.Interface;
using Example.Ecommerce.Transversal.Common.Generic;

namespace Example.Ecommerce.Application.Main
{
    public class CategoryApplication : ICategoryApplication
    {
        private readonly ICategoryDomain _categoryDomain;
        private readonly IMapper _mapper;

        public CategoryApplication(ICategoryDomain categoryDomain, IMapper mapper) =>
            (_categoryDomain, _mapper) = (categoryDomain, mapper);

        public async Task<Response<IEnumerable<CategoryResponseDto>>> GetAsync()
        {
            Response<IEnumerable<CategoryResponseDto>> response = new();

            try
            {
                IEnumerable<CategoryEntity> categories = await _categoryDomain.GetAsync();
                response.Data = _mapper.Map<IEnumerable<CategoryResponseDto>>(categories);

                if (response.Data is not null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta Exitosa!!!";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }

        public Response<bool> Insert(CategoryRequestDto categoryDto)
        {
            Response<bool> response = new();
            try
            {
                CategoryEntity category = _mapper.Map<CategoryEntity>(categoryDto);
                response.Data = _categoryDomain.Insert(category);

                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Registro Exitoso!!!";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }

            return response;
        }

        public async Task<Response<bool>> InsertAsync(CategoryRequestDto categoryDto)
        {
            Response<bool> response = new();
            try
            {
                CategoryEntity category = _mapper.Map<CategoryEntity>(categoryDto);
                response.Data = await _categoryDomain.InsertAsync(category);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Registro Exitoso!!!";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }

        public Response<bool> Delete(int categoryId)
        {
            Response<bool> response = new();
            try
            {
                response.Data = _categoryDomain.Delete(categoryId);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Eliminación Exitosa!!!";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }
    }
}

using AutoMapper;
using Example.Ecommerce.Application.DTO.Request;
using Example.Ecommerce.Application.DTO.Response;
using Example.Ecommerce.Application.Interface;
using Example.Ecommerce.Application.Validator.InputValidator;
using Example.Ecommerce.Domain.Entity;
using Example.Ecommerce.Domain.Interface;
using Example.Ecommerce.Transversal.Common.Generic;
using FluentValidation.Results;

namespace Example.Ecommerce.Application.Main
{
    public class CategoryApplication : ICategoryApplication
    {
        private readonly ICategoryDomain _categoryDomain;
        private readonly IMapper _mapper;
        private readonly CategoryRequestDtoValidator _categoryRequestDtoValidator;

        public CategoryApplication(ICategoryDomain categoryDomain, IMapper mapper, CategoryRequestDtoValidator categoryRequestDtoValidator) =>
            (_categoryDomain, _mapper, _categoryRequestDtoValidator) = (categoryDomain, mapper, categoryRequestDtoValidator);

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

        public Response<bool> Insert(CategoryRequestDto categoryRequestDto)
        {
            Response<bool> response = new();
            ValidationResult validationInput = _categoryRequestDtoValidator.Validate(categoryRequestDto);

            if (!validationInput.IsValid)
            {
                response.Message = "Parametros no pueden ser vacios";
                response.ValidationErrors = validationInput.Errors.Select(x => x.ErrorMessage);
                return response;
            }

            try
            {
                CategoryEntity category = _mapper.Map<CategoryEntity>(categoryRequestDto);
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

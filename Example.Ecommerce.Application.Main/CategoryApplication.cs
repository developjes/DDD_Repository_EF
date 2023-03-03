using AutoMapper;
using Example.Ecommerce.Application.DTO.Request;
using Example.Ecommerce.Application.Interface;
using Example.Ecommerce.Application.Validator;
using Example.Ecommerce.Domain.DTO.Request;
using Example.Ecommerce.Domain.Interface;
using Example.Ecommerce.Transversal.Common.Enum;
using Example.Ecommerce.Transversal.Common.Generic;
using FluentValidation;
using FluentValidation.Results;

namespace Example.Ecommerce.Application.Main
{
    public class CategoryApplication : ICategoryApplication
    {
        private readonly ICategoryDomain _categoryDomain;
        private readonly IMapper _mapper;
        private readonly CategoryRequestCreateDtoValidator _categoryRequestCreateDtoValidator;
        private readonly CategoryRequestUpdateDtoValidator _categoryRequestUpdateDtoValidator;

        public CategoryApplication(
            ICategoryDomain categoryDomain, IMapper mapper,
            CategoryRequestCreateDtoValidator categoryRequestCreateDtoValidator,
            CategoryRequestUpdateDtoValidator categoryRequestUpdateDtoValidator
        )
        {
            _mapper = mapper;
            _categoryDomain = categoryDomain;
            _categoryRequestCreateDtoValidator = categoryRequestCreateDtoValidator;
            _categoryRequestUpdateDtoValidator = categoryRequestUpdateDtoValidator;
        }

        public async Task<Response<bool>> Create(CategoryRequestCreateDto categoryDto)
        {
            Response<bool> response = new();
            ValidationResult validation = await _categoryRequestCreateDtoValidator.ValidateAsync(categoryDto);

            if (!validation.IsValid)
            {
                response.Message = nameof(EnumMessage.VALIDATION_ERROR);
                response.Errors = validation.Errors;
                return response;
            }

            CategoryRequestCreateDomainDto categoryRequestDomainDto = _mapper.Map<CategoryRequestCreateDomainDto>(categoryDto);
            (response.Data, EnumMessage message) = await _categoryDomain.Create(categoryRequestDomainDto);

            response.Message = message.ToString();

            if (response.Data) response.IsSuccess = true;

            return response;
        }

        public async Task<Response<bool>> Edit(CategoryRequestUpdateDto categoryDto)
        {
            Response<bool> response = new();
            ValidationResult validation = await _categoryRequestUpdateDtoValidator.ValidateAsync(categoryDto);

            if (!validation.IsValid)
            {
                response.Message = nameof(EnumMessage.VALIDATION_ERROR);
                response.Errors = validation.Errors;
                return response;
            }

            CategoryRequestUpdateDomainDto categoryRequestDomainDto = _mapper.Map<CategoryRequestUpdateDomainDto>(categoryDto);
            (response.Data, EnumMessage message) = await _categoryDomain.Edit(categoryRequestDomainDto);

            response.Message = message.ToString();

            if (response.Data) response.IsSuccess = true;

            return response;
        }
    }
}
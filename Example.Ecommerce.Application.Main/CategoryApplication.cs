using AutoMapper;
using Example.Ecommerce.Application.DTO.Request;
using Example.Ecommerce.Application.Interface;
using Example.Ecommerce.Application.Validator;
using Example.Ecommerce.Domain.DTO.Request.Category;
using Example.Ecommerce.Domain.Interface;
using Example.Ecommerce.Transversal.Common.Enum;
using Example.Ecommerce.Transversal.Common.Generic;
using FluentValidation.Results;

namespace Example.Ecommerce.Application.Main
{
    public class CategoryApplication : ICategoryApplication
    {
        private readonly IMapper _mapper;
        private readonly ICategoryDomain _categoryDomain;
        private readonly IMessageDomain _messageDomain;
        private readonly CategoryRequestCreateDtoValidator _categoryRequestCreateDtoValidator;
        private readonly CategoryRequestUpdateDtoValidator _categoryRequestUpdateDtoValidator;

        public CategoryApplication(
            IMapper mapper,
            ICategoryDomain categoryDomain,
            IMessageDomain messageDomain,
            CategoryRequestCreateDtoValidator categoryRequestCreateDtoValidator,
            CategoryRequestUpdateDtoValidator categoryRequestUpdateDtoValidator
        )
        {
            _mapper = mapper;
            _categoryDomain = categoryDomain;
            _messageDomain = messageDomain;
            _categoryRequestCreateDtoValidator = categoryRequestCreateDtoValidator;
            _categoryRequestUpdateDtoValidator = categoryRequestUpdateDtoValidator;
        }

        public async Task<Response<int?>> Create(CategoryRequestCreateDto categoryDto)
        {
            Response<int?> response = new();
            ValidationResult validation = await _categoryRequestCreateDtoValidator.ValidateAsync(categoryDto);

            if (!validation.IsValid)
            {
                response.Message =
                    _mapper.Map<ResponseMessage>(await _messageDomain.GetByKey(nameof(EnumMessage.VALIDATION_ERROR)));
                response.InputDataErrors = validation.Errors;
                return response;
            }

            CategoryRequestCreateDomainDto categoryRequestDomainDto = _mapper.Map<CategoryRequestCreateDomainDto>(categoryDto);
            (response.Data, EnumMessage message) = await _categoryDomain.Create(categoryRequestDomainDto);

            response.Message = _mapper.Map<ResponseMessage>(await _messageDomain.GetByKey(message.ToString()));

            if (response.Data > 0) response.IsSuccess = true;

            return response;
        }

        public async Task<Response<bool>> Edit(int categoryId, CategoryRequestUpdateDto categoryDto)
        {
            Response<bool> response = new();
            ValidationResult validation = await _categoryRequestUpdateDtoValidator.ValidateAsync(categoryDto);

            if (!validation.IsValid)
            {
                response.Message =
                    _mapper.Map<ResponseMessage>(await _messageDomain.GetByKey(nameof(EnumMessage.VALIDATION_ERROR)));
                response.InputDataErrors = validation.Errors;
                return response;
            }

            CategoryRequestUpdateDomainDto categoryRequestDomainDto = _mapper.Map<CategoryRequestUpdateDomainDto>(categoryDto);
            categoryRequestDomainDto.CategoryId = categoryId;
            (response.Data, EnumMessage message) = await _categoryDomain.Edit(categoryRequestDomainDto);

            response.Message = _mapper.Map<ResponseMessage>(await _messageDomain.GetByKey(message.ToString()));

            if (response.Data) response.IsSuccess = true;

            return response;
        }
    }
}
using AutoMapper;
using Example.Ecommerce.Domain.DTO.Request;
using Example.Ecommerce.Domain.Entity;
using Example.Ecommerce.Domain.Interface;
using Example.Ecommerce.Domain.Validator.Category;
using Example.Ecommerce.Infrastructure.Interface.UnitOfWork;
using Example.Ecommerce.Transversal.Common.Enum;
using System.ComponentModel;

namespace Example.Ecommerce.Domain.Core
{
    public class CategoryDomain : ICategoryDomain
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryDomain(IUnitOfWork unitOfWork, IMapper mapper) => (_unitOfWork, _mapper) = (unitOfWork, mapper);

        public async Task<(bool, EnumMessage)> Create(CategoryRequestCreateDomainDto categoryRequestDomainDto)
        {
            try
            {
                // Validaciones de negocio con mensajeria manual
                (bool responseValidation, EnumMessage message) = CategoryValidator.CreateCategory(categoryRequestDomainDto);

                if (!responseValidation) return (responseValidation, message);

                // logica de negocio
                CategoryEntity categoryEntity = _mapper.Map<CategoryEntity>(categoryRequestDomainDto);
                await _unitOfWork.CategoryRepository.InsertAsync(categoryEntity);

                // retorno de proceso bool y cod mensajeria
                return (await _unitOfWork.SaveChangesAsync() > 0, EnumMessage.INSERT_SUCCESS);
            }
            catch (Exception) { return (false, EnumMessage.INSERT_ERROR); }
        }

        public async Task<(bool, EnumMessage)> Edit(CategoryRequestUpdateDomainDto categoryRequestDomainDto)
        {
            try
            {
                // Validaciones de negocio con mensajeria manual
                (bool responseValidation, EnumMessage message) = await CategoryValidator
                    .EditCategory(categoryRequestDomainDto, _unitOfWork);

                if (!responseValidation) return (responseValidation, message);

                // logica de negocio
                CategoryEntity? categoryEntity = _unitOfWork.CategoryRepository.GetById(categoryRequestDomainDto.CategoryId);
                _unitOfWork.CategoryRepository.SetUpdateFields(categoryRequestDomainDto, categoryEntity!);

                // retorno de proceso bool y cod mensajeria
                bool responseStatus = await _unitOfWork.SaveChangesAsync() > 0;
                return (responseStatus, responseStatus ? EnumMessage.UPDATE_SUCCESS : EnumMessage.UPDATE_ERROR);
            }
            catch (Exception) { return (false, EnumMessage.UPDATE_ERROR); }
        }

        public Task<(bool, EnumMessage)> Remove(int categoryId)
        {
            throw new NotImplementedException();
        }
    }
}
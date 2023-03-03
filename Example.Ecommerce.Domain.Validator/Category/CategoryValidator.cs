using Example.Ecommerce.Domain.DTO.Request;
using Example.Ecommerce.Domain.Entity;
using Example.Ecommerce.Infrastructure.Interface.UnitOfWork;
using Example.Ecommerce.Transversal.Common.Enum;

namespace Example.Ecommerce.Domain.Validator.Category
{
    public static class CategoryValidator
    {
        public static (bool, EnumMessage) CreateCategory(CategoryRequestCreateDomainDto categoryRequestDomainDto)
        {
            return (true, EnumMessage.VALIDATION_SUCCESS);
        }

        public async static Task<(bool, EnumMessage)> EditCategory(CategoryRequestUpdateDomainDto categoryRequestDomainDto, IUnitOfWork _unitOfWork)
        {
            CategoryEntity? categoryById = await _unitOfWork.CategoryRepository
                .GetOneAsync(filter: x => x.CategoryId == categoryRequestDomainDto.CategoryId, asTracking: false);

            if (categoryById is null)
                return (false, EnumMessage.VALIDATION_ERROR);

            return (true, EnumMessage.VALIDATION_SUCCESS);
        }

        public static (bool, EnumMessage) RemoveCategory(CategoryRequestCreateDomainDto categoryRequestDomainDto)
        {
            //return CommonValidator.ValidateCustomRegex(categoryRequestDomainDto.Name!, CommonRegex.FullName);
            return (true, EnumMessage.VALIDATION_SUCCESS);
        }
    }
}
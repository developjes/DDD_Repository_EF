using Example.Ecommerce.Domain.DTO.Request.Category;
using Example.Ecommerce.Domain.DTO.Response.Category;
using Example.Ecommerce.Transversal.Common.Enum;

namespace Example.Ecommerce.Domain.Interface
{
    public interface ICategoryDomain
    {
        Task<(int?, EnumMessage)> Create(CategoryRequestCreateDomainDto categoryRequestDomainDto);
        Task<(bool, EnumMessage)> Patch(CategoryRequestUpdateDomainDto categoryRequestDomainDto);
        Task<(bool, EnumMessage)> Remove(int categoryId);
        Task<(CategoryResponseDomainDto?, EnumMessage)> GetById(int categoryId);
    }
}
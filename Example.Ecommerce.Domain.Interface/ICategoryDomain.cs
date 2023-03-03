using Example.Ecommerce.Domain.DTO.Request;
using Example.Ecommerce.Transversal.Common.Enum;

namespace Example.Ecommerce.Domain.Interface
{
    public interface ICategoryDomain
    {
        Task<(bool, EnumMessage)> Create(CategoryRequestCreateDomainDto categoryRequestDomainDto);
        Task<(bool, EnumMessage)> Edit(CategoryRequestUpdateDomainDto categoryRequestDomainDto);
        Task<(bool, EnumMessage)> Remove(int categoryId);
    }
}
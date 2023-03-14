using Example.Ecommerce.Domain.DTO.Response.Message;
using Example.Ecommerce.Transversal.Common.Enum;

namespace Example.Ecommerce.Domain.Interface
{
    public interface IMessageDomain
    {
        Task<MessageResponseDomainDto> GetByKey(EnumMessage messageKey);
    }
}

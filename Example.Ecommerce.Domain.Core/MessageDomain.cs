using AutoMapper;
using Example.Ecommerce.Domain.DTO.Response.Message;
using Example.Ecommerce.Domain.Entity;
using Example.Ecommerce.Domain.Interface;
using Example.Ecommerce.Infrastructure.Interface.UnitOfWork;
using Example.Ecommerce.Transversal.Common.Enum;

namespace Example.Ecommerce.Domain.Core
{
    public class MessageDomain : IMessageDomain
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MessageDomain(IUnitOfWork unitOfWork, IMapper mapper) => (_unitOfWork, _mapper) = (unitOfWork, mapper);

        public async Task<MessageResponseDomainDto> GetByKey(EnumMessage messageKey)
        {
            MessageEntity? message = await _unitOfWork.MessageRepository
                .GetOneAsync(m => m.Key == messageKey.ToString(), asTracking: false);

            if (message is null)
                throw new InvalidOperationException($"{messageKey} not found.");

            return _mapper.Map<MessageResponseDomainDto>(message);
        }
    }
}
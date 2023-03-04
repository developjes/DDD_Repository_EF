using Example.Ecommerce.Domain.Entity;
using Example.Ecommerce.Infrastructure.Data.Context;
using Example.Ecommerce.Infrastructure.Interface.Repository;

namespace Example.Ecommerce.Infrastructure.Repository.Repository
{
    public class MessageRepository : GenericRepository<MessageEntity>, IMessageRepository
    {
        public MessageRepository(EfContext context) : base(context) { }
    }
}

using Example.Ecommerce.Domain.Entity;
using Example.Ecommerce.Infrastructure.Interface.Repository;
using Microsoft.EntityFrameworkCore.Storage;

namespace Example.Ecommerce.Infrastructure.Interface.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoryRepository CategoryRepository { get; }
        new void Dispose();
        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}

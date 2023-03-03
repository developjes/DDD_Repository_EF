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
        Task<IDbContextTransaction> BeginTransactionAsync();
        Task CommitAsync(IDbContextTransaction transaction);
        Task RollbackAsync(IDbContextTransaction transaction);
    }
}

using Example.Ecommerce.Infrastructure.Data.Context;
using Example.Ecommerce.Infrastructure.Interface.Repository;
using Example.Ecommerce.Infrastructure.Interface.UnitOfWork;
using Example.Ecommerce.Infrastructure.Repository.Repository;
using Microsoft.EntityFrameworkCore.Storage;

namespace Example.Ecommerce.Infrastructure.Repository.UnitOfWork
{
    public class UnitOfWork: IUnitOfWork
    {
        protected readonly EfContext _context;
        private bool _disposed;

        private readonly ICategoryRepository _categoryRepository = null!;
        private readonly IMessageRepository _messageRepository = null!;

        public UnitOfWork(EfContext context) => _context = context;

        #region Repositories

        public ICategoryRepository CategoryRepository { get { return _categoryRepository ?? new CategoryRepository(_context); } }
        public IMessageRepository MessageRepository { get { return _messageRepository ?? new MessageRepository(_context); } }

        #endregion

        protected async virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing) { await _context.DisposeAsync(); }
            _disposed = true;
        }

        public void Dispose() { Dispose(true); GC.SuppressFinalize(this); }

        public int SaveChanges() => _context.SaveChanges();

        public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();

        #region Transaction

        public async Task<IDbContextTransaction> BeginTransactionAsync() => await _context.Database.BeginTransactionAsync();
        public async Task CommitAsync(IDbContextTransaction transaction) => await transaction.CommitAsync();
        public async Task RollbackAsync(IDbContextTransaction transaction) => await transaction.RollbackAsync();

        #endregion
    }
}

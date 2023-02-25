using Example.Ecommerce.Infrastructure.Data.Context;
using Example.Ecommerce.Infrastructure.Interface.Repository;
using Example.Ecommerce.Infrastructure.Interface.UnitOfWork;
using Example.Ecommerce.Infrastructure.Repository.Repository;

namespace Example.Ecommerce.Infrastructure.Repository.UnitOfWork
{
    public class UnitOfWork: IUnitOfWork
    {
        protected readonly EfContext _context;
        private bool _disposed;
        private readonly ICategoryRepository _categoryRepository;

        public UnitOfWork(EfContext context) =>
            (_context, _categoryRepository) = (context, new CategoryRepository(context));

        #region Repositories

        public ICategoryRepository CategoryRepository { get { return _categoryRepository ?? new CategoryRepository(_context); } }

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

        #endregion
    }
}

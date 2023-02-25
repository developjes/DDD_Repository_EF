using Example.Ecommerce.Domain.Entity;
using Example.Ecommerce.Infrastructure.Data.Context;
using Example.Ecommerce.Infrastructure.Interface.Repository;
using Microsoft.EntityFrameworkCore;

namespace Example.Ecommerce.Infrastructure.Repository.Repository
{
    public sealed class CategoryRepository : GenericRepository<CategoryEntity>, ICategoryRepository
    {
        public CategoryRepository(EfContext context) : base(context) { }

        public async Task<IEnumerable<CategoryEntity>> GetCategories()
        {
            DbSet<CategoryEntity> categoryEntity = _dbSet;
            DbSet<CategoryEntity> category2 = _dbcontext.Set<CategoryEntity>();

            return await (
                from cat in categoryEntity
                select new CategoryEntity { CategoryId = cat.CategoryId }
            ).ToListAsync();
        }
    }
}

using Example.Ecommerce.Domain.Entity;

namespace Example.Ecommerce.Domain.Interface
{
    public interface ICategoryDomain
    {
        IEnumerable<CategoryEntity> Get();
        Task<IEnumerable<CategoryEntity>> GetAsync();
        CategoryEntity? GetById(int categoryId);
        Task<CategoryEntity?> GetByIdAsync(int categoryId);
        bool Insert(CategoryEntity tEntity);
        bool Insert(IEnumerable<CategoryEntity> tEntities);
        Task<bool> InsertAsync(CategoryEntity tEntity);
        Task<bool> InsertAsync(IEnumerable<CategoryEntity> tEntities);
        bool Update(CategoryEntity tEntity);
        bool Update(IEnumerable<CategoryEntity> tEntitites);
        bool Delete(int categoryId);
        bool Delete(IEnumerable<CategoryEntity> tEntities);
    }
}
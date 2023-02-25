using Example.Ecommerce.Domain.Entity;
using Example.Ecommerce.Domain.Interface;
using Example.Ecommerce.Infrastructure.Interface.UnitOfWork;

namespace Example.Ecommerce.Domain.Core
{
    public class CategoryDomain : ICategoryDomain
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryDomain(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public CategoryEntity? GetById(int categoryId) => _unitOfWork.CategoryRepository.GetById(categoryId);

        public async Task<CategoryEntity?> GetByIdAsync(int categoryId) => await _unitOfWork.CategoryRepository.GetByIdAsync(categoryId);

        public bool Insert(CategoryEntity tEntity)
        {
            _unitOfWork.CategoryRepository.Insert(tEntity);
            return _unitOfWork.SaveChanges() > 0;
        }

        public bool Insert(IEnumerable<CategoryEntity> tEntities)
        {
            _unitOfWork.CategoryRepository.Insert(tEntities);
            return _unitOfWork.SaveChanges() > 0;
        }

        public async Task InsertAsync(CategoryEntity tEntity) => await _unitOfWork.CategoryRepository.InsertAsync(tEntity);

        public bool Delete(int categoryId)
        {
            CategoryEntity? category = _unitOfWork.CategoryRepository.GetById(categoryId);

            if (category is null)
                throw new ArgumentNullException(nameof(categoryId));

            _unitOfWork.CategoryRepository.Delete(categoryId);
            return _unitOfWork.SaveChanges() > 0;
        }

        public IEnumerable<CategoryEntity> Get() => _unitOfWork.CategoryRepository.Get();

        public async Task<IEnumerable<CategoryEntity>> GetAsync() =>  await _unitOfWork.CategoryRepository.GetAsync();

        Task<bool> ICategoryDomain.InsertAsync(CategoryEntity tEntity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertAsync(IEnumerable<CategoryEntity> tEntities)
        {
            throw new NotImplementedException();
        }

        public bool Update(CategoryEntity tEntity)
        {
            throw new NotImplementedException();
        }

        public bool Update(IEnumerable<CategoryEntity> tEntitites)
        {
            throw new NotImplementedException();
        }

        public bool Delete(IEnumerable<CategoryEntity> tEntities)
        {
            throw new NotImplementedException();
        }
    }
}

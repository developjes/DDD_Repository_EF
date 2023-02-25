using System.Linq.Expressions;

namespace Example.Ecommerce.Infrastructure.Interface.Repository
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        #region Queries action

        #region Sync methods

        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>>? filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            string includeProperties = "", bool asTracking = true);
        Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>>? filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            string includeProperties = "", bool asTracking = true);
        TEntity? GetById(object tEntityId);
        Task<TEntity?> GetByIdAsync(object tEntityId);
        TEntity? GetOne(Expression<Func<TEntity, bool>> filter, string includeProperties = "", bool asTracking = true);
        Task<TEntity?> GetOneAsync(Expression<Func<TEntity, bool>>? filter = null, string includeProperties = "", bool asTracking = true);
        void Insert(TEntity tEntity);
        void Insert(IEnumerable<TEntity> tEntities);
        Task InsertAsync(TEntity tEntity);
        Task InsertAsync(IEnumerable<TEntity> tEntities);
        void Update(TEntity tEntity);
        void Update(IEnumerable<TEntity> tEntitites);
        public void Delete(object id);
        void Delete(IEnumerable<TEntity> tEntities);

        #endregion

        #endregion
    }
}
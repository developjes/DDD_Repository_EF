using Example.Ecommerce.Infrastructure.Data.Context;
using Example.Ecommerce.Infrastructure.Interface.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Linq.Expressions;
using System.Reflection;
using System.Security.Principal;

namespace Example.Ecommerce.Infrastructure.Repository.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext _dbcontext;
        protected readonly DbSet<TEntity> _dbSet;

        public GenericRepository(DbContext dbcontext) =>
            (_dbcontext, _dbSet) = (dbcontext, dbcontext.Set<TEntity>());

        private IQueryable<TEntity> CreateAsQueryable() => _dbSet.AsQueryable<TEntity>();

        private static IQueryable<TEntity> CreateQuery(
            IQueryable<TEntity> query,
            Expression<Func<TEntity, bool>>? filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            string includeProperties = "", bool asTracking = true
        )
        {
            if (filter is not null) query = query.Where(filter);

            foreach (string includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                query = query.Include(includeProperty);

            if (orderBy is not null)
                query = orderBy(query);

            return asTracking ? query.AsTracking() : query.AsNoTracking();
        }

        public virtual IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>>? filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            string includeProperties = "", bool asTracking = true) =>
                CreateQuery(CreateAsQueryable(), filter, orderBy, includeProperties, asTracking).ToList();

        public virtual async Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>>? filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            string includeProperties = "", bool asTracking = true) =>
                await CreateQuery(CreateAsQueryable(), filter, orderBy, includeProperties, asTracking).ToListAsync();

        public virtual TEntity? GetById(object tEntityId) => _dbSet.Find(tEntityId);

        public virtual async Task<TEntity?> GetByIdAsync(object tEntityId) => await _dbSet.FindAsync(tEntityId);

        public virtual TEntity? GetOne(Expression<Func<TEntity, bool>> filter, string includeProperties = "", bool asTracking = true) =>
            CreateQuery(CreateAsQueryable(), filter, includeProperties: includeProperties, asTracking: asTracking).FirstOrDefault();

        public virtual async Task<TEntity?> GetOneAsync(Expression<Func<TEntity, bool>>? filter = null, string includeProperties = "", bool asTracking = true) =>
            await CreateQuery(CreateAsQueryable(), filter, includeProperties: includeProperties, asTracking: asTracking).FirstOrDefaultAsync();

        public virtual void Insert(TEntity tEntity) => _dbcontext.Add(tEntity);

        public virtual void Insert(IEnumerable<TEntity> tEntities) => _dbcontext.AddRange(tEntities);

        public virtual async Task InsertAsync(TEntity tEntity) => await _dbcontext.AddAsync(tEntity);

        public virtual async Task InsertAsync(IEnumerable<TEntity> tEntities) => await _dbcontext.AddRangeAsync(tEntities);

        public virtual void Patch(object patchEntity, TEntity dbEntity)
        {
            if (patchEntity is null)
                throw new ArgumentNullException(nameof(patchEntity), $"{nameof(patchEntity)} cannot be null.");

            if (dbEntity is null)
                throw new ArgumentNullException(nameof(dbEntity), $"{nameof(dbEntity)} cannot be null.");

            foreach (PropertyInfo? dbProperty in
                dbEntity!.GetType().GetProperties().Where(p => !p.GetGetMethod()!.GetParameters().Any()))
            {
                PropertyInfo? propertyNameNewTentity =
                    Array.Find(patchEntity.GetType().GetProperties(), pp => pp.Name == dbProperty.Name);

                if (propertyNameNewTentity is not null && (propertyNameNewTentity.GetType().Name == dbProperty.GetType().Name))
                    dbProperty.SetValue(dbEntity, propertyNameNewTentity.GetValue(patchEntity, null));
            }
        }

        public virtual void Update(TEntity tEntity) => _dbcontext.Update(tEntity);

        public virtual void Update(IEnumerable<TEntity> tEntitites) => _dbcontext.UpdateRange(tEntitites);

        public virtual void Delete(object id) { TEntity? tEntity = _dbSet.Find(id); Delete(tEntity); }

        private void Delete(TEntity? tEntity)
        {
            if (tEntity is null)
                throw new DbUpdateConcurrencyException();

            if (_dbcontext.Entry(tEntity).State == EntityState.Detached)
                _dbSet.Attach(tEntity);

            _dbSet.Remove(tEntity);
        }

        public void Delete(IEnumerable<TEntity> tEntities)
        {
            if (tEntities.Any(x => x is null))
                throw new DbUpdateConcurrencyException();

            foreach (TEntity tEntity in tEntities)
            {
                if (_dbcontext.Entry(tEntity).State == EntityState.Detached)
                    _dbSet.Attach(tEntity);

                _dbSet.Remove(tEntity);
            }
        }
    }
}
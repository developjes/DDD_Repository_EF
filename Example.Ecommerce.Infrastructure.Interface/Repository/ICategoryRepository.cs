﻿using Example.Ecommerce.Domain.Entity;

namespace Example.Ecommerce.Infrastructure.Interface.Repository
{
    public interface ICategoryRepository : IGenericRepository<CategoryEntity>
    {
        Task<IEnumerable<CategoryEntity>> GetCategories();
    }
}

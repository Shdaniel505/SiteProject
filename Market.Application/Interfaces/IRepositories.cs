using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Market.Application.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> Query();

        Task<TEntity?> GetByIdAsync(long id, CancellationToken ct = default);
        Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken ct = default);

        Task AddAsync(TEntity entity, CancellationToken ct = default);
        void Remove(TEntity entity);
    }
}

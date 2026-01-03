using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Market.Application.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity?> GetByIdAsync(long id, CancellationToken ct = default);
        Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken ct = default);

        IQueryable<TEntity> Query();

        Task AddAsync(TEntity entity, CancellationToken ct = default);
        void Update(TEntity entity);
        void Remove(TEntity entity);
    }
}

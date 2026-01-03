using Market.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Market.Infrastructure.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DataBaseContext _db;
        protected readonly DbSet<TEntity> _set;

        public Repository(DataBaseContext db)
        {
            _db = db;
            _set = db.Set<TEntity>();
        }

        public IQueryable<TEntity> Query() => _set.AsQueryable();

        public async Task<TEntity?> GetByIdAsync(long id, CancellationToken ct = default)
            => await _set.FindAsync([id], ct);

        public async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken ct = default)
            => await _set.AnyAsync(predicate, ct);

        public async Task AddAsync(TEntity entity, CancellationToken ct = default)
            => await _set.AddAsync(entity, ct);

        public void Update(TEntity entity) => _set.Update(entity);

        public void Remove(TEntity entity) => _set.Remove(entity);
    }
}

using Market.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Market.Infrastructure.UnitOfWork
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private readonly DataBaseContext _db;

        public UnitOfWork(
            DataBaseContext db,
            ICategoryRepository categories,
            IProductRepository products)
        {
            _db = db;
            Categories = categories;
            Products = products;
        }

        public ICategoryRepository Categories { get; }
        public IProductRepository Products { get; }

        public Task<int> SaveChangesAsync(CancellationToken ct = default)
            => _db.SaveChangesAsync(ct);
    }
}

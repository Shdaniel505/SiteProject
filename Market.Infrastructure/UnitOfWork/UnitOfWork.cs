using Market.Application.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;
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
            IProductRepository products,
            IProductImageRepository productImages)
        {
            _db = db;
            Categories = categories;
            Products = products;
            ProductImages = productImages;
        }

        public ICategoryRepository Categories { get; }
        public IProductRepository Products { get; }
        public IProductImageRepository ProductImages { get; }

        public Task<int> SaveChangesAsync(CancellationToken ct = default) => _db.SaveChangesAsync(ct);

        public async Task ExecuteInTransactionAsync(Func<CancellationToken, Task> action, CancellationToken ct = default)
        {
            await using IDbContextTransaction tx = await _db.Database.BeginTransactionAsync(ct);
            try
            {
                await action(ct);
                await _db.SaveChangesAsync(ct);
                await tx.CommitAsync(ct);
            }
            catch
            {
                await tx.RollbackAsync(ct);
                throw;
            }
        }
    }
}

using Market.Application.Interfaces;
using Market.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Market.Infrastructure.Repositories
{
    public sealed class ProductRepository
        : Repository<Product>, IProductRepository
    {
        public ProductRepository(DataBaseContext db) : base(db) { }

        public async Task<bool> CategoryExistsAsync(long categoryId, CancellationToken ct = default)
        {
            return await _db.Categories.AnyAsync(x => x.Id == categoryId, ct);
        }
    }
}

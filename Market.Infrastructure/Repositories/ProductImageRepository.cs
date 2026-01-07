using Market.Application.Interfaces;
using Market.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Market.Infrastructure.Repositories
{
    public sealed class ProductImageRepository : Repository<ProductImage>, IProductImageRepository
    {
        public ProductImageRepository(DataBaseContext db) : base(db) { }

        public async Task<bool> ProductExistsAsync(long productId, CancellationToken ct = default)
            => await _db.Products.AnyAsync(x => x.Id == productId, ct);

        public async Task<ProductImage?> GetByIdForProductAsync(long imageId, long productId, CancellationToken ct = default)
            => await _db.ProductImages.FirstOrDefaultAsync(x => x.Id == imageId && x.ProductId == productId, ct);

        public async Task UnsetAllMainAsync(long productId, CancellationToken token)
        {
            var mains = await _db.ProductImages
                .Where(x => x.ProductId == productId && x.IsMain)
                .ToListAsync(token);

            if (mains.Count == 0) return;

            foreach (var img in mains)
                img.SetMain(false);

        }
    }
}

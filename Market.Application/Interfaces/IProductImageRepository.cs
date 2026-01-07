using Market.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Market.Application.Interfaces
{
    public interface IProductImageRepository : IRepository<ProductImage>
    {
        Task<bool> ProductExistsAsync(long productId, CancellationToken ct = default);
        Task<ProductImage?> GetByIdForProductAsync(long imageId, long productId, CancellationToken ct = default);
        Task UnsetAllMainAsync(long productId, CancellationToken token);
    }
}

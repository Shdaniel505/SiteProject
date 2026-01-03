using Market.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Market.Application.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<bool> CategoryExistsAsync(long categoryId, CancellationToken ct = default);
    }
}

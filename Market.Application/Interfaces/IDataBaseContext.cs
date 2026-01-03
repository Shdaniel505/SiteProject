using Market.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Market.Application.Interfaces
{
    public interface IDataBaseContext
    {
        DbSet<Category> Categories { get; }
        DbSet<Product> Products { get; }
        DbSet<ProductImage> ProductImages { get; }

        Task<int> SaveChangesAsync(CancellationToken ct = default);
    }
}

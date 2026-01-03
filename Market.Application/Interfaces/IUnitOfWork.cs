using System;
using System.Collections.Generic;
using System.Text;

namespace Market.Application.Interfaces
{
    public interface IUnitOfWork
    {
        ICategoryRepository Categories { get; }
        IProductRepository Products { get; }

        Task<int> SaveChangesAsync(CancellationToken ct = default);
    }
}

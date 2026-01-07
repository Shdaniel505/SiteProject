using Market.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Market.Application.Interfaces
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<bool> ExistsByTitleAsync(string v, CancellationToken ct);
        Task<bool> TitleExistsAsync(string title, long? parentId, CancellationToken ct);
    }
}

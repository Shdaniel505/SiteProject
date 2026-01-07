using Market.Application.Interfaces;
using Market.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Market.Infrastructure.Repositories
{
    public sealed class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(DataBaseContext db) : base(db) { }

        public async Task<bool> ExistsByTitleAsync(string v, CancellationToken ct)
        {
            v = (v ?? "").Trim();
            return await _db.Categories.AnyAsync(x => x.Title == v, ct);
        }

        public async Task<bool> TitleExistsAsync(string title, long? parentId, CancellationToken ct)
        {
            title = (title ?? "").Trim();
            return await _db.Categories.AnyAsync(x => x.Title == title && x.ParentId == parentId, ct);
        }
    }
}

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

        public async Task<bool> TitleExistsUnderParentAsync(string title, long? parentId, CancellationToken ct = default)
        {
            title = title.Trim();

            return await _db.Categories.AnyAsync(x =>
                x.ParentId == parentId &&
                x.Title == title, ct);
        }
    }
}

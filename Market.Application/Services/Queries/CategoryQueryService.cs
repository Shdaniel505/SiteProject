using Market.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Market.Application.Services.Queries
{
    public sealed class CategoryQueryService
    {
        private readonly IDataBaseContext _db;

        public CategoryQueryService(IDataBaseContext db)
        {
            _db = db;
        }

        public async Task<List<CategoryListItemDto>> GetAllAsync()
        {
            return await _db.Categories
                .AsNoTracking()
                .OrderBy(x => x.Title)
                .Select(x => new CategoryListItemDto
                {
                    Id = x.Id,
                    Title = x.Title,
                    ParentId = x.ParentId,
                    IsActive = x.IsActive
                })
                .ToListAsync();
        }
    }
}

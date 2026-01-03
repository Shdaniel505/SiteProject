using Market.Application.Interfaces;
using Market.Application.Services.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Market.Application.Services.Queries
{
    public sealed class GetCategoriesQueryService
    {
        private readonly IDataBaseContext _db;

        public GetCategoriesQueryService(IDataBaseContext db)
        {
            _db = db;
        }

        public async Task<List<CategoryDto>> ExecuteAsync()
        {
            return await _db.Categories
                .AsNoTracking()
                .OrderBy(x => x.Id)
                .Select(x => new CategoryDto
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

using Market.Application.Interfaces;
using Market.Application.Services.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Market.Application.Services.Queries
{
    public sealed class GetProductsQueryService
    {
        private readonly IDataBaseContext _db;
        public GetProductsQueryService(IDataBaseContext db) => _db = db;

        public async Task<PagedResult<ProductDto>> ExecuteAsync(
            PagedRequest request,
            string? search = null,
            long? categoryId = null,
            CancellationToken ct = default)
        {
            request.Normalize();

            var q = _db.Products
                .AsNoTracking()
                .Include(x => x.Category)
                .Include(x => x.Images)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                search = search.Trim();
                q = q.Where(x => x.Title.Contains(search));
            }

            if (categoryId.HasValue)
                q = q.Where(x => x.CategoryId == categoryId.Value);

            var total = await q.CountAsync(ct);

            var items = await q
                .OrderByDescending(x => x.Id)
                .Skip((request.Page - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new ProductDto
                {
                    Id = x.Id,
                    Title = x.Title,
                    Price = x.Price,
                    IsActive = x.IsActive,
                    CategoryId = x.CategoryId,
                    CategoryTitle = x.Category.Title,
                    Images = x.Images
                        .OrderBy(i => i.SortOrder)
                        .Select(i => new ProductImageDto
                        {
                            Id = i.Id,
                            Url = i.Url,
                            Alt = i.Alt,
                            SortOrder = i.SortOrder,
                            IsMain = i.IsMain
                        }).ToList()
                })
                .ToListAsync(ct);

            return new PagedResult<ProductDto>
            {
                Items = items,
                Page = request.Page,
                PageSize = request.PageSize,
                TotalCount = total
            };
        }
    }
}

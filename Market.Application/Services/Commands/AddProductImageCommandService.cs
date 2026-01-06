using Market.Application.Common;
using Market.Application.Interfaces;
using Market.Application.Services.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Market.Application.Services.Commands
{
    public sealed class AddProductImageCommandService
    {
        private readonly IUnitOfWork _uow;
        public AddProductImageCommandService(IUnitOfWork uow) => _uow = uow;

        public async Task<Result> ExecuteAsync(AddProductImageDto dto, CancellationToken ct = default)
        {
            if (dto.ProductId <= 0) return Result.Fail("Invalid productId");
            if (string.IsNullOrWhiteSpace(dto.Url)) return Result.Fail("Url is required");
            if (dto.SortOrder < 0) return Result.Fail("SortOrder cannot be negative");

            var url = dto.Url.Trim();
            var alt = dto.Alt?.Trim();

            var productExists = await _uow.ProductImages.ProductExistsAsync(dto.ProductId, ct);
            if (!productExists)
                return Result.Fail("Product not found");

            await _uow.ExecuteInTransactionAsync(async token =>
            {
                if (dto.IsMain)
                {
                    // همه‌ی عکس‌های اصلی قبلی رو false کن
                    var mains = await _uow.ProductImages.Query()
                        .Where(x => x.ProductId == dto.ProductId && x.IsMain)
                        .ToListAsync(token);

                    foreach (var m in mains)
                        m.SetIsMain(false);
                }

                var image = new ProductImage(dto.ProductId, url, alt, dto.SortOrder, dto.IsMain);
                await _uow.ProductImages.AddAsync(image, token);

                await _uow.SaveChangesAsync(token);
            }, ct);

            return Result.Ok();
        }
    }
}

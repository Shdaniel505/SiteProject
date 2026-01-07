using Market.Application.Common;
using Market.Application.Interfaces;
using Market.Application.Services.DTO;
using Market.Domain.Entities;
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
            if (dto.ProductId <= 0)
                return Result.Failure("VALIDATION_ERROR", "Invalid productId");

            if (string.IsNullOrWhiteSpace(dto.Url))
                return Result.Failure("VALIDATION_ERROR", "Url is required");

            if (dto.SortOrder < 0)
                return Result.Failure("VALIDATION_ERROR", "SortOrder cannot be negative");

            var product = await _uow.Products.GetByIdAsync(dto.ProductId, ct);
            if (product is null)
                return Result.Failure("NOT_FOUND", "Product not found");

            await _uow.ExecuteInTransactionAsync(async token =>
            {
                if (dto.IsMain)
                    await _uow.ProductImages.UnsetAllMainAsync(dto.ProductId, token);

                var image = new ProductImage(
                    productId: dto.ProductId,
                    url: dto.Url.Trim(),
                    sortOrder: dto.SortOrder,
                    isMain: dto.IsMain);

                await _uow.ProductImages.AddAsync(image, token);
            }, ct);

            return Result.Success();
        }
    }
}
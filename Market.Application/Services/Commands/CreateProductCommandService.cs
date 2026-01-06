using Market.Application.Common;
using Market.Application.Interfaces;
using Market.Application.Services.DTO.Create;
using Market.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Market.Application.Services.Commands
{
    public sealed class CreateProductCommandService
    {
        private readonly IUnitOfWork _uow;
        public CreateProductCommandService(IUnitOfWork uow) => _uow = uow;

        public async Task<Result> ExecuteAsync(CreateProductDto dto, CancellationToken ct = default)
        {
            if (string.IsNullOrWhiteSpace(dto.Title))
                return Result.Fail("Title is required");

            if (dto.Price < 0)
                return Result.Fail("Price cannot be negative");

            var title = dto.Title.Trim();

            var catExists = await _uow.Products.CategoryExistsAsync(dto.CategoryId, ct);
            if (!catExists)
                return Result.Fail("Category not found");

            var product = new Product(title, dto.Price, dto.CategoryId, dto.IsActive);

            await _uow.Products.AddAsync(product, ct);
            await _uow.SaveChangesAsync(ct);

            return Result.Ok();
        }
    }
}

using Market.Application.Common;
using Market.Application.Interfaces;
using Market.Application.Services.DTO;
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
                return Result.Failure("VALIDATION_ERROR", "Title is required");

            if (dto.Price < 0)
                return Result.Failure("VALIDATION_ERROR", "Price cannot be negative");

            var catExists = await _uow.Products.CategoryExistsAsync(dto.CategoryId, ct);
            if (!catExists)
                return Result.Failure("NOT_FOUND", "Category not found");

            var product = new Product(
                title: dto.Title.Trim(),
                price: dto.Price,
                categoryId: dto.CategoryId,
                description: dto.Description,
                stock: dto.Stock);

            if (!dto.IsActive)
                product.Deactivate();

            await _uow.Products.AddAsync(product, ct);
            await _uow.SaveChangesAsync(ct);

            return Result.Success();
        }
    }
}
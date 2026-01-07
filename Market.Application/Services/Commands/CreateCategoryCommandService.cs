using Market.Application.Common;
using Market.Application.Interfaces;
using Market.Application.Services.DTO;
using Market.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Market.Application.Services.Commands
{
    public sealed class CreateCategoryCommandService
    {
        private readonly IUnitOfWork _uow;
        public CreateCategoryCommandService(IUnitOfWork uow) => _uow = uow;

        public async Task<Result> ExecuteAsync(CreateCategoryDto dto, CancellationToken ct = default)
        {
            if (string.IsNullOrWhiteSpace(dto.Title))
                return Result.Failure("VALIDATION_ERROR", "Title is required");

            if (dto.ParentId is not null && dto.ParentId > 0)
            {
                var parent = await _uow.Categories.GetByIdAsync(dto.ParentId.Value, ct);
                if (parent is null)
                    return Result.Failure("NOT_FOUND", "Parent category not found");
            }

            var exists = await _uow.Categories.TitleExistsAsync(dto.Title.Trim(), dto.ParentId, ct);
            if (exists)
                return Result.Failure("DUPLICATE", "Duplicate category title");

            var category = new Category(dto.Title.Trim(), dto.ParentId);
            await _uow.Categories.AddAsync(category, ct);
            await _uow.SaveChangesAsync(ct);

            return Result.Success();
        }
    }
}
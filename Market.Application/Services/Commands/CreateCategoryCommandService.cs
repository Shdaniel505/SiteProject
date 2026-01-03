using Market.Application.Common;
using Market.Application.Interfaces;
using Market.Application.Services.DTO.Create;
using Market.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Market.Application.Services.Commands
{
    public sealed class CreateCategoryCommandService
    {
        private readonly IUnitOfWork _uow;

        public CreateCategoryCommandService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<Result> ExecuteAsync(CreateCategoryDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Title))
                return Result.Fail("Title is required");

            if (dto.ParentId.HasValue)
            {
                var parentExists = await _uow.Categories
                    .ExistsAsync(x => x.Id == dto.ParentId.Value);
                if (!parentExists)
                    return Result.Fail("Parent category not found");
            }

            var duplicate = await _uow.Categories
                .TitleExistsAsync(dto.Title.Trim(), dto.ParentId);
            if (duplicate)
                return Result.Fail("Duplicate category title");

            await _uow.Categories.AddAsync(
                new Category(dto.Title.Trim(), dto.ParentId));

            await _uow.SaveChangesAsync();
            return Result.Ok();
        }
    }
}

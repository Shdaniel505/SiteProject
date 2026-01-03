using Market.Application.Common;
using Market.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Market.Application.Services.Commands
{
    public sealed class CategoryCommandService
    {
        private readonly IUnitOfWork _uow;

        public CategoryCommandService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<Result> CreateAsync(CreateCategoryDto dto)
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
                .TitleExistsUnderParentAsync(dto.Title, dto.ParentId);

            if (duplicate)
                return Result.Fail("Duplicate title");

            var category = new Market.Domain.Entities.Category(
                dto.Title.Trim(),
                dto.ParentId
            );

            await _uow.Categories.AddAsync(category);
            await _uow.SaveChangesAsync();

            return Result.Ok();
        }
    }
}

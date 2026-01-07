using System;
using System.Collections.Generic;
using System.Text;

namespace Market.Application.Services.DTO
{
    public sealed class CreateCategoryDto
    {
        public string Title { get; set; } = null!;
        public long? ParentId { get; set; }
    }
}

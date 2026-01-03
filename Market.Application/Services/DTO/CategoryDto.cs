using System;
using System.Collections.Generic;
using System.Text;

namespace Market.Application.Services.DTO
{
    public sealed class CategoryDto
    {
        public long Id { get; set; }
        public string Title { get; set; } = null!;
        public long? ParentId { get; set; }
        public bool IsActive { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Market.Application.Services.DTO
{
    public sealed class CreateProductDto
    {
        public string Title { get; set; } = null!;
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public int Stock { get; set; }
        public long CategoryId { get; set; }
        public bool IsActive { get; set; } = true;
    }
}

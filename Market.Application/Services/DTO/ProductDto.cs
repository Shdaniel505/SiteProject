using System;
using System.Collections.Generic;
using System.Text;

namespace Market.Application.Services.DTO
{
    public sealed class ProductDto
    {
        public long Id { get; set; }
        public string Title { get; set; } = null!;
        public decimal Price { get; set; }
        public bool IsActive { get; set; }
        public long CategoryId { get; set; }
        public string CategoryTitle { get; set; } = null!;

        public List<ProductImageDto> Images { get; set; } = new();
    }
}

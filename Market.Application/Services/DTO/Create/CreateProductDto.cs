using System;
using System.Collections.Generic;
using System.Text;

namespace Market.Application.Services.DTO.Create
{
    public sealed class CreateProductDto
    {
        public string Title { get; set; } = null!;
        public decimal Price { get; set; }
        public long CategoryId { get; set; }
        public bool IsActive { get; set; } = true;
    }
}

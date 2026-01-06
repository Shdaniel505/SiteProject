using System;
using System.Collections.Generic;
using System.Text;

namespace Market.Application.Services.DTO
{
    public sealed class ProductImageDto
    {
        public long Id { get; set; }
        public string Url { get; set; } = null!;
        public string? Alt { get; set; }
        public int SortOrder { get; set; }
        public bool IsMain { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Market.Application.Services.DTO
{
    public sealed class AddProductImageDto
    {
        public long ProductId { get; set; }
        public string Url { get; set; } = null!;
        public int SortOrder { get; set; } = 0;
        public bool IsMain { get; set; } = false;
    }
}

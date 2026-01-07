using System;
using System.Collections.Generic;
using System.Text;

namespace Market.Common
{
    public sealed class PagedRequest
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 20;

        public void Normalize(int maxPageSize = 200)
        {
            if (Page < 1) Page = 1;
            if (PageSize < 1) PageSize = 1;
            if (PageSize > maxPageSize) PageSize = maxPageSize;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Market.Domain.Common;

namespace Market.Domain.Entities
{
    public class ProductImage : EntityBase
    {
        public long ProductId { get; private set; }
        public Product Product { get; private set; } = null!;
        public string Url { get; private set; } = null!;
        public string? Alt { get; private set; }
        public int SortOrder { get; private set; }
        public bool IsMain { get; private set; }

        private ProductImage() { }

        public ProductImage(long productId, string url, string? alt = null, int sortOrder = 0, bool isMain = false)
        {
            ProductId = productId;
            SetUrl(url);
            SetAlt(alt);
            SortOrder = sortOrder;
            IsMain = isMain;
        }

        public void SetUrl(string url)
        {
            url = (url ?? "").Trim();
            if (url.Length < 5) throw new ArgumentException("Image Url is invalid.");
            Url = url;
            Touch();
        }

        public void SetAlt(string? alt)
        {
            Alt = string.IsNullOrWhiteSpace(alt) ? null : alt.Trim();
            Touch();
        }

        public void SetMain(bool isMain)
        {
            IsMain = isMain;
            Touch();
        }

        public void SetSortOrder(int sortOrder)
        {
            SortOrder = sortOrder;
            Touch();
        }
    }
}

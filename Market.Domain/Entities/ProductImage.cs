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
        public int SortOrder { get; private set; }
        public bool IsMain { get; private set; }

        private ProductImage() { }

        public ProductImage(long productId, string url, int sortOrder = 0, bool isMain = false)
        {
            ProductId = productId;
            SetUrl(url);
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

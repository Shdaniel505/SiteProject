using System;
using System.Collections.Generic;
using System.Text;
using Market.Domain.Common;

namespace Market.Domain.Entities
{
    public class Product : EntityBase
    {
        public string Title { get; private set; } = null!;
        public decimal Price { get; private set; }
        public bool IsActive { get; private set; } = true;
        public long CategoryId { get; private set; }
        public Category Category { get; private set; } = null!;

        public ICollection<ProductImage> Images { get; private set; } = new List<ProductImage>();

        private Product() { }

        public Product(string title, decimal price, long categoryId)
        {
            SetTitle(title);
            SetPrice(price);
            CategoryId = categoryId;
        }

        public void SetTitle(string title)
        {
            title = (title ?? "").Trim();
            if (title.Length < 2) throw new ArgumentException("Product title is invalid.");
            Title = title;
            Touch();
        }

        public void SetPrice(decimal price)
        {
            if (price < 0) throw new ArgumentException("Price cannot be negative.");
            Price = price;
            Touch();
        }

        public void Activate()
        {
            IsActive = true;
            Touch();
        }

        public void Deactivate()
        {
            IsActive = false;
            Touch();
        }

        public void ChangeCategory(long categoryId)
        {
            CategoryId = categoryId;
            Touch();
        }
    }
}

using Market.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Market.Domain.Entities
{
    public class Category : EntityBase
    {
        public string Title { get; private set; } = null!;
        public bool IsActive { get; private set; } = true;
        public long? ParentId { get; private set; }
        public Category? Parent { get; private set; }
        public ICollection<Category> Children { get; private set; } = new List<Category>();

        public ICollection<Product> Products { get; private set; } = new List<Product>();

        private Category() { }

        public Category(string title, long? parentId = null)
        {
            SetTitle(title);
            ParentId = parentId;
        }

        public void SetTitle(string title)
        {
            title = (title ?? "").Trim();
            if (title.Length < 2) throw new ArgumentException("Category title is invalid.");
            Title = title;
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

        public void SetParent(long? parentId)
        {
            ParentId = parentId;
            Touch();
        }




    }
}

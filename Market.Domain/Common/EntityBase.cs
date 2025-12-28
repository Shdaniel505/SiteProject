using System;
using System.Collections.Generic;
using System.Text;

namespace Market.Domain.Common
{
    public class EntityBase
    {
        public long Id { get; protected set; }

        public DateTime CreatedAtUtc { get; protected set; } = DateTime.UtcNow;
        public DateTime UpdatedAtUtc { get; protected set; } = DateTime.UtcNow;

        protected void Touch() => UpdatedAtUtc = DateTime.UtcNow;
    }
}

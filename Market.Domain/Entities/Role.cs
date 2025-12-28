using Market.Domain.Common;

namespace Market.Domain.Entities
{
    public class Role : EntityBase
    {
        public string Name { get; private set; } = null!;
        public ICollection<UserInRole> UserInRoles { get; private set; } = new List<UserInRole>();
        private Role() { } 

        public Role(string name)
        {
            SetName(name);
        }

        public void SetName(string name)
        {
            name = (name ?? "").Trim();
            if (name.Length < 2) throw new ArgumentException("Role name is invalid.");
            Name = name;
            Touch();
        }

    }
}

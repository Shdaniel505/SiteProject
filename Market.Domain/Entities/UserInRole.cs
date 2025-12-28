namespace Market.Domain.Entities
{
    public class UserInRole
    {
        public long UserId { get; private set; }
        public User User { get; private set; } = null!;

        public long RoleId { get; private set; }
        public Role Role { get; private set; } = null!;

        private UserInRole() { } 

        public UserInRole(long userId, long roleId)
        {
            UserId = userId;
            RoleId = roleId;
        }


    }
}

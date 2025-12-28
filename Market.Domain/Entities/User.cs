using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Market.Domain.Common;

namespace Market.Domain.Entities
{
    public class User : EntityBase
    {
        public string FullName { get; private set; } = null!;
        public string Email { get; private set; } = null!;
        public string PasswordHash { get; private set; } = null!;
        public bool IsActive { get; private set; } = true;

        public ICollection<UserInRole> UserInRoles { get; private set; } = new List<UserInRole>();

        private User() { }

        public User(string fullName, string email, string passwordHash)
        {
            SetFullName(fullName);
            SetEmail(email);
            SetPasswordHash(passwordHash);
        }

        public void SetFullName(string fullName)
        {
            fullName = (fullName ?? "").Trim();
            if (fullName.Length < 2) throw new ArgumentException("FullName is invalid.");
            FullName = fullName;
            Touch();
        }

        public void SetEmail(string email)
        {
            email = (email ?? "").Trim().ToLowerInvariant();
            if (email.Length < 5 || !email.Contains('@')) throw new ArgumentException("Email is invalid.");
            Email = email;
            Touch();
        }

        public void SetPasswordHash(string passwordHash)
        {
            passwordHash = (passwordHash ?? "").Trim();
            if (passwordHash.Length < 10) throw new ArgumentException("PasswordHash is invalid.");
            PasswordHash = passwordHash;
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

    }
}

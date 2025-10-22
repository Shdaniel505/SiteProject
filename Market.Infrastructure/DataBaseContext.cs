using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Market.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Market.Infrastructure
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet <UserInRole> UserInRoles { get; set; }

    }
}

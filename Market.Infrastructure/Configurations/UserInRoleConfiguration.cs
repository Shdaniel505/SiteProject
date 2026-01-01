using Market.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Market.Infrastructure.Configurations
{
    public class UserInRoleConfiguration : IEntityTypeConfiguration<UserInRole>
    {
        public void Configure(EntityTypeBuilder<UserInRole> builder)
        {
            builder.ToTable("UserInRoles");

            builder.HasKey(x => new { x.UserId, x.RoleId });

            builder.HasOne(x => x.User)
                .WithMany(x => x.UserInRoles)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Role)
                .WithMany(x => x.UserInRoles)
                .HasForeignKey(x => x.RoleId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(x => x.RoleId);

        }
    }
}

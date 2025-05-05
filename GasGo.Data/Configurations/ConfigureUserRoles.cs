using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GasGo.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GasGo.Data.Configurations
{
    public class ConfigureUserRoles : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id)
                   .ValueGeneratedOnAdd()
                   .IsRequired();

            builder.HasOne(b => b.User)
                .WithMany(b => b.UserRoles)
                .HasForeignKey(b => b.UserId);

            builder.HasOne(b => b.Role)
                .WithMany(b => b.UserRoles)
                .HasForeignKey(b => b.RoleId);
        }
    }
}

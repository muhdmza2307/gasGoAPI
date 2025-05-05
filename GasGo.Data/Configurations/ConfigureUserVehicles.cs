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
    public class ConfigureUserVehicles : IEntityTypeConfiguration<UserVehicle>
    {
        public void Configure(EntityTypeBuilder<UserVehicle> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id)
                   .ValueGeneratedOnAdd()
                   .IsRequired();

            builder.HasOne(b => b.UserRole)
                .WithMany(b => b.UserVehicles)
                .HasForeignKey(b => b.UserRoleId);
        }
    }
}

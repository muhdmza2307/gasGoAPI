using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GasGo.Common.Enums;
using GasGo.Common.Extensions;
using GasGo.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GasGo.Data.Configurations
{
    public class ConfigureRoles : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id)
                   .ValueGeneratedOnAdd()
                   .IsRequired();

            var entries = Enum.GetValues(typeof(RoleEnum))
                .Cast<RoleEnum>()
                .Select(r => new Role
                {
                    Id = r,
                    Description = r.GetEnumDescription()
                })
                .ToArray();
            builder.HasData(entries);
        }
    }
}

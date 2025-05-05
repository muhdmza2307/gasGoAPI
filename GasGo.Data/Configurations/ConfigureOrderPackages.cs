using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GasGo.Common.Enums;
using GasGo.Data.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using GasGo.Common.Extensions;

namespace GasGo.Data.Configurations
{
    public class ConfigureOrderPackages : IEntityTypeConfiguration<OrderPackage>
    {
        public void Configure(EntityTypeBuilder<OrderPackage> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id)
                   .ValueGeneratedOnAdd()
                   .IsRequired();

            var entries = Enum.GetValues(typeof(FuelOrderPackage))
                .Cast<FuelOrderPackage>()
                .Select(p => new OrderPackage
                {
                    Id = p,
                    Description = p.GetEnumDescription()
                })
                .ToArray();
            builder.HasData(entries);
        }
    }
}
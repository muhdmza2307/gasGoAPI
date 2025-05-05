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
    public class ConfigureFuelTypes : IEntityTypeConfiguration<FuelType>
    {
        public void Configure(EntityTypeBuilder<FuelType> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id)
                   .ValueGeneratedOnAdd()
                   .IsRequired();

            var entries = Enum.GetValues(typeof(FuelTypeEnum))
                .Cast<FuelTypeEnum>()
                .Select(f => new FuelType
                {
                    Id = f,
                    Description = f.GetEnumDescription()
                })
                .ToArray();
            builder.HasData(entries);
        }
    }
}

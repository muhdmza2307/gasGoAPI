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
    public class ConfigureDeliveryStatuses : IEntityTypeConfiguration<DeliveryStatus>
    {
        public void Configure(EntityTypeBuilder<DeliveryStatus> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id)
                   .ValueGeneratedOnAdd()
                   .IsRequired();

            var entries = Enum.GetValues(typeof(FuelDeliveryStatus))
                .Cast<FuelDeliveryStatus>()
                .Select(s => new DeliveryStatus
                {
                    Id = s,
                    Description = s.GetEnumDescription()
                })
                .ToArray();
            builder.HasData(entries);
        }
    }
}

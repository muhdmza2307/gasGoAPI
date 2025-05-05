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
    public class ConfigureOrderStatuses : IEntityTypeConfiguration<OrderStatus>
    {
        public void Configure(EntityTypeBuilder<OrderStatus> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id)
                   .ValueGeneratedOnAdd()
                   .IsRequired();

            var entries = Enum.GetValues(typeof(FuelOrderStatus))
                .Cast<FuelOrderStatus>()
                .Select(s => new OrderStatus
                {
                    Id = s,
                    Description = s.GetEnumDescription()
                })
                .ToArray();
            builder.HasData(entries);
        }
    }
}

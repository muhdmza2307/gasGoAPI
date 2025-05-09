using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using GasGo.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GasGo.Data.Configurations
{
    public class ConfigureDeliveries : IEntityTypeConfiguration<Delivery>
    {
        public void Configure(EntityTypeBuilder<Delivery> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id)
                   .ValueGeneratedOnAdd()
                   .IsRequired();

            builder.HasOne(o => o.DriverVehicle)
                .WithMany(o => o.DriverDeliveries)
                .HasForeignKey(o => o.DriverVehicleId);

            builder.Property(d => d.ScheduledTime)
                .HasDefaultValueSql("NOW()");

            builder.HasOne(b => b.Status)
                .WithMany(b => b.Deliveries);
        }
    }
}

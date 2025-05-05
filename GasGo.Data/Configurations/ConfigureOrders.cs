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
    public class ConfigureOrders : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id)
                   .ValueGeneratedOnAdd()
                   .IsRequired();

            builder.HasOne(o => o.CustomerVehicle)
                .WithMany(o => o.CustomerOrders)
                .HasForeignKey(o => o.CustomerVehicleId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(o => o.DriverVehicle)
                .WithMany(o => o.DriverAssignments)
                .HasForeignKey(o => o.DriverVehicleId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(b => b.Package)
                .WithMany(b => b.Orders);

            builder.HasOne(b => b.Status)
                .WithMany(b => b.Orders);
        }
    }
}

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
                .HasForeignKey(o => o.CustomerVehicleId);

            builder.HasOne(o => o.Delivery)
                .WithOne(d => d.Order)
                .HasForeignKey<Delivery>(d => d.OrderId);

            builder.HasOne(o => o.Package)
                .WithMany(o => o.Orders);

            builder.HasOne(o => o.Status)
                .WithMany(o => o.Orders);

            builder.HasOne(o => o.OrderAddress)
                .WithOne(a => a.Order);
        }
    }
}

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
    public class ConfigureOrderAddresses : IEntityTypeConfiguration<OrderAddress>
    {
        public void Configure(EntityTypeBuilder<OrderAddress> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id)
                   .ValueGeneratedOnAdd()
                   .IsRequired();
        }
    }
}

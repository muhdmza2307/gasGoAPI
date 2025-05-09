using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GasGo.Common.Options;
using GasGo.Data.Entities;
using GasGo.Data.Extensions;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace GasGo.Data
{
    public class DataContext : DbContext, IDataContext
    {
        private SqlServerOption? _sqlServerOption;

        public DataContext(SqlServerOption? sqlServerOption = null)
        {
            _sqlServerOption = sqlServerOption;
        }

        public DbSet<User> Users { get; set; } = null!;
        public DbSet<UserRole> UserRoles { get; set; } = null!;
        public DbSet<Role> Roles { get; set; } = null!;
        public DbSet<UserVehicle> UserVehicles { get; set; } = null!;
        public DbSet<FuelType> FuelTypes { get; set; } = null!;
        public DbSet<OrderPackage> OrderPackages { get; set; } = null!;
        public DbSet<OrderStatus> OrderStatuses { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<DeliveryStatus> DeliveryStatuses { get; set; } = null!;
        public DbSet<Delivery> Deliveries { get; set; } = null!;
        public DbSet<OrderAddress> OrderAddresses { get; set; } = null!;


        private bool IsUnitOfWorkActive { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) =>
            IsUnitOfWorkActive
                ? Task.FromResult(0)
                : base.SaveChangesAsync(cancellationToken );

        public void ActivateUnitOfWork() => IsUnitOfWorkActive = true;

        public void DeactivateUnitOfWork() => IsUnitOfWorkActive = false;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            _sqlServerOption ??= new SqlServerOption
            {
                ServerName = "localhost",
                DatabaseName = "gasgo-api",
                UseIntegratedSecurity = false,
            };

            var npgsqlBuilder = new NpgsqlConnectionStringBuilder
            {
                Host = _sqlServerOption.ServerName,
                Database = _sqlServerOption.DatabaseName,
                Username = _sqlServerOption.Username,
                Password = _sqlServerOption.Password,
                TrustServerCertificate = true // optional, for SSL
            };

            optionsBuilder.UseNpgsql(npgsqlBuilder.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyAllConfigurations();
        }
    }
}

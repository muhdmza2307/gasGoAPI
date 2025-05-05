using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GasGo.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddOrderConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrderPackages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderPackages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CustomerVehicleId = table.Column<Guid>(type: "uuid", nullable: false),
                    DriverVehicleId = table.Column<Guid>(type: "uuid", nullable: false),
                    Package = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    OrderPackageId = table.Column<int>(type: "integer", nullable: true),
                    OrderStatusId = table.Column<int>(type: "integer", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DateLastModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_OrderPackages_OrderPackageId",
                        column: x => x.OrderPackageId,
                        principalTable: "OrderPackages",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Orders_OrderStatuses_OrderStatusId",
                        column: x => x.OrderStatusId,
                        principalTable: "OrderStatuses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Orders_UserVehicles_CustomerVehicleId",
                        column: x => x.CustomerVehicleId,
                        principalTable: "UserVehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_UserVehicles_DriverVehicleId",
                        column: x => x.DriverVehicleId,
                        principalTable: "UserVehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "OrderPackages",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { 20, "Small Package - 20 Liters" },
                    { 40, "Medium Package - 40 Liters" },
                    { 60, "Large Package - 60 Liters" }
                });

            migrationBuilder.InsertData(
                table: "OrderStatuses",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { 1, "Order has been created" },
                    { 2, "Order has been confirmed by the system or user" },
                    { 3, "Order is currently in progress" },
                    { 4, "Order has been successfully delivered" },
                    { 5, "Order has been cancelled" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerVehicleId",
                table: "Orders",
                column: "CustomerVehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DriverVehicleId",
                table: "Orders",
                column: "DriverVehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderPackageId",
                table: "Orders",
                column: "OrderPackageId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderStatusId",
                table: "Orders",
                column: "OrderStatusId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "OrderPackages");

            migrationBuilder.DropTable(
                name: "OrderStatuses");
        }
    }
}

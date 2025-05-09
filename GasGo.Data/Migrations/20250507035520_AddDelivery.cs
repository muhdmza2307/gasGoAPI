using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GasGo.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddDelivery : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_UserVehicles_CustomerVehicleId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_UserVehicles_DriverVehicleId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_DriverVehicleId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DriverVehicleId",
                table: "Orders");

            migrationBuilder.CreateTable(
                name: "DeliveryStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Deliveries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DriverVehicleId = table.Column<Guid>(type: "uuid", nullable: false),
                    OrderId = table.Column<Guid>(type: "uuid", nullable: false),
                    StatusId = table.Column<int>(type: "integer", nullable: false),
                    ScheduledTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DateLastModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deliveries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Deliveries_DeliveryStatuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "DeliveryStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Deliveries_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Deliveries_UserVehicles_DriverVehicleId",
                        column: x => x.DriverVehicleId,
                        principalTable: "UserVehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "DeliveryStatuses",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { 1, "Scheduled for Pickup" },
                    { 2, "En Route to Customer" },
                    { 3, "Successfully Delivered" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Deliveries_DriverVehicleId",
                table: "Deliveries",
                column: "DriverVehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_Deliveries_OrderId",
                table: "Deliveries",
                column: "OrderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Deliveries_StatusId",
                table: "Deliveries",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_UserVehicles_CustomerVehicleId",
                table: "Orders",
                column: "CustomerVehicleId",
                principalTable: "UserVehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_UserVehicles_CustomerVehicleId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "Deliveries");

            migrationBuilder.DropTable(
                name: "DeliveryStatuses");

            migrationBuilder.AddColumn<Guid>(
                name: "DriverVehicleId",
                table: "Orders",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DriverVehicleId",
                table: "Orders",
                column: "DriverVehicleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_UserVehicles_CustomerVehicleId",
                table: "Orders",
                column: "CustomerVehicleId",
                principalTable: "UserVehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_UserVehicles_DriverVehicleId",
                table: "Orders",
                column: "DriverVehicleId",
                principalTable: "UserVehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

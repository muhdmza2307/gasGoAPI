using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GasGo.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddOrderAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "OrderAddressId",
                table: "Orders",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "OrderAddresses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Latitude = table.Column<decimal>(type: "numeric", nullable: false),
                    Longitude = table.Column<decimal>(type: "numeric", nullable: false),
                    Street = table.Column<string>(type: "text", nullable: false),
                    State = table.Column<string>(type: "text", nullable: false),
                    PostalCode = table.Column<string>(type: "text", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DateLastModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderAddresses", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderAddressId",
                table: "Orders",
                column: "OrderAddressId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_OrderAddresses_OrderAddressId",
                table: "Orders",
                column: "OrderAddressId",
                principalTable: "OrderAddresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OrderAddresses_OrderAddressId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "OrderAddresses");

            migrationBuilder.DropIndex(
                name: "IX_Orders_OrderAddressId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderAddressId",
                table: "Orders");
        }
    }
}

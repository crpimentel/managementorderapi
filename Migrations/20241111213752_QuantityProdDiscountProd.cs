using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace managementorderapi.Migrations
{
    /// <inheritdoc />
    public partial class QuantityProdDiscountProd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "DiscountProd",
                table: "OrderProducts",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "QuantityProd",
                table: "OrderProducts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiscountProd",
                table: "OrderProducts");

            migrationBuilder.DropColumn(
                name: "QuantityProd",
                table: "OrderProducts");
        }
    }
}

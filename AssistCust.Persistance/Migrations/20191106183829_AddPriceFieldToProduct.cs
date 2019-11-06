using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AssistCust.Persistance.Migrations
{
    public partial class AddPriceFieldToProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "PurchaseTime",
                table: "Purchases",
                nullable: false,
                defaultValue: new DateTime(2019, 11, 6, 18, 38, 28, 779, DateTimeKind.Utc).AddTicks(6018),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2019, 11, 6, 14, 45, 33, 74, DateTimeKind.Utc).AddTicks(2320));

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Products",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegistrationDate",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: new DateTime(2019, 11, 6, 18, 38, 28, 788, DateTimeKind.Utc).AddTicks(4428),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2019, 11, 6, 14, 45, 33, 80, DateTimeKind.Utc).AddTicks(3812));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Products");

            migrationBuilder.AlterColumn<DateTime>(
                name: "PurchaseTime",
                table: "Purchases",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2019, 11, 6, 14, 45, 33, 74, DateTimeKind.Utc).AddTicks(2320),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 11, 6, 18, 38, 28, 779, DateTimeKind.Utc).AddTicks(6018));

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegistrationDate",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2019, 11, 6, 14, 45, 33, 80, DateTimeKind.Utc).AddTicks(3812),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 11, 6, 18, 38, 28, 788, DateTimeKind.Utc).AddTicks(4428));
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AssistCust.Persistance.Migrations
{
    public partial class AddFinistTimetoPurchase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "PurchaseTime",
                table: "Purchases",
                nullable: false,
                defaultValue: new DateTime(2019, 11, 6, 14, 45, 33, 74, DateTimeKind.Utc).AddTicks(2320),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2019, 10, 20, 12, 28, 38, 596, DateTimeKind.Utc).AddTicks(9397));

            migrationBuilder.AddColumn<DateTime>(
                name: "FinishTime",
                table: "Purchases",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegistrationDate",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: new DateTime(2019, 11, 6, 14, 45, 33, 80, DateTimeKind.Utc).AddTicks(3812),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2019, 10, 20, 12, 28, 38, 604, DateTimeKind.Utc).AddTicks(7686));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FinishTime",
                table: "Purchases");

            migrationBuilder.AlterColumn<DateTime>(
                name: "PurchaseTime",
                table: "Purchases",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2019, 10, 20, 12, 28, 38, 596, DateTimeKind.Utc).AddTicks(9397),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 11, 6, 14, 45, 33, 74, DateTimeKind.Utc).AddTicks(2320));

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegistrationDate",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2019, 10, 20, 12, 28, 38, 604, DateTimeKind.Utc).AddTicks(7686),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 11, 6, 14, 45, 33, 80, DateTimeKind.Utc).AddTicks(3812));
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AssistCust.Persistance.Migrations
{
    public partial class minsizetonamesofentitiesto4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "PurchaseTime",
                table: "Purchases",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 13, 11, 39, 38, 294, DateTimeKind.Utc).AddTicks(1861),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 6, 13, 11, 37, 56, 3, DateTimeKind.Utc).AddTicks(2921));

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegistrationTime",
                table: "IoTDevices",
                nullable: true,
                defaultValue: new DateTime(2021, 6, 13, 11, 39, 38, 287, DateTimeKind.Utc).AddTicks(1246),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2021, 6, 13, 11, 37, 55, 996, DateTimeKind.Utc).AddTicks(6908));

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegistrationDate",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 13, 11, 39, 38, 298, DateTimeKind.Utc).AddTicks(337),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 6, 13, 11, 37, 56, 6, DateTimeKind.Utc).AddTicks(5265));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "PurchaseTime",
                table: "Purchases",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 13, 11, 37, 56, 3, DateTimeKind.Utc).AddTicks(2921),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 6, 13, 11, 39, 38, 294, DateTimeKind.Utc).AddTicks(1861));

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegistrationTime",
                table: "IoTDevices",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2021, 6, 13, 11, 37, 55, 996, DateTimeKind.Utc).AddTicks(6908),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2021, 6, 13, 11, 39, 38, 287, DateTimeKind.Utc).AddTicks(1246));

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegistrationDate",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 13, 11, 37, 56, 6, DateTimeKind.Utc).AddTicks(5265),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 6, 13, 11, 39, 38, 298, DateTimeKind.Utc).AddTicks(337));
        }
    }
}

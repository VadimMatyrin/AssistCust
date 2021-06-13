using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AssistCust.Persistance.Migrations
{
    public partial class minsizetonamesofentitiesusingDA : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "PurchaseTime",
                table: "Purchases",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 13, 11, 42, 24, 999, DateTimeKind.Utc).AddTicks(8489),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 6, 13, 11, 39, 38, 294, DateTimeKind.Utc).AddTicks(1861));

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegistrationTime",
                table: "IoTDevices",
                nullable: true,
                defaultValue: new DateTime(2021, 6, 13, 11, 42, 24, 993, DateTimeKind.Utc).AddTicks(9197),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2021, 6, 13, 11, 39, 38, 287, DateTimeKind.Utc).AddTicks(1246));

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegistrationDate",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 13, 11, 42, 25, 2, DateTimeKind.Utc).AddTicks(8486),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 6, 13, 11, 39, 38, 298, DateTimeKind.Utc).AddTicks(337));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "PurchaseTime",
                table: "Purchases",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 13, 11, 39, 38, 294, DateTimeKind.Utc).AddTicks(1861),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 6, 13, 11, 42, 24, 999, DateTimeKind.Utc).AddTicks(8489));

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegistrationTime",
                table: "IoTDevices",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2021, 6, 13, 11, 39, 38, 287, DateTimeKind.Utc).AddTicks(1246),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2021, 6, 13, 11, 42, 24, 993, DateTimeKind.Utc).AddTicks(9197));

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegistrationDate",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 13, 11, 39, 38, 298, DateTimeKind.Utc).AddTicks(337),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 6, 13, 11, 42, 25, 2, DateTimeKind.Utc).AddTicks(8486));
        }
    }
}

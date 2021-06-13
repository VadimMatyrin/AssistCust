using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AssistCust.Persistance.Migrations
{
    public partial class companyshopidiot : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "PurchaseTime",
                table: "Purchases",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 3, 12, 32, 30, 903, DateTimeKind.Utc).AddTicks(7808),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2019, 12, 22, 12, 13, 10, 531, DateTimeKind.Utc).AddTicks(4863));

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegistrationTime",
                table: "IoTDevices",
                nullable: true,
                defaultValue: new DateTime(2021, 5, 3, 12, 32, 30, 897, DateTimeKind.Utc).AddTicks(9266),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2019, 12, 22, 12, 13, 10, 523, DateTimeKind.Utc).AddTicks(8923));

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegistrationDate",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 3, 12, 32, 30, 908, DateTimeKind.Utc).AddTicks(2931),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2019, 12, 22, 12, 13, 10, 534, DateTimeKind.Utc).AddTicks(4898));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "PurchaseTime",
                table: "Purchases",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2019, 12, 22, 12, 13, 10, 531, DateTimeKind.Utc).AddTicks(4863),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 5, 3, 12, 32, 30, 903, DateTimeKind.Utc).AddTicks(7808));

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegistrationTime",
                table: "IoTDevices",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2019, 12, 22, 12, 13, 10, 523, DateTimeKind.Utc).AddTicks(8923),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2021, 5, 3, 12, 32, 30, 897, DateTimeKind.Utc).AddTicks(9266));

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegistrationDate",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2019, 12, 22, 12, 13, 10, 534, DateTimeKind.Utc).AddTicks(4898),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 5, 3, 12, 32, 30, 908, DateTimeKind.Utc).AddTicks(2931));
        }
    }
}

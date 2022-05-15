using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AssistCust.Persistance.Migrations
{
    public partial class addshopfieldtoIoTdevice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "PurchaseTime",
                table: "Purchases",
                nullable: false,
                defaultValue: new DateTime(2019, 12, 22, 12, 13, 10, 531, DateTimeKind.Utc).AddTicks(4863),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2019, 12, 22, 11, 51, 45, 845, DateTimeKind.Utc).AddTicks(9038));

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegistrationTime",
                table: "IoTDevices",
                nullable: true,
                defaultValue: new DateTime(2019, 12, 22, 12, 13, 10, 523, DateTimeKind.Utc).AddTicks(8923),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2019, 12, 22, 11, 51, 45, 838, DateTimeKind.Utc).AddTicks(823));

            migrationBuilder.AddColumn<int>(
                name: "CompanyShopId",
                table: "IoTDevices",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegistrationDate",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: new DateTime(2019, 12, 22, 12, 13, 10, 534, DateTimeKind.Utc).AddTicks(4898),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2019, 12, 22, 11, 51, 45, 849, DateTimeKind.Utc).AddTicks(4494));

            migrationBuilder.CreateIndex(
                name: "IX_IoTDevices_CompanyShopId",
                table: "IoTDevices",
                column: "CompanyShopId");

            migrationBuilder.AddForeignKey(
                name: "FK_IoTDevices_CompanyShops_CompanyShopId",
                table: "IoTDevices",
                column: "CompanyShopId",
                principalTable: "CompanyShops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IoTDevices_CompanyShops_CompanyShopId",
                table: "IoTDevices");

            migrationBuilder.DropIndex(
                name: "IX_IoTDevices_CompanyShopId",
                table: "IoTDevices");

            migrationBuilder.DropColumn(
                name: "CompanyShopId",
                table: "IoTDevices");

            migrationBuilder.AlterColumn<DateTime>(
                name: "PurchaseTime",
                table: "Purchases",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2019, 12, 22, 11, 51, 45, 845, DateTimeKind.Utc).AddTicks(9038),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 12, 22, 12, 13, 10, 531, DateTimeKind.Utc).AddTicks(4863));

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegistrationTime",
                table: "IoTDevices",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2019, 12, 22, 11, 51, 45, 838, DateTimeKind.Utc).AddTicks(823),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2019, 12, 22, 12, 13, 10, 523, DateTimeKind.Utc).AddTicks(8923));

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegistrationDate",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2019, 12, 22, 11, 51, 45, 849, DateTimeKind.Utc).AddTicks(4494),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 12, 22, 12, 13, 10, 534, DateTimeKind.Utc).AddTicks(4898));
        }
    }
}

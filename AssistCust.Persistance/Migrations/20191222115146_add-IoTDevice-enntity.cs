using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AssistCust.Persistance.Migrations
{
    public partial class addIoTDeviceenntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "PurchaseTime",
                table: "Purchases",
                nullable: false,
                defaultValue: new DateTime(2019, 12, 22, 11, 51, 45, 845, DateTimeKind.Utc).AddTicks(9038),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2019, 11, 6, 18, 38, 28, 779, DateTimeKind.Utc).AddTicks(6018));

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegistrationDate",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: new DateTime(2019, 12, 22, 11, 51, 45, 849, DateTimeKind.Utc).AddTicks(4494),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2019, 11, 6, 18, 38, 28, 788, DateTimeKind.Utc).AddTicks(4428));

            migrationBuilder.CreateTable(
                name: "IoTDevices",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    RegistrationTime = table.Column<DateTime>(nullable: true, defaultValue: new DateTime(2019, 12, 22, 11, 51, 45, 838, DateTimeKind.Utc).AddTicks(823))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IoTDevices", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IoTDevices");

            migrationBuilder.AlterColumn<DateTime>(
                name: "PurchaseTime",
                table: "Purchases",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2019, 11, 6, 18, 38, 28, 779, DateTimeKind.Utc).AddTicks(6018),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 12, 22, 11, 51, 45, 845, DateTimeKind.Utc).AddTicks(9038));

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegistrationDate",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2019, 11, 6, 18, 38, 28, 788, DateTimeKind.Utc).AddTicks(4428),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 12, 22, 11, 51, 45, 849, DateTimeKind.Utc).AddTicks(4494));
        }
    }
}

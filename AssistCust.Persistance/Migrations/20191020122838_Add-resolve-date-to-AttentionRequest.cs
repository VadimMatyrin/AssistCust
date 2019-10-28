using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AssistCust.Persistance.Migrations
{
    public partial class AddresolvedatetoAttentionRequest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "PurchaseTime",
                table: "Purchases",
                nullable: false,
                defaultValue: new DateTime(2019, 10, 20, 12, 28, 38, 596, DateTimeKind.Utc).AddTicks(9397),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2019, 10, 20, 12, 14, 26, 713, DateTimeKind.Utc).AddTicks(6624));

            migrationBuilder.AddColumn<DateTime>(
                name: "ResolveDate",
                table: "AttentionRequests",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegistrationDate",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: new DateTime(2019, 10, 20, 12, 28, 38, 604, DateTimeKind.Utc).AddTicks(7686),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2019, 10, 20, 12, 14, 26, 720, DateTimeKind.Utc).AddTicks(3382));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ResolveDate",
                table: "AttentionRequests");

            migrationBuilder.AlterColumn<DateTime>(
                name: "PurchaseTime",
                table: "Purchases",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2019, 10, 20, 12, 14, 26, 713, DateTimeKind.Utc).AddTicks(6624),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 10, 20, 12, 28, 38, 596, DateTimeKind.Utc).AddTicks(9397));

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegistrationDate",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2019, 10, 20, 12, 14, 26, 720, DateTimeKind.Utc).AddTicks(3382),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 10, 20, 12, 28, 38, 604, DateTimeKind.Utc).AddTicks(7686));
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AssistCust.Persistance.Migrations
{
    public partial class addcreationdatefieldtoattentionrequest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "PurchaseTime",
                table: "Purchases",
                nullable: false,
                defaultValue: new DateTime(2019, 10, 20, 12, 14, 26, 713, DateTimeKind.Utc).AddTicks(6624),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2019, 10, 20, 11, 31, 46, 760, DateTimeKind.Utc).AddTicks(7681));

            migrationBuilder.AddColumn<int>(
                name: "CompanyShopId",
                table: "AttentionRequests",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "AttentionRequests",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegistrationDate",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: new DateTime(2019, 10, 20, 12, 14, 26, 720, DateTimeKind.Utc).AddTicks(3382),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2019, 10, 20, 11, 31, 46, 767, DateTimeKind.Utc).AddTicks(9294));

            migrationBuilder.CreateIndex(
                name: "IX_AttentionRequests_CompanyShopId",
                table: "AttentionRequests",
                column: "CompanyShopId");

            migrationBuilder.AddForeignKey(
                name: "FK_AttentionRequests_CompanyShops_CompanyShopId",
                table: "AttentionRequests",
                column: "CompanyShopId",
                principalTable: "CompanyShops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AttentionRequests_CompanyShops_CompanyShopId",
                table: "AttentionRequests");

            migrationBuilder.DropIndex(
                name: "IX_AttentionRequests_CompanyShopId",
                table: "AttentionRequests");

            migrationBuilder.DropColumn(
                name: "CompanyShopId",
                table: "AttentionRequests");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "AttentionRequests");

            migrationBuilder.AlterColumn<DateTime>(
                name: "PurchaseTime",
                table: "Purchases",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2019, 10, 20, 11, 31, 46, 760, DateTimeKind.Utc).AddTicks(7681),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 10, 20, 12, 14, 26, 713, DateTimeKind.Utc).AddTicks(6624));

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegistrationDate",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2019, 10, 20, 11, 31, 46, 767, DateTimeKind.Utc).AddTicks(9294),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 10, 20, 12, 14, 26, 720, DateTimeKind.Utc).AddTicks(3382));
        }
    }
}

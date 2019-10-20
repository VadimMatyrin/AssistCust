using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AssistCust.Persistance.Migrations
{
    public partial class AddAttentionRequestentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "PurchaseTime",
                table: "Purchases",
                nullable: false,
                defaultValue: new DateTime(2019, 10, 20, 11, 31, 46, 760, DateTimeKind.Utc).AddTicks(7681),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2019, 10, 14, 7, 53, 21, 449, DateTimeKind.Utc).AddTicks(40));

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegistrationDate",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: new DateTime(2019, 10, 20, 11, 31, 46, 767, DateTimeKind.Utc).AddTicks(9294),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2019, 10, 14, 7, 53, 21, 461, DateTimeKind.Utc).AddTicks(4826));

            migrationBuilder.CreateTable(
                name: "AttentionRequests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message = table.Column<string>(nullable: true),
                    IsResolved = table.Column<bool>(nullable: false),
                    SenderId = table.Column<string>(nullable: true),
                    ManagerId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttentionRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AttentionRequests_AspNetUsers_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AttentionRequests_AspNetUsers_SenderId",
                        column: x => x.SenderId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AttentionRequests_ManagerId",
                table: "AttentionRequests",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_AttentionRequests_SenderId",
                table: "AttentionRequests",
                column: "SenderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AttentionRequests");

            migrationBuilder.AlterColumn<DateTime>(
                name: "PurchaseTime",
                table: "Purchases",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2019, 10, 14, 7, 53, 21, 449, DateTimeKind.Utc).AddTicks(40),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 10, 20, 11, 31, 46, 760, DateTimeKind.Utc).AddTicks(7681));

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegistrationDate",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2019, 10, 14, 7, 53, 21, 461, DateTimeKind.Utc).AddTicks(4826),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 10, 20, 11, 31, 46, 767, DateTimeKind.Utc).AddTicks(9294));
        }
    }
}

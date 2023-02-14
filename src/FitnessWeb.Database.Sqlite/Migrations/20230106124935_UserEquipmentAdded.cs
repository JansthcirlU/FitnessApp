using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessWeb.Database.Sqlite.Migrations
{
    public partial class UserEquipmentAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "OwnerId",
                table: "Equipment",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_OwnerId",
                table: "Equipment",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipment_User_OwnerId",
                table: "Equipment",
                column: "OwnerId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipment_User_OwnerId",
                table: "Equipment");

            migrationBuilder.DropIndex(
                name: "IX_Equipment_OwnerId",
                table: "Equipment");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Equipment");
        }
    }
}

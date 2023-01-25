using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessWeb.Database.Sqlite.Migrations
{
    public partial class UserEquipmentManyToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "EquipmentUser",
                columns: table => new
                {
                    EquipmentId = table.Column<Guid>(type: "TEXT", nullable: false),
                    OwnersId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentUser", x => new { x.EquipmentId, x.OwnersId });
                    table.ForeignKey(
                        name: "FK_EquipmentUser_Equipment_EquipmentId",
                        column: x => x.EquipmentId,
                        principalTable: "Equipment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EquipmentUser_User_OwnersId",
                        column: x => x.OwnersId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentUser_OwnersId",
                table: "EquipmentUser",
                column: "OwnersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EquipmentUser");

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
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessWeb.Database.Sqlite.Migrations
{
    /// <inheritdoc />
    public partial class PlanToStepLink : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "StepPlanId",
                table: "WorkoutPlanStep",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            // migrationBuilder.AddColumn<double>(
            //     name: "WeightDisc_DiameterMm",
            //     table: "Equipment",
            //     type: "REAL",
            //     nullable: true);

            // migrationBuilder.AddColumn<double>(
            //     name: "WeightDisc_MassKg",
            //     table: "Equipment",
            //     type: "REAL",
            //     nullable: true);

            migrationBuilder.CreateTable(
                name: "WorkoutPlan",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkoutPlan", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutPlanStep_StepPlanId",
                table: "WorkoutPlanStep",
                column: "StepPlanId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkoutPlanStep_WorkoutPlan_StepPlanId",
                table: "WorkoutPlanStep",
                column: "StepPlanId",
                principalTable: "WorkoutPlan",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkoutPlanStep_WorkoutPlan_StepPlanId",
                table: "WorkoutPlanStep");

            migrationBuilder.DropTable(
                name: "WorkoutPlan");

            migrationBuilder.DropIndex(
                name: "IX_WorkoutPlanStep_StepPlanId",
                table: "WorkoutPlanStep");

            migrationBuilder.DropColumn(
                name: "StepPlanId",
                table: "WorkoutPlanStep");

            // migrationBuilder.DropColumn(
            //     name: "WeightDisc_DiameterMm",
            //     table: "Equipment");

            // migrationBuilder.DropColumn(
            //     name: "WeightDisc_MassKg",
            //     table: "Equipment");
        }
    }
}

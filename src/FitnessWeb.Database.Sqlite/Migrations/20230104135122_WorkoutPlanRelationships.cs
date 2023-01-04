using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessWeb.Database.Sqlite.Migrations
{
    /// <inheritdoc />
    public partial class WorkoutPlanRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "ExerciseRoutine",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ExerciseId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Sets = table.Column<int>(type: "INTEGER", nullable: false),
                    Repetitions = table.Column<int>(type: "INTEGER", nullable: false),
                    RestTime = table.Column<TimeSpan>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseRoutine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExerciseRoutine_Exercise_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercise",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkoutPlanStep",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Step = table.Column<int>(type: "INTEGER", nullable: false),
                    StepRoutineId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkoutPlanStep", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkoutPlanStep_ExerciseRoutine_StepRoutineId",
                        column: x => x.StepRoutineId,
                        principalTable: "ExerciseRoutine",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseRoutine_ExerciseId",
                table: "ExerciseRoutine",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutPlanStep_StepRoutineId",
                table: "WorkoutPlanStep",
                column: "StepRoutineId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkoutPlanStep");

            migrationBuilder.DropTable(
                name: "ExerciseRoutine");

            // migrationBuilder.DropColumn(
            //     name: "WeightDisc_DiameterMm",
            //     table: "Equipment");

            // migrationBuilder.DropColumn(
            //     name: "WeightDisc_MassKg",
            //     table: "Equipment");
        }
    }
}

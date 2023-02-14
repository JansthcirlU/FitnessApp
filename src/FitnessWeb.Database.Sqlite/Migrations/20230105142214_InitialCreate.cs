using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessWeb.Database.Sqlite.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Equipment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Type = table.Column<int>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    DiameterMm = table.Column<double>(type: "REAL", nullable: true),
                    LengthCm = table.Column<double>(type: "REAL", nullable: true),
                    MassKg = table.Column<double>(type: "REAL", nullable: true),
                    WeightDisc_MassKg = table.Column<double>(type: "REAL", nullable: true),
                    WeightDisc_DiameterMm = table.Column<double>(type: "REAL", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Exercise",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercise", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Muscle",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Muscle", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MuscleGroup",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MuscleGroup", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "EquipmentExercise",
                columns: table => new
                {
                    RequiredEquipmentId = table.Column<Guid>(type: "TEXT", nullable: false),
                    SuitableExercisesId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentExercise", x => new { x.RequiredEquipmentId, x.SuitableExercisesId });
                    table.ForeignKey(
                        name: "FK_EquipmentExercise_Equipment_RequiredEquipmentId",
                        column: x => x.RequiredEquipmentId,
                        principalTable: "Equipment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EquipmentExercise_Exercise_SuitableExercisesId",
                        column: x => x.SuitableExercisesId,
                        principalTable: "Exercise",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "ExerciseMuscle",
                columns: table => new
                {
                    MuscleExercisesId = table.Column<Guid>(type: "TEXT", nullable: false),
                    TrainedMusclesId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseMuscle", x => new { x.MuscleExercisesId, x.TrainedMusclesId });
                    table.ForeignKey(
                        name: "FK_ExerciseMuscle_Exercise_MuscleExercisesId",
                        column: x => x.MuscleExercisesId,
                        principalTable: "Exercise",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExerciseMuscle_Muscle_TrainedMusclesId",
                        column: x => x.TrainedMusclesId,
                        principalTable: "Muscle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MuscleMuscleGroup",
                columns: table => new
                {
                    MuscleGroupsId = table.Column<Guid>(type: "TEXT", nullable: false),
                    MusclesId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MuscleMuscleGroup", x => new { x.MuscleGroupsId, x.MusclesId });
                    table.ForeignKey(
                        name: "FK_MuscleMuscleGroup_Muscle_MusclesId",
                        column: x => x.MusclesId,
                        principalTable: "Muscle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MuscleMuscleGroup_MuscleGroup_MuscleGroupsId",
                        column: x => x.MuscleGroupsId,
                        principalTable: "MuscleGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkoutPlanStep",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    StepPlanId = table.Column<Guid>(type: "TEXT", nullable: false),
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
                    table.ForeignKey(
                        name: "FK_WorkoutPlanStep_WorkoutPlan_StepPlanId",
                        column: x => x.StepPlanId,
                        principalTable: "WorkoutPlan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentExercise_SuitableExercisesId",
                table: "EquipmentExercise",
                column: "SuitableExercisesId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseMuscle_TrainedMusclesId",
                table: "ExerciseMuscle",
                column: "TrainedMusclesId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseRoutine_ExerciseId",
                table: "ExerciseRoutine",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_MuscleMuscleGroup_MusclesId",
                table: "MuscleMuscleGroup",
                column: "MusclesId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutPlanStep_StepPlanId",
                table: "WorkoutPlanStep",
                column: "StepPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutPlanStep_StepRoutineId",
                table: "WorkoutPlanStep",
                column: "StepRoutineId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EquipmentExercise");

            migrationBuilder.DropTable(
                name: "ExerciseMuscle");

            migrationBuilder.DropTable(
                name: "MuscleMuscleGroup");

            migrationBuilder.DropTable(
                name: "WorkoutPlanStep");

            migrationBuilder.DropTable(
                name: "Equipment");

            migrationBuilder.DropTable(
                name: "Muscle");

            migrationBuilder.DropTable(
                name: "MuscleGroup");

            migrationBuilder.DropTable(
                name: "ExerciseRoutine");

            migrationBuilder.DropTable(
                name: "WorkoutPlan");

            migrationBuilder.DropTable(
                name: "Exercise");
        }
    }
}

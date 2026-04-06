using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymApp.Api.Database.Migrations
{
    /// <inheritdoc />
    public partial class TableChangedWorkoutSets : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseSets_Exercises_ExerciseId",
                schema: "gymApp",
                table: "ExerciseSets");

            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseSets_Sessions_SessionId",
                schema: "gymApp",
                table: "ExerciseSets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExerciseSets",
                schema: "gymApp",
                table: "ExerciseSets");

            migrationBuilder.RenameTable(
                name: "ExerciseSets",
                schema: "gymApp",
                newName: "WorkoutSets",
                newSchema: "gymApp");

            migrationBuilder.RenameIndex(
                name: "IX_ExerciseSets_SessionId",
                schema: "gymApp",
                table: "WorkoutSets",
                newName: "IX_WorkoutSets_SessionId");

            migrationBuilder.RenameIndex(
                name: "IX_ExerciseSets_ExerciseId",
                schema: "gymApp",
                table: "WorkoutSets",
                newName: "IX_WorkoutSets_ExerciseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkoutSets",
                schema: "gymApp",
                table: "WorkoutSets",
                column: "WorkoutSetId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkoutSets_Exercises_ExerciseId",
                schema: "gymApp",
                table: "WorkoutSets",
                column: "ExerciseId",
                principalSchema: "gymApp",
                principalTable: "Exercises",
                principalColumn: "ExerciseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkoutSets_Sessions_SessionId",
                schema: "gymApp",
                table: "WorkoutSets",
                column: "SessionId",
                principalSchema: "gymApp",
                principalTable: "Sessions",
                principalColumn: "SessionId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkoutSets_Exercises_ExerciseId",
                schema: "gymApp",
                table: "WorkoutSets");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkoutSets_Sessions_SessionId",
                schema: "gymApp",
                table: "WorkoutSets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkoutSets",
                schema: "gymApp",
                table: "WorkoutSets");

            migrationBuilder.RenameTable(
                name: "WorkoutSets",
                schema: "gymApp",
                newName: "ExerciseSets",
                newSchema: "gymApp");

            migrationBuilder.RenameIndex(
                name: "IX_WorkoutSets_SessionId",
                schema: "gymApp",
                table: "ExerciseSets",
                newName: "IX_ExerciseSets_SessionId");

            migrationBuilder.RenameIndex(
                name: "IX_WorkoutSets_ExerciseId",
                schema: "gymApp",
                table: "ExerciseSets",
                newName: "IX_ExerciseSets_ExerciseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExerciseSets",
                schema: "gymApp",
                table: "ExerciseSets",
                column: "WorkoutSetId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseSets_Exercises_ExerciseId",
                schema: "gymApp",
                table: "ExerciseSets",
                column: "ExerciseId",
                principalSchema: "gymApp",
                principalTable: "Exercises",
                principalColumn: "ExerciseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseSets_Sessions_SessionId",
                schema: "gymApp",
                table: "ExerciseSets",
                column: "SessionId",
                principalSchema: "gymApp",
                principalTable: "Sessions",
                principalColumn: "SessionId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

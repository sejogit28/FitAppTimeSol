using Microsoft.EntityFrameworkCore.Migrations;

namespace FitAppDataStoreEF.Migrations
{
    public partial class ChangedNameOfWorkoutTableToExeWorkout : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exe_Workout_WorkoutId",
                table: "Exe");

            migrationBuilder.DropForeignKey(
                name: "FK_ExeProgramWorkouts_Workout_WorkoutId",
                table: "ExeProgramWorkouts");

            migrationBuilder.DropTable(
                name: "Workout");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "217a4864-5e87-40eb-9805-2d5c0f128225");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "69ca88e6-f72b-4f69-8e10-03c8da09f818");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "89d21cc6-b5fb-4fee-8ab3-68970ffc8531");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bb5d3085-5d4f-4344-9e52-206d6ed9d01a");

            migrationBuilder.RenameColumn(
                name: "WorkoutId",
                table: "ExeProgramWorkouts",
                newName: "ExeWorkoutId");

            migrationBuilder.RenameColumn(
                name: "WorkoutWorkoutId",
                table: "ExeProgramWorkouts",
                newName: "ExeWorkoutExeWorkoutId");

            migrationBuilder.RenameIndex(
                name: "IX_ExeProgramWorkouts_WorkoutId",
                table: "ExeProgramWorkouts",
                newName: "IX_ExeProgramWorkouts_ExeWorkoutId");

            migrationBuilder.RenameColumn(
                name: "WorkoutWorkoutId",
                table: "Exe",
                newName: "ExeWorkoutExeWorkoutId");

            migrationBuilder.RenameColumn(
                name: "WorkoutId",
                table: "Exe",
                newName: "ExeWorkoutId");

            migrationBuilder.RenameIndex(
                name: "IX_Exe_WorkoutId",
                table: "Exe",
                newName: "IX_Exe_ExeWorkoutId");

            migrationBuilder.CreateTable(
                name: "ExeWorkout",
                columns: table => new
                {
                    ExeWorkoutId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    GoalNotes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FitAppUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    FitAppUserFirstName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExeWorkout", x => x.ExeWorkoutId);
                    table.ForeignKey(
                        name: "FK_ExeWorkout_AspNetUsers_FitAppUserId",
                        column: x => x.FitAppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "ff7d49d3-3e2f-449d-bf09-7b03858dd721", "6a4be15c-95f2-4da4-b28c-3e10c4f55d6f", "Athlete", "ATHLETE" },
                    { "8ff485f4-01c9-4274-9410-14d534abee0b", "f30a80f9-8cb1-4aa0-a33b-e0013994c613", "Coach", "COACH" },
                    { "f7f3cc2c-f5b4-4b61-9bc1-b01b71ac966e", "72fe5fcc-2ec8-46d1-a8f6-e4e69d876e11", "Head Coach", "HEAD COACH" },
                    { "c9aba6a1-233c-4e01-b12b-0551a1120111", "5badfa23-41ad-424c-8dee-629b98ab9736", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExeWorkout_FitAppUserId",
                table: "ExeWorkout",
                column: "FitAppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exe_ExeWorkout_ExeWorkoutId",
                table: "Exe",
                column: "ExeWorkoutId",
                principalTable: "ExeWorkout",
                principalColumn: "ExeWorkoutId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExeProgramWorkouts_ExeWorkout_ExeWorkoutId",
                table: "ExeProgramWorkouts",
                column: "ExeWorkoutId",
                principalTable: "ExeWorkout",
                principalColumn: "ExeWorkoutId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exe_ExeWorkout_ExeWorkoutId",
                table: "Exe");

            migrationBuilder.DropForeignKey(
                name: "FK_ExeProgramWorkouts_ExeWorkout_ExeWorkoutId",
                table: "ExeProgramWorkouts");

            migrationBuilder.DropTable(
                name: "ExeWorkout");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8ff485f4-01c9-4274-9410-14d534abee0b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c9aba6a1-233c-4e01-b12b-0551a1120111");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f7f3cc2c-f5b4-4b61-9bc1-b01b71ac966e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ff7d49d3-3e2f-449d-bf09-7b03858dd721");

            migrationBuilder.RenameColumn(
                name: "ExeWorkoutId",
                table: "ExeProgramWorkouts",
                newName: "WorkoutId");

            migrationBuilder.RenameColumn(
                name: "ExeWorkoutExeWorkoutId",
                table: "ExeProgramWorkouts",
                newName: "WorkoutWorkoutId");

            migrationBuilder.RenameIndex(
                name: "IX_ExeProgramWorkouts_ExeWorkoutId",
                table: "ExeProgramWorkouts",
                newName: "IX_ExeProgramWorkouts_WorkoutId");

            migrationBuilder.RenameColumn(
                name: "ExeWorkoutId",
                table: "Exe",
                newName: "WorkoutId");

            migrationBuilder.RenameColumn(
                name: "ExeWorkoutExeWorkoutId",
                table: "Exe",
                newName: "WorkoutWorkoutId");

            migrationBuilder.RenameIndex(
                name: "IX_Exe_ExeWorkoutId",
                table: "Exe",
                newName: "IX_Exe_WorkoutId");

            migrationBuilder.CreateTable(
                name: "Workout",
                columns: table => new
                {
                    WorkoutId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FitAppUserFirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FitAppUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    GoalNotes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workout", x => x.WorkoutId);
                    table.ForeignKey(
                        name: "FK_Workout_AspNetUsers_FitAppUserId",
                        column: x => x.FitAppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "89d21cc6-b5fb-4fee-8ab3-68970ffc8531", "1c865cd4-4ea4-4dfc-862f-07bd0361b1dc", "Athlete", "ATHLETE" },
                    { "217a4864-5e87-40eb-9805-2d5c0f128225", "a530d4c8-c436-43af-abec-24cd15917321", "Coach", "COACH" },
                    { "bb5d3085-5d4f-4344-9e52-206d6ed9d01a", "b0660d8c-1d44-4567-a45d-89329bef4a8d", "Head Coach", "HEAD COACH" },
                    { "69ca88e6-f72b-4f69-8e10-03c8da09f818", "f117c1db-dde1-415d-b2c0-98313295a0bc", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Workout_FitAppUserId",
                table: "Workout",
                column: "FitAppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exe_Workout_WorkoutId",
                table: "Exe",
                column: "WorkoutId",
                principalTable: "Workout",
                principalColumn: "WorkoutId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExeProgramWorkouts_Workout_WorkoutId",
                table: "ExeProgramWorkouts",
                column: "WorkoutId",
                principalTable: "Workout",
                principalColumn: "WorkoutId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

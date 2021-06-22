using Microsoft.EntityFrameworkCore.Migrations;

namespace FitAppDataStoreEF.Migrations
{
    public partial class AddedEverythingBack : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "17ccacd6-6622-49be-8468-b948f228a32c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "da91d04d-6a20-4ddd-9922-7fb8327c62d6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e47691af-ea87-4a17-808f-6c955544a6f9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "efd7ad09-c5ad-4458-9ddb-f34fa85de3a3");

            migrationBuilder.CreateTable(
                name: "ExeWorkout",
                columns: table => new
                {
                    ExeWorkoutId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GoalNotes = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    Title = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
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

            migrationBuilder.CreateTable(
                name: "ExeProgramWorkouts",
                columns: table => new
                {
                    ExeProgramExeProgramId = table.Column<int>(type: "int", nullable: false),
                    ExeWorkoutExeWorkoutId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExeProgramWorkouts", x => new { x.ExeProgramExeProgramId, x.ExeWorkoutExeWorkoutId });
                    table.ForeignKey(
                        name: "FK_ExeProgramWorkouts_ExeProgram_ExeProgramExeProgramId",
                        column: x => x.ExeProgramExeProgramId,
                        principalTable: "ExeProgram",
                        principalColumn: "ExeProgramId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExeProgramWorkouts_ExeWorkout_ExeWorkoutExeWorkoutId",
                        column: x => x.ExeWorkoutExeWorkoutId,
                        principalTable: "ExeWorkout",
                        principalColumn: "ExeWorkoutId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4efac84d-6449-4675-aed3-f82d18012692", "e7240151-a58a-4878-8ff3-8e6ccc2a66ff", "Athlete", "ATHLETE" },
                    { "851f1862-525a-4b7d-9d2f-238e449540fb", "e692368e-e167-4ad1-8a33-ce9804f41767", "Coach", "COACH" },
                    { "b45a780c-a39b-4554-bfe2-ef52a0199af8", "fee90aba-4d0b-48ec-a1bf-50822b9e671b", "Head Coach", "HEAD COACH" },
                    { "ebe2d5cd-ae9a-4aec-a083-7a3ba0475fe3", "540a6bf3-427e-4694-9b49-4e285e5768d1", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExeProgramWorkouts_ExeWorkoutExeWorkoutId",
                table: "ExeProgramWorkouts",
                column: "ExeWorkoutExeWorkoutId");

            migrationBuilder.CreateIndex(
                name: "IX_ExeWorkout_FitAppUserId",
                table: "ExeWorkout",
                column: "FitAppUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExeProgramWorkouts");

            migrationBuilder.DropTable(
                name: "ExeWorkout");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4efac84d-6449-4675-aed3-f82d18012692");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "851f1862-525a-4b7d-9d2f-238e449540fb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b45a780c-a39b-4554-bfe2-ef52a0199af8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ebe2d5cd-ae9a-4aec-a083-7a3ba0475fe3");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "da91d04d-6a20-4ddd-9922-7fb8327c62d6", "920e01d0-036e-4526-b1d2-90b3c673b057", "Athlete", "ATHLETE" },
                    { "17ccacd6-6622-49be-8468-b948f228a32c", "28534968-fd12-4878-850f-a0352d86f287", "Coach", "COACH" },
                    { "efd7ad09-c5ad-4458-9ddb-f34fa85de3a3", "2ca82795-15f3-4967-8da2-e6b69c79eba6", "Head Coach", "HEAD COACH" },
                    { "e47691af-ea87-4a17-808f-6c955544a6f9", "51308b6f-35c6-46aa-8c0a-88582e58360b", "Administrator", "ADMINISTRATOR" }
                });
        }
    }
}

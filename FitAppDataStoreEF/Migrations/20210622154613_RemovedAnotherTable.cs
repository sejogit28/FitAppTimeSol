using Microsoft.EntityFrameworkCore.Migrations;

namespace FitAppDataStoreEF.Migrations
{
    public partial class RemovedAnotherTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExeProgramWorkouts");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "016cc092-3649-47b8-ac05-6214d7bd87be");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "370cf88d-92ac-44e0-b127-aaeb9a152b53");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "45aea709-d43d-4d69-b19c-11baca2b6221");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "84844850-b4db-46c8-a462-c83840498e10");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "d278fa4e-b878-408a-88dd-4801f676f75e", "476ae964-66be-42f6-a383-9a3b460424a9", "Athlete", "ATHLETE" },
                    { "6ab16036-6315-4bd1-acd4-7f312eed3f70", "973473cb-d2cb-4c1b-89f9-3657b1476606", "Coach", "COACH" },
                    { "3dfefd39-4cf3-48e3-9d4c-3000a936c85a", "ebeaad40-0290-423e-8df6-379ea1b6d2ce", "Head Coach", "HEAD COACH" },
                    { "cb4ef567-6b4e-465c-82d3-96b192049d7d", "0d8eafee-682e-4c46-933d-1dc0948e029f", "Administrator", "ADMINISTRATOR" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3dfefd39-4cf3-48e3-9d4c-3000a936c85a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6ab16036-6315-4bd1-acd4-7f312eed3f70");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cb4ef567-6b4e-465c-82d3-96b192049d7d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d278fa4e-b878-408a-88dd-4801f676f75e");

            migrationBuilder.CreateTable(
                name: "ExeProgramWorkouts",
                columns: table => new
                {
                    ExeProgramExeProgramId = table.Column<int>(type: "int", nullable: false),
                    ExeWorkoutExeWorkoutId = table.Column<int>(type: "int", nullable: false),
                    ExeWorkoutId = table.Column<string>(type: "nvarchar(450)", nullable: true)
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
                        name: "FK_ExeProgramWorkouts_ExeWorkout_ExeWorkoutId",
                        column: x => x.ExeWorkoutId,
                        principalTable: "ExeWorkout",
                        principalColumn: "ExeWorkoutId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "370cf88d-92ac-44e0-b127-aaeb9a152b53", "9fbe4c0b-0a81-44a3-98cc-17b7c672f1a6", "Athlete", "ATHLETE" },
                    { "84844850-b4db-46c8-a462-c83840498e10", "c884a6b0-18b1-4eda-a6c0-af675fb95305", "Coach", "COACH" },
                    { "016cc092-3649-47b8-ac05-6214d7bd87be", "edaeb0fe-5089-451d-ada1-7734b92d7c9b", "Head Coach", "HEAD COACH" },
                    { "45aea709-d43d-4d69-b19c-11baca2b6221", "f55885bb-2184-4f5a-b3b5-ef1597d8e0f9", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExeProgramWorkouts_ExeWorkoutId",
                table: "ExeProgramWorkouts",
                column: "ExeWorkoutId");
        }
    }
}

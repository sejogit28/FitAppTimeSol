using Microsoft.EntityFrameworkCore.Migrations;

namespace FitAppDataStoreEF.Migrations
{
    public partial class RemovedYetAnotherTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exe_ExeWorkout_ExeWorkoutId",
                table: "Exe");

            migrationBuilder.DropTable(
                name: "ExeWorkout");

            migrationBuilder.DropIndex(
                name: "IX_Exe_ExeWorkoutId",
                table: "Exe");

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

            migrationBuilder.DropColumn(
                name: "ExeWorkoutId",
                table: "Exe");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "ExeWorkoutId",
                table: "Exe",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ExeWorkout",
                columns: table => new
                {
                    ExeWorkoutId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FitAppUserFirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FitAppUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    GoalNotes = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    Title = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
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
                    { "d278fa4e-b878-408a-88dd-4801f676f75e", "476ae964-66be-42f6-a383-9a3b460424a9", "Athlete", "ATHLETE" },
                    { "6ab16036-6315-4bd1-acd4-7f312eed3f70", "973473cb-d2cb-4c1b-89f9-3657b1476606", "Coach", "COACH" },
                    { "3dfefd39-4cf3-48e3-9d4c-3000a936c85a", "ebeaad40-0290-423e-8df6-379ea1b6d2ce", "Head Coach", "HEAD COACH" },
                    { "cb4ef567-6b4e-465c-82d3-96b192049d7d", "0d8eafee-682e-4c46-933d-1dc0948e029f", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Exe_ExeWorkoutId",
                table: "Exe",
                column: "ExeWorkoutId");

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
        }
    }
}

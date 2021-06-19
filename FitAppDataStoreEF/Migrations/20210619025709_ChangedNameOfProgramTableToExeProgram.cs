using Microsoft.EntityFrameworkCore.Migrations;

namespace FitAppDataStoreEF.Migrations
{
    public partial class ChangedNameOfProgramTableToExeProgram : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExeProgramWorkouts_Program_ExeProgramExeProgramId",
                table: "ExeProgramWorkouts");

            migrationBuilder.DropForeignKey(
                name: "FK_FitAppUserExePrograms_Program_ExeProgramExeProgramId",
                table: "FitAppUserExePrograms");

            migrationBuilder.DropForeignKey(
                name: "FK_Program_AspNetUsers_FitAppUserId",
                table: "Program");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Program",
                table: "Program");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1306be6b-02f5-470d-8558-b413cf2da526");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "79b9697b-a2f9-4385-8c6e-734a54b3940b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7a123f11-9fd6-408a-9902-6803e2f21348");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a1d4eeb3-7317-4255-88d1-8988db60e936");

            migrationBuilder.RenameTable(
                name: "Program",
                newName: "ExeProgram");

            migrationBuilder.RenameIndex(
                name: "IX_Program_FitAppUserId",
                table: "ExeProgram",
                newName: "IX_ExeProgram_FitAppUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExeProgram",
                table: "ExeProgram",
                column: "ExeProgramId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_ExeProgram_AspNetUsers_FitAppUserId",
                table: "ExeProgram",
                column: "FitAppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExeProgramWorkouts_ExeProgram_ExeProgramExeProgramId",
                table: "ExeProgramWorkouts",
                column: "ExeProgramExeProgramId",
                principalTable: "ExeProgram",
                principalColumn: "ExeProgramId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FitAppUserExePrograms_ExeProgram_ExeProgramExeProgramId",
                table: "FitAppUserExePrograms",
                column: "ExeProgramExeProgramId",
                principalTable: "ExeProgram",
                principalColumn: "ExeProgramId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExeProgram_AspNetUsers_FitAppUserId",
                table: "ExeProgram");

            migrationBuilder.DropForeignKey(
                name: "FK_ExeProgramWorkouts_ExeProgram_ExeProgramExeProgramId",
                table: "ExeProgramWorkouts");

            migrationBuilder.DropForeignKey(
                name: "FK_FitAppUserExePrograms_ExeProgram_ExeProgramExeProgramId",
                table: "FitAppUserExePrograms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExeProgram",
                table: "ExeProgram");

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

            migrationBuilder.RenameTable(
                name: "ExeProgram",
                newName: "Program");

            migrationBuilder.RenameIndex(
                name: "IX_ExeProgram_FitAppUserId",
                table: "Program",
                newName: "IX_Program_FitAppUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Program",
                table: "Program",
                column: "ExeProgramId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1306be6b-02f5-470d-8558-b413cf2da526", "4863e5a1-b495-4c30-98c1-6fb3b789a672", "Athlete", "ATHLETE" },
                    { "a1d4eeb3-7317-4255-88d1-8988db60e936", "05f1ebbc-e59f-436f-abac-1e96246a2524", "Coach", "COACH" },
                    { "7a123f11-9fd6-408a-9902-6803e2f21348", "576b52bb-46ce-4c4f-979d-b2abbd2f4c37", "Head Coach", "HEAD COACH" },
                    { "79b9697b-a2f9-4385-8c6e-734a54b3940b", "0e68d818-1bfd-4828-af53-9a121fdafc19", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ExeProgramWorkouts_Program_ExeProgramExeProgramId",
                table: "ExeProgramWorkouts",
                column: "ExeProgramExeProgramId",
                principalTable: "Program",
                principalColumn: "ExeProgramId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FitAppUserExePrograms_Program_ExeProgramExeProgramId",
                table: "FitAppUserExePrograms",
                column: "ExeProgramExeProgramId",
                principalTable: "Program",
                principalColumn: "ExeProgramId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Program_AspNetUsers_FitAppUserId",
                table: "Program",
                column: "FitAppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

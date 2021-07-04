using Microsoft.EntityFrameworkCore.Migrations;

namespace FitAppDataStoreEF.Migrations
{
    public partial class addedOrganizationMTMTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1a3301ec-32bd-42a2-a0ca-191127f895cd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2ba56203-1583-487d-afda-da3f9bbf85fe");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "76822e67-2b32-44cc-86a0-5ec4bfdb5acb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a296467a-47d7-400e-a85c-5f5573cd535a");

            migrationBuilder.AddColumn<int>(
                name: "OrganizationLevel",
                table: "Organizations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "OrganizationExePrograms",
                columns: table => new
                {
                    OrganizationsOrganizationId = table.Column<int>(type: "int", nullable: false),
                    ExeProgramExeProgramId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationExePrograms", x => new { x.OrganizationsOrganizationId, x.ExeProgramExeProgramId });
                    table.ForeignKey(
                        name: "FK_OrganizationExePrograms_ExeProgram_ExeProgramExeProgramId",
                        column: x => x.ExeProgramExeProgramId,
                        principalTable: "ExeProgram",
                        principalColumn: "ExeProgramId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrganizationExePrograms_Organizations_OrganizationsOrganizationId",
                        column: x => x.OrganizationsOrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "OrganizationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrganizationExeWorkouts",
                columns: table => new
                {
                    OrganizationsOrganizationId = table.Column<int>(type: "int", nullable: false),
                    ExeWorkoutExeWorkoutId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationExeWorkouts", x => new { x.OrganizationsOrganizationId, x.ExeWorkoutExeWorkoutId });
                    table.ForeignKey(
                        name: "FK_OrganizationExeWorkouts_ExeWorkout_ExeWorkoutExeWorkoutId",
                        column: x => x.ExeWorkoutExeWorkoutId,
                        principalTable: "ExeWorkout",
                        principalColumn: "ExeWorkoutId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrganizationExeWorkouts_Organizations_OrganizationsOrganizationId",
                        column: x => x.OrganizationsOrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "OrganizationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "52dbd8d2-1789-40cd-bb83-a4ff8eb98ca7", "504dc29a-6b08-4198-a0a8-d90e1ecfeeb0", "Athlete", "ATHLETE" },
                    { "14502816-ef64-4eaf-86ae-65168f63c6b1", "27b65cb6-0689-4d24-9c20-a4123f19abcf", "Level 1 Coach", "LEVEL 1 COACH" },
                    { "0a8adbc4-e2d9-4aa3-9456-8710df330305", "7aff2b09-21f6-4f4f-8b15-d3119270f2c9", "Level 2 Coach", "LEVEL 2 COACH" },
                    { "69e3a7c2-7048-4fce-a065-06a171e232fc", "8aeb0d5a-35e4-4504-9b65-fa05a04bfe1b", "Level 3 Small Organization", "LEVEL 3 SMALL ORGANIZATION" },
                    { "56005b66-a5a8-4b4f-a7ed-7db5de2cd11d", "4626153c-5611-4753-bbcc-27f6d65e918d", "Level 4 Organization", "LEVEL 4 LARGE ORGANIZATION" },
                    { "613c08a6-887f-43e4-82fd-ad2bc7a7a547", "e15d463b-9d8f-4743-9d13-a6779c1a937a", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationExePrograms_ExeProgramExeProgramId",
                table: "OrganizationExePrograms",
                column: "ExeProgramExeProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationExeWorkouts_ExeWorkoutExeWorkoutId",
                table: "OrganizationExeWorkouts",
                column: "ExeWorkoutExeWorkoutId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrganizationExePrograms");

            migrationBuilder.DropTable(
                name: "OrganizationExeWorkouts");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0a8adbc4-e2d9-4aa3-9456-8710df330305");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "14502816-ef64-4eaf-86ae-65168f63c6b1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "52dbd8d2-1789-40cd-bb83-a4ff8eb98ca7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "56005b66-a5a8-4b4f-a7ed-7db5de2cd11d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "613c08a6-887f-43e4-82fd-ad2bc7a7a547");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "69e3a7c2-7048-4fce-a065-06a171e232fc");

            migrationBuilder.DropColumn(
                name: "OrganizationLevel",
                table: "Organizations");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a296467a-47d7-400e-a85c-5f5573cd535a", "2224b64c-ca25-49d2-915d-7d5dab11bb0d", "Athlete", "ATHLETE" },
                    { "76822e67-2b32-44cc-86a0-5ec4bfdb5acb", "4a48e556-913b-47f7-af1d-83924706229e", "Coach", "COACH" },
                    { "2ba56203-1583-487d-afda-da3f9bbf85fe", "178ed860-571a-4726-9505-27ac7bad97a9", "Head Coach", "HEAD COACH" },
                    { "1a3301ec-32bd-42a2-a0ca-191127f895cd", "5908dfc9-a701-451e-a275-6acf169e014f", "Administrator", "ADMINISTRATOR" }
                });
        }
    }
}

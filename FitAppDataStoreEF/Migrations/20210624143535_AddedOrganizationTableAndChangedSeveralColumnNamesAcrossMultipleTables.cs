using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FitAppDataStoreEF.Migrations
{
    public partial class AddedOrganizationTableAndChangedSeveralColumnNamesAcrossMultipleTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1b1fddc8-da6b-4146-b18f-31c6dd14e720");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "241bb269-f644-4403-a310-44fd8ac22d72");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3fce39cc-7e08-4c61-9644-ce84741af058");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "95c5f7a7-8f96-4748-bc74-dc0ae601fc70");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "ExeWorkout",
                newName: "ExeWorkoutTitle");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "ExeProgram",
                newName: "ExeProgramTitle");

            migrationBuilder.AlterColumn<string>(
                name: "Goal",
                table: "ExeProgram",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Organizations",
                columns: table => new
                {
                    OrganizationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrganizationName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.OrganizationId);
                });

            migrationBuilder.CreateTable(
                name: "OrganizationFitAppUsers",
                columns: table => new
                {
                    OrganizationsOrganizationId = table.Column<int>(type: "int", nullable: false),
                    FitAppUserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationFitAppUsers", x => new { x.OrganizationsOrganizationId, x.FitAppUserId });
                    table.ForeignKey(
                        name: "FK_OrganizationFitAppUsers_AspNetUsers_FitAppUserId",
                        column: x => x.FitAppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrganizationFitAppUsers_Organizations_OrganizationsOrganizationId",
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
                    { "79242580-5367-4ac3-a85d-b4905fb0fd0b", "80a6924b-19dc-4b55-b2ce-444fd92410b3", "Athlete", "ATHLETE" },
                    { "ac86c1ac-4b42-49eb-bea5-b0e193cf9ed3", "a2a8cbba-a99d-4f51-887d-3db6cdac3c25", "Coach", "COACH" },
                    { "9aad10ae-0a13-4531-a15c-e43b99ec5855", "764cc3c3-39d2-473f-a759-027dbf9b881b", "Head Coach", "HEAD COACH" },
                    { "f7bcfe87-1067-4206-887d-1f91e59e60ae", "f05ab25b-4246-44c0-b49c-9f4eae88da01", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationFitAppUsers_FitAppUserId",
                table: "OrganizationFitAppUsers",
                column: "FitAppUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrganizationFitAppUsers");

            migrationBuilder.DropTable(
                name: "Organizations");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "79242580-5367-4ac3-a85d-b4905fb0fd0b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9aad10ae-0a13-4531-a15c-e43b99ec5855");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ac86c1ac-4b42-49eb-bea5-b0e193cf9ed3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f7bcfe87-1067-4206-887d-1f91e59e60ae");

            migrationBuilder.RenameColumn(
                name: "ExeWorkoutTitle",
                table: "ExeWorkout",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "ExeProgramTitle",
                table: "ExeProgram",
                newName: "Title");

            migrationBuilder.AlterColumn<string>(
                name: "Goal",
                table: "ExeProgram",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "241bb269-f644-4403-a310-44fd8ac22d72", "99a72cdf-c086-4e02-ad9c-b4666c653986", "Athlete", "ATHLETE" },
                    { "3fce39cc-7e08-4c61-9644-ce84741af058", "ccf772aa-f2c8-4c56-863b-40616c930660", "Coach", "COACH" },
                    { "1b1fddc8-da6b-4146-b18f-31c6dd14e720", "7a05a2a3-c1ee-4ff9-b558-e16fee06ee79", "Head Coach", "HEAD COACH" },
                    { "95c5f7a7-8f96-4748-bc74-dc0ae601fc70", "8fd4644e-2822-460f-9023-51c324ca8610", "Administrator", "ADMINISTRATOR" }
                });
        }
    }
}

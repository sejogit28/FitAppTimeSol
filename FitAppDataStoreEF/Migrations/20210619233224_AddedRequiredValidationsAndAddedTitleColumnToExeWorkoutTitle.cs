using Microsoft.EntityFrameworkCore.Migrations;

namespace FitAppDataStoreEF.Migrations
{
    public partial class AddedRequiredValidationsAndAddedTitleColumnToExeWorkoutTitle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7bdd1300-b0c4-4647-932f-5a05a7ecbd9b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99344ca2-10c0-4baf-8ddb-06ed4890b542");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b75fb90a-1968-4e40-b1d6-ed0f993ec294");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f33fe27a-2989-4df1-834f-1ad8ff88e298");

            migrationBuilder.AlterColumn<string>(
                name: "LibExeName",
                table: "LibExe",
                type: "nvarchar(75)",
                maxLength: 75,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(75)",
                oldMaxLength: 75,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "ExeWorkout",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "be5ffcb9-9bab-4633-a3cc-ba26e309c55a", "97e802cb-f216-4a9c-9937-54ee9ba15389", "Athlete", "ATHLETE" },
                    { "58254641-1cee-4365-a8ca-ab6981d1d79d", "b4b5d4e9-bbf4-4ef2-ba64-1920696d338f", "Coach", "COACH" },
                    { "b1f2fe74-239c-4c7c-9df5-278af6d4ff2f", "97c6b516-77cf-4ade-8e22-c9747ef4cdb5", "Head Coach", "HEAD COACH" },
                    { "a3cfde46-47ba-424a-bf71-85a234c68096", "e6312a0f-79af-4b76-9ca9-40476274f746", "Administrator", "ADMINISTRATOR" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "58254641-1cee-4365-a8ca-ab6981d1d79d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a3cfde46-47ba-424a-bf71-85a234c68096");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b1f2fe74-239c-4c7c-9df5-278af6d4ff2f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "be5ffcb9-9bab-4633-a3cc-ba26e309c55a");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "ExeWorkout");

            migrationBuilder.AlterColumn<string>(
                name: "LibExeName",
                table: "LibExe",
                type: "nvarchar(75)",
                maxLength: 75,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(75)",
                oldMaxLength: 75);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "99344ca2-10c0-4baf-8ddb-06ed4890b542", "242ae1e5-4369-4193-8ae1-a9b1fe0dd1d5", "Athlete", "ATHLETE" },
                    { "f33fe27a-2989-4df1-834f-1ad8ff88e298", "299e948a-8c38-432e-999d-83045ff11b63", "Coach", "COACH" },
                    { "7bdd1300-b0c4-4647-932f-5a05a7ecbd9b", "d052c462-b517-482c-9abb-0a6824daeda6", "Head Coach", "HEAD COACH" },
                    { "b75fb90a-1968-4e40-b1d6-ed0f993ec294", "f93fee44-80ad-4b37-91b7-fd612c112172", "Administrator", "ADMINISTRATOR" }
                });
        }
    }
}

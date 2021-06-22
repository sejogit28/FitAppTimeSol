using Microsoft.EntityFrameworkCore.Migrations;

namespace FitAppDataStoreEF.Migrations
{
    public partial class RemovedExeWorkoutTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                    { "be5ffcb9-9bab-4633-a3cc-ba26e309c55a", "97e802cb-f216-4a9c-9937-54ee9ba15389", "Athlete", "ATHLETE" },
                    { "58254641-1cee-4365-a8ca-ab6981d1d79d", "b4b5d4e9-bbf4-4ef2-ba64-1920696d338f", "Coach", "COACH" },
                    { "b1f2fe74-239c-4c7c-9df5-278af6d4ff2f", "97c6b516-77cf-4ade-8e22-c9747ef4cdb5", "Head Coach", "HEAD COACH" },
                    { "a3cfde46-47ba-424a-bf71-85a234c68096", "e6312a0f-79af-4b76-9ca9-40476274f746", "Administrator", "ADMINISTRATOR" }
                });
        }
    }
}

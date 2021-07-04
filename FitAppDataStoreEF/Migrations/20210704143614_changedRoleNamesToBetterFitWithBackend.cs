using Microsoft.EntityFrameworkCore.Migrations;

namespace FitAppDataStoreEF.Migrations
{
    public partial class changedRoleNamesToBetterFitWithBackend : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8f79a877-75a8-405b-9e24-94acb349f89e", "3e6c01d1-30b2-4038-8849-9ce6b46c343d", "Athlete", "ATHLETE" },
                    { "840de69a-5818-4bfb-a6b0-1eeb1992599c", "66984ae4-9494-4a16-9ae9-1afae848325f", "Coach", "COACH" },
                    { "3933e396-bc98-4176-88da-9cdc0e9f0a24", "5aa16087-e195-43c3-a566-68f2dd4ff5c6", "Level 1 Small Organization", "LEVEL 1 SMALL ORGANIZATION" },
                    { "343dc2d1-c61a-4e62-a1b4-cdab49a6942e", "1d5cf765-79d0-4016-b8e8-1dce92fb1560", "Level 2 Medium Organization", "LEVEL 2 MEDIUM ORGANIZATION" },
                    { "61eab27a-97f4-405a-b804-a67be1774bcc", "e40c47da-6f40-4803-9cd7-9eacc7ed41a8", "Level 3 Organization", "LEVEL 3 LARGE ORGANIZATION" },
                    { "931cf437-9a91-4d4d-ba65-f6bb94dd0dad", "cfe9e801-9daa-49e0-a5e3-3f7ca2ad8ea5", "Administrator", "ADMINISTRATOR" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "343dc2d1-c61a-4e62-a1b4-cdab49a6942e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3933e396-bc98-4176-88da-9cdc0e9f0a24");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "61eab27a-97f4-405a-b804-a67be1774bcc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "840de69a-5818-4bfb-a6b0-1eeb1992599c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8f79a877-75a8-405b-9e24-94acb349f89e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "931cf437-9a91-4d4d-ba65-f6bb94dd0dad");

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
        }
    }
}

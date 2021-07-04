using Microsoft.EntityFrameworkCore.Migrations;

namespace FitAppDataStoreEF.Migrations
{
    public partial class addedNewRolesToBetterAccomodatePossibleCoachChoices : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "Set11Values",
                table: "UserExeValues",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Set12Values",
                table: "UserExeValues",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Set13Values",
                table: "UserExeValues",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Set14Values",
                table: "UserExeValues",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Set15Values",
                table: "UserExeValues",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "598e31c3-c7c8-4971-b402-19706b3192a4", "1907d258-f203-4216-b2aa-112b53d26057", "Athlete", "ATHLETE" },
                    { "26f89a5c-65a4-4120-9ba3-04a41e983e09", "05ded6f5-9022-4a7d-a193-df36e5cebcb3", "Coach", "COACH" },
                    { "9c569e6d-9ecf-4185-b8d0-f1a64e01ee6f", "d77253d4-7e95-4fe2-a58f-d9f4ed427479", "Level 1 Organization", "LEVEL 1 ORGANIZATION" },
                    { "3def6517-1968-4fe2-bbd4-b48556aa8346", "d7977576-cb9a-4b3f-8bc1-eee2471afa54", "Level 2 Organization", "LEVEL 2 ORGANIZATION" },
                    { "e23c4c8a-3f68-4dda-8c0e-1f178528bdd4", "c19df55d-86ee-4756-98cc-81cc8f75cf70", "Level 3 Organization", "LEVEL 3 LARGE ORGANIZATION" },
                    { "d725b8c6-f3a1-4a4c-97dd-a277864a3d0a", "af3a22eb-298c-4b31-a932-f48462a61759", "Level 4 Organization", "LEVEL 4 ORGANIZATION" },
                    { "4312e2f7-91c8-47bd-ba9c-5855fe2bc294", "666c6b3c-c078-4916-b094-981a11decc27", "Level 5 Organization", "LEVEL 5 ORGANIZATION" },
                    { "29312808-d130-4582-8837-bccb6cb1186f", "fd32d02f-1524-4782-942c-2712881a7c77", "Administrator", "ADMINISTRATOR" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "26f89a5c-65a4-4120-9ba3-04a41e983e09");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29312808-d130-4582-8837-bccb6cb1186f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3def6517-1968-4fe2-bbd4-b48556aa8346");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4312e2f7-91c8-47bd-ba9c-5855fe2bc294");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "598e31c3-c7c8-4971-b402-19706b3192a4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9c569e6d-9ecf-4185-b8d0-f1a64e01ee6f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d725b8c6-f3a1-4a4c-97dd-a277864a3d0a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e23c4c8a-3f68-4dda-8c0e-1f178528bdd4");

            migrationBuilder.DropColumn(
                name: "Set11Values",
                table: "UserExeValues");

            migrationBuilder.DropColumn(
                name: "Set12Values",
                table: "UserExeValues");

            migrationBuilder.DropColumn(
                name: "Set13Values",
                table: "UserExeValues");

            migrationBuilder.DropColumn(
                name: "Set14Values",
                table: "UserExeValues");

            migrationBuilder.DropColumn(
                name: "Set15Values",
                table: "UserExeValues");

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
    }
}

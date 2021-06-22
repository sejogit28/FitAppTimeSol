using Microsoft.EntityFrameworkCore.Migrations;

namespace FitAppDataStoreEF.Migrations
{
    public partial class SecondMigrationToContinueFixingNVARCharMaxProblem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6d147f49-1573-406b-be7f-9830dbd338b4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "71e7c510-9215-4bd4-9296-9f2e6d2f9780");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ee73ffdd-efa7-43c0-ac84-493a9902f60d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f3e307bf-e0c5-4400-ae9d-11668f597c0a");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(140)",
                maxLength: 140,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "812e3e51-c7ed-4a20-86ae-6ffcfbe5a79a", "8a17ed6e-807a-4871-abc9-0648a4e555d7", "Athlete", "ATHLETE" },
                    { "332b46c5-c724-4503-a8fd-032f76266ebf", "6d0a304e-fe1f-4627-be46-65f129292df1", "Coach", "COACH" },
                    { "cd434bb4-c0e0-4835-a4bf-b3e6a6b43281", "7e096719-c89a-4a4c-a388-b4d5b443d7db", "Head Coach", "HEAD COACH" },
                    { "a8b7c08e-f2dc-4f0f-b0b9-9f89fe232697", "3f4a047a-476a-47c9-9e6f-904f3e7a6da0", "Administrator", "ADMINISTRATOR" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "332b46c5-c724-4503-a8fd-032f76266ebf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "812e3e51-c7ed-4a20-86ae-6ffcfbe5a79a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a8b7c08e-f2dc-4f0f-b0b9-9f89fe232697");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cd434bb4-c0e0-4835-a4bf-b3e6a6b43281");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(140)",
                oldMaxLength: 140,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "71e7c510-9215-4bd4-9296-9f2e6d2f9780", "d5434311-429e-4eb4-a06e-e8747e3f6bb7", "Athlete", "ATHLETE" },
                    { "6d147f49-1573-406b-be7f-9830dbd338b4", "dc0442d8-c63e-4987-8b98-92ea58a74154", "Coach", "COACH" },
                    { "ee73ffdd-efa7-43c0-ac84-493a9902f60d", "989cf926-c711-47c2-82b4-45552a3f63b3", "Head Coach", "HEAD COACH" },
                    { "f3e307bf-e0c5-4400-ae9d-11668f597c0a", "6577c27e-e5d5-4bdb-bb59-dbd1e0f9e551", "Administrator", "ADMINISTRATOR" }
                });
        }
    }
}

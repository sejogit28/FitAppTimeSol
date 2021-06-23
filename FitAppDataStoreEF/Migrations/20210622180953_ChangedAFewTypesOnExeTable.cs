using Microsoft.EntityFrameworkCore.Migrations;

namespace FitAppDataStoreEF.Migrations
{
    public partial class ChangedAFewTypesOnExeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4efac84d-6449-4675-aed3-f82d18012692");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "851f1862-525a-4b7d-9d2f-238e449540fb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b45a780c-a39b-4554-bfe2-ef52a0199af8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ebe2d5cd-ae9a-4aec-a083-7a3ba0475fe3");

            migrationBuilder.AlterColumn<int>(
                name: "Rest",
                table: "Exe",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "86d1e1f9-aad4-473d-a696-608fba885863", "403c154f-659d-4318-babc-729445765a04", "Athlete", "ATHLETE" },
                    { "9232f789-0066-4457-95e7-e5a0ae08ac6a", "b8aeff48-b53d-41d5-b416-acd3c0fb0e91", "Coach", "COACH" },
                    { "8afd14dc-04ae-41df-a7ca-697ee0033c96", "33f5b5b6-567b-490d-b6b9-5f10249c6408", "Head Coach", "HEAD COACH" },
                    { "fbdf5dda-c09f-4205-8a02-e8f39b103790", "6f5cb2a3-bcc0-44c6-82d3-397dcd2faef0", "Administrator", "ADMINISTRATOR" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "86d1e1f9-aad4-473d-a696-608fba885863");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8afd14dc-04ae-41df-a7ca-697ee0033c96");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9232f789-0066-4457-95e7-e5a0ae08ac6a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fbdf5dda-c09f-4205-8a02-e8f39b103790");

            migrationBuilder.AlterColumn<string>(
                name: "Rest",
                table: "Exe",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4efac84d-6449-4675-aed3-f82d18012692", "e7240151-a58a-4878-8ff3-8e6ccc2a66ff", "Athlete", "ATHLETE" },
                    { "851f1862-525a-4b7d-9d2f-238e449540fb", "e692368e-e167-4ad1-8a33-ce9804f41767", "Coach", "COACH" },
                    { "b45a780c-a39b-4554-bfe2-ef52a0199af8", "fee90aba-4d0b-48ec-a1bf-50822b9e671b", "Head Coach", "HEAD COACH" },
                    { "ebe2d5cd-ae9a-4aec-a083-7a3ba0475fe3", "540a6bf3-427e-4694-9b49-4e285e5768d1", "Administrator", "ADMINISTRATOR" }
                });
        }
    }
}

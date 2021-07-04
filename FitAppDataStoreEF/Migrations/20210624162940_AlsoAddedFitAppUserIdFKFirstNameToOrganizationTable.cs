using Microsoft.EntityFrameworkCore.Migrations;

namespace FitAppDataStoreEF.Migrations
{
    public partial class AlsoAddedFitAppUserIdFKFirstNameToOrganizationTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c0e5bea1-9c20-4510-8324-efa3ccad0a37");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e7fc522a-dc43-45a8-986b-973d4ab04a04");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f1df0910-28fe-4f12-9f0a-714275900ab7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f6badb1a-4d9c-435c-8e06-dc8a43cfa69d");

            migrationBuilder.AddColumn<string>(
                name: "FitAppUserFirstName",
                table: "Organizations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6ead671e-2848-4d27-a598-3146208ab734", "b3eb1384-ce55-40e0-b08c-d52733c1ac51", "Athlete", "ATHLETE" },
                    { "e0db3f33-4099-4cab-b78a-9123cd896097", "53992ddb-9288-489e-ab6d-505d20773375", "Coach", "COACH" },
                    { "f0f36e80-69af-402e-89a9-8904b37199a5", "455e405c-4946-49fd-944d-bde8d81ede1e", "Head Coach", "HEAD COACH" },
                    { "20247550-7539-40fa-8589-880644d72eae", "fbec268d-dc36-4a92-bb16-f5543dab3ae0", "Administrator", "ADMINISTRATOR" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "20247550-7539-40fa-8589-880644d72eae");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6ead671e-2848-4d27-a598-3146208ab734");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e0db3f33-4099-4cab-b78a-9123cd896097");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f0f36e80-69af-402e-89a9-8904b37199a5");

            migrationBuilder.DropColumn(
                name: "FitAppUserFirstName",
                table: "Organizations");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "e7fc522a-dc43-45a8-986b-973d4ab04a04", "6a27efbf-e753-4015-bc16-3195bf85e9fe", "Athlete", "ATHLETE" },
                    { "f6badb1a-4d9c-435c-8e06-dc8a43cfa69d", "66653853-fbcf-4511-98c5-f89e69d641e6", "Coach", "COACH" },
                    { "f1df0910-28fe-4f12-9f0a-714275900ab7", "264474dc-fd09-486d-96a0-6a4990522ce7", "Head Coach", "HEAD COACH" },
                    { "c0e5bea1-9c20-4510-8324-efa3ccad0a37", "b6def647-4113-4e1f-8ccd-fc04b95bfca2", "Administrator", "ADMINISTRATOR" }
                });
        }
    }
}

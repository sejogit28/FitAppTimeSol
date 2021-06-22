using Microsoft.EntityFrameworkCore.Migrations;

namespace FitAppDataStoreEF.Migrations
{
    public partial class AddedboolEachSideToExeLibTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<bool>(
                name: "EachSide",
                table: "LibExe",
                type: "bit",
                nullable: false,
                defaultValue: false);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "EachSide",
                table: "LibExe");

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
    }
}

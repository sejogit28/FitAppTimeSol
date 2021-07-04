using Microsoft.EntityFrameworkCore.Migrations;

namespace FitAppDataStoreEF.Migrations
{
    public partial class MovedExeTypeColumnFromExeTableToLibExeTableAndRenamedItLibExeType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "ExeType",
                table: "Exe");

            migrationBuilder.AddColumn<string>(
                name: "LibExeType",
                table: "LibExe",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "WorkoutGroup",
                table: "Exe",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "73da0b67-6df2-4851-8895-d0a3ffa30fda", "53ea45b5-2c25-42e1-a383-f2469b6c17b5", "Athlete", "ATHLETE" },
                    { "d5663a88-5a4c-4167-b84f-a0aaa43fdaf7", "eda179c5-632c-4741-aaa0-73db9a53f53c", "Coach", "COACH" },
                    { "3d969be7-04e3-4731-b1c2-67e3346f5c77", "d340514b-fc78-41f3-afca-6f24911293a0", "Head Coach", "HEAD COACH" },
                    { "736a5463-2ab4-4d40-b584-f907f7265d12", "3ae3d7c1-9857-47b8-a090-85ce6d89cc9e", "Administrator", "ADMINISTRATOR" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d969be7-04e3-4731-b1c2-67e3346f5c77");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "736a5463-2ab4-4d40-b584-f907f7265d12");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "73da0b67-6df2-4851-8895-d0a3ffa30fda");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d5663a88-5a4c-4167-b84f-a0aaa43fdaf7");

            migrationBuilder.DropColumn(
                name: "LibExeType",
                table: "LibExe");

            migrationBuilder.AlterColumn<string>(
                name: "WorkoutGroup",
                table: "Exe",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "ExeType",
                table: "Exe",
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
    }
}

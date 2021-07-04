using Microsoft.EntityFrameworkCore.Migrations;

namespace FitAppDataStoreEF.Migrations
{
    public partial class addedCharacterLimitsToStringColumnsAcrossMulitpleTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "OrganizationName",
                table: "Organizations",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "WorkoutGroup",
                table: "Exe",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Tempo",
                table: "Exe",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ExeNotes",
                table: "Exe",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ExeName",
                table: "Exe",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a296467a-47d7-400e-a85c-5f5573cd535a", "2224b64c-ca25-49d2-915d-7d5dab11bb0d", "Athlete", "ATHLETE" },
                    { "76822e67-2b32-44cc-86a0-5ec4bfdb5acb", "4a48e556-913b-47f7-af1d-83924706229e", "Coach", "COACH" },
                    { "2ba56203-1583-487d-afda-da3f9bbf85fe", "178ed860-571a-4726-9505-27ac7bad97a9", "Head Coach", "HEAD COACH" },
                    { "1a3301ec-32bd-42a2-a0ca-191127f895cd", "5908dfc9-a701-451e-a275-6acf169e014f", "Administrator", "ADMINISTRATOR" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1a3301ec-32bd-42a2-a0ca-191127f895cd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2ba56203-1583-487d-afda-da3f9bbf85fe");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "76822e67-2b32-44cc-86a0-5ec4bfdb5acb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a296467a-47d7-400e-a85c-5f5573cd535a");

            migrationBuilder.AlterColumn<string>(
                name: "OrganizationName",
                table: "Organizations",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "WorkoutGroup",
                table: "Exe",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(5)",
                oldMaxLength: 5);

            migrationBuilder.AlterColumn<string>(
                name: "Tempo",
                table: "Exe",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ExeNotes",
                table: "Exe",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ExeName",
                table: "Exe",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150,
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
    }
}

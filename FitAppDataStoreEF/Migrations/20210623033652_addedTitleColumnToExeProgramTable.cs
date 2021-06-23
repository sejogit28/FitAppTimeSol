using Microsoft.EntityFrameworkCore.Migrations;

namespace FitAppDataStoreEF.Migrations
{
    public partial class addedTitleColumnToExeProgramTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2dedf019-7a0c-4c04-becf-4882878ec008");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4817bae3-9dd5-4132-874d-a981e163d203");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "78d73634-079e-45bd-a9df-b7cfcb6ef97b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e66ec655-96dc-44de-b74b-226cce1d5cd5");

            migrationBuilder.AlterColumn<string>(
                name: "Goal",
                table: "ExeProgram",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(75)",
                oldMaxLength: 75,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "ExeProgram",
                type: "nvarchar(75)",
                maxLength: 75,
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "241bb269-f644-4403-a310-44fd8ac22d72", "99a72cdf-c086-4e02-ad9c-b4666c653986", "Athlete", "ATHLETE" },
                    { "3fce39cc-7e08-4c61-9644-ce84741af058", "ccf772aa-f2c8-4c56-863b-40616c930660", "Coach", "COACH" },
                    { "1b1fddc8-da6b-4146-b18f-31c6dd14e720", "7a05a2a3-c1ee-4ff9-b558-e16fee06ee79", "Head Coach", "HEAD COACH" },
                    { "95c5f7a7-8f96-4748-bc74-dc0ae601fc70", "8fd4644e-2822-460f-9023-51c324ca8610", "Administrator", "ADMINISTRATOR" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1b1fddc8-da6b-4146-b18f-31c6dd14e720");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "241bb269-f644-4403-a310-44fd8ac22d72");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3fce39cc-7e08-4c61-9644-ce84741af058");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "95c5f7a7-8f96-4748-bc74-dc0ae601fc70");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "ExeProgram");

            migrationBuilder.AlterColumn<string>(
                name: "Goal",
                table: "ExeProgram",
                type: "nvarchar(75)",
                maxLength: 75,
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
                    { "4817bae3-9dd5-4132-874d-a981e163d203", "29276622-c43c-418e-befd-310781088b5b", "Athlete", "ATHLETE" },
                    { "2dedf019-7a0c-4c04-becf-4882878ec008", "162e6e85-ad6b-4035-bf74-1c8f76945674", "Coach", "COACH" },
                    { "78d73634-079e-45bd-a9df-b7cfcb6ef97b", "8c1afb98-edc5-4235-a024-ce8bd718f4c8", "Head Coach", "HEAD COACH" },
                    { "e66ec655-96dc-44de-b74b-226cce1d5cd5", "129bfc41-6a7f-4f1d-a489-5e163479a83b", "Administrator", "ADMINISTRATOR" }
                });
        }
    }
}

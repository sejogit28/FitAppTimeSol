using Microsoft.EntityFrameworkCore.Migrations;

namespace FitAppDataStoreEF.Migrations
{
    public partial class AddedFitAppUserIdFKToOrganizationTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "79242580-5367-4ac3-a85d-b4905fb0fd0b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9aad10ae-0a13-4531-a15c-e43b99ec5855");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ac86c1ac-4b42-49eb-bea5-b0e193cf9ed3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f7bcfe87-1067-4206-887d-1f91e59e60ae");

            migrationBuilder.AddColumn<string>(
                name: "FitAppUserId",
                table: "Organizations",
                type: "nvarchar(450)",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Organizations_FitAppUserId",
                table: "Organizations",
                column: "FitAppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Organizations_AspNetUsers_FitAppUserId",
                table: "Organizations",
                column: "FitAppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Organizations_AspNetUsers_FitAppUserId",
                table: "Organizations");

            migrationBuilder.DropIndex(
                name: "IX_Organizations_FitAppUserId",
                table: "Organizations");

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

            migrationBuilder.DropColumn(
                name: "FitAppUserId",
                table: "Organizations");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "79242580-5367-4ac3-a85d-b4905fb0fd0b", "80a6924b-19dc-4b55-b2ce-444fd92410b3", "Athlete", "ATHLETE" },
                    { "ac86c1ac-4b42-49eb-bea5-b0e193cf9ed3", "a2a8cbba-a99d-4f51-887d-3db6cdac3c25", "Coach", "COACH" },
                    { "9aad10ae-0a13-4531-a15c-e43b99ec5855", "764cc3c3-39d2-473f-a759-027dbf9b881b", "Head Coach", "HEAD COACH" },
                    { "f7bcfe87-1067-4206-887d-1f91e59e60ae", "f05ab25b-4246-44c0-b49c-9f4eae88da01", "Administrator", "ADMINISTRATOR" }
                });
        }
    }
}

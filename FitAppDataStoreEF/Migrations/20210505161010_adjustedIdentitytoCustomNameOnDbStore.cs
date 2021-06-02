using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FitAppDataStoreEF.Migrations
{
    public partial class adjustedIdentitytoCustomNameOnDbStore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "33267863-5757-4436-ad8c-6a400f1c399a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "59008d9a-35c4-47bd-9d33-3e3a9c04b82d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c5a8a465-3495-4a86-b827-a1de0c218149");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e6ed6b79-72ab-4dfe-8930-23b1b8e083b8");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateAdded",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1306be6b-02f5-470d-8558-b413cf2da526", "4863e5a1-b495-4c30-98c1-6fb3b789a672", "Athlete", "ATHLETE" },
                    { "a1d4eeb3-7317-4255-88d1-8988db60e936", "05f1ebbc-e59f-436f-abac-1e96246a2524", "Coach", "COACH" },
                    { "7a123f11-9fd6-408a-9902-6803e2f21348", "576b52bb-46ce-4c4f-979d-b2abbd2f4c37", "Head Coach", "HEAD COACH" },
                    { "79b9697b-a2f9-4385-8c6e-734a54b3940b", "0e68d818-1bfd-4828-af53-9a121fdafc19", "Administrator", "ADMINISTRATOR" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1306be6b-02f5-470d-8558-b413cf2da526");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "79b9697b-a2f9-4385-8c6e-734a54b3940b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7a123f11-9fd6-408a-9902-6803e2f21348");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a1d4eeb3-7317-4255-88d1-8988db60e936");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateAdded",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "e6ed6b79-72ab-4dfe-8930-23b1b8e083b8", "00422203-096f-49ad-a869-8868df9047a1", "Athlete", "ATHLETE" },
                    { "59008d9a-35c4-47bd-9d33-3e3a9c04b82d", "80f91ed6-7c1b-4450-89ce-dbee5524655c", "Coach", "COACH" },
                    { "33267863-5757-4436-ad8c-6a400f1c399a", "8a0e1c25-30eb-4f23-8d18-e089a710a977", "Head Coach", "HEAD COACH" },
                    { "c5a8a465-3495-4a86-b827-a1de0c218149", "e596863c-63fc-46a7-98c2-6f3149d2fe70", "Administrator", "ADMINISTRATOR" }
                });
        }
    }
}

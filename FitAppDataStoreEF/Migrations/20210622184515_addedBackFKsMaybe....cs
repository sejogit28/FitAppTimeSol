using Microsoft.EntityFrameworkCore.Migrations;

namespace FitAppDataStoreEF.Migrations
{
    public partial class addedBackFKsMaybe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateIndex(
                name: "IX_Exe_ExeWorkoutExeWorkoutId",
                table: "Exe",
                column: "ExeWorkoutExeWorkoutId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exe_ExeWorkout_ExeWorkoutExeWorkoutId",
                table: "Exe",
                column: "ExeWorkoutExeWorkoutId",
                principalTable: "ExeWorkout",
                principalColumn: "ExeWorkoutId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exe_ExeWorkout_ExeWorkoutExeWorkoutId",
                table: "Exe");

            migrationBuilder.DropIndex(
                name: "IX_Exe_ExeWorkoutExeWorkoutId",
                table: "Exe");

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
    }
}

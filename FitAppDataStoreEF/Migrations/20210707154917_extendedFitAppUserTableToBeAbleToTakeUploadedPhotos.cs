using Microsoft.EntityFrameworkCore.Migrations;

namespace FitAppDataStoreEF.Migrations
{
    public partial class extendedFitAppUserTableToBeAbleToTakeUploadedPhotos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0aebc334-9191-46da-814e-0dc26ea5c10a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0e55a74a-ec33-4c9f-8d7e-d878a0c8812e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1e40a62f-9a30-4a85-b450-f7056f102d6d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "24597902-ac56-4c9b-9139-6363c455783e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "64ff9410-9f8c-4685-a638-07856bc26cd0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7974bd32-8bf9-4a11-a0c4-65f1f334e5b8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7a3ff640-ac1d-4d52-8c29-8e6971fbcafe");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c87227ab-2e95-4055-b17a-a3121cf99919");

            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "AspNetUsers",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "ea7078f8-ca83-445e-9f95-4b484efd10bb", "7ea0ab4b-2193-4814-a59b-4bdd26653b97", "Athlete", "ATHLETE" },
                    { "adb15ade-517d-4d07-98de-bdeab7dd7565", "d104edfb-36f0-4172-9474-4330a1a1e2b7", "Coach", "COACH" },
                    { "bd63eba9-3233-4a52-b14f-d80dffee54f6", "7ed04876-28cd-4b90-8cbb-755375870f48", "Level 1 Organization", "LEVEL 1 ORGANIZATION" },
                    { "58fd24a7-69f5-4f70-91f0-e03c3599965c", "d3d833e9-e020-4412-ae80-01c9e7a76d38", "Level 2 Organization", "LEVEL 2 ORGANIZATION" },
                    { "ce5fab8e-5508-4983-9d5d-0e426d259ac0", "97a96156-3824-4fa4-924a-fa1ef9617b11", "Level 3 Organization", "LEVEL 3 LARGE ORGANIZATION" },
                    { "b76b097d-86c4-4c09-b041-f62ae93bb67b", "85e6cf60-45c4-4db1-97a2-a3e036a13215", "Level 4 Organization", "LEVEL 4 ORGANIZATION" },
                    { "a665a333-3989-43f7-b6f7-9f88ad9953ab", "40cd5bd9-2bbb-4c24-9bdd-d76bce2eaca8", "Level 5 Organization", "LEVEL 5 ORGANIZATION" },
                    { "1a8ed796-fd5d-48ba-a59b-1d982ea4758c", "e627b23c-f583-48b0-b91f-5b72d729cdfc", "Administrator", "ADMINISTRATOR" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1a8ed796-fd5d-48ba-a59b-1d982ea4758c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "58fd24a7-69f5-4f70-91f0-e03c3599965c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a665a333-3989-43f7-b6f7-9f88ad9953ab");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "adb15ade-517d-4d07-98de-bdeab7dd7565");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b76b097d-86c4-4c09-b041-f62ae93bb67b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bd63eba9-3233-4a52-b14f-d80dffee54f6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ce5fab8e-5508-4983-9d5d-0e426d259ac0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ea7078f8-ca83-445e-9f95-4b484efd10bb");

            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7a3ff640-ac1d-4d52-8c29-8e6971fbcafe", "d124fde7-51c5-449b-bacd-fd5f0f51a13c", "Athlete", "ATHLETE" },
                    { "0aebc334-9191-46da-814e-0dc26ea5c10a", "0adf2ccf-4f92-44fa-8e74-92d5768599c9", "Coach", "COACH" },
                    { "24597902-ac56-4c9b-9139-6363c455783e", "1747df97-e90a-4a60-aa8f-0d2e170444dd", "Level 1 Organization", "LEVEL 1 ORGANIZATION" },
                    { "0e55a74a-ec33-4c9f-8d7e-d878a0c8812e", "a9fbf586-1c08-4a6e-935c-fa77db84b0b6", "Level 2 Organization", "LEVEL 2 ORGANIZATION" },
                    { "1e40a62f-9a30-4a85-b450-f7056f102d6d", "ba655617-1cd5-4e83-bced-6ea0636532c3", "Level 3 Organization", "LEVEL 3 LARGE ORGANIZATION" },
                    { "c87227ab-2e95-4055-b17a-a3121cf99919", "b75b946e-e157-4746-8631-fdaf7195541b", "Level 4 Organization", "LEVEL 4 ORGANIZATION" },
                    { "7974bd32-8bf9-4a11-a0c4-65f1f334e5b8", "20d57cbd-e85e-4752-8560-5e1a56ac633e", "Level 5 Organization", "LEVEL 5 ORGANIZATION" },
                    { "64ff9410-9f8c-4685-a638-07856bc26cd0", "a854ee22-701b-4421-a527-9e9a05c6a636", "Administrator", "ADMINISTRATOR" }
                });
        }
    }
}

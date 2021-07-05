using Microsoft.EntityFrameworkCore.Migrations;

namespace FitAppDataStoreEF.Migrations
{
    public partial class createdTestedAndImplementedRoutesForWorkingWithMTMOrganizationModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "26f89a5c-65a4-4120-9ba3-04a41e983e09");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29312808-d130-4582-8837-bccb6cb1186f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3def6517-1968-4fe2-bbd4-b48556aa8346");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4312e2f7-91c8-47bd-ba9c-5855fe2bc294");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "598e31c3-c7c8-4971-b402-19706b3192a4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9c569e6d-9ecf-4185-b8d0-f1a64e01ee6f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d725b8c6-f3a1-4a4c-97dd-a277864a3d0a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e23c4c8a-3f68-4dda-8c0e-1f178528bdd4");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "598e31c3-c7c8-4971-b402-19706b3192a4", "1907d258-f203-4216-b2aa-112b53d26057", "Athlete", "ATHLETE" },
                    { "26f89a5c-65a4-4120-9ba3-04a41e983e09", "05ded6f5-9022-4a7d-a193-df36e5cebcb3", "Coach", "COACH" },
                    { "9c569e6d-9ecf-4185-b8d0-f1a64e01ee6f", "d77253d4-7e95-4fe2-a58f-d9f4ed427479", "Level 1 Organization", "LEVEL 1 ORGANIZATION" },
                    { "3def6517-1968-4fe2-bbd4-b48556aa8346", "d7977576-cb9a-4b3f-8bc1-eee2471afa54", "Level 2 Organization", "LEVEL 2 ORGANIZATION" },
                    { "e23c4c8a-3f68-4dda-8c0e-1f178528bdd4", "c19df55d-86ee-4756-98cc-81cc8f75cf70", "Level 3 Organization", "LEVEL 3 LARGE ORGANIZATION" },
                    { "d725b8c6-f3a1-4a4c-97dd-a277864a3d0a", "af3a22eb-298c-4b31-a932-f48462a61759", "Level 4 Organization", "LEVEL 4 ORGANIZATION" },
                    { "4312e2f7-91c8-47bd-ba9c-5855fe2bc294", "666c6b3c-c078-4916-b094-981a11decc27", "Level 5 Organization", "LEVEL 5 ORGANIZATION" },
                    { "29312808-d130-4582-8837-bccb6cb1186f", "fd32d02f-1524-4782-942c-2712881a7c77", "Administrator", "ADMINISTRATOR" }
                });
        }
    }
}

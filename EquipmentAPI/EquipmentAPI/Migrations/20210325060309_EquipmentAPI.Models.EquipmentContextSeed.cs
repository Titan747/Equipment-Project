using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EquipmentAPI.Migrations
{
    public partial class EquipmentAPIModelsEquipmentContextSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Equipments",
                columns: new[] { "EquipmentId", "EquipmentAmount", "EquipmentName", "EquipmentPurchaseDate" },
                values: new object[] { 1L, 77777, "Titan", new DateTime(1979, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Equipments",
                columns: new[] { "EquipmentId", "EquipmentAmount", "EquipmentName", "EquipmentPurchaseDate" },
                values: new object[] { 2L, 11111, "Tony", new DateTime(1981, 7, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "EquipmentId",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "EquipmentId",
                keyValue: 2L);
        }
    }
}

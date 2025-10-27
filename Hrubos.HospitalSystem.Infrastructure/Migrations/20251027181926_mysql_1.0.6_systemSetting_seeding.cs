using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hrubos.HospitalSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class mysql_106_systemSetting_seeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NextDose",
                table: "Vaccination");

            migrationBuilder.RenameColumn(
                name: "Notes",
                table: "Examination",
                newName: "ProblemDescription");

            migrationBuilder.AddColumn<int>(
                name: "MaxExaminationPerDay",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SystemSetting",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Key = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Value = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemSetting", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "MaxExaminationPerDay", "SecurityStamp" },
                values: new object[] { "dfe4ac27-981c-4ea3-847e-a0dcbd82e345", null, "9037eee47c5d46849f34ace6795a033c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "MaxExaminationPerDay", "SecurityStamp" },
                values: new object[] { "d5ad6c53-d0b3-4f7a-b30b-419f244dfbee", 10, "1509007b77b549689fcfce85bb7fc67b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "MaxExaminationPerDay", "SecurityStamp" },
                values: new object[] { "81bd4d38-fe75-4c92-87f4-60c2550486c6", 5, "918503b3812a4aa7856f0c4b59244f14" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "MaxExaminationPerDay", "SecurityStamp" },
                values: new object[] { "1eee41b9-83c1-415b-b7e7-262521313624", 2, "15e7b7f54e0d4976b40ec2c229101325" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ConcurrencyStamp", "MaxExaminationPerDay", "SecurityStamp" },
                values: new object[] { "e9f1c3e9-441f-48e0-9b57-a451ee6cdd7b", 0, "6fd5a95cdec948399ebb511b56fc2f1f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ConcurrencyStamp", "MaxExaminationPerDay", "SecurityStamp" },
                values: new object[] { "ff1e2452-0287-4d15-a4ec-7db1256378d6", null, "d100a6d196064feb9d59a2da11d9c8f5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ConcurrencyStamp", "MaxExaminationPerDay", "SecurityStamp" },
                values: new object[] { "aa52e817-44ac-40c7-83f0-c591fcc001f0", null, "d14301a513194498ac43fe7c3d38455c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "ConcurrencyStamp", "MaxExaminationPerDay", "SecurityStamp" },
                values: new object[] { "89877e9c-e500-4d81-9baf-f79f3bafa85a", null, "cdf3ef419ad04d28a1ec7d3c2ad2a3c1" });

            migrationBuilder.UpdateData(
                table: "Examination",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateTime", "ProblemDescription" },
                values: new object[] { new DateTime(2025, 10, 17, 19, 19, 26, 61, DateTimeKind.Local).AddTicks(3047), "Vysoký tlak" });

            migrationBuilder.UpdateData(
                table: "Examination",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateTime",
                value: new DateTime(2025, 10, 22, 19, 19, 26, 62, DateTimeKind.Local).AddTicks(6153));

            migrationBuilder.UpdateData(
                table: "Examination",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateTime", "ProblemDescription" },
                values: new object[] { new DateTime(2025, 10, 25, 19, 19, 26, 62, DateTimeKind.Local).AddTicks(6167), "Bolest kloubů" });

            migrationBuilder.UpdateData(
                table: "Examination",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateTime", "ProblemDescription" },
                values: new object[] { new DateTime(2025, 10, 19, 19, 19, 26, 62, DateTimeKind.Local).AddTicks(6171), "Bolest zápěstí" });

            migrationBuilder.InsertData(
                table: "SystemSetting",
                columns: new[] { "Id", "Key", "Value" },
                values: new object[] { 1, "MaxVaccinationPerDay", "20" });

            migrationBuilder.UpdateData(
                table: "Vaccination",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateTime",
                value: new DateTime(2024, 10, 27, 19, 19, 26, 63, DateTimeKind.Local).AddTicks(243));

            migrationBuilder.UpdateData(
                table: "Vaccination",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateTime",
                value: new DateTime(2025, 2, 27, 19, 19, 26, 63, DateTimeKind.Local).AddTicks(540));

            migrationBuilder.UpdateData(
                table: "Vaccination",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateTime",
                value: new DateTime(2025, 4, 27, 19, 19, 26, 63, DateTimeKind.Local).AddTicks(543));

            migrationBuilder.UpdateData(
                table: "Vaccination",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateTime",
                value: new DateTime(2025, 7, 27, 19, 19, 26, 63, DateTimeKind.Local).AddTicks(544));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SystemSetting");

            migrationBuilder.DropColumn(
                name: "MaxExaminationPerDay",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "ProblemDescription",
                table: "Examination",
                newName: "Notes");

            migrationBuilder.AddColumn<DateTime>(
                name: "NextDose",
                table: "Vaccination",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "c7f9499d-dc35-4df8-af69-01c324f7978f", "4b2c649c54f645ce87d0a5bab2300bc2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "cde480e0-53be-40de-a746-f71e19c3e968", "6fd7297ae8f04872a9eda6314c038ae0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "33d5e71a-cd55-4e64-9531-9961f7ab18e0", "88ba44dd5e8a422bb15f5293689aa2e5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "a0aee65b-b82e-44a5-954a-0b1737af0ee9", "0f2ba195e9c142e9974a379026eedfea" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "520a35d8-69c8-4821-8b97-7dc9f18ad3e1", "9786a9a09e6243ceb14f661a42154e5d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "247da5bc-c59f-40ef-b0ba-938430c9148f", "7e47fba95c6b4e8f8db372a876ece98f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "8c6587d2-d464-46d9-828f-ef566c7c6c0a", "01fc56ad197349e5a5f8a5605cec8dda" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "e3527a4a-3b21-4daf-8eb1-4e69fe8a6d18", "41d7fba66015490dae07df08701ee4ca" });

            migrationBuilder.UpdateData(
                table: "Examination",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateTime", "Notes" },
                values: new object[] { new DateTime(2025, 10, 17, 0, 25, 46, 825, DateTimeKind.Local).AddTicks(2667), "Kontrola tlaku" });

            migrationBuilder.UpdateData(
                table: "Examination",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateTime",
                value: new DateTime(2025, 10, 22, 0, 25, 46, 826, DateTimeKind.Local).AddTicks(5066));

            migrationBuilder.UpdateData(
                table: "Examination",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateTime", "Notes" },
                values: new object[] { new DateTime(2025, 10, 25, 0, 25, 46, 826, DateTimeKind.Local).AddTicks(5080), "Vyšetření kloubů" });

            migrationBuilder.UpdateData(
                table: "Examination",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateTime", "Notes" },
                values: new object[] { new DateTime(2025, 10, 19, 0, 25, 46, 826, DateTimeKind.Local).AddTicks(5082), "Vyšetření ruky" });

            migrationBuilder.UpdateData(
                table: "Vaccination",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateTime", "NextDose" },
                values: new object[] { new DateTime(2024, 10, 27, 0, 25, 46, 826, DateTimeKind.Local).AddTicks(9588), new DateTime(2026, 4, 27, 0, 25, 46, 826, DateTimeKind.Local).AddTicks(9733) });

            migrationBuilder.UpdateData(
                table: "Vaccination",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateTime", "NextDose" },
                values: new object[] { new DateTime(2025, 2, 27, 0, 25, 46, 827, DateTimeKind.Local).AddTicks(57), new DateTime(2026, 2, 27, 0, 25, 46, 827, DateTimeKind.Local).AddTicks(60) });

            migrationBuilder.UpdateData(
                table: "Vaccination",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateTime", "NextDose" },
                values: new object[] { new DateTime(2025, 4, 27, 0, 25, 46, 827, DateTimeKind.Local).AddTicks(62), new DateTime(2026, 4, 27, 0, 25, 46, 827, DateTimeKind.Local).AddTicks(63) });

            migrationBuilder.UpdateData(
                table: "Vaccination",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateTime", "NextDose" },
                values: new object[] { new DateTime(2025, 7, 27, 0, 25, 46, 827, DateTimeKind.Local).AddTicks(64), new DateTime(2026, 10, 27, 0, 25, 46, 827, DateTimeKind.Local).AddTicks(65) });
        }
    }
}

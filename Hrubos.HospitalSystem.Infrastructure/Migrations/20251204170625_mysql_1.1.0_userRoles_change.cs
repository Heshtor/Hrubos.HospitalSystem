using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Hrubos.HospitalSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class mysql_110_userRoles_change : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 3, 4 });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 3, 5 });

            migrationBuilder.UpdateData(
                table: "Examination",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateTime",
                value: new DateTime(2025, 11, 24, 18, 6, 24, 918, DateTimeKind.Local).AddTicks(8043));

            migrationBuilder.UpdateData(
                table: "Examination",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateTime",
                value: new DateTime(2025, 11, 29, 18, 6, 24, 920, DateTimeKind.Local).AddTicks(1593));

            migrationBuilder.UpdateData(
                table: "Examination",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateTime",
                value: new DateTime(2025, 12, 2, 18, 6, 24, 920, DateTimeKind.Local).AddTicks(1607));

            migrationBuilder.UpdateData(
                table: "Examination",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateTime",
                value: new DateTime(2025, 11, 26, 18, 6, 24, 920, DateTimeKind.Local).AddTicks(1610));

            migrationBuilder.UpdateData(
                table: "ExaminationResult",
                keyColumn: "Id",
                keyValue: 2,
                column: "AttachmentSrc",
                value: "\\attachments\\examinationResults\\erecept.png");

            migrationBuilder.UpdateData(
                table: "ExaminationResult",
                keyColumn: "Id",
                keyValue: 3,
                column: "AttachmentSrc",
                value: "\\attachments\\examinationResults\\rentgen.pdf");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "753ef8d3-8d1f-4161-857c-5b45762b81cb", "1c9fcff7ad1c431597dab79fbf3ebd0c" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "e00f84bc-49ce-432c-9095-d590b0279ac7", "61e983fbaca2474a958e15d65cfb65b7" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "8a82502a-37bd-4ea0-8c0a-46826aac4061", "ed14b93cd67047bdbe899e9b7475fd39" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "442884b4-d816-488d-942a-fa86c31489e4", "3f0c7b2aa93f4d838a65a3cdda10e75e" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "aae0fe29-2549-45ce-9221-2e12b87c6d65", "4d088408704c4be4ad55880efcfb8b35" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "SecurityStamp" },
                values: new object[] { "74d60400-96fd-4c18-b4ae-9fa113753a2c", "PATIENT1", "514c4ac13b7f4880a9da85d6d2323ae0" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "SecurityStamp" },
                values: new object[] { "e38fb7f8-8cc9-4b9f-abff-bacd9c3e08a7", "PATIENT2", "e81d3e58419246af884d6959d979d742" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "SecurityStamp" },
                values: new object[] { "9057178c-3d36-4f99-9c5e-f4a4ae5241cb", "PATIENT3", "7c74be02ae1f4b2bb35b80361a19fa97" });

            migrationBuilder.UpdateData(
                table: "Vaccination",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateTime",
                value: new DateTime(2024, 12, 4, 18, 6, 24, 920, DateTimeKind.Local).AddTicks(5894));

            migrationBuilder.UpdateData(
                table: "Vaccination",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateTime",
                value: new DateTime(2025, 4, 4, 18, 6, 24, 920, DateTimeKind.Local).AddTicks(6192));

            migrationBuilder.UpdateData(
                table: "Vaccination",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateTime",
                value: new DateTime(2025, 6, 4, 18, 6, 24, 920, DateTimeKind.Local).AddTicks(6195));

            migrationBuilder.UpdateData(
                table: "Vaccination",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateTime",
                value: new DateTime(2025, 9, 4, 18, 6, 24, 920, DateTimeKind.Local).AddTicks(6197));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Examination",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateTime",
                value: new DateTime(2025, 11, 19, 19, 15, 5, 781, DateTimeKind.Local).AddTicks(285));

            migrationBuilder.UpdateData(
                table: "Examination",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateTime",
                value: new DateTime(2025, 11, 24, 19, 15, 5, 782, DateTimeKind.Local).AddTicks(3906));

            migrationBuilder.UpdateData(
                table: "Examination",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateTime",
                value: new DateTime(2025, 11, 27, 19, 15, 5, 782, DateTimeKind.Local).AddTicks(3921));

            migrationBuilder.UpdateData(
                table: "Examination",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateTime",
                value: new DateTime(2025, 11, 21, 19, 15, 5, 782, DateTimeKind.Local).AddTicks(3924));

            migrationBuilder.UpdateData(
                table: "ExaminationResult",
                keyColumn: "Id",
                keyValue: 2,
                column: "AttachmentSrc",
                value: null);

            migrationBuilder.UpdateData(
                table: "ExaminationResult",
                keyColumn: "Id",
                keyValue: 3,
                column: "AttachmentSrc",
                value: "\\attachments\\examinationResults\\cloub_knee_xray.jpg");

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { 2, 1 },
                    { 3, 1 },
                    { 3, 2 },
                    { 3, 3 },
                    { 3, 4 },
                    { 3, 5 }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "becd5cd0-d074-439c-97b1-f64f59e7d41e", "940f0fcef8284074bfedab3bc59d5833" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "01418e50-37aa-4135-962e-327d8c69fdb2", "20a11a4feb64490dbe25445ebb909ef2" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "b655dcdc-b4a8-4e98-a81d-d8073872941d", "953a8cadbd62446ca59ea22c7a758c0c" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "6f616f48-a103-4b7b-a343-d80c3fbdfc7a", "31970a56c0ee41ae821cab291b8a7437" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "05c7bc75-8b4a-47a6-bf8c-22b7261e309c", "7648ac0009294b89b91c75293a081f32" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "SecurityStamp" },
                values: new object[] { "1b658b9b-4ac9-4eeb-97b1-3a047ea21a2b", "PACIENT1", "b4e47b5e66b24d98a3530ae9f15f7056" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "SecurityStamp" },
                values: new object[] { "83b0fe94-5b65-4348-b4c9-88d1a39a7ba7", "PACIENT2", "57ecb94df4634385a0b691b3968b08c7" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "SecurityStamp" },
                values: new object[] { "e2a384b8-60da-4c4b-93de-56ced6e85c8a", "PACIENT3", "fd6b4cf03bca4e21923f6d43c0757b08" });

            migrationBuilder.UpdateData(
                table: "Vaccination",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateTime",
                value: new DateTime(2024, 11, 29, 19, 15, 5, 782, DateTimeKind.Local).AddTicks(8000));

            migrationBuilder.UpdateData(
                table: "Vaccination",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateTime",
                value: new DateTime(2025, 3, 29, 19, 15, 5, 782, DateTimeKind.Local).AddTicks(8385));

            migrationBuilder.UpdateData(
                table: "Vaccination",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateTime",
                value: new DateTime(2025, 5, 29, 19, 15, 5, 782, DateTimeKind.Local).AddTicks(8389));

            migrationBuilder.UpdateData(
                table: "Vaccination",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateTime",
                value: new DateTime(2025, 8, 29, 19, 15, 5, 782, DateTimeKind.Local).AddTicks(8391));
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hrubos.HospitalSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class mysql_107_examinationResult : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Attachment",
                table: "ExaminationResult",
                newName: "AttachmentSrc");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "de87a082-5461-40fe-9f7f-7119ffec0f60", "f38409844898492483187f69130e973f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "59ea360b-0776-4e99-aeb9-10668f24f758", "3d98cd58736245a19cafb57b12e671a5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "52022b32-75f1-41a5-9b63-2304ed5bf072", "f423f1802efe4b9dbf0bd391c0edb8e2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "f55301f4-7dc5-40bc-8b70-0c52ad249369", "d9da53a1deb746e2ba05339c507252e1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "e2faea44-bf57-408b-a3a8-c37af5b967e6", "64a659de93ab49918f6fc67dec0b2b3e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "8cb9e147-131a-442a-a62d-731c5277658b", "2d92ee082d9245ad86758e4405bdca8d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "976015b3-be92-4d8e-9965-aef4154491d9", "933bf2efeeb942468dcf20b0e6f4292e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "21d97ced-2483-44b4-97b7-0fb309d73910", "f344aa64ec60426f894d2c247e2c4033" });

            migrationBuilder.UpdateData(
                table: "Examination",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateTime",
                value: new DateTime(2025, 11, 8, 10, 15, 29, 834, DateTimeKind.Local).AddTicks(5489));

            migrationBuilder.UpdateData(
                table: "Examination",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateTime",
                value: new DateTime(2025, 11, 13, 10, 15, 29, 836, DateTimeKind.Local).AddTicks(8203));

            migrationBuilder.UpdateData(
                table: "Examination",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateTime",
                value: new DateTime(2025, 11, 16, 10, 15, 29, 836, DateTimeKind.Local).AddTicks(8228));

            migrationBuilder.UpdateData(
                table: "Examination",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateTime",
                value: new DateTime(2025, 11, 10, 10, 15, 29, 836, DateTimeKind.Local).AddTicks(8231));

            migrationBuilder.UpdateData(
                table: "ExaminationResult",
                keyColumn: "Id",
                keyValue: 3,
                column: "AttachmentSrc",
                value: "/attachments/examinationResults/cloub_knee_xray.jpg");

            migrationBuilder.UpdateData(
                table: "Vaccination",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateTime",
                value: new DateTime(2024, 11, 18, 10, 15, 29, 837, DateTimeKind.Local).AddTicks(6200));

            migrationBuilder.UpdateData(
                table: "Vaccination",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateTime",
                value: new DateTime(2025, 3, 18, 10, 15, 29, 837, DateTimeKind.Local).AddTicks(6915));

            migrationBuilder.UpdateData(
                table: "Vaccination",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateTime",
                value: new DateTime(2025, 5, 18, 10, 15, 29, 837, DateTimeKind.Local).AddTicks(6924));

            migrationBuilder.UpdateData(
                table: "Vaccination",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateTime",
                value: new DateTime(2025, 8, 18, 10, 15, 29, 837, DateTimeKind.Local).AddTicks(6927));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AttachmentSrc",
                table: "ExaminationResult",
                newName: "Attachment");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "dfe4ac27-981c-4ea3-847e-a0dcbd82e345", "9037eee47c5d46849f34ace6795a033c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "d5ad6c53-d0b3-4f7a-b30b-419f244dfbee", "1509007b77b549689fcfce85bb7fc67b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "81bd4d38-fe75-4c92-87f4-60c2550486c6", "918503b3812a4aa7856f0c4b59244f14" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "1eee41b9-83c1-415b-b7e7-262521313624", "15e7b7f54e0d4976b40ec2c229101325" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "e9f1c3e9-441f-48e0-9b57-a451ee6cdd7b", "6fd5a95cdec948399ebb511b56fc2f1f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "ff1e2452-0287-4d15-a4ec-7db1256378d6", "d100a6d196064feb9d59a2da11d9c8f5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "aa52e817-44ac-40c7-83f0-c591fcc001f0", "d14301a513194498ac43fe7c3d38455c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "89877e9c-e500-4d81-9baf-f79f3bafa85a", "cdf3ef419ad04d28a1ec7d3c2ad2a3c1" });

            migrationBuilder.UpdateData(
                table: "Examination",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateTime",
                value: new DateTime(2025, 10, 17, 19, 19, 26, 61, DateTimeKind.Local).AddTicks(3047));

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
                column: "DateTime",
                value: new DateTime(2025, 10, 25, 19, 19, 26, 62, DateTimeKind.Local).AddTicks(6167));

            migrationBuilder.UpdateData(
                table: "Examination",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateTime",
                value: new DateTime(2025, 10, 19, 19, 19, 26, 62, DateTimeKind.Local).AddTicks(6171));

            migrationBuilder.UpdateData(
                table: "ExaminationResult",
                keyColumn: "Id",
                keyValue: 3,
                column: "Attachment",
                value: "cloub_knee_xray.jpg");

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
    }
}

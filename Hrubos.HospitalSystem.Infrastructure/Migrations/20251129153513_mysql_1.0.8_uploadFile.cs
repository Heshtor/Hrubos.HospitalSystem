using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hrubos.HospitalSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class mysql_108_uploadFile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "192571c6-9cad-474d-89a8-6bf4fe7200c1", "379714f7bfab4de6b58a45e9472e2a4e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "53dd5d36-d946-4fe8-abac-ff2ad05283d1", "53dd784b4e0c4108af7a5ef91f5ccc74" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "251aebeb-31aa-47e0-a65b-1af9d0624028", "a1371586366c46bbb75b5b18bd2e7208" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "c1d1104d-1326-4294-a10f-497746cf7e4a", "098c2bc1d4344e9fa84f593379a87252" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "41f71395-6f37-48cb-b4e5-3186cf65fb8e", "52d238f5d4344d04ba9893e8f3813d04" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "c22e96b5-bab9-469e-92e5-ee2c6e4e494e", "5c8d94780bd64c6da55f65345ba2c29e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "4d8ebb1d-4fa0-4898-ad5a-e148c34961bf", "8ab4207868fb47e091dbc9fd6b1e9ce1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "432f973a-b112-43d4-99e9-b42a2819e322", "ee690ad7e64f40f6bde8a37bf97c10b0" });

            migrationBuilder.UpdateData(
                table: "Examination",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateTime",
                value: new DateTime(2025, 11, 19, 16, 35, 12, 543, DateTimeKind.Local).AddTicks(599));

            migrationBuilder.UpdateData(
                table: "Examination",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateTime",
                value: new DateTime(2025, 11, 24, 16, 35, 12, 544, DateTimeKind.Local).AddTicks(3551));

            migrationBuilder.UpdateData(
                table: "Examination",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateTime",
                value: new DateTime(2025, 11, 27, 16, 35, 12, 544, DateTimeKind.Local).AddTicks(3564));

            migrationBuilder.UpdateData(
                table: "Examination",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateTime",
                value: new DateTime(2025, 11, 21, 16, 35, 12, 544, DateTimeKind.Local).AddTicks(3567));

            migrationBuilder.UpdateData(
                table: "ExaminationResult",
                keyColumn: "Id",
                keyValue: 3,
                column: "AttachmentSrc",
                value: "\\attachments\\examinationResults\\cloub_knee_xray.jpg");

            migrationBuilder.UpdateData(
                table: "Vaccination",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateTime",
                value: new DateTime(2024, 11, 29, 16, 35, 12, 544, DateTimeKind.Local).AddTicks(7606));

            migrationBuilder.UpdateData(
                table: "Vaccination",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateTime",
                value: new DateTime(2025, 3, 29, 16, 35, 12, 544, DateTimeKind.Local).AddTicks(7970));

            migrationBuilder.UpdateData(
                table: "Vaccination",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateTime",
                value: new DateTime(2025, 5, 29, 16, 35, 12, 544, DateTimeKind.Local).AddTicks(7974));

            migrationBuilder.UpdateData(
                table: "Vaccination",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateTime",
                value: new DateTime(2025, 8, 29, 16, 35, 12, 544, DateTimeKind.Local).AddTicks(7975));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}

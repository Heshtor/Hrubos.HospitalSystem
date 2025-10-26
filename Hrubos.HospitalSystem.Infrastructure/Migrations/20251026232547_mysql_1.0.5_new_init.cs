using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hrubos.HospitalSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class mysql_105_new_init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "33d5e71a-cd55-4e64-9531-9961f7ab18e0", "AQAAAAEAACcQAAAAEK4DkND+5IwQiNI01DelkSwKPGQnzZAxCmobmvF3J0w5Xr6YO4bUtzjJwe2qRzUv7g==", "88ba44dd5e8a422bb15f5293689aa2e5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a0aee65b-b82e-44a5-954a-0b1737af0ee9", "AQAAAAEAACcQAAAAEMK02V+4Wdm0lgraNwSBHPhhYUFmVpoCrp103XwzNXTFK6/s8xx0AAdpsd2G2KquQQ==", "0f2ba195e9c142e9974a379026eedfea" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "520a35d8-69c8-4821-8b97-7dc9f18ad3e1", "AQAAAAEAACcQAAAAEGrcdYyAHwCXTbk9VS3VItkcEq4bhgiPBFetA8rLbp/6Asw87PI2TqWE5csu8u6TDA==", "9786a9a09e6243ceb14f661a42154e5d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "247da5bc-c59f-40ef-b0ba-938430c9148f", "AQAAAAEAACcQAAAAEBacwHfAQ8oysuC+yEOFP2TakEie2+73wHf89V+TJX+Ioy5NfCTZkS0U/P5kN7yjmg==", "7e47fba95c6b4e8f8db372a876ece98f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8c6587d2-d464-46d9-828f-ef566c7c6c0a", "AQAAAAEAACcQAAAAEK31Pd3GzmAcXrVtoSezhRdeqGp0l5c6Zl0IjUvn6vAeslrjG7bgOuN4jHqQBRDbZA==", "01fc56ad197349e5a5f8a5605cec8dda" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e3527a4a-3b21-4daf-8eb1-4e69fe8a6d18", "AQAAAAEAACcQAAAAEGDwHucn5uWF1684moFrwbqoaym+z0IHUiN+/EDQnXgz6HiEbGnaqFT136phybDc4g==", "41d7fba66015490dae07df08701ee4ca" });

            migrationBuilder.UpdateData(
                table: "Examination",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateTime",
                value: new DateTime(2025, 10, 17, 0, 25, 46, 825, DateTimeKind.Local).AddTicks(2667));

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
                column: "DateTime",
                value: new DateTime(2025, 10, 25, 0, 25, 46, 826, DateTimeKind.Local).AddTicks(5080));

            migrationBuilder.UpdateData(
                table: "Examination",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateTime",
                value: new DateTime(2025, 10, 19, 0, 25, 46, 826, DateTimeKind.Local).AddTicks(5082));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "4c72ddef-1aa7-4411-9a02-f8783dd44ca9", "d572d30355394513a9f9c043e9ab8196" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "506432e5-4fde-4c73-a54f-6b491c40a372", "3dd1981a443d473c81b8b4aa6a9af64f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "23b53f1a-574f-4e7d-aa91-4fa895389d56", "AQAAAAEAACcQAAAAECxrKr4YAVakrkIYFy7MgUA11ryq0Sgun00+cj9FnR6EHzH8EL9WRc3J60f5x2nv0g==", "279fb73875ae47cd879c99b203c3b207" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ea57e9c6-b536-4949-8821-c33c6aa32c87", "AQAAAAEAACcQAAAAECxrKr4YAVakrkIYFy7MgUA11ryq0Sgun00+cj9FnR6EHzH8EL9WRc3J60f5x2nv0g==", "ae5bf88681b44301b71cd14a895dc5fe" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3d4642f4-2169-4ada-b4b9-6f6454227581", "AQAAAAEAACcQAAAAECxrKr4YAVakrkIYFy7MgUA11ryq0Sgun00+cj9FnR6EHzH8EL9WRc3J60f5x2nv0g==", "c8ac754367164f5d88147a0f58fbf945" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a037be5a-9a37-4694-8c16-014b84fd5b18", "AQAAAAEAACcQAAAAECxrKr4YAVakrkIYFy7MgUA11ryq0Sgun00+cj9FnR6EHzH8EL9WRc3J60f5x2nv0g==", "e31f49e78c9842208d02434430c42343" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1d74d165-6a7f-43df-b89c-30f08f3aceb7", "AQAAAAEAACcQAAAAECxrKr4YAVakrkIYFy7MgUA11ryq0Sgun00+cj9FnR6EHzH8EL9WRc3J60f5x2nv0g==", "88390c5c7c9243e18c81feeb86277a26" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7900dbe2-54f4-4c77-a022-52a94694efbc", "AQAAAAEAACcQAAAAECxrKr4YAVakrkIYFy7MgUA11ryq0Sgun00+cj9FnR6EHzH8EL9WRc3J60f5x2nv0g==", "76c3da1c81144103b0a0476e8530584e" });

            migrationBuilder.UpdateData(
                table: "Examination",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateTime",
                value: new DateTime(2025, 10, 17, 0, 18, 26, 931, DateTimeKind.Local).AddTicks(7497));

            migrationBuilder.UpdateData(
                table: "Examination",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateTime",
                value: new DateTime(2025, 10, 22, 0, 18, 26, 932, DateTimeKind.Local).AddTicks(9735));

            migrationBuilder.UpdateData(
                table: "Examination",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateTime",
                value: new DateTime(2025, 10, 25, 0, 18, 26, 932, DateTimeKind.Local).AddTicks(9749));

            migrationBuilder.UpdateData(
                table: "Examination",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateTime",
                value: new DateTime(2025, 10, 19, 0, 18, 26, 932, DateTimeKind.Local).AddTicks(9752));

            migrationBuilder.UpdateData(
                table: "Vaccination",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateTime", "NextDose" },
                values: new object[] { new DateTime(2024, 10, 27, 0, 18, 26, 933, DateTimeKind.Local).AddTicks(4240), new DateTime(2026, 4, 27, 0, 18, 26, 933, DateTimeKind.Local).AddTicks(4387) });

            migrationBuilder.UpdateData(
                table: "Vaccination",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateTime", "NextDose" },
                values: new object[] { new DateTime(2025, 2, 27, 0, 18, 26, 933, DateTimeKind.Local).AddTicks(4706), new DateTime(2026, 2, 27, 0, 18, 26, 933, DateTimeKind.Local).AddTicks(4708) });

            migrationBuilder.UpdateData(
                table: "Vaccination",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateTime", "NextDose" },
                values: new object[] { new DateTime(2025, 4, 27, 0, 18, 26, 933, DateTimeKind.Local).AddTicks(4710), new DateTime(2026, 4, 27, 0, 18, 26, 933, DateTimeKind.Local).AddTicks(4711) });

            migrationBuilder.UpdateData(
                table: "Vaccination",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateTime", "NextDose" },
                values: new object[] { new DateTime(2025, 7, 27, 0, 18, 26, 933, DateTimeKind.Local).AddTicks(4718), new DateTime(2026, 10, 27, 0, 18, 26, 933, DateTimeKind.Local).AddTicks(4719) });
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Hrubos.HospitalSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class mysql_104_all_seeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DoctorPatient",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorPatient", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DoctorPatient_AspNetUsers_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DoctorPatient_AspNetUsers_PatientId",
                        column: x => x.PatientId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Examination",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DateTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Notes = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ExaminationTypeId = table.Column<int>(type: "int", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    DoctorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Examination", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Examination_AspNetUsers_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Examination_AspNetUsers_PatientId",
                        column: x => x.PatientId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Examination_ExaminationType_ExaminationTypeId",
                        column: x => x.ExaminationTypeId,
                        principalTable: "ExaminationType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Specialization",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(70)", maxLength: 70, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialization", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Vaccination",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    VaccineTypeId = table.Column<int>(type: "int", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    NextDose = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    PatientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vaccination", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vaccination_AspNetUsers_PatientId",
                        column: x => x.PatientId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Vaccination_VaccineType_VaccineTypeId",
                        column: x => x.VaccineTypeId,
                        principalTable: "VaccineType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

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
                columns: new[] { "ConcurrencyStamp", "Email", "FirstName", "LastName", "NormalizedEmail", "PhoneNumber", "SecurityStamp", "SpecializationId" },
                values: new object[] { "506432e5-4fde-4c73-a54f-6b491c40a372", "jan.novak@nemocnice.cz", "Jan", "Novák", "JAN.NOVAK@NEMOCNICE.CZ", "111222333", "3dd1981a443d473c81b8b4aa6a9af64f", 1 });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthNumber", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "SpecializationId", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 6, 0, "900101/1234", "a037be5a-9a37-4694-8c16-014b84fd5b18", "tomas.horak@email.cz", true, "Tomáš", "Horák", true, null, "TOMAS.HORAK@EMAIL.CZ", "PACIENT1", "AQAAAAEAACcQAAAAECxrKr4YAVakrkIYFy7MgUA11ryq0Sgun00+cj9FnR6EHzH8EL9WRc3J60f5x2nv0g==", "601111111", false, "e31f49e78c9842208d02434430c42343", null, false, "patient1" },
                    { 7, 0, "950202/2345", "1d74d165-6a7f-43df-b89c-30f08f3aceb7", "anna.mala@email.cz", true, "Anna", "Malá", true, null, "ANNA.MALA@EMAIL.CZ", "PACIENT2", "AQAAAAEAACcQAAAAECxrKr4YAVakrkIYFy7MgUA11ryq0Sgun00+cj9FnR6EHzH8EL9WRc3J60f5x2nv0g==", "602222222", false, "88390c5c7c9243e18c81feeb86277a26", null, false, "patient2" },
                    { 8, 0, "880303/3456", "7900dbe2-54f4-4c77-a022-52a94694efbc", "karel.novotny@email.cz", true, "Karel", "Novotný", true, null, "KAREL.NOVOTNY@EMAIL.CZ", "PACIENT3", "AQAAAAEAACcQAAAAECxrKr4YAVakrkIYFy7MgUA11ryq0Sgun00+cj9FnR6EHzH8EL9WRc3J60f5x2nv0g==", "603333333", false, "76c3da1c81144103b0a0476e8530584e", null, false, "patient3" }
                });

            migrationBuilder.InsertData(
                table: "Specialization",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Oftalmologie" },
                    { 2, "Chirurgie" },
                    { 3, "Pediatrie" },
                    { 4, "Kardiologie" },
                    { 5, "Pneumologie" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { 3, 6 },
                    { 3, 7 },
                    { 3, 8 }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthNumber", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "SpecializationId", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 3, 0, null, "23b53f1a-574f-4e7d-aa91-4fa895389d56", "petr.svoboda@nemocnice.cz", true, "Petr", "Svoboda", true, null, "PETR.SVOBODA@NEMOCNICE.CZ", "DOCTOR2", "AQAAAAEAACcQAAAAECxrKr4YAVakrkIYFy7MgUA11ryq0Sgun00+cj9FnR6EHzH8EL9WRc3J60f5x2nv0g==", "222333444", false, "279fb73875ae47cd879c99b203c3b207", 2, false, "doctor2" },
                    { 4, 0, null, "ea57e9c6-b536-4949-8821-c33c6aa32c87", "lucie.dvorakova@nemocnice.cz", true, "Lucie", "Dvořáková", true, null, "LUCIE.DVORAKOVA@NEMOCNICE.CZ", "DOCTOR3", "AQAAAAEAACcQAAAAECxrKr4YAVakrkIYFy7MgUA11ryq0Sgun00+cj9FnR6EHzH8EL9WRc3J60f5x2nv0g==", "333444555", false, "ae5bf88681b44301b71cd14a895dc5fe", 3, false, "doctor3" },
                    { 5, 0, null, "3d4642f4-2169-4ada-b4b9-6f6454227581", "arnost.patek@nemocnice.cz", true, "Arnošt", "Pátek", true, null, "ARNOST.PATEK@NEMOCNICE.CZ", "DOCTOR4", "AQAAAAEAACcQAAAAECxrKr4YAVakrkIYFy7MgUA11ryq0Sgun00+cj9FnR6EHzH8EL9WRc3J60f5x2nv0g==", "444555666", false, "c8ac754367164f5d88147a0f58fbf945", 2, false, "doctor4" }
                });

            migrationBuilder.InsertData(
                table: "DoctorPatient",
                columns: new[] { "Id", "DoctorId", "PatientId" },
                values: new object[,]
                {
                    { 1, 2, 6 },
                    { 4, 2, 8 }
                });

            migrationBuilder.InsertData(
                table: "Examination",
                columns: new[] { "Id", "DateTime", "DoctorId", "ExaminationTypeId", "Notes", "PatientId" },
                values: new object[] { 1, new DateTime(2025, 10, 17, 0, 18, 26, 931, DateTimeKind.Local).AddTicks(7497), 2, 1, "Kontrola tlaku", 6 });

            migrationBuilder.InsertData(
                table: "Vaccination",
                columns: new[] { "Id", "DateTime", "NextDose", "PatientId", "VaccineTypeId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 10, 27, 0, 18, 26, 933, DateTimeKind.Local).AddTicks(4240), new DateTime(2026, 4, 27, 0, 18, 26, 933, DateTimeKind.Local).AddTicks(4387), 6, 1 },
                    { 2, new DateTime(2025, 2, 27, 0, 18, 26, 933, DateTimeKind.Local).AddTicks(4706), new DateTime(2026, 2, 27, 0, 18, 26, 933, DateTimeKind.Local).AddTicks(4708), 7, 2 },
                    { 3, new DateTime(2025, 4, 27, 0, 18, 26, 933, DateTimeKind.Local).AddTicks(4710), new DateTime(2026, 4, 27, 0, 18, 26, 933, DateTimeKind.Local).AddTicks(4711), 8, 3 },
                    { 4, new DateTime(2025, 7, 27, 0, 18, 26, 933, DateTimeKind.Local).AddTicks(4718), new DateTime(2026, 10, 27, 0, 18, 26, 933, DateTimeKind.Local).AddTicks(4719), 6, 2 }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { 2, 3 },
                    { 3, 3 },
                    { 2, 4 },
                    { 3, 4 },
                    { 2, 5 },
                    { 3, 5 }
                });

            migrationBuilder.InsertData(
                table: "DoctorPatient",
                columns: new[] { "Id", "DoctorId", "PatientId" },
                values: new object[,]
                {
                    { 2, 3, 7 },
                    { 3, 4, 8 },
                    { 5, 5, 7 }
                });

            migrationBuilder.InsertData(
                table: "Examination",
                columns: new[] { "Id", "DateTime", "DoctorId", "ExaminationTypeId", "Notes", "PatientId" },
                values: new object[,]
                {
                    { 2, new DateTime(2025, 10, 22, 0, 18, 26, 932, DateTimeKind.Local).AddTicks(9735), 3, 3, "Krevní test", 7 },
                    { 3, new DateTime(2025, 10, 25, 0, 18, 26, 932, DateTimeKind.Local).AddTicks(9749), 4, 2, "Vyšetření kloubů", 8 },
                    { 4, new DateTime(2025, 10, 19, 0, 18, 26, 932, DateTimeKind.Local).AddTicks(9752), 4, 2, "Vyšetření ruky", 7 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExaminationResult_ExaminationId",
                table: "ExaminationResult",
                column: "ExaminationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_SpecializationId",
                table: "AspNetUsers",
                column: "SpecializationId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorPatient_DoctorId",
                table: "DoctorPatient",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorPatient_PatientId",
                table: "DoctorPatient",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Examination_DoctorId",
                table: "Examination",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Examination_ExaminationTypeId",
                table: "Examination",
                column: "ExaminationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Examination_PatientId",
                table: "Examination",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Vaccination_PatientId",
                table: "Vaccination",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Vaccination_VaccineTypeId",
                table: "Vaccination",
                column: "VaccineTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Specialization_SpecializationId",
                table: "AspNetUsers",
                column: "SpecializationId",
                principalTable: "Specialization",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExaminationResult_Examination_ExaminationId",
                table: "ExaminationResult",
                column: "ExaminationId",
                principalTable: "Examination",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Specialization_SpecializationId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_ExaminationResult_Examination_ExaminationId",
                table: "ExaminationResult");

            migrationBuilder.DropTable(
                name: "DoctorPatient");

            migrationBuilder.DropTable(
                name: "Examination");

            migrationBuilder.DropTable(
                name: "Specialization");

            migrationBuilder.DropTable(
                name: "Vaccination");

            migrationBuilder.DropIndex(
                name: "IX_ExaminationResult_ExaminationId",
                table: "ExaminationResult");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_SpecializationId",
                table: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 4 });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 3, 4 });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 5 });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 3, 5 });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 3, 6 });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 3, 7 });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 3, 8 });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "b09a83ae-cfd3-4ee7-97e6-fbcf0b0fe78c", "SEJEPXC646ZBNCDYSM3H5FRK5RWP2TN6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "Email", "FirstName", "LastName", "NormalizedEmail", "PhoneNumber", "SecurityStamp", "SpecializationId" },
                values: new object[] { "7a8d96fd-5918-441b-b800-cbafa99de97b", "doctor1@doctor.cz", "Doktor", "Jedna", "DOCTOR1@DOCTOR.CZ", null, "MAJXOSATJKOEM4YFF32Y5G2XPR5OFEL6", null });
        }
    }
}

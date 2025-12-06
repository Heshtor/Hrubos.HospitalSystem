using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Hrubos.HospitalSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class mysql_100_new_initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ExaminationType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExaminationType", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Specialization",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialization", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

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

            migrationBuilder.CreateTable(
                name: "VaccineType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VaccineType", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimValue = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaims_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FirstName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumber = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BirthNumber = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MaxExaminationPerDay = table.Column<int>(type: "int", nullable: false),
                    SpecializationId = table.Column<int>(type: "int", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedEmail = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EmailConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    PasswordHash = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SecurityStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumberConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Specialization_SpecializationId",
                        column: x => x.SpecializationId,
                        principalTable: "Specialization",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

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
                        name: "FK_DoctorPatient_Users_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DoctorPatient_Users_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Examination",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DateTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ProblemDescription = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ExaminationTypeId = table.Column<int>(type: "int", nullable: true),
                    PatientId = table.Column<int>(type: "int", nullable: true),
                    DoctorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Examination", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Examination_ExaminationType_ExaminationTypeId",
                        column: x => x.ExaminationTypeId,
                        principalTable: "ExaminationType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Examination_Users_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Examination_Users_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimValue = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProviderKey = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProviderDisplayName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserLogins_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Value = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Vaccination",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    VaccineTypeId = table.Column<int>(type: "int", nullable: true),
                    DateTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vaccination", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vaccination_Users_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Vaccination_VaccineType_VaccineTypeId",
                        column: x => x.VaccineTypeId,
                        principalTable: "VaccineType",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ExaminationResult",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Values = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AttachmentSrc = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ExaminationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExaminationResult", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExaminationResult_Examination_ExaminationId",
                        column: x => x.ExaminationId,
                        principalTable: "Examination",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "ExaminationType",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Obvodní vyšetření" },
                    { 2, "Specialistické vyšetření" },
                    { 3, "Laboratorní test" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, "9cf14c2c-19e7-40d6-b744-8917505c3106", "Admin", "ADMIN" },
                    { 2, "be0efcde-9d0a-461d-8eb6-444b043d6660", "Doctor", "DOCTOR" },
                    { 3, "29dafca7-cd20-4cd9-a3dd-4779d7bac3ee", "Patient", "PATIENT" }
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
                table: "SystemSetting",
                columns: new[] { "Id", "Key", "Value" },
                values: new object[] { 1, "MaxVaccinationPerDay", "20" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "BirthNumber", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "MaxExaminationPerDay", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "SpecializationId", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 1, 0, null, "1a174d18-905f-485b-b1a7-8f94437fc615", "admin@admin.cz", true, "Admin", "Martin", true, null, 0, "ADMIN@ADMIN.CZ", "ADMIN", "AQAAAAEAACcQAAAAEC4prnSMIdRUykdd65G87+g3lLCc9cqJ/re6T1TsQFv5xlMrmVIe4k7yMQiEYWpH3A==", null, false, "88e7e00c35b7437398cca7c6b8ae0969", null, false, "admin" },
                    { 6, 0, "050510/2224", "ee3774fd-818b-4b94-b275-2bf14ef0f755", "tomas.horak@email.cz", true, "Tomáš", "Horák", true, null, 0, "TOMAS.HORAK@EMAIL.CZ", "PATIENT1", "AQAAAAEAACcQAAAAEBacwHfAQ8oysuC+yEOFP2TakEie2+73wHf89V+TJX+Ioy5NfCTZkS0U/P5kN7yjmg==", "601111111", false, "bdddfcb81de347a7a5cabd831fe48b0f", null, false, "patient1" },
                    { 7, 0, "855801/0406", "34c88d3f-ba51-4e04-8d46-a9f887a3e119", "anna.mala@email.cz", true, "Anna", "Malá", true, null, 0, "ANNA.MALA@EMAIL.CZ", "PATIENT2", "AQAAAAEAACcQAAAAEK31Pd3GzmAcXrVtoSezhRdeqGp0l5c6Zl0IjUvn6vAeslrjG7bgOuN4jHqQBRDbZA==", "602222222", false, "7f4eed24be3b493ab523a0dd8fa645d2", null, false, "patient2" },
                    { 8, 0, "920808/8032", "bcff5923-7a82-4af7-8d06-2641d1747f2b", "karel.novotny@email.cz", true, "Karel", "Novotný", true, null, 0, "KAREL.NOVOTNY@EMAIL.CZ", "PATIENT3", "AQAAAAEAACcQAAAAEGDwHucn5uWF1684moFrwbqoaym+z0IHUiN+/EDQnXgz6HiEbGnaqFT136phybDc4g==", "603333333", false, "53599ee32caa4e93b483e1bb40077e71", null, false, "patient3" }
                });

            migrationBuilder.InsertData(
                table: "VaccineType",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Chřipka" },
                    { 2, "Hepatitida B" },
                    { 3, "Tetanus" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 3, 6 },
                    { 3, 7 },
                    { 3, 8 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "BirthNumber", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "MaxExaminationPerDay", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "SpecializationId", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 2, 0, null, "93f4a1d3-158e-4fa0-8d08-764e70dce14d", "jan.novak@nemocnice.cz", true, "Jan", "Novák", true, null, 10, "JAN.NOVAK@NEMOCNICE.CZ", "DOCTOR1", "AQAAAAEAACcQAAAAECxrKr4YAVakrkIYFy7MgUA11ryq0Sgun00+cj9FnR6EHzH8EL9WRc3J60f5x2nv0g==", "111222333", false, "733739cee0194ba7a09c2aed3fd9e7b1", 1, false, "doctor1" },
                    { 3, 0, null, "3d59f31f-94f6-4535-ba9e-8b18147fc137", "petr.svoboda@nemocnice.cz", true, "Petr", "Svoboda", true, null, 5, "PETR.SVOBODA@NEMOCNICE.CZ", "DOCTOR2", "AQAAAAEAACcQAAAAEK4DkND+5IwQiNI01DelkSwKPGQnzZAxCmobmvF3J0w5Xr6YO4bUtzjJwe2qRzUv7g==", "222333444", false, "9704108d3a1a4efebe344ae78980c2f4", 2, false, "doctor2" },
                    { 4, 0, null, "c9885337-8037-4a88-b93c-6d7f997b3a8e", "lucie.dvorakova@nemocnice.cz", true, "Lucie", "Dvořáková", true, null, 2, "LUCIE.DVORAKOVA@NEMOCNICE.CZ", "DOCTOR3", "AQAAAAEAACcQAAAAEMK02V+4Wdm0lgraNwSBHPhhYUFmVpoCrp103XwzNXTFK6/s8xx0AAdpsd2G2KquQQ==", "333444555", false, "520ff02ea7584ad380a0121d9763a47c", 3, false, "doctor3" },
                    { 5, 0, null, "652043ed-e151-4263-8711-4141fdc45a13", "arnost.patek@nemocnice.cz", true, "Arnošt", "Pátek", true, null, 0, "ARNOST.PATEK@NEMOCNICE.CZ", "DOCTOR4", "AQAAAAEAACcQAAAAEGrcdYyAHwCXTbk9VS3VItkcEq4bhgiPBFetA8rLbp/6Asw87PI2TqWE5csu8u6TDA==", "444555666", false, "3441b987d50249b1a12253ff597e31fd", 2, false, "doctor4" }
                });

            migrationBuilder.InsertData(
                table: "Vaccination",
                columns: new[] { "Id", "DateTime", "PatientId", "VaccineTypeId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 12, 6, 18, 41, 54, 177, DateTimeKind.Local).AddTicks(4896), 6, 1 },
                    { 2, new DateTime(2025, 4, 6, 18, 41, 54, 177, DateTimeKind.Local).AddTicks(5190), 7, 2 },
                    { 3, new DateTime(2025, 6, 6, 18, 41, 54, 177, DateTimeKind.Local).AddTicks(5193), 8, 3 },
                    { 4, new DateTime(2025, 9, 6, 18, 41, 54, 177, DateTimeKind.Local).AddTicks(5195), 6, 2 }
                });

            migrationBuilder.InsertData(
                table: "DoctorPatient",
                columns: new[] { "Id", "DoctorId", "PatientId" },
                values: new object[,]
                {
                    { 1, 2, 6 },
                    { 2, 3, 7 },
                    { 3, 4, 8 },
                    { 4, 2, 8 },
                    { 5, 5, 7 }
                });

            migrationBuilder.InsertData(
                table: "Examination",
                columns: new[] { "Id", "DateTime", "DoctorId", "ExaminationTypeId", "PatientId", "ProblemDescription" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 11, 26, 18, 41, 54, 175, DateTimeKind.Local).AddTicks(7712), 2, 1, 6, "Vysoký tlak" },
                    { 2, new DateTime(2025, 12, 1, 18, 41, 54, 177, DateTimeKind.Local).AddTicks(468), 3, 3, 7, "Krevní test" },
                    { 3, new DateTime(2025, 12, 4, 18, 41, 54, 177, DateTimeKind.Local).AddTicks(482), 4, 2, 8, "Bolest kloubů" },
                    { 4, new DateTime(2025, 11, 28, 18, 41, 54, 177, DateTimeKind.Local).AddTicks(485), 4, 2, 7, "Bolest zápěstí" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { 2, 2 },
                    { 2, 3 },
                    { 2, 4 },
                    { 2, 5 }
                });

            migrationBuilder.InsertData(
                table: "ExaminationResult",
                columns: new[] { "Id", "AttachmentSrc", "Description", "ExaminationId", "Values" },
                values: new object[,]
                {
                    { 1, null, "Vše v pořádku", 1, "TK: 120/80, Puls: 72" },
                    { 2, "\\attachments\\examinationResults\\erecept.png", "Lehká anémie", 2, "Hemoglobin: 110 g/l, Hct: 33%" },
                    { 3, "\\attachments\\examinationResults\\rentgen.pdf", "Artritida kolene", 3, "RTG: mírná artritida, rentgenový snímek v příloze" }
                });

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
                name: "IX_ExaminationResult_ExaminationId",
                table: "ExaminationResult",
                column: "ExaminationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_RoleId",
                table: "RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Roles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                table: "UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserId",
                table: "UserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_Users_SpecializationId",
                table: "Users",
                column: "SpecializationId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Users",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vaccination_PatientId",
                table: "Vaccination",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Vaccination_VaccineTypeId",
                table: "Vaccination",
                column: "VaccineTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DoctorPatient");

            migrationBuilder.DropTable(
                name: "ExaminationResult");

            migrationBuilder.DropTable(
                name: "RoleClaims");

            migrationBuilder.DropTable(
                name: "SystemSetting");

            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "UserTokens");

            migrationBuilder.DropTable(
                name: "Vaccination");

            migrationBuilder.DropTable(
                name: "Examination");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "VaccineType");

            migrationBuilder.DropTable(
                name: "ExaminationType");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Specialization");
        }
    }
}

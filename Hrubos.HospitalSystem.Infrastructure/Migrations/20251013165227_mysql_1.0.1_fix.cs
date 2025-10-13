using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Hrubos.HospitalSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class mysql_101_fix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExaminationResult_Examination_ExaminationId",
                table: "ExaminationResult");

            migrationBuilder.DropTable(
                name: "DoctorPatient");

            migrationBuilder.DropTable(
                name: "Examination");

            migrationBuilder.DropTable(
                name: "Vaccination");

            migrationBuilder.DropTable(
                name: "Doctor");

            migrationBuilder.DropTable(
                name: "Patient");

            migrationBuilder.DropTable(
                name: "Specialization");

            migrationBuilder.DropIndex(
                name: "IX_ExaminationResult_ExaminationId",
                table: "ExaminationResult");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Patient",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    BirthNumber = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FirstName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumber = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient", x => x.Id);
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
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    VaccineTypeId = table.Column<int>(type: "int", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    NextDose = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vaccination", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vaccination_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vaccination_VaccineType_VaccineTypeId",
                        column: x => x.VaccineTypeId,
                        principalTable: "VaccineType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Doctor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SpecializationId = table.Column<int>(type: "int", nullable: false),
                    BirthNumber = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FirstName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumber = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Doctor_Specialization_SpecializationId",
                        column: x => x.SpecializationId,
                        principalTable: "Specialization",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                        name: "FK_DoctorPatient_Doctor_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DoctorPatient_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patient",
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
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    ExaminationTypeId = table.Column<int>(type: "int", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Notes = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Examination", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Examination_Doctor_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Examination_ExaminationType_ExaminationTypeId",
                        column: x => x.ExaminationTypeId,
                        principalTable: "ExaminationType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Examination_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Patient",
                columns: new[] { "Id", "BirthNumber", "Email", "FirstName", "LastName", "PhoneNumber", "UserName" },
                values: new object[,]
                {
                    { 1, "900101/1234", "tomas.horak@email.cz", "Tomáš", "Horák", "601111111", "pacient1" },
                    { 2, "950202/2345", "anna.mala@email.cz", "Anna", "Malá", "602222222", "pacient2" },
                    { 3, "880303/3456", "karel.novotny@email.cz", "Karel", "Novotný", "603333333", "pacient3" }
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
                table: "Doctor",
                columns: new[] { "Id", "BirthNumber", "Email", "FirstName", "LastName", "PhoneNumber", "SpecializationId", "UserName" },
                values: new object[,]
                {
                    { 1, null, "jan.novak@nemocnice.cz", "Jan", "Novák", "111222333", 1, "doktor1" },
                    { 2, null, "petr.svoboda@nemocnice.cz", "Petr", "Svoboda", "222333444", 2, "doktor2" },
                    { 3, null, "lucie.dvorakova@nemocnice.cz", "Lucie", "Dvořáková", "333444555", 3, "doktor3" },
                    { 4, null, "arnost.patek@nemocnice.cz", "Arnošt", "Pátek", "444555666", 2, "doktor4" }
                });

            migrationBuilder.InsertData(
                table: "Vaccination",
                columns: new[] { "Id", "DateTime", "NextDose", "PatientId", "VaccineTypeId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 10, 6, 20, 41, 27, 927, DateTimeKind.Local).AddTicks(9306), new DateTime(2026, 4, 6, 20, 41, 27, 927, DateTimeKind.Local).AddTicks(9452), 1, 1 },
                    { 2, new DateTime(2025, 2, 6, 20, 41, 27, 927, DateTimeKind.Local).AddTicks(9791), new DateTime(2026, 2, 6, 20, 41, 27, 927, DateTimeKind.Local).AddTicks(9794), 2, 2 },
                    { 3, new DateTime(2025, 4, 6, 20, 41, 27, 927, DateTimeKind.Local).AddTicks(9797), new DateTime(2026, 4, 6, 20, 41, 27, 927, DateTimeKind.Local).AddTicks(9798), 3, 3 },
                    { 4, new DateTime(2025, 7, 6, 20, 41, 27, 927, DateTimeKind.Local).AddTicks(9799), new DateTime(2026, 10, 6, 20, 41, 27, 927, DateTimeKind.Local).AddTicks(9800), 1, 2 }
                });

            migrationBuilder.InsertData(
                table: "DoctorPatient",
                columns: new[] { "Id", "DoctorId", "PatientId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 },
                    { 3, 3, 3 },
                    { 4, 1, 3 },
                    { 5, 4, 2 }
                });

            migrationBuilder.InsertData(
                table: "Examination",
                columns: new[] { "Id", "DateTime", "DoctorId", "ExaminationTypeId", "Notes", "PatientId" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 9, 26, 20, 41, 27, 926, DateTimeKind.Local).AddTicks(2603), 1, 1, "Kontrola tlaku", 1 },
                    { 2, new DateTime(2025, 10, 1, 20, 41, 27, 927, DateTimeKind.Local).AddTicks(4744), 2, 3, "Krevní test", 2 },
                    { 3, new DateTime(2025, 10, 4, 20, 41, 27, 927, DateTimeKind.Local).AddTicks(4759), 3, 2, "Vyšetření kloubů", 3 },
                    { 4, new DateTime(2025, 9, 28, 20, 41, 27, 927, DateTimeKind.Local).AddTicks(4762), 3, 2, "Vyšetření ruky", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExaminationResult_ExaminationId",
                table: "ExaminationResult",
                column: "ExaminationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Doctor_SpecializationId",
                table: "Doctor",
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
                name: "FK_ExaminationResult_Examination_ExaminationId",
                table: "ExaminationResult",
                column: "ExaminationId",
                principalTable: "Examination",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

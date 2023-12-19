using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace soul_whisper.Migrations
{
    /// <inheritdoc />
    public partial class InitDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    birthday = table.Column<DateOnly>(type: "date", nullable: false),
                    gender = table.Column<int>(type: "int", nullable: false),
                    activationStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "doctors",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    avatar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    birthday = table.Column<DateOnly>(type: "date", nullable: false),
                    gender = table.Column<int>(type: "int", nullable: false),
                    activationStatus = table.Column<int>(type: "int", nullable: false),
                    specialty = table.Column<int>(type: "int", nullable: false),
                    moneyInWallet = table.Column<decimal>(type: "Money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_doctors", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "messages",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    sender = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    receiver = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_messages", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "patients",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BloodType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    birthday = table.Column<DateOnly>(type: "date", nullable: false),
                    gender = table.Column<int>(type: "int", nullable: false),
                    activationStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_patients", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "rules",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    type = table.Column<int>(type: "int", nullable: false),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rules", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Achievement",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    doctorid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    type = table.Column<int>(type: "int", nullable: false),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dateEarned = table.Column<DateTime>(type: "datetime2", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    createAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Achievement", x => x.id);
                    table.ForeignKey(
                        name: "FK_Achievement_doctors_doctorid",
                        column: x => x.doctorid,
                        principalTable: "doctors",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "doctorship_registrations",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_doctorship_registrations", x => x.id);
                    table.ForeignKey(
                        name: "FK_doctorship_registrations_doctors_id",
                        column: x => x.id,
                        principalTable: "doctors",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "exercises",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    type = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    duration = table.Column<TimeSpan>(type: "TIME", nullable: false),
                    Doctorid = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_exercises", x => x.id);
                    table.ForeignKey(
                        name: "FK_exercises_doctors_Doctorid",
                        column: x => x.Doctorid,
                        principalTable: "doctors",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "habits",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    type = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    patientid = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_habits", x => x.id);
                    table.ForeignKey(
                        name: "FK_habits_patients_patientid",
                        column: x => x.patientid,
                        principalTable: "patients",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "patient_doctor_registrations",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    patientid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    doctorid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_patient_doctor_registrations", x => x.id);
                    table.ForeignKey(
                        name: "FK_patient_doctor_registrations_doctors_doctorid",
                        column: x => x.doctorid,
                        principalTable: "doctors",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_patient_doctor_registrations_patients_patientid",
                        column: x => x.patientid,
                        principalTable: "patients",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ratings",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    patientid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    doctorid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    value = table.Column<int>(type: "int", nullable: false),
                    comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    createAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ratings", x => x.id);
                    table.ForeignKey(
                        name: "FK_ratings_doctors_doctorid",
                        column: x => x.doctorid,
                        principalTable: "doctors",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ratings_patients_patientid",
                        column: x => x.patientid,
                        principalTable: "patients",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "receipts",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    type = table.Column<int>(type: "int", nullable: false),
                    doctorid = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    patientid = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Amount = table.Column<decimal>(type: "Money", nullable: false),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_receipts", x => x.id);
                    table.ForeignKey(
                        name: "FK_receipts_doctors_doctorid",
                        column: x => x.doctorid,
                        principalTable: "doctors",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_receipts_patients_patientid",
                        column: x => x.patientid,
                        principalTable: "patients",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Achievement_Image",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    belongToid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    image = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Achievement_Image", x => x.id);
                    table.ForeignKey(
                        name: "FK_Achievement_Image_Achievement_belongToid",
                        column: x => x.belongToid,
                        principalTable: "Achievement",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "appointments",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    type = table.Column<int>(type: "int", nullable: false),
                    startTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    endTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    diagnosis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    prescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    doctorid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    patientid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    Patient_Doctor_Registrationid = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_appointments", x => x.id);
                    table.ForeignKey(
                        name: "FK_appointments_doctors_doctorid",
                        column: x => x.doctorid,
                        principalTable: "doctors",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_appointments_patient_doctor_registrations_Patient_Doctor_Registrationid",
                        column: x => x.Patient_Doctor_Registrationid,
                        principalTable: "patient_doctor_registrations",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_appointments_patients_patientid",
                        column: x => x.patientid,
                        principalTable: "patients",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Achievement_doctorid",
                table: "Achievement",
                column: "doctorid");

            migrationBuilder.CreateIndex(
                name: "IX_Achievement_Image_belongToid",
                table: "Achievement_Image",
                column: "belongToid");

            migrationBuilder.CreateIndex(
                name: "IX_Admin_email",
                table: "Admin",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_appointments_doctorid",
                table: "appointments",
                column: "doctorid");

            migrationBuilder.CreateIndex(
                name: "IX_appointments_Patient_Doctor_Registrationid",
                table: "appointments",
                column: "Patient_Doctor_Registrationid");

            migrationBuilder.CreateIndex(
                name: "IX_appointments_patientid",
                table: "appointments",
                column: "patientid");

            migrationBuilder.CreateIndex(
                name: "IX_doctors_email",
                table: "doctors",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_exercises_Doctorid",
                table: "exercises",
                column: "Doctorid");

            migrationBuilder.CreateIndex(
                name: "IX_habits_patientid",
                table: "habits",
                column: "patientid");

            migrationBuilder.CreateIndex(
                name: "IX_patient_doctor_registrations_doctorid",
                table: "patient_doctor_registrations",
                column: "doctorid");

            migrationBuilder.CreateIndex(
                name: "IX_patient_doctor_registrations_patientid",
                table: "patient_doctor_registrations",
                column: "patientid");

            migrationBuilder.CreateIndex(
                name: "IX_patients_email",
                table: "patients",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ratings_doctorid",
                table: "ratings",
                column: "doctorid");

            migrationBuilder.CreateIndex(
                name: "IX_ratings_patientid",
                table: "ratings",
                column: "patientid");

            migrationBuilder.CreateIndex(
                name: "IX_receipts_doctorid",
                table: "receipts",
                column: "doctorid");

            migrationBuilder.CreateIndex(
                name: "IX_receipts_patientid",
                table: "receipts",
                column: "patientid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Achievement_Image");

            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "appointments");

            migrationBuilder.DropTable(
                name: "doctorship_registrations");

            migrationBuilder.DropTable(
                name: "exercises");

            migrationBuilder.DropTable(
                name: "habits");

            migrationBuilder.DropTable(
                name: "messages");

            migrationBuilder.DropTable(
                name: "ratings");

            migrationBuilder.DropTable(
                name: "receipts");

            migrationBuilder.DropTable(
                name: "rules");

            migrationBuilder.DropTable(
                name: "Achievement");

            migrationBuilder.DropTable(
                name: "patient_doctor_registrations");

            migrationBuilder.DropTable(
                name: "doctors");

            migrationBuilder.DropTable(
                name: "patients");
        }
    }
}

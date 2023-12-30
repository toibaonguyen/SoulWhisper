using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace soul_whisper.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
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
                name: "Doctor",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    avatar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    birthday = table.Column<DateOnly>(type: "date", nullable: false),
                    gender = table.Column<int>(type: "int", nullable: false),
                    activationStatus = table.Column<int>(type: "int", nullable: false),
                    specialty = table.Column<int>(type: "int", nullable: false),
                    moneyInWallet = table.Column<decimal>(type: "Money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctor", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Exercise",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    type = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    duration = table.Column<TimeSpan>(type: "TIME", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercise", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Message",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    sender = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    receiver = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Message", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Patient",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    bloodType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    birthday = table.Column<DateOnly>(type: "date", nullable: false),
                    gender = table.Column<int>(type: "int", nullable: false),
                    activationStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Rule",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    type = table.Column<int>(type: "int", nullable: false),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rule", x => x.id);
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
                    activationStatus = table.Column<int>(type: "int", nullable: false),
                    createAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Achievement", x => x.id);
                    table.ForeignKey(
                        name: "FK_Achievement_Doctor_doctorid",
                        column: x => x.doctorid,
                        principalTable: "Doctor",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Doctorship_Registration",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    expiredAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctorship_Registration", x => x.id);
                    table.ForeignKey(
                        name: "FK_Doctorship_Registration_Doctor_id",
                        column: x => x.id,
                        principalTable: "Doctor",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Appointment",
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
                    status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointment", x => x.id);
                    table.ForeignKey(
                        name: "FK_Appointment_Doctor_doctorid",
                        column: x => x.doctorid,
                        principalTable: "Doctor",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointment_Patient_patientid",
                        column: x => x.patientid,
                        principalTable: "Patient",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Habit",
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
                    table.PrimaryKey("PK_Habit", x => x.id);
                    table.ForeignKey(
                        name: "FK_Habit_Patient_patientid",
                        column: x => x.patientid,
                        principalTable: "Patient",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rating",
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
                    table.PrimaryKey("PK_Rating", x => x.id);
                    table.ForeignKey(
                        name: "FK_Rating_Doctor_doctorid",
                        column: x => x.doctorid,
                        principalTable: "Doctor",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rating_Patient_patientid",
                        column: x => x.patientid,
                        principalTable: "Patient",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Receipt",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    type = table.Column<int>(type: "int", nullable: false),
                    doctorid = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    patientid = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    amount = table.Column<decimal>(type: "Money", nullable: false),
                    details = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    createAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receipt", x => x.id);
                    table.ForeignKey(
                        name: "FK_Receipt_Doctor_doctorid",
                        column: x => x.doctorid,
                        principalTable: "Doctor",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Receipt_Patient_patientid",
                        column: x => x.patientid,
                        principalTable: "Patient",
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
                name: "Appointment_Registration",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    patientid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    doctorid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    appointmentid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    status = table.Column<int>(type: "int", nullable: true),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointment_Registration", x => x.id);
                    table.ForeignKey(
                        name: "FK_Appointment_Registration_Appointment_appointmentid",
                        column: x => x.appointmentid,
                        principalTable: "Appointment",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointment_Registration_Doctor_doctorid",
                        column: x => x.doctorid,
                        principalTable: "Doctor",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointment_Registration_Patient_patientid",
                        column: x => x.patientid,
                        principalTable: "Patient",
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
                name: "IX_Appointment_doctorid",
                table: "Appointment",
                column: "doctorid");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_patientid",
                table: "Appointment",
                column: "patientid");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_Registration_appointmentid",
                table: "Appointment_Registration",
                column: "appointmentid");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_Registration_doctorid",
                table: "Appointment_Registration",
                column: "doctorid");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_Registration_patientid",
                table: "Appointment_Registration",
                column: "patientid");

            migrationBuilder.CreateIndex(
                name: "IX_Doctor_email",
                table: "Doctor",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Habit_patientid",
                table: "Habit",
                column: "patientid");

            migrationBuilder.CreateIndex(
                name: "IX_Patient_email",
                table: "Patient",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rating_doctorid",
                table: "Rating",
                column: "doctorid");

            migrationBuilder.CreateIndex(
                name: "IX_Rating_patientid",
                table: "Rating",
                column: "patientid");

            migrationBuilder.CreateIndex(
                name: "IX_Receipt_doctorid",
                table: "Receipt",
                column: "doctorid");

            migrationBuilder.CreateIndex(
                name: "IX_Receipt_patientid",
                table: "Receipt",
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
                name: "Appointment_Registration");

            migrationBuilder.DropTable(
                name: "Doctorship_Registration");

            migrationBuilder.DropTable(
                name: "Exercise");

            migrationBuilder.DropTable(
                name: "Habit");

            migrationBuilder.DropTable(
                name: "Message");

            migrationBuilder.DropTable(
                name: "Rating");

            migrationBuilder.DropTable(
                name: "Receipt");

            migrationBuilder.DropTable(
                name: "Rule");

            migrationBuilder.DropTable(
                name: "Achievement");

            migrationBuilder.DropTable(
                name: "Appointment");

            migrationBuilder.DropTable(
                name: "Doctor");

            migrationBuilder.DropTable(
                name: "Patient");
        }
    }
}

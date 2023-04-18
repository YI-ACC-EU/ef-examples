using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AirportExample.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    CountryCode = table.Column<string>(type: "char(3)", unicode: false, fixedLength: true, maxLength: 3, nullable: false),
                    CountryName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.CountryCode);
                });

            migrationBuilder.CreateTable(
                name: "FlightAttendant",
                columns: table => new
                {
                    AttendantID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    DOB = table.Column<DateTime>(type: "date", nullable: false),
                    HireDate = table.Column<DateTime>(type: "date", nullable: false),
                    MentorID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FA_AttendantID", x => x.AttendantID);
                    table.ForeignKey(
                        name: "FK_MentorID",
                        column: x => x.MentorID,
                        principalTable: "FlightAttendant",
                        principalColumn: "AttendantID");
                });

            migrationBuilder.CreateTable(
                name: "Pilot",
                columns: table => new
                {
                    PilotID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    DOB = table.Column<DateTime>(type: "date", nullable: false),
                    HoursFlown = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_P_PilotId", x => x.PilotID);
                });

            migrationBuilder.CreateTable(
                name: "PlaneModel",
                columns: table => new
                {
                    ModelNumber = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    ManufacturerName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    PlaneRange = table.Column<short>(type: "smallint", nullable: false),
                    CruiseSpeed = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PM_ModelN", x => x.ModelNumber);
                });

            migrationBuilder.CreateTable(
                name: "Airport",
                columns: table => new
                {
                    AirportCode = table.Column<string>(type: "char(3)", unicode: false, fixedLength: true, maxLength: 3, nullable: false),
                    AirportName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    ContactNo = table.Column<decimal>(type: "numeric(18,0)", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    CountryCode = table.Column<string>(type: "char(3)", unicode: false, fixedLength: true, maxLength: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airport", x => x.AirportCode);
                    table.ForeignKey(
                        name: "FK_CountryCode",
                        column: x => x.CountryCode,
                        principalTable: "Country",
                        principalColumn: "CountryCode");
                });

            migrationBuilder.CreateTable(
                name: "PlaneDetail",
                columns: table => new
                {
                    PlaneID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModelNumber = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    RegistrationNo = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    BuiltYear = table.Column<short>(type: "smallint", nullable: false),
                    FirstClassCapacity = table.Column<short>(type: "smallint", nullable: false),
                    EcoCapacity = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PD_PlaneId", x => x.PlaneID);
                    table.ForeignKey(
                        name: "FK_ModelN",
                        column: x => x.ModelNumber,
                        principalTable: "PlaneModel",
                        principalColumn: "ModelNumber");
                });

            migrationBuilder.CreateTable(
                name: "PlanePilot",
                columns: table => new
                {
                    PilotID = table.Column<int>(type: "int", nullable: false),
                    PlaneModel = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanePilot", x => new { x.PilotID, x.PlaneModel });
                    table.ForeignKey(
                        name: "PK_PilotID",
                        column: x => x.PilotID,
                        principalTable: "Pilot",
                        principalColumn: "PilotID");
                    table.ForeignKey(
                        name: "PK_PlaneModel",
                        column: x => x.PlaneModel,
                        principalTable: "PlaneModel",
                        principalColumn: "ModelNumber");
                });

            migrationBuilder.CreateTable(
                name: "Flight",
                columns: table => new
                {
                    FlightNo = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    FlightDepartToId = table.Column<string>(type: "char(3)", unicode: false, fixedLength: true, maxLength: 3, nullable: false),
                    FlightArriveFromId = table.Column<string>(type: "char(3)", unicode: false, fixedLength: true, maxLength: 3, nullable: false),
                    Distance = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlightNo", x => x.FlightNo);
                    table.ForeignKey(
                        name: "FK_F_FlightArriveFrom",
                        column: x => x.FlightArriveFromId,
                        principalTable: "Airport",
                        principalColumn: "AirportCode");
                    table.ForeignKey(
                        name: "FK_F_FlightDepartTo",
                        column: x => x.FlightDepartToId,
                        principalTable: "Airport",
                        principalColumn: "AirportCode");
                });

            migrationBuilder.CreateTable(
                name: "FlightInstance",
                columns: table => new
                {
                    InstanceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FlightNo = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    PlaneID = table.Column<int>(type: "int", nullable: false),
                    PilotAboardID = table.Column<int>(type: "int", nullable: false),
                    CoPilotAboardID = table.Column<int>(type: "int", nullable: false),
                    FSM_AttendantID = table.Column<int>(type: "int", nullable: false),
                    DateTimeLeave = table.Column<DateTime>(type: "datetime", nullable: false),
                    DateTimeArrive = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("InstanceId_pk", x => x.InstanceID);
                    table.ForeignKey(
                        name: "FK_FI_CoPilotAboardId",
                        column: x => x.CoPilotAboardID,
                        principalTable: "Pilot",
                        principalColumn: "PilotID");
                    table.ForeignKey(
                        name: "FK_FI_FSMAttendantID",
                        column: x => x.FSM_AttendantID,
                        principalTable: "FlightAttendant",
                        principalColumn: "AttendantID");
                    table.ForeignKey(
                        name: "FK_FI_FlightNo",
                        column: x => x.FlightNo,
                        principalTable: "Flight",
                        principalColumn: "FlightNo");
                    table.ForeignKey(
                        name: "FK_FI_PilotAboardId",
                        column: x => x.PilotAboardID,
                        principalTable: "Pilot",
                        principalColumn: "PilotID");
                    table.ForeignKey(
                        name: "FK_FI_PlaneID",
                        column: x => x.PlaneID,
                        principalTable: "PlaneDetail",
                        principalColumn: "PlaneID");
                });

            migrationBuilder.CreateTable(
                name: "InstanceAttendant",
                columns: table => new
                {
                    InstanceID = table.Column<int>(type: "int", nullable: false),
                    AttendantID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstanceAttendantID", x => new { x.InstanceID, x.AttendantID });
                    table.ForeignKey(
                        name: "FK_IA_AttendantId",
                        column: x => x.AttendantID,
                        principalTable: "FlightAttendant",
                        principalColumn: "AttendantID");
                    table.ForeignKey(
                        name: "FK_IA_InstanceId",
                        column: x => x.InstanceID,
                        principalTable: "FlightInstance",
                        principalColumn: "InstanceID");
                });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "CountryCode", "CountryName" },
                values: new object[,]
                {
                    { "AUS", "Australia" },
                    { "AUT", "Austria" },
                    { "BEL", "Belgium" },
                    { "BRA", "Brazil" },
                    { "CAN", "Canada" },
                    { "CHN", "China" },
                    { "ENG", "England" },
                    { "ESP", "Spain" },
                    { "GER", "Germany" },
                    { "NPl", "Nepal" },
                    { "NZL", "New Zealand" },
                    { "POR", "Portugal" },
                    { "SWE", "Sweden" },
                    { "UAE", "United Arab Emirates" },
                    { "USA", "United States of America" }
                });

            migrationBuilder.InsertData(
                table: "PlaneModel",
                columns: new[] { "ModelNumber", "CruiseSpeed", "ManufacturerName", "PlaneRange" },
                values: new object[,]
                {
                    { "737", (short)780, "Boeing", (short)5600 },
                    { "777", (short)892, "Boeing", (short)10000 },
                    { "779", (short)922, "Boeing", (short)17000 },
                    { "787", (short)903, "Boeing", (short)15000 },
                    { "A300", (short)871, "Airbus", (short)13450 },
                    { "A340", (short)881, "Airbus", (short)12400 },
                    { "A380", (short)900, "Airbus", (short)15700 },
                    { "A390", (short)1081, "Airbus", (short)17400 }
                });

            migrationBuilder.InsertData(
                table: "PlaneDetail",
                columns: new[] { "PlaneID", "BuiltYear", "EcoCapacity", "FirstClassCapacity", "ModelNumber", "RegistrationNo" },
                values: new object[,]
                {
                    { 1, (short)1989, (short)50, (short)50, "A390", "AU-1989" },
                    { 2, (short)2000, (short)200, (short)100, "A380", "AU-2000" },
                    { 3, (short)1970, (short)350, (short)200, "A300", "AU-1970" },
                    { 4, (short)1880, (short)420, (short)310, "A340", "AU-1880" },
                    { 5, (short)1990, (short)230, (short)110, "A390", "AU-1990" },
                    { 6, (short)2001, (short)120, (short)40, "737", "BO-2001" },
                    { 7, (short)1990, (short)450, (short)155, "777", "BO-1990" },
                    { 8, (short)2002, (short)244, (short)121, "779", "BO-2002" },
                    { 9, (short)2005, (short)340, (short)195, "787", "BO-2005" },
                    { 10, (short)2005, (short)140, (short)95, "787", "BO-2005-1" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Airport_CountryCode",
                table: "Airport",
                column: "CountryCode");

            migrationBuilder.CreateIndex(
                name: "UK_CountryName",
                table: "Country",
                column: "CountryName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Flight_FlightArriveFromId",
                table: "Flight",
                column: "FlightArriveFromId");

            migrationBuilder.CreateIndex(
                name: "IX_Flight_FlightDepartToId",
                table: "Flight",
                column: "FlightDepartToId");

            migrationBuilder.CreateIndex(
                name: "IX_FlightAttendant_MentorID",
                table: "FlightAttendant",
                column: "MentorID");

            migrationBuilder.CreateIndex(
                name: "IX_FlightInstance_CoPilotAboardID",
                table: "FlightInstance",
                column: "CoPilotAboardID");

            migrationBuilder.CreateIndex(
                name: "IX_FlightInstance_FlightNo",
                table: "FlightInstance",
                column: "FlightNo");

            migrationBuilder.CreateIndex(
                name: "IX_FlightInstance_FSM_AttendantID",
                table: "FlightInstance",
                column: "FSM_AttendantID");

            migrationBuilder.CreateIndex(
                name: "IX_FlightInstance_PilotAboardID",
                table: "FlightInstance",
                column: "PilotAboardID");

            migrationBuilder.CreateIndex(
                name: "IX_FlightInstance_PlaneID",
                table: "FlightInstance",
                column: "PlaneID");

            migrationBuilder.CreateIndex(
                name: "IX_InstanceAttendant_AttendantID",
                table: "InstanceAttendant",
                column: "AttendantID");

            migrationBuilder.CreateIndex(
                name: "IX_PlaneDetail_ModelNumber",
                table: "PlaneDetail",
                column: "ModelNumber");

            migrationBuilder.CreateIndex(
                name: "UK_RegNO",
                table: "PlaneDetail",
                column: "RegistrationNo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlanePilot_PlaneModel",
                table: "PlanePilot",
                column: "PlaneModel");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InstanceAttendant");

            migrationBuilder.DropTable(
                name: "PlanePilot");

            migrationBuilder.DropTable(
                name: "FlightInstance");

            migrationBuilder.DropTable(
                name: "Pilot");

            migrationBuilder.DropTable(
                name: "FlightAttendant");

            migrationBuilder.DropTable(
                name: "Flight");

            migrationBuilder.DropTable(
                name: "PlaneDetail");

            migrationBuilder.DropTable(
                name: "Airport");

            migrationBuilder.DropTable(
                name: "PlaneModel");

            migrationBuilder.DropTable(
                name: "Country");
        }
    }
}

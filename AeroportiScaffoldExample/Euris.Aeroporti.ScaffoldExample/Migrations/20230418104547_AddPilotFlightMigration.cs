using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Euris.Aeroporti.ScaffoldExample.Migrations
{
    /// <inheritdoc />
    public partial class AddPilotFlightMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PilotaVolo",
                columns: table => new
                {
                    FlightsIdVolo = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    PilotsNavigationId = table.Column<string>(type: "nvarchar(8)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PilotaVolo", x => new { x.FlightsIdVolo, x.PilotsNavigationId });
                    table.ForeignKey(
                        name: "FK_PilotaVolo_Piloti_PilotsNavigationId",
                        column: x => x.PilotsNavigationId,
                        principalTable: "Piloti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PilotaVolo_Volo_FlightsIdVolo",
                        column: x => x.FlightsIdVolo,
                        principalTable: "Volo",
                        principalColumn: "IdVolo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PilotaVolo_PilotsNavigationId",
                table: "PilotaVolo",
                column: "PilotsNavigationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PilotaVolo");
        }
    }
}

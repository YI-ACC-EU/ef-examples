using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Euris.Aeroporti.ScaffoldExample.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aereo",
                columns: table => new
                {
                    TipoAereo = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    NumPasseggeri = table.Column<int>(type: "int", nullable: false),
                    QtaMerci = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Aereo__7ADE5096CDA08E91", x => x.TipoAereo);
                });

            migrationBuilder.CreateTable(
                name: "Aeroporto",
                columns: table => new
                {
                    Citta = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Nazione = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NumPiste = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Aeroport__878CD512E0D2AF38", x => x.Citta);
                });

            migrationBuilder.CreateTable(
                name: "Volo",
                columns: table => new
                {
                    IdVolo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    GiornoSett = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CittaPart = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    OraPart = table.Column<TimeSpan>(type: "time", nullable: false),
                    CittaArr = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    OraArr = table.Column<TimeSpan>(type: "time", nullable: false),
                    TipoAereo = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Volo__550D6D6DF0B59EAD", x => x.IdVolo);
                    table.ForeignKey(
                        name: "FK__Volo__CittaArr__2E1BDC42",
                        column: x => x.CittaArr,
                        principalTable: "Aeroporto",
                        principalColumn: "Citta");
                    table.ForeignKey(
                        name: "FK__Volo__CittaPart__2D27B809",
                        column: x => x.CittaPart,
                        principalTable: "Aeroporto",
                        principalColumn: "Citta");
                    table.ForeignKey(
                        name: "FK__Volo__TipoAereo__2F10007B",
                        column: x => x.TipoAereo,
                        principalTable: "Aereo",
                        principalColumn: "TipoAereo");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Volo_CittaArr",
                table: "Volo",
                column: "CittaArr");

            migrationBuilder.CreateIndex(
                name: "IX_Volo_CittaPart",
                table: "Volo",
                column: "CittaPart");

            migrationBuilder.CreateIndex(
                name: "IX_Volo_TipoAereo",
                table: "Volo",
                column: "TipoAereo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Volo");

            migrationBuilder.DropTable(
                name: "Aeroporto");

            migrationBuilder.DropTable(
                name: "Aereo");
        }
    }
}

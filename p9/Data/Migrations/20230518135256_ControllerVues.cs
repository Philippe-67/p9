using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace p9.Data.Migrations
{
    /// <inheritdoc />
    public partial class ControllerVues : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Voitures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Annee = table.Column<int>(type: "int", nullable: false),
                    Marque = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Modele = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Finition = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateAchat = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PrixAchat = table.Column<float>(type: "real", nullable: true),
                    PrixVente = table.Column<float>(type: "real", nullable: true),
                    DateVente = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EstDisponible = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NomPhoto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CheminPhoto = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voitures", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reparations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateReparation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TypeIntervention = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CoutReparation = table.Column<float>(type: "real", nullable: false),
                    VoitureId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reparations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reparations_Voitures_VoitureId",
                        column: x => x.VoitureId,
                        principalTable: "Voitures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reparations_VoitureId",
                table: "Reparations",
                column: "VoitureId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reparations");

            migrationBuilder.DropTable(
                name: "Voitures");
        }
    }
}

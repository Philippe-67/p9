using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace p9.Data.Migrations
{
    /// <inheritdoc />
    public partial class RoleUtilisateur : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UtilisateurId",
                table: "Voitures",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Utilisateurs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pw = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utilisateurs", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Voitures_UtilisateurId",
                table: "Voitures",
                column: "UtilisateurId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Voitures_Utilisateurs_UtilisateurId",
                table: "Voitures",
                column: "UtilisateurId",
                principalTable: "Utilisateurs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Voitures_Utilisateurs_UtilisateurId",
                table: "Voitures");

            migrationBuilder.DropTable(
                name: "Utilisateurs");

            migrationBuilder.DropIndex(
                name: "IX_Voitures_UtilisateurId",
                table: "Voitures");

            migrationBuilder.DropColumn(
                name: "UtilisateurId",
                table: "Voitures");
        }
    }
}

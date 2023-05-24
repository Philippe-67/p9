using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace p9.Data.Migrations
{
    /// <inheritdoc />
    public partial class essai : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Voitures_Utilisateurs_UtilisateurId",
                table: "Voitures");

            migrationBuilder.AlterColumn<int>(
                name: "UtilisateurId",
                table: "Voitures",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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

            migrationBuilder.AlterColumn<int>(
                name: "UtilisateurId",
                table: "Voitures",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Voitures_Utilisateurs_UtilisateurId",
                table: "Voitures",
                column: "UtilisateurId",
                principalTable: "Utilisateurs",
                principalColumn: "Id");
        }
    }
}

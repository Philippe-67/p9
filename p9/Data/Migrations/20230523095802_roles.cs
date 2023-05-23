using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace p9.Data.Migrations
{
    /// <inheritdoc />
    public partial class roles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Voitures_Utilisateurs_UtilisateurId",
                table: "Voitures");

            migrationBuilder.DropIndex(
                name: "IX_Voitures_UtilisateurId",
                table: "Voitures");

            migrationBuilder.AlterColumn<int>(
                name: "UtilisateurId",
                table: "Voitures",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "Utilisateurs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Pw",
                table: "Utilisateurs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Utilisateurs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Voitures_UtilisateurId",
                table: "Voitures",
                column: "UtilisateurId");

            migrationBuilder.AddForeignKey(
                name: "FK_Voitures_Utilisateurs_UtilisateurId",
                table: "Voitures",
                column: "UtilisateurId",
                principalTable: "Utilisateurs",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Voitures_Utilisateurs_UtilisateurId",
                table: "Voitures");

            migrationBuilder.DropIndex(
                name: "IX_Voitures_UtilisateurId",
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

            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "Utilisateurs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Pw",
                table: "Utilisateurs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Utilisateurs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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
    }
}

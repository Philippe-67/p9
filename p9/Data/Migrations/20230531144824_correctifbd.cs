using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace p9.Data.Migrations
{
    /// <inheritdoc />
    public partial class correctifbd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CheminPhoto",
                table: "Voitures");

            migrationBuilder.DropColumn(
                name: "NomPhoto",
                table: "Voitures");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CheminPhoto",
                table: "Voitures",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NomPhoto",
                table: "Voitures",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}

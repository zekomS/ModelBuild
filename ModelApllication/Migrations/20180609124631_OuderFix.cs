using Microsoft.EntityFrameworkCore.Migrations;

namespace ModelApllication.Migrations
{
    public partial class OuderFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Naam",
                table: "Ouders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Voornaam",
                table: "Ouders",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "leeftijd",
                table: "Ouders",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Naam",
                table: "Ouders");

            migrationBuilder.DropColumn(
                name: "Voornaam",
                table: "Ouders");

            migrationBuilder.DropColumn(
                name: "leeftijd",
                table: "Ouders");
        }
    }
}

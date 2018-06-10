using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ModelApllication.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kinderen",
                columns: table => new
                {
                    Naam = table.Column<string>(nullable: true),
                    Voornaam = table.Column<string>(nullable: true),
                    leeftijd = table.Column<int>(nullable: true),
                    id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kinderen", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Ouders",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ouders", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "OurderKinderen",
                columns: table => new
                {
                    Kindid = table.Column<Guid>(nullable: true),
                    Ouderid = table.Column<Guid>(nullable: true),
                    Id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OurderKinderen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OurderKinderen_Kinderen_Kindid",
                        column: x => x.Kindid,
                        principalTable: "Kinderen",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OurderKinderen_Ouders_Ouderid",
                        column: x => x.Ouderid,
                        principalTable: "Ouders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OurderKinderen_Kindid",
                table: "OurderKinderen",
                column: "Kindid");

            migrationBuilder.CreateIndex(
                name: "IX_OurderKinderen_Ouderid",
                table: "OurderKinderen",
                column: "Ouderid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OurderKinderen");

            migrationBuilder.DropTable(
                name: "Kinderen");

            migrationBuilder.DropTable(
                name: "Ouders");
        }
    }
}

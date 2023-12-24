using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JITCATALOG.INFRASTRUCTURE.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Auteur",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    FullName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    DateNaissance = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auteur", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Editeur",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    TitreEditeur = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    DateEditeur = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Editeur", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Nom = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Livre",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    ISBN = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Titre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    DatePublication = table.Column<DateTime>(type: "date", nullable: true),
                    NombrePage = table.Column<int>(type: "int", nullable: true),
                    FormatLivre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    EditeurId = table.Column<int>(type: "int", nullable: true),
                    AuteurId = table.Column<int>(type: "int", nullable: true),
                    Couverture = table.Column<string>(type: "text", nullable: true),
                    IsDisponible = table.Column<bool>(type: "bit", nullable: true),
                    Langue = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    GenreId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Livre", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Livre_Editeur",
                        column: x => x.EditeurId,
                        principalTable: "Editeur",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Livre_Genre",
                        column: x => x.GenreId,
                        principalTable: "Genre",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Catalogue",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Nom = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    DateModif = table.Column<DateTime>(type: "date", nullable: true),
                    LivreId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catalogue", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Catalogue_Livre",
                        column: x => x.LivreId,
                        principalTable: "Livre",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Historique",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    LivreId = table.Column<int>(type: "int", nullable: true),
                    AuteurId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Historique", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Historique_Auteur",
                        column: x => x.AuteurId,
                        principalTable: "Auteur",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Historique_Livre",
                        column: x => x.LivreId,
                        principalTable: "Livre",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Catalogue_LivreId",
                table: "Catalogue",
                column: "LivreId");

            migrationBuilder.CreateIndex(
                name: "IX_Historique_AuteurId",
                table: "Historique",
                column: "AuteurId");

            migrationBuilder.CreateIndex(
                name: "IX_Historique_LivreId",
                table: "Historique",
                column: "LivreId");

            migrationBuilder.CreateIndex(
                name: "IX_Livre_EditeurId",
                table: "Livre",
                column: "EditeurId");

            migrationBuilder.CreateIndex(
                name: "IX_Livre_GenreId",
                table: "Livre",
                column: "GenreId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Catalogue");

            migrationBuilder.DropTable(
                name: "Historique");

            migrationBuilder.DropTable(
                name: "Auteur");

            migrationBuilder.DropTable(
                name: "Livre");

            migrationBuilder.DropTable(
                name: "Editeur");

            migrationBuilder.DropTable(
                name: "Genre");
        }
    }
}

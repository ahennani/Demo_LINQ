using Microsoft.EntityFrameworkCore.Migrations;

namespace Demo_LINQ.Migrations
{
    public partial class M0_InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    Num_Department = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Name_Department = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Lieu = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Departme__2F3606BCA41F1BA0", x => x.Num_Department);
                });

            migrationBuilder.CreateTable(
                name: "Fournisseur",
                columns: table => new
                {
                    Num_Fourniture = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Name_Fournisseur = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Ville = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Fourniss__C10ED305FC51716E", x => x.Num_Fourniture);
                });

            migrationBuilder.CreateTable(
                name: "Produit",
                columns: table => new
                {
                    Code_Produit = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Libelle = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Origine = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Couleur = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Produit__1706ED70D67EE8A2", x => x.Code_Produit);
                });

            migrationBuilder.CreateTable(
                name: "Projet",
                columns: table => new
                {
                    Code_Projet = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Name_Projet = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Projet__B0DA995C0ACED830", x => x.Code_Projet);
                });

            migrationBuilder.CreateTable(
                name: "Employe",
                columns: table => new
                {
                    Matricule = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Name_Employe = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Poste = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    ID_Sup = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Salaire = table.Column<decimal>(type: "money", nullable: false),
                    Num_Department = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Employe__0FB9FB42F29433F5", x => x.Matricule);
                    table.ForeignKey(
                        name: "FK__Employe__ID_Sup__38996AB5",
                        column: x => x.ID_Sup,
                        principalTable: "Employe",
                        principalColumn: "Matricule",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Employe__Num_Dep__398D8EEE",
                        column: x => x.Num_Department,
                        principalTable: "Department",
                        principalColumn: "Num_Department",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Fourniture",
                columns: table => new
                {
                    Num_Fourniture = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Code_Produit = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Quantite = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK__Fournitur__Code___45F365D3",
                        column: x => x.Code_Produit,
                        principalTable: "Produit",
                        principalColumn: "Code_Produit",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Fournitur__Num_F__44FF419A",
                        column: x => x.Num_Fourniture,
                        principalTable: "Fournisseur",
                        principalColumn: "Num_Fourniture",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Participer",
                columns: table => new
                {
                    Matricule = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Code_Projet = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Particip__D4B452D79391D420", x => new { x.Matricule, x.Code_Projet });
                    table.ForeignKey(
                        name: "FK__Participe__Code___3F466844",
                        column: x => x.Code_Projet,
                        principalTable: "Projet",
                        principalColumn: "Code_Projet",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Participe__Matri__3E52440B",
                        column: x => x.Matricule,
                        principalTable: "Employe",
                        principalColumn: "Matricule",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employe_ID_Sup",
                table: "Employe",
                column: "ID_Sup");

            migrationBuilder.CreateIndex(
                name: "IX_Employe_Num_Department",
                table: "Employe",
                column: "Num_Department");

            migrationBuilder.CreateIndex(
                name: "IX_Fourniture_Code_Produit",
                table: "Fourniture",
                column: "Code_Produit");

            migrationBuilder.CreateIndex(
                name: "IX_Fourniture_Num_Fourniture",
                table: "Fourniture",
                column: "Num_Fourniture");

            migrationBuilder.CreateIndex(
                name: "IX_Participer_Code_Projet",
                table: "Participer",
                column: "Code_Projet");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fourniture");

            migrationBuilder.DropTable(
                name: "Participer");

            migrationBuilder.DropTable(
                name: "Produit");

            migrationBuilder.DropTable(
                name: "Fournisseur");

            migrationBuilder.DropTable(
                name: "Projet");

            migrationBuilder.DropTable(
                name: "Employe");

            migrationBuilder.DropTable(
                name: "Department");
        }
    }
}

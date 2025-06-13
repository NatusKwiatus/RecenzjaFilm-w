using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace bazaDanych.Migrations
{
    /// <inheritdoc />
    public partial class dane : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Wpisy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ocena = table.Column<int>(type: "int", nullable: false),
                    Recenzje = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wpisy", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Filmy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tytul = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WpisId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filmy", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Filmy_Wpisy_WpisId",
                        column: x => x.WpisId,
                        principalTable: "Wpisy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.InsertData(
                table: "Wpisy",
                columns: new[] { "Id", "Ocena", "Recenzje" },
                values: new object[,]
                {
                    { 1, 7, "Fajne" },
                    { 2, 10, "Mega mocne" },
                    { 3, 2, "Slabe" },
                    { 4, 5, "Moze byc" }
                });

            migrationBuilder.InsertData(
                table: "Filmy",
                columns: new[] { "Id", "Opis", "Tytul", "WpisId" },
                values: new object[,]
                {
                    { 1, "Dziewczynka zaprzyjaznia sie z kosmita", "Lilo i stich", 1 },
                    { 2, " 24 nastolatkowie walcza na smierc i zycie umieraja ", "Igrzyska Śmierci", 2 },
                    { 3, "O 3 wiewiorkach ktore spiewaja ", "Alwin i Wiewiórki", 3 },
                    { 4, "Bohaterowie proboja powstrzymac zagrozenie na skale wszechswiata", "Infinity war", 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Filmy_WpisId",
                table: "Filmy",
                column: "WpisId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Filmy");

            migrationBuilder.DropTable(
                name: "Wpisy");
        }
    }
}

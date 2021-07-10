using Microsoft.EntityFrameworkCore.Migrations;

namespace CashBank3.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClienteItems",
                columns: table => new
                {
                    email_proprietario = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sobrenome = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClienteItems", x => x.email_proprietario);
                });

            migrationBuilder.CreateTable(
                name: "CarteiraItems",
                columns: table => new
                {
                    id_carteira = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fk_email_proprietario = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    saldo = table.Column<double>(type: "float", nullable: false, defaultValue: 0.0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarteiraItems", x => x.id_carteira);
                    table.ForeignKey(
                        name: "FK_CarteiraItems_ClienteItems_fk_email_proprietario",
                        column: x => x.fk_email_proprietario,
                        principalTable: "ClienteItems",
                        principalColumn: "email_proprietario",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarteiraItems_fk_email_proprietario",
                table: "CarteiraItems",
                column: "fk_email_proprietario",
                unique: true,
                filter: "[fk_email_proprietario] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarteiraItems");

            migrationBuilder.DropTable(
                name: "ClienteItems");
        }
    }
}

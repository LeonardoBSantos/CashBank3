using Microsoft.EntityFrameworkCore.Migrations;

namespace CashBank3.Migrations
{
    public partial class addtransacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarteiraItems_ClienteItems_fk_email_proprietario",
                table: "CarteiraItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarteiraItems",
                table: "CarteiraItems");

            migrationBuilder.DropIndex(
                name: "IX_CarteiraItems_fk_email_proprietario",
                table: "CarteiraItems");

            migrationBuilder.RenameTable(
                name: "CarteiraItems",
                newName: "Carteira");

            migrationBuilder.AlterColumn<string>(
                name: "fk_email_proprietario",
                table: "Carteira",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Carteira",
                table: "Carteira",
                column: "id_carteira");

            migrationBuilder.CreateTable(
                name: "Transacao",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tipo_operacao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fk_id_carteira = table.Column<int>(type: "int", nullable: false),
                    valor = table.Column<double>(type: "float", nullable: false),
                    Carteiraid_carteira = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transacao", x => x.id);
                    table.ForeignKey(
                        name: "FK_Transacao_Carteira_Carteiraid_carteira",
                        column: x => x.Carteiraid_carteira,
                        principalTable: "Carteira",
                        principalColumn: "id_carteira",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Carteira_fk_email_proprietario",
                table: "Carteira",
                column: "fk_email_proprietario",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transacao_Carteiraid_carteira",
                table: "Transacao",
                column: "Carteiraid_carteira");

            migrationBuilder.AddForeignKey(
                name: "FK_Carteira_ClienteItems_fk_email_proprietario",
                table: "Carteira",
                column: "fk_email_proprietario",
                principalTable: "ClienteItems",
                principalColumn: "email_proprietario",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carteira_ClienteItems_fk_email_proprietario",
                table: "Carteira");

            migrationBuilder.DropTable(
                name: "Transacao");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Carteira",
                table: "Carteira");

            migrationBuilder.DropIndex(
                name: "IX_Carteira_fk_email_proprietario",
                table: "Carteira");

            migrationBuilder.RenameTable(
                name: "Carteira",
                newName: "CarteiraItems");

            migrationBuilder.AlterColumn<string>(
                name: "fk_email_proprietario",
                table: "CarteiraItems",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarteiraItems",
                table: "CarteiraItems",
                column: "id_carteira");

            migrationBuilder.CreateIndex(
                name: "IX_CarteiraItems_fk_email_proprietario",
                table: "CarteiraItems",
                column: "fk_email_proprietario",
                unique: true,
                filter: "[fk_email_proprietario] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_CarteiraItems_ClienteItems_fk_email_proprietario",
                table: "CarteiraItems",
                column: "fk_email_proprietario",
                principalTable: "ClienteItems",
                principalColumn: "email_proprietario",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

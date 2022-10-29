using Microsoft.EntityFrameworkCore.Migrations;

namespace BibliotecaFSJ.DAO.Migrations
{
    public partial class IdConversa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mensagens_Conversas_ConversaId",
                table: "Mensagens");

            migrationBuilder.AlterColumn<long>(
                name: "ConversaId",
                table: "Mensagens",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Mensagens_Conversas_ConversaId",
                table: "Mensagens",
                column: "ConversaId",
                principalTable: "Conversas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mensagens_Conversas_ConversaId",
                table: "Mensagens");

            migrationBuilder.AlterColumn<long>(
                name: "ConversaId",
                table: "Mensagens",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_Mensagens_Conversas_ConversaId",
                table: "Mensagens",
                column: "ConversaId",
                principalTable: "Conversas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

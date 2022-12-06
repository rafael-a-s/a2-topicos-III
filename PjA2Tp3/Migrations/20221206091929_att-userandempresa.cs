using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PjA2Tp3.Migrations
{
    public partial class attuserandempresa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Telefone_Empresa_EmpresaId",
                table: "Telefone");

            migrationBuilder.DropIndex(
                name: "IX_Telefone_EmpresaId",
                table: "Telefone");

            migrationBuilder.DropIndex(
                name: "IX_Telefone_UsuarioId",
                table: "Telefone");

            migrationBuilder.DropColumn(
                name: "EmpresaId",
                table: "Telefone");

            migrationBuilder.AlterColumn<int>(
                name: "Perfil",
                table: "Usuario",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Telefone_UsuarioId",
                table: "Telefone",
                column: "UsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Telefone_UsuarioId",
                table: "Telefone");

            migrationBuilder.AlterColumn<int>(
                name: "Perfil",
                table: "Usuario",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "EmpresaId",
                table: "Telefone",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Telefone_EmpresaId",
                table: "Telefone",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Telefone_UsuarioId",
                table: "Telefone",
                column: "UsuarioId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Telefone_Empresa_EmpresaId",
                table: "Telefone",
                column: "EmpresaId",
                principalTable: "Empresa",
                principalColumn: "Id");
        }
    }
}

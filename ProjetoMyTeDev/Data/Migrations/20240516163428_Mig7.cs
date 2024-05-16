using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoMyTeDev.Data.Migrations
{
    /// <inheritdoc />
    public partial class Mig7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CodigoAtividade",
                table: "Departamento");

            migrationBuilder.RenameColumn(
                name: "NomeFunc",
                table: "Funcionario",
                newName: "Localidade");

            migrationBuilder.RenameColumn(
                name: "NivelAcesso",
                table: "Funcionario",
                newName: "NivelAcessoId");

            migrationBuilder.RenameColumn(
                name: "DtContratacao",
                table: "Funcionario",
                newName: "DataContratacao");

            migrationBuilder.RenameColumn(
                name: "DeptoFunc",
                table: "Funcionario",
                newName: "FuncionarioNome");

            migrationBuilder.RenameColumn(
                name: "NomeDepto",
                table: "Departamento",
                newName: "DepartamentoNome");

            migrationBuilder.RenameColumn(
                name: "NivelAcessoId",
                table: "CargaHoraria",
                newName: "CargoId");

            migrationBuilder.AddColumn<int>(
                name: "CargoId",
                table: "Funcionario",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DepartamentoId",
                table: "Funcionario",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Cargo",
                columns: table => new
                {
                    CargoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CargoNome = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cargo", x => x.CargoId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Funcionario_CargoId",
                table: "Funcionario",
                column: "CargoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionario_Cargo_CargoId",
                table: "Funcionario",
                column: "CargoId",
                principalTable: "Cargo",
                principalColumn: "CargoId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Funcionario_Cargo_CargoId",
                table: "Funcionario");

            migrationBuilder.DropTable(
                name: "Cargo");

            migrationBuilder.DropIndex(
                name: "IX_Funcionario_CargoId",
                table: "Funcionario");

            migrationBuilder.DropColumn(
                name: "CargoId",
                table: "Funcionario");

            migrationBuilder.DropColumn(
                name: "DepartamentoId",
                table: "Funcionario");

            migrationBuilder.RenameColumn(
                name: "NivelAcessoId",
                table: "Funcionario",
                newName: "NivelAcesso");

            migrationBuilder.RenameColumn(
                name: "Localidade",
                table: "Funcionario",
                newName: "NomeFunc");

            migrationBuilder.RenameColumn(
                name: "FuncionarioNome",
                table: "Funcionario",
                newName: "DeptoFunc");

            migrationBuilder.RenameColumn(
                name: "DataContratacao",
                table: "Funcionario",
                newName: "DtContratacao");

            migrationBuilder.RenameColumn(
                name: "DepartamentoNome",
                table: "Departamento",
                newName: "NomeDepto");

            migrationBuilder.RenameColumn(
                name: "CargoId",
                table: "CargaHoraria",
                newName: "NivelAcessoId");

            migrationBuilder.AddColumn<string>(
                name: "CodigoAtividade",
                table: "Departamento",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}

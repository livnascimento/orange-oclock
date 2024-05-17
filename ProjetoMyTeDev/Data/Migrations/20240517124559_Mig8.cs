using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoMyTeDev.Data.Migrations
{
    /// <inheritdoc />
    public partial class Mig8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CargaHoraria");

            migrationBuilder.AlterColumn<string>(
                name: "FuncionarioNome",
                table: "Funcionario",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Funcionario",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Senha",
                table: "Funcionario",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "DepartamentoNome",
                table: "Departamento",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CargoNome",
                table: "Cargo",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CargaHoraria",
                table: "Cargo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "NivelAcesso",
                columns: table => new
                {
                    NivelAcessoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NivelAcessoNome = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NivelAcesso", x => x.NivelAcessoId);
                });

            migrationBuilder.CreateTable(
                name: "Wbs",
                columns: table => new
                {
                    WbsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WbsCodigo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WbsTipo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WbsDescricao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wbs", x => x.WbsId);
                });

            migrationBuilder.CreateTable(
                name: "RegistroDiario",
                columns: table => new
                {
                    RegistroDiarioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FuncionarioId = table.Column<int>(type: "int", nullable: false),
                    WbsId = table.Column<int>(type: "int", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Horas = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistroDiario", x => x.RegistroDiarioId);
                    table.ForeignKey(
                        name: "FK_RegistroDiario_Funcionario_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionario",
                        principalColumn: "FuncionarioId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RegistroDiario_Wbs_WbsId",
                        column: x => x.WbsId,
                        principalTable: "Wbs",
                        principalColumn: "WbsId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Funcionario_DepartamentoId",
                table: "Funcionario",
                column: "DepartamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionario_NivelAcessoId",
                table: "Funcionario",
                column: "NivelAcessoId");

            migrationBuilder.CreateIndex(
                name: "IX_RegistroDiario_FuncionarioId",
                table: "RegistroDiario",
                column: "FuncionarioId");

            migrationBuilder.CreateIndex(
                name: "IX_RegistroDiario_WbsId",
                table: "RegistroDiario",
                column: "WbsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionario_Departamento_DepartamentoId",
                table: "Funcionario",
                column: "DepartamentoId",
                principalTable: "Departamento",
                principalColumn: "DepartamentoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionario_NivelAcesso_NivelAcessoId",
                table: "Funcionario",
                column: "NivelAcessoId",
                principalTable: "NivelAcesso",
                principalColumn: "NivelAcessoId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Funcionario_Departamento_DepartamentoId",
                table: "Funcionario");

            migrationBuilder.DropForeignKey(
                name: "FK_Funcionario_NivelAcesso_NivelAcessoId",
                table: "Funcionario");

            migrationBuilder.DropTable(
                name: "NivelAcesso");

            migrationBuilder.DropTable(
                name: "RegistroDiario");

            migrationBuilder.DropTable(
                name: "Wbs");

            migrationBuilder.DropIndex(
                name: "IX_Funcionario_DepartamentoId",
                table: "Funcionario");

            migrationBuilder.DropIndex(
                name: "IX_Funcionario_NivelAcessoId",
                table: "Funcionario");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Funcionario");

            migrationBuilder.DropColumn(
                name: "Senha",
                table: "Funcionario");

            migrationBuilder.DropColumn(
                name: "CargaHoraria",
                table: "Cargo");

            migrationBuilder.AlterColumn<string>(
                name: "FuncionarioNome",
                table: "Funcionario",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "DepartamentoNome",
                table: "Departamento",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CargoNome",
                table: "Cargo",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "CargaHoraria",
                columns: table => new
                {
                    CargaHorariaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CargoId = table.Column<int>(type: "int", nullable: false),
                    Horas = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CargaHoraria", x => x.CargaHorariaId);
                });
        }
    }
}

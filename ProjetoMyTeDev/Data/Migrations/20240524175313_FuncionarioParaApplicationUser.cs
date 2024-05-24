using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoMyTeDev.Data.Migrations
{
    /// <inheritdoc />
    public partial class FuncionarioParaApplicationUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RegistroDiario_Funcionario_FuncionarioId",
                table: "RegistroDiario");

            migrationBuilder.DropTable(
                name: "Funcionario");

            migrationBuilder.DropIndex(
                name: "IX_RegistroDiario_FuncionarioId",
                table: "RegistroDiario");

            migrationBuilder.RenameColumn(
                name: "FuncionarioId",
                table: "RegistroDiario",
                newName: "ApplicationUserId");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "Data",
                table: "RegistroDiario",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId1",
                table: "RegistroDiario",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CargoId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateOnly>(
                name: "DataContratacao",
                table: "AspNetUsers",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DepartamentoId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(21)",
                maxLength: 21,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Localidade",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RegistroDiario_ApplicationUserId1",
                table: "RegistroDiario",
                column: "ApplicationUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CargoId",
                table: "AspNetUsers",
                column: "CargoId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_DepartamentoId",
                table: "AspNetUsers",
                column: "DepartamentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Cargo_CargoId",
                table: "AspNetUsers",
                column: "CargoId",
                principalTable: "Cargo",
                principalColumn: "CargoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Departamento_DepartamentoId",
                table: "AspNetUsers",
                column: "DepartamentoId",
                principalTable: "Departamento",
                principalColumn: "DepartamentoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RegistroDiario_AspNetUsers_ApplicationUserId1",
                table: "RegistroDiario",
                column: "ApplicationUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Cargo_CargoId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Departamento_DepartamentoId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_RegistroDiario_AspNetUsers_ApplicationUserId1",
                table: "RegistroDiario");

            migrationBuilder.DropIndex(
                name: "IX_RegistroDiario_ApplicationUserId1",
                table: "RegistroDiario");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_CargoId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_DepartamentoId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId1",
                table: "RegistroDiario");

            migrationBuilder.DropColumn(
                name: "CargoId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DataContratacao",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DepartamentoId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Localidade",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserId",
                table: "RegistroDiario",
                newName: "FuncionarioId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Data",
                table: "RegistroDiario",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.CreateTable(
                name: "Funcionario",
                columns: table => new
                {
                    FuncionarioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CargoId = table.Column<int>(type: "int", nullable: false),
                    DepartamentoId = table.Column<int>(type: "int", nullable: false),
                    NivelAcessoId = table.Column<int>(type: "int", nullable: false),
                    DataContratacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FuncionarioNome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Localidade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionario", x => x.FuncionarioId);
                    table.ForeignKey(
                        name: "FK_Funcionario_Cargo_CargoId",
                        column: x => x.CargoId,
                        principalTable: "Cargo",
                        principalColumn: "CargoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Funcionario_Departamento_DepartamentoId",
                        column: x => x.DepartamentoId,
                        principalTable: "Departamento",
                        principalColumn: "DepartamentoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Funcionario_NivelAcesso_NivelAcessoId",
                        column: x => x.NivelAcessoId,
                        principalTable: "NivelAcesso",
                        principalColumn: "NivelAcessoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RegistroDiario_FuncionarioId",
                table: "RegistroDiario",
                column: "FuncionarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionario_CargoId",
                table: "Funcionario",
                column: "CargoId");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionario_DepartamentoId",
                table: "Funcionario",
                column: "DepartamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionario_NivelAcessoId",
                table: "Funcionario",
                column: "NivelAcessoId");

            migrationBuilder.AddForeignKey(
                name: "FK_RegistroDiario_Funcionario_FuncionarioId",
                table: "RegistroDiario",
                column: "FuncionarioId",
                principalTable: "Funcionario",
                principalColumn: "FuncionarioId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

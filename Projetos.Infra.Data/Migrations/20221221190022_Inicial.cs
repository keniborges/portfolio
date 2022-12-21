using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Projetos.Infra.Data.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Funcionario",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: true),
                    Cargo = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Projeto",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    DataInicio = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    PrevisaoTermino = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TerminoReal = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    OrcamentoTotal = table.Column<decimal>(type: "numeric", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    Classificacao = table.Column<int>(type: "integer", nullable: false),
                    Gerente = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projeto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FuncionarioProjeto",
                columns: table => new
                {
                    FuncionariosId = table.Column<long>(type: "bigint", nullable: false),
                    ProjetosId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FuncionarioProjeto", x => new { x.FuncionariosId, x.ProjetosId });
                    table.ForeignKey(
                        name: "FK_FuncionarioProjeto_Funcionario_FuncionariosId",
                        column: x => x.FuncionariosId,
                        principalTable: "Funcionario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FuncionarioProjeto_Projeto_ProjetosId",
                        column: x => x.ProjetosId,
                        principalTable: "Projeto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FuncionarioProjeto_ProjetosId",
                table: "FuncionarioProjeto",
                column: "ProjetosId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FuncionarioProjeto");

            migrationBuilder.DropTable(
                name: "Funcionario");

            migrationBuilder.DropTable(
                name: "Projeto");
        }
    }
}

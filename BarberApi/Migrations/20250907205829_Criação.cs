using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BarberApi.Migrations
{
    /// <inheritdoc />
    public partial class Criação : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    ClientId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(245)", maxLength: 245, nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "date", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.ClientId);
                });

            migrationBuilder.CreateTable(
                name: "Agendamentos",
                columns: table => new
                {
                    AgendamentoId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataHora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Observacoes = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    ClientId = table.Column<long>(type: "bigint", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agendamentos", x => x.AgendamentoId);
                    table.ForeignKey(
                        name: "FK_Agendamentos_Clientes_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clientes",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Servicos",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeServico = table.Column<int>(type: "int", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    DuracaoMin = table.Column<int>(type: "int", nullable: false),
                    Preco = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    AgendamentoId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Servicos_Agendamentos_AgendamentoId",
                        column: x => x.AgendamentoId,
                        principalTable: "Agendamentos",
                        principalColumn: "AgendamentoId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agendamentos_ClientId",
                table: "Agendamentos",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Servicos_AgendamentoId",
                table: "Servicos",
                column: "AgendamentoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Servicos");

            migrationBuilder.DropTable(
                name: "Agendamentos");

            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}

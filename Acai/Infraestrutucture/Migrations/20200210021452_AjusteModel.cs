using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infraestrutucture.Migrations
{
    public partial class AjusteModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adicionais_Pedidos_PedidoId",
                table: "Adicionais");

            migrationBuilder.DropIndex(
                name: "IX_Adicionais_PedidoId",
                table: "Adicionais");

            migrationBuilder.DropColumn(
                name: "PedidoId",
                table: "Adicionais");

            migrationBuilder.AddColumn<int>(
                name: "MinutosAdicionais",
                table: "Sabores",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "PedidoAdicional",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdPedido = table.Column<Guid>(nullable: false),
                    IdAdicional = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidoAdicional", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PedidoAdicional_Adicionais_IdAdicional",
                        column: x => x.IdAdicional,
                        principalTable: "Adicionais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PedidoAdicional_Pedidos_IdPedido",
                        column: x => x.IdPedido,
                        principalTable: "Pedidos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PedidoAdicional_IdAdicional",
                table: "PedidoAdicional",
                column: "IdAdicional");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoAdicional_IdPedido",
                table: "PedidoAdicional",
                column: "IdPedido");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PedidoAdicional");

            migrationBuilder.DropColumn(
                name: "MinutosAdicionais",
                table: "Sabores");

            migrationBuilder.AddColumn<Guid>(
                name: "PedidoId",
                table: "Adicionais",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Adicionais_PedidoId",
                table: "Adicionais",
                column: "PedidoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Adicionais_Pedidos_PedidoId",
                table: "Adicionais",
                column: "PedidoId",
                principalTable: "Pedidos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

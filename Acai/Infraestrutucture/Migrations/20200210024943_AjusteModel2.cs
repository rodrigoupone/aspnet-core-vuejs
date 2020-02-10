using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infraestrutucture.Migrations
{
    public partial class AjusteModel2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Sabores_SaborId",
                table: "Pedidos");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Tamanhos_TamanhoId",
                table: "Pedidos");

            migrationBuilder.DropIndex(
                name: "IX_Pedidos_SaborId",
                table: "Pedidos");

            migrationBuilder.DropIndex(
                name: "IX_Pedidos_TamanhoId",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "SaborId",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "TamanhoId",
                table: "Pedidos");

            migrationBuilder.AddColumn<Guid>(
                name: "IdSabor",
                table: "Pedidos",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "IdTamanho",
                table: "Pedidos",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "TempoTotal",
                table: "Pedidos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "ValorTotal",
                table: "Pedidos",
                type: "Decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_IdSabor",
                table: "Pedidos",
                column: "IdSabor");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_IdTamanho",
                table: "Pedidos",
                column: "IdTamanho");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Sabores_IdSabor",
                table: "Pedidos",
                column: "IdSabor",
                principalTable: "Sabores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Tamanhos_IdTamanho",
                table: "Pedidos",
                column: "IdTamanho",
                principalTable: "Tamanhos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Sabores_IdSabor",
                table: "Pedidos");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Tamanhos_IdTamanho",
                table: "Pedidos");

            migrationBuilder.DropIndex(
                name: "IX_Pedidos_IdSabor",
                table: "Pedidos");

            migrationBuilder.DropIndex(
                name: "IX_Pedidos_IdTamanho",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "IdSabor",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "IdTamanho",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "TempoTotal",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "ValorTotal",
                table: "Pedidos");

            migrationBuilder.AddColumn<Guid>(
                name: "SaborId",
                table: "Pedidos",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TamanhoId",
                table: "Pedidos",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_SaborId",
                table: "Pedidos",
                column: "SaborId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_TamanhoId",
                table: "Pedidos",
                column: "TamanhoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Sabores_SaborId",
                table: "Pedidos",
                column: "SaborId",
                principalTable: "Sabores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Tamanhos_TamanhoId",
                table: "Pedidos",
                column: "TamanhoId",
                principalTable: "Tamanhos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

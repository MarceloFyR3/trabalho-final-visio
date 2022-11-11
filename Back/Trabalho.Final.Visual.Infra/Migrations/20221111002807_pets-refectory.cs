using Microsoft.EntityFrameworkCore.Migrations;

namespace Trabalho.Final.Visual.Infra.Migrations
{
    public partial class petsrefectory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agendas_Pet_PetId",
                table: "Agendas");

            migrationBuilder.AddColumn<int>(
                name: "ClienteId",
                table: "Pet",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "PetId",
                table: "Agendas",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pet_ClienteId",
                table: "Pet",
                column: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Agendas_Pet_PetId",
                table: "Agendas",
                column: "PetId",
                principalTable: "Pet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pet_Clientes_ClienteId",
                table: "Pet",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agendas_Pet_PetId",
                table: "Agendas");

            migrationBuilder.DropForeignKey(
                name: "FK_Pet_Clientes_ClienteId",
                table: "Pet");

            migrationBuilder.DropIndex(
                name: "IX_Pet_ClienteId",
                table: "Pet");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "Pet");

            migrationBuilder.AlterColumn<int>(
                name: "PetId",
                table: "Agendas",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Agendas_Pet_PetId",
                table: "Agendas",
                column: "PetId",
                principalTable: "Pet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

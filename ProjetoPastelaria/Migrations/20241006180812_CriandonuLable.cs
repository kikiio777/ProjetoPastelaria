using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoPastelaria.Migrations
{
    public partial class CriandonuLable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Endereco",
                table: "Funcionarios",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Endereco",
                table: "Funcionarios");
        }
    }
}

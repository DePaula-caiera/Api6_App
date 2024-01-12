using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IWantApp.Migrations
{
    public partial class FixNome_CreatedBy_Categoria : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreateBy",
                table: "Produtos",
                newName: "CreatedBy");

            migrationBuilder.RenameColumn(
                name: "CreateBy",
                table: "Categorias",
                newName: "CreatedBy");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "Produtos",
                newName: "CreateBy");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "Categorias",
                newName: "CreateBy");
        }
    }
}

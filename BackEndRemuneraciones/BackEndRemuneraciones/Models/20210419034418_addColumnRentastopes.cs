using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEndRemuneraciones.Models
{
    public partial class addColumnRentastopes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TipoTopeMinImp",
                table: "RentasMinImponibles",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipoTopeMinImp",
                table: "RentasMinImponibles");
        }
    }
}

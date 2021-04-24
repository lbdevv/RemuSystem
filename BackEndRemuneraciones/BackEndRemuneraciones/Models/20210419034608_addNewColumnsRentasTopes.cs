using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEndRemuneraciones.Models
{
    public partial class addNewColumnsRentasTopes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "EstaActiva",
                table: "RentasMinImponibles",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "Fecha",
                table: "RentasMinImponibles",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EstaActiva",
                table: "RentasMinImponibles");

            migrationBuilder.DropColumn(
                name: "Fecha",
                table: "RentasMinImponibles");
        }
    }
}

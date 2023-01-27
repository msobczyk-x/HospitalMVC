using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalManager.Migrations
{
    public partial class Auth221 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Imie",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Nazwisko",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Imie",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Nazwisko",
                table: "AspNetUsers");
        }
    }
}

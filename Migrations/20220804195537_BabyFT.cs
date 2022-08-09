using Microsoft.EntityFrameworkCore.Migrations;

namespace EnergyRust.Migrations
{
    public partial class BabyFT : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InteractiveDataId",
                table: "BabyFT");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InteractiveDataId",
                table: "BabyFT",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}

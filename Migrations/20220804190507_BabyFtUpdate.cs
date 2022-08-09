using Microsoft.EntityFrameworkCore.Migrations;

namespace EnergyRust.Migrations
{
    public partial class BabyFtUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InteractiveDataId",
                table: "BabyFT",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "BabyFT",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "BabyFTInteractiveData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BabyFTId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BabyFTInteractiveData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BabyFTInteractiveData_BabyFT_BabyFTId",
                        column: x => x.BabyFTId,
                        principalTable: "BabyFT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BabyFTGame",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BabyFTInteractiveDataId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BabyFTGame", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BabyFTGame_BabyFTInteractiveData_BabyFTInteractiveDataId",
                        column: x => x.BabyFTInteractiveDataId,
                        principalTable: "BabyFTInteractiveData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BabyFTGame_BabyFTInteractiveDataId",
                table: "BabyFTGame",
                column: "BabyFTInteractiveDataId",
                unique: true,
                filter: "[BabyFTInteractiveDataId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BabyFTInteractiveData_BabyFTId",
                table: "BabyFTInteractiveData",
                column: "BabyFTId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BabyFTGame");

            migrationBuilder.DropTable(
                name: "BabyFTInteractiveData");

            migrationBuilder.DropColumn(
                name: "InteractiveDataId",
                table: "BabyFT");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "BabyFT");
        }
    }
}

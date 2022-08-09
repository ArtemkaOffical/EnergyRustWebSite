using Microsoft.EntityFrameworkCore.Migrations;

namespace EnergyRust.Migrations
{
    public partial class InteractiveGame : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "BabyFTGame");

            migrationBuilder.AddColumn<int>(
                name: "AnswerId",
                table: "BabyFTGame",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "BabyFTGameData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BabyFTGameId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BabyFTGameData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BabyFTGameData_BabyFTGame_BabyFTGameId",
                        column: x => x.BabyFTGameId,
                        principalTable: "BabyFTGame",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BabyFTGameData_BabyFTGameId",
                table: "BabyFTGameData",
                column: "BabyFTGameId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BabyFTGameData");

            migrationBuilder.DropColumn(
                name: "AnswerId",
                table: "BabyFTGame");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "BabyFTGame",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}

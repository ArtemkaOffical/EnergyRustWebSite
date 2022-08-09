using Microsoft.EntityFrameworkCore.Migrations;

namespace EnergyRust.Migrations
{
    public partial class BabyFtRemoveCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BabyFT_BabyFTCategories_CategoryId",
                table: "BabyFT");

            migrationBuilder.DropTable(
                name: "BabyFTCategories");

            migrationBuilder.DropIndex(
                name: "IX_BabyFT_CategoryId",
                table: "BabyFT");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "BabyFT");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "BabyFT",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "BabyFTCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BabyFTCategories", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BabyFT_CategoryId",
                table: "BabyFT",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_BabyFT_BabyFTCategories_CategoryId",
                table: "BabyFT",
                column: "CategoryId",
                principalTable: "BabyFTCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

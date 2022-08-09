using Microsoft.EntityFrameworkCore.Migrations;

namespace EnergyRust.Migrations
{
    public partial class GSLabs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BabyFTCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BabyFTCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PartyTimeCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartyTimeCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BabyFT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VideoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BabyFT", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BabyFT_BabyFTCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "BabyFTCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PartyTimes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VideoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartyTimes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PartyTimes_PartyTimeCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "PartyTimeCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BabyFT_CategoryId",
                table: "BabyFT",
                column: "CategoryId",
                unique: true,
                filter: "[CategoryId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_PartyTimes_CategoryId",
                table: "PartyTimes",
                column: "CategoryId",
                unique: true,
                filter: "[CategoryId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BabyFT");

            migrationBuilder.DropTable(
                name: "PartyTimes");

            migrationBuilder.DropTable(
                name: "BabyFTCategories");

            migrationBuilder.DropTable(
                name: "PartyTimeCategories");
        }
    }
}

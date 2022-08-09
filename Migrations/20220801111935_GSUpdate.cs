using Microsoft.EntityFrameworkCore.Migrations;

namespace EnergyRust.Migrations
{
    public partial class GSUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BabyFT_BabyFTCategories_CategoryId",
                table: "BabyFT");

            migrationBuilder.DropForeignKey(
                name: "FK_PartyTimes_PartyTimeCategories_CategoryId",
                table: "PartyTimes");

            migrationBuilder.DropIndex(
                name: "IX_PartyTimes_CategoryId",
                table: "PartyTimes");

            migrationBuilder.DropIndex(
                name: "IX_BabyFT_CategoryId",
                table: "BabyFT");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "PartyTimes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PosterUrl",
                table: "PartyTimes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "BabyFT",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PosterUrl",
                table: "BabyFT",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PartyTimes_CategoryId",
                table: "PartyTimes",
                column: "CategoryId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_PartyTimes_PartyTimeCategories_CategoryId",
                table: "PartyTimes",
                column: "CategoryId",
                principalTable: "PartyTimeCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BabyFT_BabyFTCategories_CategoryId",
                table: "BabyFT");

            migrationBuilder.DropForeignKey(
                name: "FK_PartyTimes_PartyTimeCategories_CategoryId",
                table: "PartyTimes");

            migrationBuilder.DropIndex(
                name: "IX_PartyTimes_CategoryId",
                table: "PartyTimes");

            migrationBuilder.DropIndex(
                name: "IX_BabyFT_CategoryId",
                table: "BabyFT");

            migrationBuilder.DropColumn(
                name: "PosterUrl",
                table: "PartyTimes");

            migrationBuilder.DropColumn(
                name: "PosterUrl",
                table: "BabyFT");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "PartyTimes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "BabyFT",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_PartyTimes_CategoryId",
                table: "PartyTimes",
                column: "CategoryId",
                unique: true,
                filter: "[CategoryId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BabyFT_CategoryId",
                table: "BabyFT",
                column: "CategoryId",
                unique: true,
                filter: "[CategoryId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_BabyFT_BabyFTCategories_CategoryId",
                table: "BabyFT",
                column: "CategoryId",
                principalTable: "BabyFTCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PartyTimes_PartyTimeCategories_CategoryId",
                table: "PartyTimes",
                column: "CategoryId",
                principalTable: "PartyTimeCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

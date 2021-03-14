using Microsoft.EntityFrameworkCore.Migrations;

namespace Pixelstats.Migrations
{
    public partial class GameModes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GameModeId",
                table: "Stats",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "GameModes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameModes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Stats_GameModeId",
                table: "Stats",
                column: "GameModeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Stats_GameModes_GameModeId",
                table: "Stats",
                column: "GameModeId",
                principalTable: "GameModes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stats_GameModes_GameModeId",
                table: "Stats");

            migrationBuilder.DropTable(
                name: "GameModes");

            migrationBuilder.DropIndex(
                name: "IX_Stats_GameModeId",
                table: "Stats");

            migrationBuilder.DropColumn(
                name: "GameModeId",
                table: "Stats");
        }
    }
}

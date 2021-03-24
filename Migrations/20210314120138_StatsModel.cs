using Microsoft.EntityFrameworkCore.Migrations;

namespace Pixelstats.Migrations
{
    public partial class StatsModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StatsId",
                table: "GameModes",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Statistics",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statistics", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GameModes_StatsId",
                table: "GameModes",
                column: "StatsId");

            migrationBuilder.AddForeignKey(
                name: "FK_GameModes_Statistics_StatsId",
                table: "GameModes",
                column: "StatsId",
                principalTable: "Statistics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameModes_Statistics_StatsId",
                table: "GameModes");

            migrationBuilder.DropTable(
                name: "Statistics");

            migrationBuilder.DropIndex(
                name: "IX_GameModes_StatsId",
                table: "GameModes");

            migrationBuilder.DropColumn(
                name: "StatsId",
                table: "GameModes");
        }
    }
}

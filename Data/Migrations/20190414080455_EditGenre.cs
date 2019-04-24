using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class EditGenre : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Genres_AssetDetails_BookId",
                table: "Genres");

            migrationBuilder.DropIndex(
                name: "IX_Genres_BookId",
                table: "Genres");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "Genres");

            migrationBuilder.CreateTable(
                name: "GenreBooks",
                columns: table => new
                {
                    BookId = table.Column<int>(nullable: false),
                    GenreId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenreBooks", x => new { x.BookId, x.GenreId });
                    table.ForeignKey(
                        name: "FK_GenreBooks_AssetDetails_BookId",
                        column: x => x.BookId,
                        principalTable: "AssetDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GenreBooks_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GenreBooks_GenreId",
                table: "GenreBooks",
                column: "GenreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GenreBooks");

            migrationBuilder.AddColumn<int>(
                name: "BookId",
                table: "Genres",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Genres_BookId",
                table: "Genres",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_Genres_AssetDetails_BookId",
                table: "Genres",
                column: "BookId",
                principalTable: "AssetDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

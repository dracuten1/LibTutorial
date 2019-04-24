using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class EditDbToManagerAssetCategory1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GenreBooks");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AssetOriginDetail");

            migrationBuilder.DropColumn(
                name: "Author",
                table: "AssetOriginDetail");

            migrationBuilder.DropColumn(
                name: "DeweyIndex",
                table: "AssetOriginDetail");

            migrationBuilder.DropColumn(
                name: "ISBN",
                table: "AssetOriginDetail");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AssetOriginDetail",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Author",
                table: "AssetOriginDetail",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeweyIndex",
                table: "AssetOriginDetail",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ISBN",
                table: "AssetOriginDetail",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

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
                        name: "FK_GenreBooks_AssetOriginDetail_BookId",
                        column: x => x.BookId,
                        principalTable: "AssetOriginDetail",
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
    }
}

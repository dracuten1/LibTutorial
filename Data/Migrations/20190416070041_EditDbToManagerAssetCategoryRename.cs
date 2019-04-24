using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class EditDbToManagerAssetCategoryRename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssetInLibrary_AssetOriginDetail_AssetDetailId",
                table: "AssetInLibrary");

            migrationBuilder.DropForeignKey(
                name: "FK_AttributeTypes_AssetTypes_AssetTypeId",
                table: "AttributeTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_AttributeValues_AssetOriginDetail_AssetId",
                table: "AttributeValues");

            migrationBuilder.DropTable(
                name: "AssetOriginDetail");

            migrationBuilder.DropTable(
                name: "AssetTypes");

            migrationBuilder.DropIndex(
                name: "IX_AttributeValues_AssetId",
                table: "AttributeValues");

            migrationBuilder.DropIndex(
                name: "IX_AttributeTypes_AssetTypeId",
                table: "AttributeTypes");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "AttributeValues",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AssetCategoryId",
                table: "AttributeTypes",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AssetCategories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ParentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssetCategories_AssetCategories_ParentId",
                        column: x => x.ParentId,
                        principalTable: "AssetCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    Year = table.Column<int>(nullable: false),
                    Cost = table.Column<decimal>(nullable: false),
                    AssetCategoryId = table.Column<int>(nullable: true),
                    ImageUrls = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_AssetCategories_AssetCategoryId",
                        column: x => x.AssetCategoryId,
                        principalTable: "AssetCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AttributeValues_ProductId",
                table: "AttributeValues",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_AttributeTypes_AssetCategoryId",
                table: "AttributeTypes",
                column: "AssetCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetCategories_ParentId",
                table: "AssetCategories",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_AssetCategoryId",
                table: "Products",
                column: "AssetCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_AssetInLibrary_Products_AssetDetailId",
                table: "AssetInLibrary",
                column: "AssetDetailId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AttributeTypes_AssetCategories_AssetCategoryId",
                table: "AttributeTypes",
                column: "AssetCategoryId",
                principalTable: "AssetCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AttributeValues_Products_ProductId",
                table: "AttributeValues",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssetInLibrary_Products_AssetDetailId",
                table: "AssetInLibrary");

            migrationBuilder.DropForeignKey(
                name: "FK_AttributeTypes_AssetCategories_AssetCategoryId",
                table: "AttributeTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_AttributeValues_Products_ProductId",
                table: "AttributeValues");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "AssetCategories");

            migrationBuilder.DropIndex(
                name: "IX_AttributeValues_ProductId",
                table: "AttributeValues");

            migrationBuilder.DropIndex(
                name: "IX_AttributeTypes_AssetCategoryId",
                table: "AttributeTypes");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "AttributeValues");

            migrationBuilder.DropColumn(
                name: "AssetCategoryId",
                table: "AttributeTypes");

            migrationBuilder.CreateTable(
                name: "AssetTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    ParentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssetTypes_AssetTypes_ParentId",
                        column: x => x.ParentId,
                        principalTable: "AssetTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AssetOriginDetail",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AssetTypeId = table.Column<int>(nullable: true),
                    Cost = table.Column<decimal>(nullable: false),
                    ImageUrls = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Year = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetOriginDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssetOriginDetail_AssetTypes_AssetTypeId",
                        column: x => x.AssetTypeId,
                        principalTable: "AssetTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AttributeValues_AssetId",
                table: "AttributeValues",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_AttributeTypes_AssetTypeId",
                table: "AttributeTypes",
                column: "AssetTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetOriginDetail_AssetTypeId",
                table: "AssetOriginDetail",
                column: "AssetTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetTypes_ParentId",
                table: "AssetTypes",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_AssetInLibrary_AssetOriginDetail_AssetDetailId",
                table: "AssetInLibrary",
                column: "AssetDetailId",
                principalTable: "AssetOriginDetail",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AttributeTypes_AssetTypes_AssetTypeId",
                table: "AttributeTypes",
                column: "AssetTypeId",
                principalTable: "AssetTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AttributeValues_AssetOriginDetail_AssetId",
                table: "AttributeValues",
                column: "AssetId",
                principalTable: "AssetOriginDetail",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

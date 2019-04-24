using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class MakeRightAssetInLibrary : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssetInLibrary_Products_AssetDetailId",
                table: "AssetInLibrary");

            migrationBuilder.DropForeignKey(
                name: "FK_AttributeValues_Products_ProductId",
                table: "AttributeValues");

            migrationBuilder.RenameColumn(
                name: "AssetDetailId",
                table: "AssetInLibrary",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_AssetInLibrary_AssetDetailId",
                table: "AssetInLibrary",
                newName: "IX_AssetInLibrary_ProductId");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "AssetInLibrary",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AssetInLibrary_CategoryId",
                table: "AssetInLibrary",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_AssetInLibrary_AssetCategories_CategoryId",
                table: "AssetInLibrary",
                column: "CategoryId",
                principalTable: "AssetCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AssetInLibrary_Products_ProductId",
                table: "AssetInLibrary",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AttributeValues_AssetCategories_ProductId",
                table: "AttributeValues",
                column: "ProductId",
                principalTable: "AssetCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssetInLibrary_AssetCategories_CategoryId",
                table: "AssetInLibrary");

            migrationBuilder.DropForeignKey(
                name: "FK_AssetInLibrary_Products_ProductId",
                table: "AssetInLibrary");

            migrationBuilder.DropForeignKey(
                name: "FK_AttributeValues_AssetCategories_ProductId",
                table: "AttributeValues");

            migrationBuilder.DropIndex(
                name: "IX_AssetInLibrary_CategoryId",
                table: "AssetInLibrary");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "AssetInLibrary");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "AssetInLibrary",
                newName: "AssetDetailId");

            migrationBuilder.RenameIndex(
                name: "IX_AssetInLibrary_ProductId",
                table: "AssetInLibrary",
                newName: "IX_AssetInLibrary_AssetDetailId");

            migrationBuilder.AddForeignKey(
                name: "FK_AssetInLibrary_Products_AssetDetailId",
                table: "AssetInLibrary",
                column: "AssetDetailId",
                principalTable: "Products",
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
    }
}

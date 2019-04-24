using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class MakeRightAssetInLibrary1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssetInLibrary_AssetCategories_CategoryId",
                table: "AssetInLibrary");

            migrationBuilder.DropForeignKey(
                name: "FK_CheckoutHistories_LibraryBranches_LibraryBranchId",
                table: "CheckoutHistories");

            migrationBuilder.DropIndex(
                name: "IX_CheckoutHistories_LibraryBranchId",
                table: "CheckoutHistories");

            migrationBuilder.DropIndex(
                name: "IX_AssetInLibrary_CategoryId",
                table: "AssetInLibrary");

            migrationBuilder.DropColumn(
                name: "LibraryBranchId",
                table: "CheckoutHistories");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "AssetInLibrary");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LibraryBranchId",
                table: "CheckoutHistories",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "AssetInLibrary",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CheckoutHistories_LibraryBranchId",
                table: "CheckoutHistories",
                column: "LibraryBranchId");

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
                name: "FK_CheckoutHistories_LibraryBranches_LibraryBranchId",
                table: "CheckoutHistories",
                column: "LibraryBranchId",
                principalTable: "LibraryBranches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

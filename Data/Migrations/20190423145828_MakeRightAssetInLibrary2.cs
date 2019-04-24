using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class MakeRightAssetInLibrary2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AttributeValues_AttributeTypes_AttributeTypeId",
                table: "AttributeValues");

            migrationBuilder.DropForeignKey(
                name: "FK_AttributeValues_AssetCategories_ProductId",
                table: "AttributeValues");

            migrationBuilder.DropIndex(
                name: "IX_AttributeValues_AttributeTypeId",
                table: "AttributeValues");

            migrationBuilder.DropColumn(
                name: "AssetId",
                table: "AttributeValues");

            migrationBuilder.DropColumn(
                name: "AssetTypeId",
                table: "AttributeTypes");

            migrationBuilder.AddColumn<int>(
                name: "CategoryAttributeId",
                table: "AttributeValues",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AttributeValues_CategoryAttributeId",
                table: "AttributeValues",
                column: "CategoryAttributeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AttributeValues_AttributeTypes_CategoryAttributeId",
                table: "AttributeValues",
                column: "CategoryAttributeId",
                principalTable: "AttributeTypes",
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
                name: "FK_AttributeValues_AttributeTypes_CategoryAttributeId",
                table: "AttributeValues");

            migrationBuilder.DropForeignKey(
                name: "FK_AttributeValues_Products_ProductId",
                table: "AttributeValues");

            migrationBuilder.DropIndex(
                name: "IX_AttributeValues_CategoryAttributeId",
                table: "AttributeValues");

            migrationBuilder.DropColumn(
                name: "CategoryAttributeId",
                table: "AttributeValues");

            migrationBuilder.AddColumn<int>(
                name: "AssetId",
                table: "AttributeValues",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AssetTypeId",
                table: "AttributeTypes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AttributeValues_AttributeTypeId",
                table: "AttributeValues",
                column: "AttributeTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AttributeValues_AttributeTypes_AttributeTypeId",
                table: "AttributeValues",
                column: "AttributeTypeId",
                principalTable: "AttributeTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AttributeValues_AssetCategories_ProductId",
                table: "AttributeValues",
                column: "ProductId",
                principalTable: "AssetCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

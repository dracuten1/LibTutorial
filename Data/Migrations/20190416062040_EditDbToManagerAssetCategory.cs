using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class EditDbToManagerAssetCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssetDetails_AssetTypes_AssetTypeId",
                table: "AssetDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_AssetDetails_Genres_GenreId",
                table: "AssetDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Checkout_LibraryAssets_LibraryAssetId",
                table: "Checkout");

            migrationBuilder.DropForeignKey(
                name: "FK_CheckoutHistories_LibraryAssets_LibraryAssetId",
                table: "CheckoutHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_GenreBooks_AssetDetails_BookId",
                table: "GenreBooks");

            migrationBuilder.DropForeignKey(
                name: "FK_Holds_LibraryAssets_LibraryAssetId",
                table: "Holds");

            migrationBuilder.DropTable(
                name: "LibraryAssets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AssetDetails",
                table: "AssetDetails");

            migrationBuilder.DropIndex(
                name: "IX_AssetDetails_GenreId",
                table: "AssetDetails");

            migrationBuilder.DropColumn(
                name: "Director",
                table: "AssetDetails");

            migrationBuilder.DropColumn(
                name: "GenreId",
                table: "AssetDetails");

            migrationBuilder.RenameTable(
                name: "AssetDetails",
                newName: "AssetOriginDetail");

            migrationBuilder.RenameIndex(
                name: "IX_AssetDetails_AssetTypeId",
                table: "AssetOriginDetail",
                newName: "IX_AssetOriginDetail_AssetTypeId");

            migrationBuilder.AddColumn<int>(
                name: "ParentId",
                table: "AssetTypes",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AssetOriginDetail",
                table: "AssetOriginDetail",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "AssetInLibrary",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LocationId = table.Column<int>(nullable: true),
                    StatusId = table.Column<int>(nullable: true),
                    AssetDetailId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetInLibrary", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssetInLibrary_AssetOriginDetail_AssetDetailId",
                        column: x => x.AssetDetailId,
                        principalTable: "AssetOriginDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AssetInLibrary_LibraryBranches_LocationId",
                        column: x => x.LocationId,
                        principalTable: "LibraryBranches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AssetInLibrary_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AttributeTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ValueSystemType = table.Column<string>(nullable: true),
                    AssetTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttributeTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AttributeTypes_AssetTypes_AssetTypeId",
                        column: x => x.AssetTypeId,
                        principalTable: "AssetTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AttributeValues",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AttributeTypeId = table.Column<int>(nullable: false),
                    AssetId = table.Column<int>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttributeValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AttributeValues_AssetOriginDetail_AssetId",
                        column: x => x.AssetId,
                        principalTable: "AssetOriginDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AttributeValues_AttributeTypes_AttributeTypeId",
                        column: x => x.AttributeTypeId,
                        principalTable: "AttributeTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssetTypes_ParentId",
                table: "AssetTypes",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetInLibrary_AssetDetailId",
                table: "AssetInLibrary",
                column: "AssetDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetInLibrary_LocationId",
                table: "AssetInLibrary",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetInLibrary_StatusId",
                table: "AssetInLibrary",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_AttributeTypes_AssetTypeId",
                table: "AttributeTypes",
                column: "AssetTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AttributeValues_AssetId",
                table: "AttributeValues",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_AttributeValues_AttributeTypeId",
                table: "AttributeValues",
                column: "AttributeTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AssetOriginDetail_AssetTypes_AssetTypeId",
                table: "AssetOriginDetail",
                column: "AssetTypeId",
                principalTable: "AssetTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AssetTypes_AssetTypes_ParentId",
                table: "AssetTypes",
                column: "ParentId",
                principalTable: "AssetTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Checkout_AssetInLibrary_LibraryAssetId",
                table: "Checkout",
                column: "LibraryAssetId",
                principalTable: "AssetInLibrary",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CheckoutHistories_AssetInLibrary_LibraryAssetId",
                table: "CheckoutHistories",
                column: "LibraryAssetId",
                principalTable: "AssetInLibrary",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GenreBooks_AssetOriginDetail_BookId",
                table: "GenreBooks",
                column: "BookId",
                principalTable: "AssetOriginDetail",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Holds_AssetInLibrary_LibraryAssetId",
                table: "Holds",
                column: "LibraryAssetId",
                principalTable: "AssetInLibrary",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssetOriginDetail_AssetTypes_AssetTypeId",
                table: "AssetOriginDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_AssetTypes_AssetTypes_ParentId",
                table: "AssetTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_Checkout_AssetInLibrary_LibraryAssetId",
                table: "Checkout");

            migrationBuilder.DropForeignKey(
                name: "FK_CheckoutHistories_AssetInLibrary_LibraryAssetId",
                table: "CheckoutHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_GenreBooks_AssetOriginDetail_BookId",
                table: "GenreBooks");

            migrationBuilder.DropForeignKey(
                name: "FK_Holds_AssetInLibrary_LibraryAssetId",
                table: "Holds");

            migrationBuilder.DropTable(
                name: "AssetInLibrary");

            migrationBuilder.DropTable(
                name: "AttributeValues");

            migrationBuilder.DropTable(
                name: "AttributeTypes");

            migrationBuilder.DropIndex(
                name: "IX_AssetTypes_ParentId",
                table: "AssetTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AssetOriginDetail",
                table: "AssetOriginDetail");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "AssetTypes");

            migrationBuilder.RenameTable(
                name: "AssetOriginDetail",
                newName: "AssetDetails");

            migrationBuilder.RenameIndex(
                name: "IX_AssetOriginDetail_AssetTypeId",
                table: "AssetDetails",
                newName: "IX_AssetDetails_AssetTypeId");

            migrationBuilder.AddColumn<string>(
                name: "Director",
                table: "AssetDetails",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GenreId",
                table: "AssetDetails",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AssetDetails",
                table: "AssetDetails",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "LibraryAssets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AssetDetailId = table.Column<int>(nullable: true),
                    LocationId = table.Column<int>(nullable: true),
                    StatusId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LibraryAssets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LibraryAssets_AssetDetails_AssetDetailId",
                        column: x => x.AssetDetailId,
                        principalTable: "AssetDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LibraryAssets_LibraryBranches_LocationId",
                        column: x => x.LocationId,
                        principalTable: "LibraryBranches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LibraryAssets_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssetDetails_GenreId",
                table: "AssetDetails",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_LibraryAssets_AssetDetailId",
                table: "LibraryAssets",
                column: "AssetDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_LibraryAssets_LocationId",
                table: "LibraryAssets",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_LibraryAssets_StatusId",
                table: "LibraryAssets",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_AssetDetails_AssetTypes_AssetTypeId",
                table: "AssetDetails",
                column: "AssetTypeId",
                principalTable: "AssetTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AssetDetails_Genres_GenreId",
                table: "AssetDetails",
                column: "GenreId",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Checkout_LibraryAssets_LibraryAssetId",
                table: "Checkout",
                column: "LibraryAssetId",
                principalTable: "LibraryAssets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CheckoutHistories_LibraryAssets_LibraryAssetId",
                table: "CheckoutHistories",
                column: "LibraryAssetId",
                principalTable: "LibraryAssets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GenreBooks_AssetDetails_BookId",
                table: "GenreBooks",
                column: "BookId",
                principalTable: "AssetDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Holds_LibraryAssets_LibraryAssetId",
                table: "Holds",
                column: "LibraryAssetId",
                principalTable: "LibraryAssets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

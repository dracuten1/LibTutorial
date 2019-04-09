using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class LibraryCardPatronFinal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CheckoutHistories_LibraryCards_LibraryCardId",
                table: "CheckoutHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_Checkouts_LibraryCards_LibraryCardId",
                table: "Checkouts");

            migrationBuilder.DropForeignKey(
                name: "FK_Holds_LibraryCards_LibraryCardId",
                table: "Holds");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LibraryCards",
                table: "LibraryCards");

            migrationBuilder.DropIndex(
                name: "IX_LibraryCards_PatronId",
                table: "LibraryCards");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "LibraryCards");

            migrationBuilder.RenameColumn(
                name: "LibraryCardId",
                table: "Holds",
                newName: "LibraryCardPatronId");

            migrationBuilder.RenameIndex(
                name: "IX_Holds_LibraryCardId",
                table: "Holds",
                newName: "IX_Holds_LibraryCardPatronId");

            migrationBuilder.RenameColumn(
                name: "LibraryCardId",
                table: "Checkouts",
                newName: "LibraryCardPatronId");

            migrationBuilder.RenameIndex(
                name: "IX_Checkouts_LibraryCardId",
                table: "Checkouts",
                newName: "IX_Checkouts_LibraryCardPatronId");

            migrationBuilder.RenameColumn(
                name: "LibraryCardId",
                table: "CheckoutHistories",
                newName: "LibraryCardPatronId");

            migrationBuilder.RenameIndex(
                name: "IX_CheckoutHistories_LibraryCardId",
                table: "CheckoutHistories",
                newName: "IX_CheckoutHistories_LibraryCardPatronId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LibraryCards",
                table: "LibraryCards",
                column: "PatronId");

            migrationBuilder.AddForeignKey(
                name: "FK_CheckoutHistories_LibraryCards_LibraryCardPatronId",
                table: "CheckoutHistories",
                column: "LibraryCardPatronId",
                principalTable: "LibraryCards",
                principalColumn: "PatronId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Checkouts_LibraryCards_LibraryCardPatronId",
                table: "Checkouts",
                column: "LibraryCardPatronId",
                principalTable: "LibraryCards",
                principalColumn: "PatronId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Holds_LibraryCards_LibraryCardPatronId",
                table: "Holds",
                column: "LibraryCardPatronId",
                principalTable: "LibraryCards",
                principalColumn: "PatronId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CheckoutHistories_LibraryCards_LibraryCardPatronId",
                table: "CheckoutHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_Checkouts_LibraryCards_LibraryCardPatronId",
                table: "Checkouts");

            migrationBuilder.DropForeignKey(
                name: "FK_Holds_LibraryCards_LibraryCardPatronId",
                table: "Holds");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LibraryCards",
                table: "LibraryCards");

            migrationBuilder.RenameColumn(
                name: "LibraryCardPatronId",
                table: "Holds",
                newName: "LibraryCardId");

            migrationBuilder.RenameIndex(
                name: "IX_Holds_LibraryCardPatronId",
                table: "Holds",
                newName: "IX_Holds_LibraryCardId");

            migrationBuilder.RenameColumn(
                name: "LibraryCardPatronId",
                table: "Checkouts",
                newName: "LibraryCardId");

            migrationBuilder.RenameIndex(
                name: "IX_Checkouts_LibraryCardPatronId",
                table: "Checkouts",
                newName: "IX_Checkouts_LibraryCardId");

            migrationBuilder.RenameColumn(
                name: "LibraryCardPatronId",
                table: "CheckoutHistories",
                newName: "LibraryCardId");

            migrationBuilder.RenameIndex(
                name: "IX_CheckoutHistories_LibraryCardPatronId",
                table: "CheckoutHistories",
                newName: "IX_CheckoutHistories_LibraryCardId");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "LibraryCards",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_LibraryCards",
                table: "LibraryCards",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_LibraryCards_PatronId",
                table: "LibraryCards",
                column: "PatronId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CheckoutHistories_LibraryCards_LibraryCardId",
                table: "CheckoutHistories",
                column: "LibraryCardId",
                principalTable: "LibraryCards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Checkouts_LibraryCards_LibraryCardId",
                table: "Checkouts",
                column: "LibraryCardId",
                principalTable: "LibraryCards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Holds_LibraryCards_LibraryCardId",
                table: "Holds",
                column: "LibraryCardId",
                principalTable: "LibraryCards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

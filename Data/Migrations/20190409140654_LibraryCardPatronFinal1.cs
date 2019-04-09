using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class LibraryCardPatronFinal1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropForeignKey(
                name: "FK_LibraryCards_Patrons_PatronId",
                table: "LibraryCards");

            migrationBuilder.RenameColumn(
                name: "PatronId",
                table: "LibraryCards",
                newName: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_LibraryCards_Patrons_Id",
                table: "LibraryCards",
                column: "Id",
                principalTable: "Patrons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropForeignKey(
                name: "FK_LibraryCards_Patrons_Id",
                table: "LibraryCards");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "LibraryCards",
                newName: "PatronId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_LibraryCards_Patrons_PatronId",
                table: "LibraryCards",
                column: "PatronId",
                principalTable: "Patrons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

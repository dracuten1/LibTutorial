using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations {
    class RenameLibraryCard : Migration {
        protected override void Up(MigrationBuilder migrationBuilder) {
            migrationBuilder.RenameColumn("LibraryCards", "Id", "PatronId");
        }
        protected override void Down(MigrationBuilder migrationBuilder) {
            migrationBuilder.RenameColumn("LibraryCards", "PatronId", "Id");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FreeMovies.API.Migrations.BrightMinds
{
    /// <inheritdoc />
    public partial class FixRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookCategory_Authors_AuthorId",
                table: "BookCategory");

            migrationBuilder.RenameColumn(
                name: "AuthorId",
                table: "BookCategory",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_BookCategory_AuthorId",
                table: "BookCategory",
                newName: "IX_BookCategory_CategoryId");

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CategoryName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_BookCategory_Category_CategoryId",
                table: "BookCategory",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookCategory_Category_CategoryId",
                table: "BookCategory");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "BookCategory",
                newName: "AuthorId");

            migrationBuilder.RenameIndex(
                name: "IX_BookCategory_CategoryId",
                table: "BookCategory",
                newName: "IX_BookCategory_AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookCategory_Authors_AuthorId",
                table: "BookCategory",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "AuthorId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

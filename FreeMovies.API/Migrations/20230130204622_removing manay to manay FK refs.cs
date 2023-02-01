using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FreeMovies.API.Migrations
{
    /// <inheritdoc />
    public partial class removingmanaytomanayFKrefs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActorId",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "MovieId",
                table: "Actors");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ActorId",
                table: "Movies",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MovieId",
                table: "Actors",
                type: "INTEGER",
                nullable: true);
        }
    }
}

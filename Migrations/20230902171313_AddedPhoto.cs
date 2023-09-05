using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieCollectionAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddedPhoto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "MovieCollections",
                type: "longblob",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "MovieCollections");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieCollectionAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddedImageDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "Image",
                table: "MovieCollections",
                type: "longblob",
                nullable: true,
                defaultValue: new byte[0],
                oldClrType: typeof(byte[]),
                oldType: "longblob",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "Image",
                table: "MovieCollections",
                type: "longblob",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "longblob");
        }
    }
}

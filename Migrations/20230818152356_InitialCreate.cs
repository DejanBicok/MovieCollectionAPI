using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieCollectionAPI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE TABLE `MovieCollections` (
                `Id` int NOT NULL AUTO_INCREMENT,
                `Title` varchar(255) NOT NULL,
                `Genre` varchar(255) NOT NULL,
                `ReleaseDate` date NOT NULL,
                `Image` longblob,
                `FkUserId` int,
                PRIMARY KEY (`Id`)
                FOREIGN KEY (`FkUserId`) REFERENCES `Users`(`Id`)
            );");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieCollections");
        }
    }
}

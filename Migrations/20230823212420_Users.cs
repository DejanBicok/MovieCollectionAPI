using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieCollectionAPI.Migrations
{

    public partial class Users : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE TABLE `Users` (
                `Id` int NOT NULL AUTO_INCREMENT,
                `Username` varchar(255) NOT NULL,
                `PasswordHash` varbinary(256) NOT NULL,
                PRIMARY KEY (`Id`)
            );");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
               name: "Users");
        }
    }
}
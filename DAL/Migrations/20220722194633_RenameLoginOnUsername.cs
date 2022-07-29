using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class RenameLoginOnUsername : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "UserNameIndex",
                table: "users");

            migrationBuilder.RenameColumn(
                name: "normalized_login",
                table: "users",
                newName: "normalized_username");

            migrationBuilder.RenameColumn(
                name: "login",
                table: "users",
                newName: "username");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "users",
                column: "normalized_username",
                unique: true,
                filter: "[normalized_username] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "UserNameIndex",
                table: "users");

            migrationBuilder.RenameColumn(
                name: "username",
                table: "users",
                newName: "login");

            migrationBuilder.RenameColumn(
                name: "normalized_username",
                table: "users",
                newName: "normalized_login");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "users",
                column: "normalized_login",
                unique: true,
                filter: "[normalized_login] IS NOT NULL");
        }
    }
}

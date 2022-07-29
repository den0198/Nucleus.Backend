using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class FixUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TwoFactorEnabled",
                table: "users",
                newName: "two_factor_enabled");

            migrationBuilder.RenameColumn(
                name: "LockoutEnd",
                table: "users",
                newName: "lockout_end");

            migrationBuilder.RenameColumn(
                name: "EmailConfirmed",
                table: "users",
                newName: "email_confirmed");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "two_factor_enabled",
                table: "users",
                newName: "TwoFactorEnabled");

            migrationBuilder.RenameColumn(
                name: "lockout_end",
                table: "users",
                newName: "LockoutEnd");

            migrationBuilder.RenameColumn(
                name: "email_confirmed",
                table: "users",
                newName: "EmailConfirmed");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class Fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_user_claims_user_user_id",
                table: "user_claims");

            migrationBuilder.DropForeignKey(
                name: "FK_user_provider_user_user_id",
                table: "user_provider");

            migrationBuilder.DropForeignKey(
                name: "FK_user_roles_user_user_id",
                table: "user_roles");

            migrationBuilder.DropForeignKey(
                name: "FK_user_tokens_user_user_id",
                table: "user_tokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_user",
                table: "user");

            migrationBuilder.RenameTable(
                name: "user",
                newName: "users");

            migrationBuilder.AddPrimaryKey(
                name: "PK_users",
                table: "users",
                column: "user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_user_claims_users_user_id",
                table: "user_claims",
                column: "user_id",
                principalTable: "users",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_user_provider_users_user_id",
                table: "user_provider",
                column: "user_id",
                principalTable: "users",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_user_roles_users_user_id",
                table: "user_roles",
                column: "user_id",
                principalTable: "users",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_user_tokens_users_user_id",
                table: "user_tokens",
                column: "user_id",
                principalTable: "users",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_user_claims_users_user_id",
                table: "user_claims");

            migrationBuilder.DropForeignKey(
                name: "FK_user_provider_users_user_id",
                table: "user_provider");

            migrationBuilder.DropForeignKey(
                name: "FK_user_roles_users_user_id",
                table: "user_roles");

            migrationBuilder.DropForeignKey(
                name: "FK_user_tokens_users_user_id",
                table: "user_tokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_users",
                table: "users");

            migrationBuilder.RenameTable(
                name: "users",
                newName: "user");

            migrationBuilder.AddPrimaryKey(
                name: "PK_user",
                table: "user",
                column: "user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_user_claims_user_user_id",
                table: "user_claims",
                column: "user_id",
                principalTable: "user",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_user_provider_user_user_id",
                table: "user_provider",
                column: "user_id",
                principalTable: "user",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_user_roles_user_user_id",
                table: "user_roles",
                column: "user_id",
                principalTable: "user",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_user_tokens_user_user_id",
                table: "user_tokens",
                column: "user_id",
                principalTable: "user",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

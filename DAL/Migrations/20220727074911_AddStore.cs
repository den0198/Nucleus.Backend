using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class AddStore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_user_provider_users_user_id",
                table: "user_provider");

            migrationBuilder.DropPrimaryKey(
                name: "PK_user_provider",
                table: "user_provider");

            migrationBuilder.RenameTable(
                name: "user_provider",
                newName: "user_providers");

            migrationBuilder.RenameIndex(
                name: "IX_user_provider_user_id",
                table: "user_providers",
                newName: "IX_user_providers_user_id");

            migrationBuilder.AddColumn<long>(
                name: "store_id",
                table: "products",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_user_providers",
                table: "user_providers",
                columns: new[] { "login_provider", "provider_key" });

            migrationBuilder.CreateTable(
                name: "stores",
                columns: table => new
                {
                    store_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    user_id = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_stores", x => x.store_id);
                    table.ForeignKey(
                        name: "FK_stores_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_products_store_id",
                table: "products",
                column: "store_id");

            migrationBuilder.CreateIndex(
                name: "IX_stores_user_id",
                table: "stores",
                column: "user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_products_stores_store_id",
                table: "products",
                column: "store_id",
                principalTable: "stores",
                principalColumn: "store_id");

            migrationBuilder.AddForeignKey(
                name: "FK_user_providers_users_user_id",
                table: "user_providers",
                column: "user_id",
                principalTable: "users",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_stores_store_id",
                table: "products");

            migrationBuilder.DropForeignKey(
                name: "FK_user_providers_users_user_id",
                table: "user_providers");

            migrationBuilder.DropTable(
                name: "stores");

            migrationBuilder.DropIndex(
                name: "IX_products_store_id",
                table: "products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_user_providers",
                table: "user_providers");

            migrationBuilder.DropColumn(
                name: "store_id",
                table: "products");

            migrationBuilder.RenameTable(
                name: "user_providers",
                newName: "user_provider");

            migrationBuilder.RenameIndex(
                name: "IX_user_providers_user_id",
                table: "user_provider",
                newName: "IX_user_provider_user_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_user_provider",
                table: "user_provider",
                columns: new[] { "login_provider", "provider_key" });

            migrationBuilder.AddForeignKey(
                name: "FK_user_provider_users_user_id",
                table: "user_provider",
                column: "user_id",
                principalTable: "users",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

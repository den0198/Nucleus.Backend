using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    role_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    normalized_name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    concurrency_stamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roles", x => x.role_id);
                });

            migrationBuilder.CreateTable(
                name: "users_details",
                columns: table => new
                {
                    user_detail_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_account_id = table.Column<long>(type: "bigint", nullable: false),
                    first_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    last_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    middle_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    age = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users_details", x => x.user_detail_id);
                });

            migrationBuilder.CreateTable(
                name: "role_claims",
                columns: table => new
                {
                    role_claims_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    role_id = table.Column<long>(type: "bigint", nullable: false),
                    claim_type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    claim_value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_role_claims", x => x.role_claims_id);
                    table.ForeignKey(
                        name: "FK_role_claims_roles_role_id",
                        column: x => x.role_id,
                        principalTable: "roles",
                        principalColumn: "role_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "users_accounts",
                columns: table => new
                {
                    user_account_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_detail_id = table.Column<long>(type: "bigint", nullable: true),
                    login = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    normalized_login = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    normalized_email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    password_hash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    security_stamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    concurrency_stamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phone_number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phone_number_confirmed = table.Column<bool>(type: "bit", nullable: false),
                    is_lockout = table.Column<bool>(type: "bit", nullable: false),
                    access_failed_count = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users_accounts", x => x.user_account_id);
                    table.ForeignKey(
                        name: "FK_users_accounts_users_details_user_detail_id",
                        column: x => x.user_detail_id,
                        principalTable: "users_details",
                        principalColumn: "user_detail_id");
                });

            migrationBuilder.CreateTable(
                name: "user_claims",
                columns: table => new
                {
                    user_claims_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_account_id = table.Column<long>(type: "bigint", nullable: false),
                    claim_type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    claim_value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_claims", x => x.user_claims_id);
                    table.ForeignKey(
                        name: "FK_user_claims_users_accounts_user_account_id",
                        column: x => x.user_account_id,
                        principalTable: "users_accounts",
                        principalColumn: "user_account_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_provider",
                columns: table => new
                {
                    login_provider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    provider_key = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    provider_display_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    user_account_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_provider", x => new { x.login_provider, x.provider_key });
                    table.ForeignKey(
                        name: "FK_user_provider_users_accounts_user_account_id",
                        column: x => x.user_account_id,
                        principalTable: "users_accounts",
                        principalColumn: "user_account_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_roles",
                columns: table => new
                {
                    user_account_id = table.Column<long>(type: "bigint", nullable: false),
                    role_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_roles", x => new { x.user_account_id, x.role_id });
                    table.ForeignKey(
                        name: "FK_user_roles_roles_role_id",
                        column: x => x.role_id,
                        principalTable: "roles",
                        principalColumn: "role_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_user_roles_users_accounts_user_account_id",
                        column: x => x.user_account_id,
                        principalTable: "users_accounts",
                        principalColumn: "user_account_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_tokens",
                columns: table => new
                {
                    user_account_id = table.Column<long>(type: "bigint", nullable: false),
                    login_provider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_tokens", x => new { x.user_account_id, x.login_provider, x.name });
                    table.ForeignKey(
                        name: "FK_user_tokens_users_accounts_user_account_id",
                        column: x => x.user_account_id,
                        principalTable: "users_accounts",
                        principalColumn: "user_account_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_role_claims_role_id",
                table: "role_claims",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "roles",
                column: "normalized_name",
                unique: true,
                filter: "[normalized_name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_user_claims_user_account_id",
                table: "user_claims",
                column: "user_account_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_provider_user_account_id",
                table: "user_provider",
                column: "user_account_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_roles_role_id",
                table: "user_roles",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "users_accounts",
                column: "normalized_email");

            migrationBuilder.CreateIndex(
                name: "IX_users_accounts_user_detail_id",
                table: "users_accounts",
                column: "user_detail_id",
                unique: true,
                filter: "[user_detail_id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "users_accounts",
                column: "normalized_login",
                unique: true,
                filter: "[normalized_login] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "role_claims");

            migrationBuilder.DropTable(
                name: "user_claims");

            migrationBuilder.DropTable(
                name: "user_provider");

            migrationBuilder.DropTable(
                name: "user_roles");

            migrationBuilder.DropTable(
                name: "user_tokens");

            migrationBuilder.DropTable(
                name: "roles");

            migrationBuilder.DropTable(
                name: "users_accounts");

            migrationBuilder.DropTable(
                name: "users_details");
        }
    }
}

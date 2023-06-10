using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nucleus.DAL.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    category_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    date_time_created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    date_time_modified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.category_id);
                });

            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    role_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    date_time_created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    date_time_modified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    normalized_name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    concurrency_stamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roles", x => x.role_id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    user_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    first_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    last_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    middle_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    date_time_created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    date_time_modified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    username = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    normalized_username = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    normalized_email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    email_confirmed = table.Column<bool>(type: "bit", nullable: false),
                    password_hash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    security_stamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    concurrency_stamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phone_number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phone_number_confirmed = table.Column<bool>(type: "bit", nullable: false),
                    two_factor_enabled = table.Column<bool>(type: "bit", nullable: false),
                    lockout_end = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    is_lockout = table.Column<bool>(type: "bit", nullable: false),
                    access_failed_count = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.user_id);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    product_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    date_time_created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    date_time_modified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    category_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.product_id);
                    table.ForeignKey(
                        name: "FK_products_categories_category_id",
                        column: x => x.category_id,
                        principalTable: "categories",
                        principalColumn: "category_id");
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
                name: "user_claims",
                columns: table => new
                {
                    user_claims_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    claim_type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    claim_value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_claims", x => x.user_claims_id);
                    table.ForeignKey(
                        name: "FK_user_claims_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_providers",
                columns: table => new
                {
                    login_provider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    provider_key = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    provider_display_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    user_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_providers", x => new { x.login_provider, x.provider_key });
                    table.ForeignKey(
                        name: "FK_user_providers_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_roles",
                columns: table => new
                {
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    role_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_roles", x => new { x.user_id, x.role_id });
                    table.ForeignKey(
                        name: "FK_user_roles_roles_role_id",
                        column: x => x.role_id,
                        principalTable: "roles",
                        principalColumn: "role_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_user_roles_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_tokens",
                columns: table => new
                {
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    login_provider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_tokens", x => new { x.user_id, x.login_provider, x.name });
                    table.ForeignKey(
                        name: "FK_user_tokens_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "add_ons",
                columns: table => new
                {
                    add_on_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    price = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    quantity = table.Column<long>(type: "bigint", nullable: false),
                    date_time_created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    date_time_modified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    product_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_add_ons", x => x.add_on_id);
                    table.ForeignKey(
                        name: "FK_add_ons_products_product_id",
                        column: x => x.product_id,
                        principalTable: "products",
                        principalColumn: "product_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "parameters",
                columns: table => new
                {
                    parameter_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    date_time_created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    date_time_modified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    product_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_parameters", x => x.parameter_id);
                    table.ForeignKey(
                        name: "FK_parameters_products_product_id",
                        column: x => x.product_id,
                        principalTable: "products",
                        principalColumn: "product_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "sub_products",
                columns: table => new
                {
                    sub_product_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    price = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    quantity = table.Column<long>(type: "bigint", nullable: false),
                    date_time_created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    date_time_modified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    product_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sub_products", x => x.sub_product_id);
                    table.ForeignKey(
                        name: "FK_sub_products_products_product_id",
                        column: x => x.product_id,
                        principalTable: "products",
                        principalColumn: "product_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "parameter_values",
                columns: table => new
                {
                    parameter_value_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    date_time_created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    date_time_modified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    parameter_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_parameter_values", x => x.parameter_value_id);
                    table.ForeignKey(
                        name: "FK_parameter_values_parameters_parameter_id",
                        column: x => x.parameter_id,
                        principalTable: "parameters",
                        principalColumn: "parameter_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "sub_product_parameter_values",
                columns: table => new
                {
                    sub_product_parameter_value = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    date_time_created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    date_time_modified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    sub_product_id = table.Column<long>(type: "bigint", nullable: false),
                    parameter_id = table.Column<long>(type: "bigint", nullable: false),
                    parameter_value_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sub_product_parameter_values", x => x.sub_product_parameter_value);
                    table.ForeignKey(
                        name: "FK_sub_product_parameter_values_parameter_values_parameter_value_id",
                        column: x => x.parameter_value_id,
                        principalTable: "parameter_values",
                        principalColumn: "parameter_value_id");
                    table.ForeignKey(
                        name: "FK_sub_product_parameter_values_parameters_parameter_id",
                        column: x => x.parameter_id,
                        principalTable: "parameters",
                        principalColumn: "parameter_id");
                    table.ForeignKey(
                        name: "FK_sub_product_parameter_values_sub_products_sub_product_id",
                        column: x => x.sub_product_id,
                        principalTable: "sub_products",
                        principalColumn: "sub_product_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_add_ons_product_id",
                table: "add_ons",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_parameter_values_parameter_id",
                table: "parameter_values",
                column: "parameter_id");

            migrationBuilder.CreateIndex(
                name: "IX_parameters_product_id",
                table: "parameters",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_products_category_id",
                table: "products",
                column: "category_id");

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
                name: "IX_sub_product_parameter_values_parameter_id",
                table: "sub_product_parameter_values",
                column: "parameter_id");

            migrationBuilder.CreateIndex(
                name: "IX_sub_product_parameter_values_parameter_value_id",
                table: "sub_product_parameter_values",
                column: "parameter_value_id");

            migrationBuilder.CreateIndex(
                name: "IX_sub_product_parameter_values_sub_product_id",
                table: "sub_product_parameter_values",
                column: "sub_product_id");

            migrationBuilder.CreateIndex(
                name: "IX_sub_products_product_id",
                table: "sub_products",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_claims_user_id",
                table: "user_claims",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_providers_user_id",
                table: "user_providers",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_roles_role_id",
                table: "user_roles",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "users",
                column: "normalized_email");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "users",
                column: "normalized_username",
                unique: true,
                filter: "[normalized_username] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "add_ons");

            migrationBuilder.DropTable(
                name: "role_claims");

            migrationBuilder.DropTable(
                name: "sub_product_parameter_values");

            migrationBuilder.DropTable(
                name: "user_claims");

            migrationBuilder.DropTable(
                name: "user_providers");

            migrationBuilder.DropTable(
                name: "user_roles");

            migrationBuilder.DropTable(
                name: "user_tokens");

            migrationBuilder.DropTable(
                name: "parameter_values");

            migrationBuilder.DropTable(
                name: "sub_products");

            migrationBuilder.DropTable(
                name: "roles");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "parameters");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "categories");
        }
    }
}

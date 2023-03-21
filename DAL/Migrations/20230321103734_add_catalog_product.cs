using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class add_catalog_product : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "catalogs",
                columns: table => new
                {
                    catalog_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_catalogs", x => x.catalog_id);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    product_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    catalog_id = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.product_id);
                    table.ForeignKey(
                        name: "FK_products_catalogs_catalog_id",
                        column: x => x.catalog_id,
                        principalTable: "catalogs",
                        principalColumn: "catalog_id");
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
                    product_id = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_add_ons", x => x.add_on_id);
                    table.ForeignKey(
                        name: "FK_add_ons_products_product_id",
                        column: x => x.product_id,
                        principalTable: "products",
                        principalColumn: "product_id");
                });

            migrationBuilder.CreateTable(
                name: "parameters",
                columns: table => new
                {
                    parameter_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    product_id = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_parameters", x => x.parameter_id);
                    table.ForeignKey(
                        name: "FK_parameters_products_product_id",
                        column: x => x.product_id,
                        principalTable: "products",
                        principalColumn: "product_id");
                });

            migrationBuilder.CreateTable(
                name: "sub_products",
                columns: table => new
                {
                    sub_product_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    price = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    quantity = table.Column<long>(type: "bigint", nullable: false),
                    product_id = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sub_products", x => x.sub_product_id);
                    table.ForeignKey(
                        name: "FK_sub_products_products_product_id",
                        column: x => x.product_id,
                        principalTable: "products",
                        principalColumn: "product_id");
                });

            migrationBuilder.CreateTable(
                name: "parameter_values",
                columns: table => new
                {
                    parameter_value_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    parameter_id = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_parameter_values", x => x.parameter_value_id);
                    table.ForeignKey(
                        name: "FK_parameter_values_parameters_parameter_id",
                        column: x => x.parameter_id,
                        principalTable: "parameters",
                        principalColumn: "parameter_id");
                });

            migrationBuilder.CreateTable(
                name: "sub_product_parameter_values",
                columns: table => new
                {
                    sub_product_parameter_value = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sub_product_id = table.Column<long>(type: "bigint", nullable: true),
                    parameter_id = table.Column<long>(type: "bigint", nullable: true),
                    parameter_value_id = table.Column<long>(type: "bigint", nullable: true)
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
                name: "IX_products_catalog_id",
                table: "products",
                column: "catalog_id");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "add_ons");

            migrationBuilder.DropTable(
                name: "sub_product_parameter_values");

            migrationBuilder.DropTable(
                name: "parameter_values");

            migrationBuilder.DropTable(
                name: "sub_products");

            migrationBuilder.DropTable(
                name: "parameters");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "catalogs");
        }
    }
}

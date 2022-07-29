using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class AddProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    product_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.product_id);
                });

            migrationBuilder.CreateTable(
                name: "properties",
                columns: table => new
                {
                    property_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    product_id = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_properties", x => x.property_id);
                    table.ForeignKey(
                        name: "FK_properties_products_product_id",
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
                    count = table.Column<int>(type: "int", nullable: false),
                    price = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
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
                name: "options",
                columns: table => new
                {
                    option_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    property_id = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_options", x => x.option_id);
                    table.ForeignKey(
                        name: "FK_options_properties_property_id",
                        column: x => x.property_id,
                        principalTable: "properties",
                        principalColumn: "property_id");
                });

            migrationBuilder.CreateTable(
                name: "sub_product_property_options",
                columns: table => new
                {
                    sub_product_property_option_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sub_product_id = table.Column<long>(type: "bigint", nullable: true),
                    product_id = table.Column<long>(type: "bigint", nullable: true),
                    option_id = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sub_product_property_options", x => x.sub_product_property_option_id);
                    table.ForeignKey(
                        name: "FK_sub_product_property_options_options_option_id",
                        column: x => x.option_id,
                        principalTable: "options",
                        principalColumn: "option_id");
                    table.ForeignKey(
                        name: "FK_sub_product_property_options_properties_product_id",
                        column: x => x.product_id,
                        principalTable: "properties",
                        principalColumn: "property_id");
                    table.ForeignKey(
                        name: "FK_sub_product_property_options_sub_products_sub_product_id",
                        column: x => x.sub_product_id,
                        principalTable: "sub_products",
                        principalColumn: "sub_product_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_options_property_id",
                table: "options",
                column: "property_id");

            migrationBuilder.CreateIndex(
                name: "IX_properties_product_id",
                table: "properties",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_sub_product_property_options_option_id",
                table: "sub_product_property_options",
                column: "option_id");

            migrationBuilder.CreateIndex(
                name: "IX_sub_product_property_options_product_id",
                table: "sub_product_property_options",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_sub_product_property_options_sub_product_id",
                table: "sub_product_property_options",
                column: "sub_product_id");

            migrationBuilder.CreateIndex(
                name: "IX_sub_products_product_id",
                table: "sub_products",
                column: "product_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "sub_product_property_options");

            migrationBuilder.DropTable(
                name: "options");

            migrationBuilder.DropTable(
                name: "sub_products");

            migrationBuilder.DropTable(
                name: "properties");

            migrationBuilder.DropTable(
                name: "products");
        }
    }
}

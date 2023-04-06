using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevIO.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ufs",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    description = table.Column<string>(type: "varchar(2)", nullable: false),
                    is_active = table.Column<bool>(type: "bit", nullable: false),
                    created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ufs", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "cities",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    description = table.Column<string>(type: "varchar(100)", nullable: false),
                    uf_id = table.Column<int>(type: "int", nullable: false),
                    is_active = table.Column<bool>(type: "bit", nullable: false),
                    created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cities", x => x.id);
                    table.ForeignKey(
                        name: "FK_cities_ufs_uf_id",
                        column: x => x.uf_id,
                        principalTable: "ufs",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "neighborhoods",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    description = table.Column<string>(type: "varchar(100)", nullable: false),
                    city_id = table.Column<int>(type: "int", nullable: false),
                    is_active = table.Column<bool>(type: "bit", nullable: false),
                    created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_neighborhoods", x => x.id);
                    table.ForeignKey(
                        name: "FK_neighborhoods_cities_city_id",
                        column: x => x.city_id,
                        principalTable: "cities",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "adresses",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cep = table.Column<string>(type: "varchar(8)", nullable: false),
                    logradouro = table.Column<string>(type: "varchar(200)", nullable: false),
                    complement = table.Column<string>(type: "varchar(250)", nullable: true),
                    number = table.Column<string>(type: "varchar(50)", nullable: false),
                    neighborhood_id = table.Column<int>(type: "int", nullable: false),
                    city_id = table.Column<int>(type: "int", nullable: false),
                    uf_id = table.Column<int>(type: "int", nullable: false),
                    is_active = table.Column<bool>(type: "bit", nullable: false),
                    created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_adresses", x => x.id);
                    table.ForeignKey(
                        name: "FK_adresses_cities_city_id",
                        column: x => x.city_id,
                        principalTable: "cities",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_adresses_neighborhoods_neighborhood_id",
                        column: x => x.neighborhood_id,
                        principalTable: "neighborhoods",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_adresses_ufs_uf_id",
                        column: x => x.uf_id,
                        principalTable: "ufs",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "properties",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    reference = table.Column<string>(type: "varchar(100)", nullable: false),
                    description = table.Column<string>(type: "varchar(1000)", nullable: false),
                    price = table.Column<decimal>(type: "decimal", nullable: false),
                    address_id = table.Column<int>(type: "int", nullable: false),
                    is_active = table.Column<bool>(type: "bit", nullable: false),
                    created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_properties", x => x.id);
                    table.ForeignKey(
                        name: "FK_properties_adresses_address_id",
                        column: x => x.address_id,
                        principalTable: "adresses",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "galleries",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    file = table.Column<string>(type: "varchar(100)", nullable: false),
                    emphasis = table.Column<bool>(type: "bit", nullable: false),
                    immobile_id = table.Column<int>(type: "int", nullable: false),
                    is_active = table.Column<bool>(type: "bit", nullable: false),
                    created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_galleries", x => x.id);
                    table.ForeignKey(
                        name: "FK_galleries_properties_immobile_id",
                        column: x => x.immobile_id,
                        principalTable: "properties",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_adresses_city_id",
                table: "adresses",
                column: "city_id");

            migrationBuilder.CreateIndex(
                name: "IX_adresses_neighborhood_id",
                table: "adresses",
                column: "neighborhood_id");

            migrationBuilder.CreateIndex(
                name: "IX_adresses_uf_id",
                table: "adresses",
                column: "uf_id");

            migrationBuilder.CreateIndex(
                name: "IX_cities_uf_id",
                table: "cities",
                column: "uf_id");

            migrationBuilder.CreateIndex(
                name: "IX_galleries_immobile_id",
                table: "galleries",
                column: "immobile_id");

            migrationBuilder.CreateIndex(
                name: "IX_neighborhoods_city_id",
                table: "neighborhoods",
                column: "city_id");

            migrationBuilder.CreateIndex(
                name: "IX_properties_address_id",
                table: "properties",
                column: "address_id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "galleries");

            migrationBuilder.DropTable(
                name: "properties");

            migrationBuilder.DropTable(
                name: "adresses");

            migrationBuilder.DropTable(
                name: "neighborhoods");

            migrationBuilder.DropTable(
                name: "cities");

            migrationBuilder.DropTable(
                name: "ufs");
        }
    }
}

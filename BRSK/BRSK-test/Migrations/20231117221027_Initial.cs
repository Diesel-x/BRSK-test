using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BRSK_test.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "BRSK");

            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:PostgresExtension:pg_catalog.adminpack", ",,");

            migrationBuilder.CreateTable(
                name: "Brand",
                schema: "BRSK",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying", nullable: true),
                    Active = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Brand_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Model",
                schema: "BRSK",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "nextval('\"BRSK\".\"Brand_id_seq\"'::regclass)"),
                    Name = table.Column<string>(type: "character varying", nullable: true),
                    Active = table.Column<bool>(type: "boolean", nullable: true),
                    idBrand = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Model_pkey", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Brand",
                schema: "BRSK");

            migrationBuilder.DropTable(
                name: "Model",
                schema: "BRSK");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EmployeeService.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddedCountriesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM \"Employees\"");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Employees");

            migrationBuilder.AddColumn<int>(
                name: "CountryCode",
                table: "Employees",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    ISOCode = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    UrlPng = table.Column<string>(type: "text", nullable: false),
                    UrlSvg = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.ISOCode);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_CountryCode",
                table: "Employees",
                column: "CountryCode");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Countries_CountryCode",
                table: "Employees",
                column: "CountryCode",
                principalTable: "Countries",
                principalColumn: "ISOCode",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Countries_CountryCode",
                table: "Employees");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropIndex(
                name: "IX_Employees_CountryCode",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "CountryCode",
                table: "Employees");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Employees",
                type: "text",
                nullable: true);
        }
    }
}

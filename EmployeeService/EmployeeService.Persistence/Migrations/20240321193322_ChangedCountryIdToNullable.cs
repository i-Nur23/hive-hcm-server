using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeService.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ChangedCountryIdToNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Countries_CountryCode",
                table: "Employees");

            migrationBuilder.AlterColumn<int>(
                name: "CountryCode",
                table: "Employees",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Countries_CountryCode",
                table: "Employees",
                column: "CountryCode",
                principalTable: "Countries",
                principalColumn: "ISOCode");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Countries_CountryCode",
                table: "Employees");

            migrationBuilder.AlterColumn<int>(
                name: "CountryCode",
                table: "Employees",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Countries_CountryCode",
                table: "Employees",
                column: "CountryCode",
                principalTable: "Countries",
                principalColumn: "ISOCode",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

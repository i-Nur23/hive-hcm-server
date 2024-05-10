using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeService.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddedEmployeeStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmployeeStatus",
                table: "Employees",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmployeeStatus",
                table: "Employees");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeService.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ChangedRoleToRoleType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Role",
                table: "Employees",
                newName: "RoleType");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RoleType",
                table: "Employees",
                newName: "Role");
        }
    }
}

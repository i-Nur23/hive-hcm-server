using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserService.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class ChnagedRoleToRoleType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Role",
                table: "Users",
                newName: "RoleType");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RoleType",
                table: "Users",
                newName: "Role");
        }
    }
}

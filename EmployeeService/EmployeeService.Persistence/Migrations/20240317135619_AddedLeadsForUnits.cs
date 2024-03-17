using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeService.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddedLeadsForUnits : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LeadId",
                table: "Units",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Units_LeadId",
                table: "Units",
                column: "LeadId");

            migrationBuilder.AddForeignKey(
                name: "FK_Units_Employees_LeadId",
                table: "Units",
                column: "LeadId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Units_Employees_LeadId",
                table: "Units");

            migrationBuilder.DropIndex(
                name: "IX_Units_LeadId",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "LeadId",
                table: "Units");
        }
    }
}

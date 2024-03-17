using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeService.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddedHierarchyOfUnits : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ParentUnitId",
                table: "Units",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Units_ParentUnitId",
                table: "Units",
                column: "ParentUnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_Units_Units_ParentUnitId",
                table: "Units",
                column: "ParentUnitId",
                principalTable: "Units",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Units_Units_ParentUnitId",
                table: "Units");

            migrationBuilder.DropIndex(
                name: "IX_Units_ParentUnitId",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "ParentUnitId",
                table: "Units");
        }
    }
}

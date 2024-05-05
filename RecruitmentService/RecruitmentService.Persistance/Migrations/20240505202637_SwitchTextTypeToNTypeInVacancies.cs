using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecruitmentService.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class SwitchTextTypeToNTypeInVacancies : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OffersDescription",
                table: "Vacancies");

            migrationBuilder.DropColumn(
                name: "RequirementsDescription",
                table: "Vacancies");

            migrationBuilder.AddColumn<string>(
                name: "OffersDescription",
                table: "Vacancies",
                type: "ntext",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RequirementsDescription",
                table: "Vacancies",
                type: "ntext",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OffersDescription",
                table: "Vacancies");

            migrationBuilder.DropColumn(
                name: "RequirementsDescription",
                table: "Vacancies");

            migrationBuilder.AddColumn<string>(
                name: "OffersDescription",
                table: "Vacancies",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RequirementsDescription",
                table: "Vacancies",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}

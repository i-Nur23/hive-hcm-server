using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecruitmentService.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class RemovedRequirementsAndOffersTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Offers");

            migrationBuilder.DropTable(
                name: "Requirements");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OffersDescription",
                table: "Vacancies");

            migrationBuilder.DropColumn(
                name: "RequirementsDescription",
                table: "Vacancies");

            migrationBuilder.CreateTable(
                name: "Offers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VacancyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Offers_Vacancies_VacancyId",
                        column: x => x.VacancyId,
                        principalTable: "Vacancies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Requirements",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VacancyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requirements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Requirements_Vacancies_VacancyId",
                        column: x => x.VacancyId,
                        principalTable: "Vacancies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Offers_VacancyId",
                table: "Offers",
                column: "VacancyId");

            migrationBuilder.CreateIndex(
                name: "IX_Requirements_VacancyId",
                table: "Requirements",
                column: "VacancyId");
        }
    }
}

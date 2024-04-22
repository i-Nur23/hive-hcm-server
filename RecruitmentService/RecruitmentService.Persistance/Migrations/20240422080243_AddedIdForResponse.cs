using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecruitmentService.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class AddedIdForResponse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Responses",
                table: "Responses");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "Responses",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Responses",
                table: "Responses",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Responses_VacancyId",
                table: "Responses",
                column: "VacancyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Responses",
                table: "Responses");

            migrationBuilder.DropIndex(
                name: "IX_Responses_VacancyId",
                table: "Responses");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Responses");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Responses",
                table: "Responses",
                columns: new[] { "VacancyId", "CandidateId" });
        }
    }
}

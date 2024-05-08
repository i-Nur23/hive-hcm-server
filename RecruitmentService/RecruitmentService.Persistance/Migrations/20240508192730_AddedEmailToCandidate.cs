﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecruitmentService.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class AddedEmailToCandidate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Candidates",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Candidates");
        }
    }
}

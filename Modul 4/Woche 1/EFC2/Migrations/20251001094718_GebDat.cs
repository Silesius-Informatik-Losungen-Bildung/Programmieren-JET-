using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFC2.Migrations
{
    /// <inheritdoc />
    public partial class GebDat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDay",
                table: "Students",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BirthDay",
                table: "Students");
        }
    }
}

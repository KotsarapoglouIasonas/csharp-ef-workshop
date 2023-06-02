using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace csharp_ef_workshop.api.Migrations
{
    /// <inheritdoc />
    public partial class AddedDOBToPersonModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DOB",
                table: "People",
                type: "timestamp with time zone",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DOB",
                table: "People");
        }
    }
}

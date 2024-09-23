using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NS.Core.Models.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabaseV126 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "MenuConfig",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Order",
                table: "MenuConfig");
        }
    }
}

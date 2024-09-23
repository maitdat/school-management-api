using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NS.Core.Models.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabaseV108 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "FileId",
                table: "CaiDatChiTiet",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileId",
                table: "CaiDatChiTiet");
        }
    }
}

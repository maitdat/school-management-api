using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NS.Core.Models.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabaseV117 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CoTheLienLac",
                table: "PhongBan");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "PhongBan");

            migrationBuilder.AddColumn<int>(
                name: "LoaiPhongBan",
                table: "PhongBan",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Cot",
                table: "NhanVien",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Hang",
                table: "NhanVien",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LoaiPhongBan",
                table: "PhongBan");

            migrationBuilder.DropColumn(
                name: "Cot",
                table: "NhanVien");

            migrationBuilder.DropColumn(
                name: "Hang",
                table: "NhanVien");

            migrationBuilder.AddColumn<bool>(
                name: "CoTheLienLac",
                table: "PhongBan",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "PhongBan",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NS.Core.Models.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabaseV129 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NoiDungTiengAnh",
                table: "NamHocPhi",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "CaiDatChiTiet",
                type: "bit",
                nullable: false,
                defaultValue: true);
            migrationBuilder.Sql("update NamHocPhi set NoiDungTiengAnh = NoiDung");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NoiDungTiengAnh",
                table: "NamHocPhi");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "CaiDatChiTiet");
        }
    }
}

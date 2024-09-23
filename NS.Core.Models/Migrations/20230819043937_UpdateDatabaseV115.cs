using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NS.Core.Models.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabaseV115 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_NamHocPhi_NamHocId",
                table: "NamHocPhi");

            migrationBuilder.DropColumn(
                name: "DenNam",
                table: "NamHocPhi");

            migrationBuilder.DropColumn(
                name: "TuNam",
                table: "NamHocPhi");

            migrationBuilder.DropColumn(
                name: "MoHinhLop",
                table: "HocPhi");

            migrationBuilder.DropColumn(
                name: "MoHinhLopTiengAnh",
                table: "HocPhi");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "NamHocPhi",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "DenNam",
                table: "NamHoc",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "TuNam",
                table: "NamHoc",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "ThongTinTruong",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ViTri = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenTruong = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoDienThoai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianLamViec = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoDienThoaiTuyenSinh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailTuyenSinh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Facebook = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YouTube = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThongTinTruong", x => x.Id);
                });

            //migrationBuilder.CreateIndex(
            //    name: "IX_NamHocPhi_NamHocId",
            //    table: "NamHocPhi",
            //    column: "NamHocId",
            //    unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ThongTinTruong");

            //migrationBuilder.DropIndex(
            //    name: "IX_NamHocPhi_NamHocId",
            //    table: "NamHocPhi");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "NamHocPhi");

            migrationBuilder.DropColumn(
                name: "DenNam",
                table: "NamHoc");

            migrationBuilder.DropColumn(
                name: "TuNam",
                table: "NamHoc");

            migrationBuilder.AddColumn<long>(
                name: "DenNam",
                table: "NamHocPhi",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "TuNam",
                table: "NamHocPhi",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "MoHinhLop",
                table: "HocPhi",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MoHinhLopTiengAnh",
                table: "HocPhi",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_NamHocPhi_NamHocId",
                table: "NamHocPhi",
                column: "NamHocId");
        }
    }
}

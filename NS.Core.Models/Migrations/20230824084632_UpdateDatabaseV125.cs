using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NS.Core.Models.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabaseV125 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ThongTinTruong_FileUpload_FooterLogoFileId",
                table: "ThongTinTruong");

            migrationBuilder.DropForeignKey(
                name: "FK_ThongTinTruong_FileUpload_HeaderLogoFileId",
                table: "ThongTinTruong");

            migrationBuilder.DropIndex(
                name: "IX_ThongTinTruong_FooterLogoFileId",
                table: "ThongTinTruong");

            migrationBuilder.DropIndex(
                name: "IX_ThongTinTruong_HeaderLogoFileId",
                table: "ThongTinTruong");

            migrationBuilder.DropColumn(
                name: "FooterLogoFileId",
                table: "ThongTinTruong");

            migrationBuilder.DropColumn(
                name: "HeaderLogoFileId",
                table: "ThongTinTruong");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "FooterLogoFileId",
                table: "ThongTinTruong",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "HeaderLogoFileId",
                table: "ThongTinTruong",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_ThongTinTruong_FooterLogoFileId",
                table: "ThongTinTruong",
                column: "FooterLogoFileId");

            migrationBuilder.CreateIndex(
                name: "IX_ThongTinTruong_HeaderLogoFileId",
                table: "ThongTinTruong",
                column: "HeaderLogoFileId");

            migrationBuilder.AddForeignKey(
                name: "FK_ThongTinTruong_FileUpload_FooterLogoFileId",
                table: "ThongTinTruong",
                column: "FooterLogoFileId",
                principalTable: "FileUpload",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ThongTinTruong_FileUpload_HeaderLogoFileId",
                table: "ThongTinTruong",
                column: "HeaderLogoFileId",
                principalTable: "FileUpload",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

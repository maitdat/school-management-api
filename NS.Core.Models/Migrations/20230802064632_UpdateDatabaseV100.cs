using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NS.Core.Models.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabaseV100 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CaiDatTongThe_PhienBan_PhienBanId",
                table: "CaiDatTongThe");

            migrationBuilder.DropColumn(
                name: "TinTuctId",
                table: "MenuConfig");

            migrationBuilder.AlterColumn<long>(
                name: "PhienBanId",
                table: "CaiDatTongThe",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<long>(
                name: "TrangId",
                table: "CaiDatTongThe",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_CaiDatTongThe_TrangId",
                table: "CaiDatTongThe",
                column: "TrangId");

            migrationBuilder.AddForeignKey(
                name: "FK_CaiDatTongThe_PhienBan_PhienBanId",
                table: "CaiDatTongThe",
                column: "PhienBanId",
                principalTable: "PhienBan",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CaiDatTongThe_Trang_TrangId",
                table: "CaiDatTongThe",
                column: "TrangId",
                principalTable: "Trang",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CaiDatTongThe_PhienBan_PhienBanId",
                table: "CaiDatTongThe");

            migrationBuilder.DropForeignKey(
                name: "FK_CaiDatTongThe_Trang_TrangId",
                table: "CaiDatTongThe");

            migrationBuilder.DropIndex(
                name: "IX_CaiDatTongThe_TrangId",
                table: "CaiDatTongThe");

            migrationBuilder.DropColumn(
                name: "TrangId",
                table: "CaiDatTongThe");

            migrationBuilder.AddColumn<long>(
                name: "TinTuctId",
                table: "MenuConfig",
                type: "bigint",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "PhienBanId",
                table: "CaiDatTongThe",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CaiDatTongThe_PhienBan_PhienBanId",
                table: "CaiDatTongThe",
                column: "PhienBanId",
                principalTable: "PhienBan",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NS.Core.Models.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabaseV109 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChiTietCoSoVatChat",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CoSoVatChatId = table.Column<long>(type: "bigint", nullable: false),
                    HienThi = table.Column<bool>(type: "bit", nullable: false),
                    LoaiMedia = table.Column<int>(type: "int", nullable: false),
                    LinkAnh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietCoSoVatChat", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChiTietCoSoVatChat_CoSoVatChat_CoSoVatChatId",
                        column: x => x.CoSoVatChatId,
                        principalTable: "CoSoVatChat",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietCoSoVatChat_CoSoVatChatId",
                table: "ChiTietCoSoVatChat",
                column: "CoSoVatChatId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChiTietCoSoVatChat");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NS.Core.Models.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabaseV120 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FileUpload_CauLacBo_CauLacBoId",
                table: "FileUpload");

            migrationBuilder.DropIndex(
                name: "IX_FileUpload_CauLacBoId",
                table: "FileUpload");

            migrationBuilder.DropColumn(
                name: "CauLacBoId",
                table: "FileUpload");

            migrationBuilder.CreateTable(
                name: "AnhCauLacBo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CauLacBoId = table.Column<long>(type: "bigint", nullable: false),
                    FileUploadId = table.Column<long>(type: "bigint", nullable: false),
                    LinkAnh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnhCauLacBo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnhCauLacBo_CauLacBo_CauLacBoId",
                        column: x => x.CauLacBoId,
                        principalTable: "CauLacBo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_AnhCauLacBo_FileUpload_FileUploadId",
                        column: x => x.FileUploadId,
                        principalTable: "FileUpload",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnhCauLacBo_CauLacBoId",
                table: "AnhCauLacBo",
                column: "CauLacBoId");

            migrationBuilder.CreateIndex(
                name: "IX_AnhCauLacBo_FileUploadId",
                table: "AnhCauLacBo",
                column: "FileUploadId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnhCauLacBo");

            migrationBuilder.AddColumn<long>(
                name: "CauLacBoId",
                table: "FileUpload",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FileUpload_CauLacBoId",
                table: "FileUpload",
                column: "CauLacBoId");

            migrationBuilder.AddForeignKey(
                name: "FK_FileUpload_CauLacBo_CauLacBoId",
                table: "FileUpload",
                column: "CauLacBoId",
                principalTable: "CauLacBo",
                principalColumn: "Id");
        }
    }
}

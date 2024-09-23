using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NS.Core.Models.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabaseV127 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ThuTu",
                table: "CaiDatTongThe",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ThuTu",
                table: "CaiDatChiTiet",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CaiDatChiTiet_FileId",
                table: "CaiDatChiTiet",
                column: "FileId");
            migrationBuilder.Sql(@"
                declare @fileId int;
                declare @caiDatTongTheId int;
                select @fileId = max(id) + 1 from FileUpload
                insert into CaiDatTongThe (ThuTu, TrangId) values (1, 1)
                select @caiDatTongTheId = max(id) from CaiDatTongThe


                SET IDENTITY_INSERT FileUpload ON
                INSERT INTO FileUpload (Id, FileName, FilePath, FileType, OriginName)
                values (@fileId, '069CB778-25BB-4112-A927-F442FFE30E9A', 'imgs/TrangChu/069CB778-25BB-4112-A927-F442FFE30E9A.png', 2, 'imgTrangChu.png')
                SET IDENTITY_INSERT FileUpload OFF
                insert into CaiDatChiTiet(CaiDatTongTheId, FileId) values (@caiDatTongTheId, @FileId)

                set @fileId = @fileId + 1
                SET IDENTITY_INSERT FileUpload ON
                INSERT INTO FileUpload (Id, FileName, FilePath, FileType, OriginName)
                values (@fileId, '0246D6AF-C51A-4578-99DB-9CAC42E0902C', 'imgs/TrangChu/0246D6AF-C51A-4578-99DB-9CAC42E0902C.jpg', 2, 'truyenThong1.jpg')
                SET IDENTITY_INSERT FileUpload OFF
                insert into CaiDatChiTiet(CaiDatTongTheId, FileId) values (@caiDatTongTheId, @FileId)

                set @fileId = @fileId + 1
                SET IDENTITY_INSERT FileUpload ON
                INSERT INTO FileUpload (Id, FileName, FilePath, FileType, OriginName)
                values (@fileId, '6227B939-3397-44C9-AE2C-51CCE3A10B27', 'imgs/TrangChu/6227B939-3397-44C9-AE2C-51CCE3A10B27.jpg', 2, 'truyenThong2.jpg')
                SET IDENTITY_INSERT FileUpload OFF
                insert into CaiDatChiTiet(CaiDatTongTheId, FileId) values (@caiDatTongTheId, @FileId)

                set @fileId = @fileId + 1
                SET IDENTITY_INSERT FileUpload ON
                INSERT INTO FileUpload (Id, FileName, FilePath, FileType, OriginName)
                values (@fileId, '4E635465-AC1A-4FF3-A15B-986C2392AD01', 'imgs/TrangChu/4E635465-AC1A-4FF3-A15B-986C2392AD01.jpg', 2, 'truyenThong3.jpg')
                SET IDENTITY_INSERT FileUpload OFF
                insert into CaiDatChiTiet(CaiDatTongTheId, FileId) values (@caiDatTongTheId, @FileId)

                set @fileId = @fileId + 1
                SET IDENTITY_INSERT FileUpload ON
                INSERT INTO FileUpload (Id, FileName, FilePath, FileType, OriginName)
                values (@fileId, '7777918F-4CA8-4B4F-8808-1119FFCFC1D2', 'imgs/TrangChu/7777918F-4CA8-4B4F-8808-1119FFCFC1D2.mp4', 2, 'bg.mp4')
                SET IDENTITY_INSERT FileUpload OFF
                insert into CaiDatChiTiet(CaiDatTongTheId, FileId) values (@caiDatTongTheId, @FileId)
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CaiDatChiTiet_FileId",
                table: "CaiDatChiTiet");

            migrationBuilder.DropColumn(
                name: "ThuTu",
                table: "CaiDatTongThe");

            migrationBuilder.DropColumn(
                name: "ThuTu",
                table: "CaiDatChiTiet");
        }
    }
}

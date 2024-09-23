using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NS.Core.Models.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabaseV103 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentName",
                table: "FileUpload");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "FileUpload",
                newName: "OriginName");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "FileUpload",
                newName: "FilePath");

            migrationBuilder.AddColumn<Guid>(
                name: "FileName",
                table: "FileUpload",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "FileType",
                table: "FileUpload",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileName",
                table: "FileUpload");

            migrationBuilder.DropColumn(
                name: "FileType",
                table: "FileUpload");

            migrationBuilder.RenameColumn(
                name: "OriginName",
                table: "FileUpload",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "FilePath",
                table: "FileUpload",
                newName: "Name");

            migrationBuilder.AddColumn<string>(
                name: "CurrentName",
                table: "FileUpload",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}

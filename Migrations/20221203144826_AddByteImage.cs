using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Diploma_v1._1.Migrations
{
    public partial class AddByteImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "NewsList");

            migrationBuilder.AddColumn<byte[]>(
                name: "ImageData",
                table: "NewsList",
                type: "varbinary(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageData",
                table: "NewsList");

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "NewsList",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}

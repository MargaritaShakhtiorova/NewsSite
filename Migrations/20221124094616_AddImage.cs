using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Diploma_v1._1.Migrations
{
    public partial class AddImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                table: "NewsList",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageData = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NewsList_ImageId",
                table: "NewsList",
                column: "ImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_NewsList_Image_ImageId",
                table: "NewsList",
                column: "ImageId",
                principalTable: "Image",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NewsList_Image_ImageId",
                table: "NewsList");

            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropIndex(
                name: "IX_NewsList_ImageId",
                table: "NewsList");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "NewsList");
        }
    }
}

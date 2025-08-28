using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PustokProject.Migrations
{
    /// <inheritdoc />
    public partial class TagUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookTags_Tags_TagId1",
                table: "BookTags");

            migrationBuilder.DropIndex(
                name: "IX_BookTags_TagId1",
                table: "BookTags");

            migrationBuilder.DropColumn(
                name: "TagId1",
                table: "BookTags");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TagId1",
                table: "BookTags",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BookTags_TagId1",
                table: "BookTags",
                column: "TagId1");

            migrationBuilder.AddForeignKey(
                name: "FK_BookTags_Tags_TagId1",
                table: "BookTags",
                column: "TagId1",
                principalTable: "Tags",
                principalColumn: "Id");
        }
    }
}

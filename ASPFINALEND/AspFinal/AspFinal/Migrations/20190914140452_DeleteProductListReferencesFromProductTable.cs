using Microsoft.EntityFrameworkCore.Migrations;

namespace AspFinal.Migrations
{
    public partial class DeleteProductListReferencesFromProductTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ListProductTitles_ListProductTitleId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ListProductTitleId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ListProductTitileID",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ListProductTitleId",
                table: "Products");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ListProductTitileID",
                table: "Products",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ListProductTitleId",
                table: "Products",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_ListProductTitleId",
                table: "Products",
                column: "ListProductTitleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ListProductTitles_ListProductTitleId",
                table: "Products",
                column: "ListProductTitleId",
                principalTable: "ListProductTitles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

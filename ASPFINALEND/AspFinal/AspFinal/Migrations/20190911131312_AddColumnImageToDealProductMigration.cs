using Microsoft.EntityFrameworkCore.Migrations;

namespace AspFinal.Migrations
{
    public partial class AddColumnImageToDealProductMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "DealProducts",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 400);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "DealProducts",
                maxLength: 250,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "DealProducts");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "DealProducts",
                maxLength: 400,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}

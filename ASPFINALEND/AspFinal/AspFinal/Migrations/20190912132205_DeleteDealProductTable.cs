using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AspFinal.Migrations
{
    public partial class DeleteDealProductTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DealProducts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DealProducts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateDiscount = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Discount = table.Column<string>(nullable: true),
                    Image = table.Column<string>(maxLength: 250, nullable: false),
                    PriceNow = table.Column<double>(nullable: false),
                    PriceOld = table.Column<double>(nullable: false),
                    Title1 = table.Column<string>(maxLength: 155, nullable: false),
                    Title2 = table.Column<string>(maxLength: 155, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DealProducts", x => x.Id);
                });
        }
    }
}

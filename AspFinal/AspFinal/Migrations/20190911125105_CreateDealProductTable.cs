using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AspFinal.Migrations
{
    public partial class CreateDealProductTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DealProducts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title1 = table.Column<string>(maxLength: 155, nullable: false),
                    Title2 = table.Column<string>(maxLength: 155, nullable: false),
                    Description = table.Column<string>(maxLength: 400, nullable: false),
                    PriceNow = table.Column<double>(nullable: false),
                    PriceOld = table.Column<double>(nullable: false),
                    Discount = table.Column<string>(nullable: true),
                    DateDiscount = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DealProducts", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DealProducts");
        }
    }
}

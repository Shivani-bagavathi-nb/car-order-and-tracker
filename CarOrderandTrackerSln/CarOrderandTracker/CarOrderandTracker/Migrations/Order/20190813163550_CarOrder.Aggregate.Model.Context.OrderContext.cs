using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CarOrder.Aggregate.Migrations.Order
{
    public partial class CarOrderAggregateModelContextOrderContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Orderitem = table.Column<long>(nullable: false),
                    Orderid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Orderitemmodel = table.Column<string>(nullable: true),
                    Engine = table.Column<string>(nullable: true),
                    Make = table.Column<string>(nullable: true),
                    Year = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Orderitem);
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Orderitem", "Engine", "Make", "Orderitemmodel", "Year" },
                values: new object[] { 152223333L, "Petrol", "AA", "Desire - Zxi", "Jan- 2019" });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Orderitem", "Engine", "Make", "Orderitemmodel", "Year" },
                values: new object[] { 1522233855L, "Diesel", "MA", "Desire - Zxi+", "Jan- 2018" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}

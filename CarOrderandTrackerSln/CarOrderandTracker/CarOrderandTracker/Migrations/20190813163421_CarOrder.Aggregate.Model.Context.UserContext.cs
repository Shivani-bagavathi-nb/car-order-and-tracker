using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CarOrder.Aggregate.Migrations
{
    public partial class CarOrderAggregateModelContextUserContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    EmailId = table.Column<string>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.EmailId);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "EmailId", "Password" },
                values: new object[] { "rkv@gmail.com", "pass@word1" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "EmailId", "Password" },
                values: new object[] { "shiv@gmail.com", "pass@word2" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}

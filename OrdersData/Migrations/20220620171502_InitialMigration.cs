using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrdersData.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerEmail = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CustomerFName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerLName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerPhone = table.Column<int>(type: "int", nullable: true),
                    CustomerPassword = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerEmail);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    ItemName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ItemsRate = table.Column<int>(type: "int", nullable: true),
                    ItemQty = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.ItemName);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Items");
        }
    }
}

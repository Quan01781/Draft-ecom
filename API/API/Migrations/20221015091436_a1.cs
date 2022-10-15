using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class a1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ID", "Name", "Number", "Price" },
                values: new object[,]
                {
                    { 1, "AA", 10, 10000.0 },
                    { 2, "BB", 15, 20000.0 },
                    { 3, "CC", 20, 30000.0 },
                    { 4, "DD", 11, 20000.0 },
                    { 5, "EE", 12, 70000.0 },
                    { 6, "FF", 16, 65000.0 },
                    { 7, "GG", 17, 30000.0 },
                    { 8, "HH", 15, 70000.0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}

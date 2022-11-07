using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ecommerce.Data.Migrations
{
    public partial class a3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ID", "Created_at", "Created_by", "Img", "Name", "Number", "Price", "Updated_At" },
                values: new object[,]
                {
                    { 1, null, null, null, "AA", 10, 10000.0, null },
                    { 2, null, null, null, "BB", 15, 20000.0, null },
                    { 3, null, null, null, "CC", 20, 30000.0, null },
                    { 4, null, null, null, "DD", 11, 20000.0, null },
                    { 5, null, null, null, "EE", 12, 70000.0, null },
                    { 6, null, null, null, "FF", 16, 65000.0, null },
                    { 7, null, null, null, "GG", 17, 30000.0, null },
                    { 8, null, null, null, "HH", 15, 70000.0, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 8);
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class v5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Customers_CustomerID",
                table: "Ratings");

            migrationBuilder.DropIndex(
                name: "IX_Ratings_CustomerID",
                table: "Ratings");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Ratings");

            migrationBuilder.DropColumn(
                name: "CustomerID",
                table: "Ratings");

            migrationBuilder.AddColumn<DateTime>(
                name: "Created_at",
                table: "Ratings",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created_at",
                table: "Customers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "Description", "Name" },
                values: new object[] { "flowers for holidays", "Holiday flowers" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "ID", "Created_at", "Created_by", "Description", "Name", "Updated_at" },
                values: new object[,]
                {
                    { 2, null, null, "flowers for wedding", "Wedding flowers", null },
                    { 3, null, null, "flowers for sadness", "Condolence flowers", null },
                    { 4, null, null, "flowers for anniversary events", "Anniversary flowers", null },
                    { 5, null, null, "flowers for mother's day", "Mother's day flowers", null }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "Name", "Price", "Quantity" },
                values: new object[] { "Blossom bouquet flower", 60000.0, 100 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DropColumn(
                name: "Created_at",
                table: "Ratings");

            migrationBuilder.DropColumn(
                name: "Created_at",
                table: "Customers");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Ratings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CustomerID",
                table: "Ratings",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "Description", "Name" },
                values: new object[] { "ok", "A1" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "Name", "Price", "Quantity" },
                values: new object[] { "AA", 10000.0, 10 });

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_CustomerID",
                table: "Ratings",
                column: "CustomerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Customers_CustomerID",
                table: "Ratings",
                column: "CustomerID",
                principalTable: "Customers",
                principalColumn: "ID");
        }
    }
}

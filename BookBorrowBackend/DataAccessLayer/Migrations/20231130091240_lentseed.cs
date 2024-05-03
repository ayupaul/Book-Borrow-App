using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class lentseed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "bookLenteds",
                columns: new[] { "Id", "LentedUserId", "Lented_BookId" },
                values: new object[] { 3, 2, 1 });

            migrationBuilder.InsertData(
                table: "bookLenteds",
                columns: new[] { "Id", "LentedUserId", "Lented_BookId" },
                values: new object[] { 4, 2, 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "bookLenteds",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "bookLenteds",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}

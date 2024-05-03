using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rating = table.Column<int>(type: "int", nullable: true),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsBookAvailable = table.Column<bool>(type: "bit", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BookId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TokenAvailable = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "bookBorroweds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrentBorrowedByUserId = table.Column<int>(type: "int", nullable: true),
                    Currently_Borrowed_BookId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bookBorroweds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_bookBorroweds_Books_Currently_Borrowed_BookId",
                        column: x => x.Currently_Borrowed_BookId,
                        principalTable: "Books",
                        principalColumn: "BookId");
                    table.ForeignKey(
                        name: "FK_bookBorroweds_Users_CurrentBorrowedByUserId",
                        column: x => x.CurrentBorrowedByUserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "bookLenteds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LentedUserId = table.Column<int>(type: "int", nullable: true),
                    Lented_BookId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bookLenteds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_bookLenteds_Books_Lented_BookId",
                        column: x => x.Lented_BookId,
                        principalTable: "Books",
                        principalColumn: "BookId");
                    table.ForeignKey(
                        name: "FK_bookLenteds_Users_LentedUserId",
                        column: x => x.LentedUserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "Author", "BookName", "Description", "Genre", "IsBookAvailable", "Rating" },
                values: new object[,]
                {
                    { 1, "Joey", "Friends", "Story of six friends", "Comedy", true, 5 },
                    { 2, "Tony", "Avengers", "Saving the world", "Action", true, 4 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Name", "Password", "TokenAvailable", "Username" },
                values: new object[,]
                {
                    { 1, "Ayush Pal", "Ayush123@", 5, "ayush@gmail.com" },
                    { 2, "Abhishek Pal", "Abhishek123@", 4, "abhishek@gmail.com" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_bookBorroweds_CurrentBorrowedByUserId",
                table: "bookBorroweds",
                column: "CurrentBorrowedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_bookBorroweds_Currently_Borrowed_BookId",
                table: "bookBorroweds",
                column: "Currently_Borrowed_BookId");

            migrationBuilder.CreateIndex(
                name: "IX_bookLenteds_Lented_BookId",
                table: "bookLenteds",
                column: "Lented_BookId");

            migrationBuilder.CreateIndex(
                name: "IX_bookLenteds_LentedUserId",
                table: "bookLenteds",
                column: "LentedUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bookBorroweds");

            migrationBuilder.DropTable(
                name: "bookLenteds");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Data.Migrations
{
    public partial class AddedImageDbSetToDbContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("30bca8b2-f61c-4125-b71e-9ec62ffc293e"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("31c3a76c-e04c-4cd4-a324-40595a1a9a2d"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("f9135489-0aaa-4b64-ab9f-e49107177ac4"));

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Url = table.Column<string>(type: "TEXT", nullable: false),
                    PublishId = table.Column<string>(type: "TEXT", nullable: false),
                    ArticleId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "Contents", "Summary", "Title" },
                values: new object[] { new Guid("164bee47-ef9f-48c0-b07a-2eb5ad1bb73e"), "This is content for article 1", "This is summary for article 1", "Testing bla bla 1" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "Contents", "Summary", "Title" },
                values: new object[] { new Guid("5542c0fa-4c3c-4eec-8e18-3ae07883d2b7"), "This is content for article 2", "This is summary for article 2", "Testing bla bla 2" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "Contents", "Summary", "Title" },
                values: new object[] { new Guid("f9b78da2-b16d-4583-ab45-635f239dbac8"), "This is content for article 3", "This is summary for article 3", "Testing bla bla 3" });

            migrationBuilder.CreateIndex(
                name: "IX_Images_ArticleId",
                table: "Images",
                column: "ArticleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("164bee47-ef9f-48c0-b07a-2eb5ad1bb73e"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("5542c0fa-4c3c-4eec-8e18-3ae07883d2b7"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("f9b78da2-b16d-4583-ab45-635f239dbac8"));

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "Contents", "Summary", "Title" },
                values: new object[] { new Guid("30bca8b2-f61c-4125-b71e-9ec62ffc293e"), "This is content for article 2", "This is summary for article 2", "Testing bla bla 2" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "Contents", "Summary", "Title" },
                values: new object[] { new Guid("31c3a76c-e04c-4cd4-a324-40595a1a9a2d"), "This is content for article 1", "This is summary for article 1", "Testing bla bla 1" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "Contents", "Summary", "Title" },
                values: new object[] { new Guid("f9135489-0aaa-4b64-ab9f-e49107177ac4"), "This is content for article 3", "This is summary for article 3", "Testing bla bla 3" });
        }
    }
}

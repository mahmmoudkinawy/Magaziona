using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class SeededArcticlesData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "Contents", "Summary", "Title" },
                values: new object[] { new Guid("79e5e9b9-0d98-4616-bf3a-64701cda78d7"), "This is content for article 1", "This is summary for article 1", "Testing bla bla 1" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "Contents", "Summary", "Title" },
                values: new object[] { new Guid("83ded46f-ddcc-4db4-b9d7-962e7da0357d"), "This is content for article 2", "This is summary for article 2", "Testing bla bla 2" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "Contents", "Summary", "Title" },
                values: new object[] { new Guid("dd0d715c-abd3-4372-be75-70a72a54fcfa"), "This is content for article 3", "This is summary for article 3", "Testing bla bla 3" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("79e5e9b9-0d98-4616-bf3a-64701cda78d7"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("83ded46f-ddcc-4db4-b9d7-962e7da0357d"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("dd0d715c-abd3-4372-be75-70a72a54fcfa"));
        }
    }
}

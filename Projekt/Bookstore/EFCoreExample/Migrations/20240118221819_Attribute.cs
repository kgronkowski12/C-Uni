using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreExample.Migrations
{
    public partial class Attribute : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "Price",
                table: "Book",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Book");
        }
    }
}

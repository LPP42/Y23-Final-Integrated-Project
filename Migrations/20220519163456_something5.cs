using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lab3.Migrations
{
    public partial class something5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Point");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Point",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}

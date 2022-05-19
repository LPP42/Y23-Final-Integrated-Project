using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lab3.Migrations
{
    public partial class signup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Signup",
                columns: table => new
                {
                    SignupId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: true),
                    HikeId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Signup", x => x.SignupId);
                    table.ForeignKey(
                        name: "FK_Signup_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Signup_Hike_HikeId",
                        column: x => x.HikeId,
                        principalTable: "Hike",
                        principalColumn: "HikeId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Signup_HikeId",
                table: "Signup",
                column: "HikeId");

            migrationBuilder.CreateIndex(
                name: "IX_Signup_UserId",
                table: "Signup",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Signup");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lab3.Migrations
{
    public partial class user2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Signup_AspNetUsers_UserId",
                table: "Signup");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Signup",
                newName: "HikeUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Signup_UserId",
                table: "Signup",
                newName: "IX_Signup_HikeUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Signup_AspNetUsers_HikeUserId",
                table: "Signup",
                column: "HikeUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Signup_AspNetUsers_HikeUserId",
                table: "Signup");

            migrationBuilder.RenameColumn(
                name: "HikeUserId",
                table: "Signup",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Signup_HikeUserId",
                table: "Signup",
                newName: "IX_Signup_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Signup_AspNetUsers_UserId",
                table: "Signup",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}

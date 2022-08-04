using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace To_Do_List.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserTasks_AspNetUsers_To_Do_ListUserId",
                table: "UserTasks");

            migrationBuilder.RenameColumn(
                name: "To_Do_ListUserId",
                table: "UserTasks",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserTasks_To_Do_ListUserId",
                table: "UserTasks",
                newName: "IX_UserTasks_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserTasks_AspNetUsers_UserId",
                table: "UserTasks",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserTasks_AspNetUsers_UserId",
                table: "UserTasks");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "UserTasks",
                newName: "To_Do_ListUserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserTasks_UserId",
                table: "UserTasks",
                newName: "IX_UserTasks_To_Do_ListUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserTasks_AspNetUsers_To_Do_ListUserId",
                table: "UserTasks",
                column: "To_Do_ListUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}

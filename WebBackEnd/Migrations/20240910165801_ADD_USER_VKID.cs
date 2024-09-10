using Microsoft.EntityFrameworkCore.Migrations;

namespace WebBackEnd.Migrations
{
    public partial class ADD_USER_VKID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "VKID",
                table: "user",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VKID",
                table: "user");
        }
    }
}

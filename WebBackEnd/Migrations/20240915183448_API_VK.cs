using Microsoft.EntityFrameworkCore.Migrations;

namespace WebBackEnd.Migrations
{
    public partial class API_VK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Password",
                table: "User",
                newName: "SecondName");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "User",
                newName: "ScreenName");

            migrationBuilder.Sql(
                @"ALTER TABLE ""User""
              ALTER COLUMN ""VKID"" TYPE bigint
              USING CASE
                  WHEN ""VKID"" ~ '^[0-9]+$' THEN ""VKID""::bigint
                  ELSE NULL -- или укажите значение по умолчанию, если это необходимо
              END;"
            );

            migrationBuilder.AlterColumn<long>(
                name: "VKID",
                table: "User",
                type: "bigint",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "User",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "User");

            migrationBuilder.RenameColumn(
                name: "SecondName",
                table: "User",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "ScreenName",
                table: "User",
                newName: "Email");

            migrationBuilder.AlterColumn<string>(
                name: "VKID",
                table: "User",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(long),
                oldType: "bigint");
        }
    }
}

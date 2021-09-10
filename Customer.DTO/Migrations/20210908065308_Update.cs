using Microsoft.EntityFrameworkCore.Migrations;

namespace Customer.DTO.Migrations
{
    public partial class Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserReference",
                table: "User",
                newName: "UserCreator");

            migrationBuilder.AlterColumn<int>(
                name: "Role",
                table: "User",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserCreator",
                table: "User",
                newName: "UserReference");

            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "User",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");
        }
    }
}

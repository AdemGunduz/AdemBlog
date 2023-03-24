using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class mig_rol2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "WriterStatus",
                table: "Users",
                newName: "UserStatus");

            migrationBuilder.RenameColumn(
                name: "WriterPassword",
                table: "Users",
                newName: "UserPassword");

            migrationBuilder.RenameColumn(
                name: "WriterName",
                table: "Users",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "WriterMail",
                table: "Users",
                newName: "UserMail");

            migrationBuilder.RenameColumn(
                name: "WriterID",
                table: "Users",
                newName: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserStatus",
                table: "Users",
                newName: "WriterStatus");

            migrationBuilder.RenameColumn(
                name: "UserPassword",
                table: "Users",
                newName: "WriterPassword");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Users",
                newName: "WriterName");

            migrationBuilder.RenameColumn(
                name: "UserMail",
                table: "Users",
                newName: "WriterMail");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Users",
                newName: "WriterID");
        }
    }
}

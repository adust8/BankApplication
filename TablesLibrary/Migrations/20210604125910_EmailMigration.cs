using Microsoft.EntityFrameworkCore.Migrations;

namespace DatabaseLibrary.Migrations
{
    public partial class EmailMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase(
                collation: "SQL_Latin1_General_CP1_CS_AS");

            migrationBuilder.AddColumn<string>(
                name: "user_email",
                table: "LoginsAndPasswords",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "user_email",
                table: "LoginsAndPasswords");

            migrationBuilder.AlterDatabase(
                oldCollation: "SQL_Latin1_General_CP1_CS_AS");
        }
    }
}

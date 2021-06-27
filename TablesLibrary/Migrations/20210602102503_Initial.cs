using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DatabaseLibrary.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountNumbers",
                columns: table => new
                {
                    account_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    account_number = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountNumbers", x => x.account_id);
                });

            migrationBuilder.CreateTable(
                name: "AccountTypes",
                columns: table => new
                {
                    account_type_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    account_type_name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountTypes", x => x.account_type_id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    user_surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    user_patronymic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    user_birth_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    user_registration_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    user_phone_number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountTypeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                    table.ForeignKey(
                        name: "FK_Users_AccountTypes_AccountTypeId",
                        column: x => x.AccountTypeId,
                        principalTable: "AccountTypes",
                        principalColumn: "account_type_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    account_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    account_balance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    account_user_id = table.Column<int>(type: "int", nullable: false),
                    account_id_number = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    account_type_id = table.Column<int>(type: "int", nullable: false),
                    account_phone_number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    account_create_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    account_next_replenishment = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.account_id);
                    table.UniqueConstraint("AK_Accounts_account_id_number", x => x.account_id_number);
                    table.ForeignKey(
                        name: "FK_Accounts_AccountTypes_account_type_id",
                        column: x => x.account_type_id,
                        principalTable: "AccountTypes",
                        principalColumn: "account_type_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Accounts_Users_account_user_id",
                        column: x => x.account_user_id,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LoginsAndPasswords",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    user_password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoginsAndPasswords", x => x.id);
                    table.ForeignKey(
                        name: "FK_LoginsAndPasswords_Users_user_id",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AccountNumbers",
                columns: new[] { "account_id", "account_number" },
                values: new object[] { 1, 3090m });

            migrationBuilder.InsertData(
                table: "AccountTypes",
                columns: new[] { "account_type_id", "account_type_name" },
                values: new object[] { 2, "Депозитный(7%)" });

            migrationBuilder.InsertData(
                table: "AccountTypes",
                columns: new[] { "account_type_id", "account_type_name" },
                values: new object[] { 1, "До востребования" });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_account_type_id",
                table: "Accounts",
                column: "account_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_account_user_id",
                table: "Accounts",
                column: "account_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_LoginsAndPasswords_user_id",
                table: "LoginsAndPasswords",
                column: "user_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_AccountTypeId",
                table: "Users",
                column: "AccountTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountNumbers");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "LoginsAndPasswords");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "AccountTypes");
        }
    }
}

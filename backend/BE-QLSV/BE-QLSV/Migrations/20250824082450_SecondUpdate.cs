using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BE_QLSV.Migrations
{
    /// <inheritdoc />
    public partial class SecondUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lecturers_Users_AccountId",
                table: "Lecturers");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Users_AccountId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "Accounts");

            migrationBuilder.RenameIndex(
                name: "IX_Users_Username",
                table: "Accounts",
                newName: "IX_Accounts_Username");

            migrationBuilder.RenameIndex(
                name: "IX_Users_RoleId",
                table: "Accounts",
                newName: "IX_Accounts_RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Accounts",
                table: "Accounts",
                column: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Roles_RoleId",
                table: "Accounts",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Lecturers_Accounts_AccountId",
                table: "Lecturers",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "AccountId",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Accounts_AccountId",
                table: "Students",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "AccountId",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Roles_RoleId",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Lecturers_Accounts_AccountId",
                table: "Lecturers");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Accounts_AccountId",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Accounts",
                table: "Accounts");

            migrationBuilder.RenameTable(
                name: "Accounts",
                newName: "Users");

            migrationBuilder.RenameIndex(
                name: "IX_Accounts_Username",
                table: "Users",
                newName: "IX_Users_Username");

            migrationBuilder.RenameIndex(
                name: "IX_Accounts_RoleId",
                table: "Users",
                newName: "IX_Users_RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lecturers_Users_AccountId",
                table: "Lecturers",
                column: "AccountId",
                principalTable: "Users",
                principalColumn: "AccountId",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Users_AccountId",
                table: "Students",
                column: "AccountId",
                principalTable: "Users",
                principalColumn: "AccountId",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

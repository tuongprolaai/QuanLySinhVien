using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BE_QLSV.Migrations
{
    /// <inheritdoc />
    public partial class FirstUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("650b4f9f-c291-4230-b4d6-276d1579b1f9"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("9c52ff3d-818c-4d64-9aff-dcf455e77d26"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("c6f58b78-7268-4a06-881d-70c313dfd6f3"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "Description", "RoleName" },
                values: new object[,]
                {
                    { new Guid("650b4f9f-c291-4230-b4d6-276d1579b1f9"), "Student user role", "Student" },
                    { new Guid("9c52ff3d-818c-4d64-9aff-dcf455e77d26"), "System Administrator", "Admin" },
                    { new Guid("c6f58b78-7268-4a06-881d-70c313dfd6f3"), "Lecturer user role", "Lecturer" }
                });
        }
    }
}

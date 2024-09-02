using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyLoginAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddAdminUserSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Pedidos",
                keyColumn: "Id",
                keyValue: 1,
                column: "Data",
                value: new DateTime(2024, 9, 2, 11, 38, 47, 48, DateTimeKind.Utc).AddTicks(2840));

            migrationBuilder.UpdateData(
                table: "Pedidos",
                keyColumn: "Id",
                keyValue: 2,
                column: "Data",
                value: new DateTime(2024, 9, 2, 11, 38, 47, 48, DateTimeKind.Utc).AddTicks(2845));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Password", "Username" },
                values: new object[] { 1, "AQAAAAIAAYagAAAAENlynyAn7Nhh4VmQPBnKi1my+Ezmu3aUYIa2N/AWjliskmeN7bAmLqHollZLs6fylg==", "admin@example.com" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "Pedidos",
                keyColumn: "Id",
                keyValue: 1,
                column: "Data",
                value: new DateTime(2024, 9, 2, 0, 10, 2, 466, DateTimeKind.Utc).AddTicks(2058));

            migrationBuilder.UpdateData(
                table: "Pedidos",
                keyColumn: "Id",
                keyValue: 2,
                column: "Data",
                value: new DateTime(2024, 9, 2, 0, 10, 2, 466, DateTimeKind.Utc).AddTicks(2062));
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UsuariosApi.Migrations
{
    public partial class adicionandoCustomIdentityUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataNascimento",
                table: "AspNetUsers",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99997,
                column: "ConcurrencyStamp",
                value: "a02be25d-e958-492b-b00a-00ddc08c4eb2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "8352cd8d-4247-4c94-b0b0-6edf9c5d913a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7c6a9f22-4c26-4e58-b2ba-7f795e19ac8a", "AQAAAAEAACcQAAAAECP19V097F9Rq1FmTqnZrd6TTEoAH+V806sJF45JyQX8w4ZzJwBzgKKrSLgBFlHy+w==", "37d61bb8-d13d-4ea2-ae2a-ad8bf69bd0c7" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataNascimento",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99997,
                column: "ConcurrencyStamp",
                value: "5155f9a2-62f3-47ab-941a-75cbe26f13cb");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "71f8edc6-52d2-493c-892d-2afaed8965b5");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f62193e2-c57c-4f32-a8c0-5ef0320d7649", "AQAAAAEAACcQAAAAEJrLNxVuKWEpHv1+5p/w+sc7QoNgXxM9rM0O3432FC7CBmZRnBfYfjItnk08KK2Cuw==", "e8199706-bdd1-4776-90e2-d0859927c01d" });
        }
    }
}

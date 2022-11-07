using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UsuariosApi.Migrations
{
    public partial class criandoroleregular : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "71f8edc6-52d2-493c-892d-2afaed8965b5");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { 99997, "5155f9a2-62f3-47ab-941a-75cbe26f13cb", "regular", "REGULAR" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f62193e2-c57c-4f32-a8c0-5ef0320d7649", "AQAAAAEAACcQAAAAEJrLNxVuKWEpHv1+5p/w+sc7QoNgXxM9rM0O3432FC7CBmZRnBfYfjItnk08KK2Cuw==", "e8199706-bdd1-4776-90e2-d0859927c01d" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99997);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "03c2da6b-2d6e-4834-8fe9-54e705f74924");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1422d43b-ea88-47d3-9020-b5ec551acc5c", "AQAAAAEAACcQAAAAENRepqZtUaKca7UCGejrqhPUecroOsnDlB2I+h8vtG2mzu31x8slct0nbdoCXjl3fg==", "066372f5-43e5-4881-9197-fdb95a43c99b" });
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Example.Ecommerce.Infrastructure.Data.Migrations
{
    public partial class AddMessageData2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "Parametrization",
                table: "Message",
                columns: new[] { "Key", "CreateAt", "Description", "UpdateAt" },
                values: new object[] { "DELETE_ERROR", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Registro no pudo ser eliminado", null });

            migrationBuilder.InsertData(
                schema: "Parametrization",
                table: "Message",
                columns: new[] { "Key", "CreateAt", "Description", "UpdateAt" },
                values: new object[] { "INSERT_ERROR", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Registro no pudo ser correctamente", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Parametrization",
                table: "Message",
                keyColumn: "Key",
                keyValue: "DELETE_ERROR");

            migrationBuilder.DeleteData(
                schema: "Parametrization",
                table: "Message",
                keyColumn: "Key",
                keyValue: "INSERT_ERROR");
        }
    }
}

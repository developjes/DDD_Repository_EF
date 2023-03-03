using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Example.Ecommerce.Infrastructure.Data.Migrations
{
    public partial class AddMessageData3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "Parametrization",
                table: "Message",
                keyColumn: "Key",
                keyValue: "DELETE_ERROR",
                column: "Description",
                value: "Registro no pudo ser removido correctamente");

            migrationBuilder.UpdateData(
                schema: "Parametrization",
                table: "Message",
                keyColumn: "Key",
                keyValue: "DELETE_SUCCESS",
                column: "Description",
                value: "Registro removido correctamente");

            migrationBuilder.UpdateData(
                schema: "Parametrization",
                table: "Message",
                keyColumn: "Key",
                keyValue: "INSERT_ERROR",
                column: "Description",
                value: "Registro no pudo ser creado correctamente");

            migrationBuilder.UpdateData(
                schema: "Parametrization",
                table: "Message",
                keyColumn: "Key",
                keyValue: "NOT_FOUND",
                column: "Description",
                value: "Registro(s) no encontrado(s)");

            migrationBuilder.UpdateData(
                schema: "Parametrization",
                table: "Message",
                keyColumn: "Key",
                keyValue: "UPDATE_SUCCESS",
                column: "Description",
                value: "Registro editado correctamente");

            migrationBuilder.InsertData(
                schema: "Parametrization",
                table: "Message",
                columns: new[] { "Key", "CreateAt", "Description", "UpdateAt" },
                values: new object[,]
                {
                    { "UPDATE_ERROR", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Registro no pudo ser editado correctamente", null },
                    { "VALIDATION_ERROR", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Errores de validación", null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Parametrization",
                table: "Message",
                keyColumn: "Key",
                keyValue: "UPDATE_ERROR");

            migrationBuilder.DeleteData(
                schema: "Parametrization",
                table: "Message",
                keyColumn: "Key",
                keyValue: "VALIDATION_ERROR");

            migrationBuilder.UpdateData(
                schema: "Parametrization",
                table: "Message",
                keyColumn: "Key",
                keyValue: "DELETE_ERROR",
                column: "Description",
                value: "Registro no pudo ser eliminado");

            migrationBuilder.UpdateData(
                schema: "Parametrization",
                table: "Message",
                keyColumn: "Key",
                keyValue: "DELETE_SUCCESS",
                column: "Description",
                value: "Registro eliminado correctamente");

            migrationBuilder.UpdateData(
                schema: "Parametrization",
                table: "Message",
                keyColumn: "Key",
                keyValue: "INSERT_ERROR",
                column: "Description",
                value: "Registro no pudo ser correctamente");

            migrationBuilder.UpdateData(
                schema: "Parametrization",
                table: "Message",
                keyColumn: "Key",
                keyValue: "NOT_FOUND",
                column: "Description",
                value: "Registro no encontrado");

            migrationBuilder.UpdateData(
                schema: "Parametrization",
                table: "Message",
                keyColumn: "Key",
                keyValue: "UPDATE_SUCCESS",
                column: "Description",
                value: "Registro actualizado correctamente");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Example.Ecommerce.Infrastructure.Data.Migrations
{
    public partial class AddMessageData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Message_Key",
                schema: "Parametrization",
                table: "Message");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateAt",
                schema: "Parametrization",
                table: "Message",
                type: "datetime2",
                nullable: true,
                comment: "Fecha de actualizacion del registro",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateAt",
                schema: "Parametrization",
                table: "Message",
                type: "datetime2",
                nullable: false,
                comment: "Fecha de creacion del registro",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Message",
                schema: "Parametrization",
                table: "Message",
                column: "Key");

            migrationBuilder.InsertData(
                schema: "Parametrization",
                table: "Message",
                columns: new[] { "Key", "CreateAt", "Description", "UpdateAt" },
                values: new object[,]
                {
                    { "DELETE_SUCCESS", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Registro eliminado correctamente", null },
                    { "INSERT_SUCCESS", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Registro creado correctamente", null },
                    { "NOT_FOUND", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Registro no encontrado", null },
                    { "UPDATE_SUCCESS", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Registro actualizado correctamente", null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Message",
                schema: "Parametrization",
                table: "Message");

            migrationBuilder.DeleteData(
                schema: "Parametrization",
                table: "Message",
                keyColumn: "Key",
                keyValue: "DELETE_SUCCESS");

            migrationBuilder.DeleteData(
                schema: "Parametrization",
                table: "Message",
                keyColumn: "Key",
                keyValue: "INSERT_SUCCESS");

            migrationBuilder.DeleteData(
                schema: "Parametrization",
                table: "Message",
                keyColumn: "Key",
                keyValue: "NOT_FOUND");

            migrationBuilder.DeleteData(
                schema: "Parametrization",
                table: "Message",
                keyColumn: "Key",
                keyValue: "UPDATE_SUCCESS");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateAt",
                schema: "Parametrization",
                table: "Message",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldComment: "Fecha de actualizacion del registro");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateAt",
                schema: "Parametrization",
                table: "Message",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldComment: "Fecha de creacion del registro");

            migrationBuilder.CreateIndex(
                name: "IX_Message_Key",
                schema: "Parametrization",
                table: "Message",
                column: "Key",
                unique: true);
        }
    }
}

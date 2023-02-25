using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Example.Ecommerce.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateFiledCategoryTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CategoryID",
                schema: "Parametrization",
                table: "Category",
                newName: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CategoryId",
                schema: "Parametrization",
                table: "Category",
                newName: "CategoryID");
        }
    }
}

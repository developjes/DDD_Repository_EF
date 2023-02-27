using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Example.Ecommerce.Infrastructure.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Parametrization");

            migrationBuilder.CreateTable(
                name: "Movie",
                schema: "Parametrization",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "int", nullable: false, comment: "Id tabla")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Nombre de la categoria"),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false, comment: "Descripcion de la categoria"),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Fecha de creacion del registro"),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Fecha de actualizacion del registro")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movie", x => x.MovieId);
                });

            migrationBuilder.CreateTable(
                name: "Plan",
                schema: "Parametrization",
                columns: table => new
                {
                    PlanId = table.Column<int>(type: "int", nullable: false, comment: "Id tabla")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Nombre del plan"),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Fecha de creacion del registro"),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Fecha de actualizacion del registro")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plan", x => x.PlanId);
                });

            migrationBuilder.CreateTable(
                name: "State",
                schema: "Parametrization",
                columns: table => new
                {
                    StateId = table.Column<int>(type: "int", nullable: false, comment: "Id tabla")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Nombre del estado"),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false, comment: "Descripcion del estado"),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Fecha de creacion del registro"),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Fecha de actualizacion del registro")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_State", x => x.StateId);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                schema: "Parametrization",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false, comment: "Id tabla")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Nombre de la categoria"),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false, comment: "Descripcion de la categoria"),
                    Picture = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "imagen de la categoria"),
                    StateId = table.Column<int>(type: "int", nullable: false, comment: "Id tabla foranea"),
                    PlanId = table.Column<int>(type: "int", nullable: true, comment: "Id tabla foranea"),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Fecha de creacion del registro"),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Fecha de actualizacion del registro")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryId);
                    table.ForeignKey(
                        name: "FK_Category_Plan_PlanId",
                        column: x => x.PlanId,
                        principalSchema: "Parametrization",
                        principalTable: "Plan",
                        principalColumn: "PlanId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Category_State_StateId",
                        column: x => x.StateId,
                        principalSchema: "Parametrization",
                        principalTable: "State",
                        principalColumn: "StateId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MovieCategory",
                schema: "Parametrization",
                columns: table => new
                {
                    MovieCategoryId = table.Column<int>(type: "int", nullable: false, comment: "Id tabla")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieId = table.Column<int>(type: "int", nullable: false, comment: "Id tabla foranea"),
                    CategoryId = table.Column<int>(type: "int", nullable: false, comment: "Id tabla foranea"),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Fecha de creacion del registro"),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Fecha de actualizacion del registro")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieCategory", x => x.MovieCategoryId);
                    table.ForeignKey(
                        name: "FK_MovieCategory_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "Parametrization",
                        principalTable: "Category",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MovieCategory_Movie_MovieId",
                        column: x => x.MovieId,
                        principalSchema: "Parametrization",
                        principalTable: "Movie",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Category_PlanId",
                schema: "Parametrization",
                table: "Category",
                column: "PlanId");

            migrationBuilder.CreateIndex(
                name: "IX_Category_StateId",
                schema: "Parametrization",
                table: "Category",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieCategory_CategoryId",
                schema: "Parametrization",
                table: "MovieCategory",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieCategory_MovieId",
                schema: "Parametrization",
                table: "MovieCategory",
                column: "MovieId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieCategory",
                schema: "Parametrization");

            migrationBuilder.DropTable(
                name: "Category",
                schema: "Parametrization");

            migrationBuilder.DropTable(
                name: "Movie",
                schema: "Parametrization");

            migrationBuilder.DropTable(
                name: "Plan",
                schema: "Parametrization");

            migrationBuilder.DropTable(
                name: "State",
                schema: "Parametrization");
        }
    }
}

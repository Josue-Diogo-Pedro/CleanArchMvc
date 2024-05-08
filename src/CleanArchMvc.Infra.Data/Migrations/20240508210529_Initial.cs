using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchMvc.Infra.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreateBy", "CreateDate", "ModifiedBy", "ModifiedDate", "Name" },
                values: new object[] { 1, null, new DateTime(2024, 5, 8, 14, 5, 28, 786, DateTimeKind.Local).AddTicks(367), null, new DateTime(2024, 5, 8, 14, 5, 28, 786, DateTimeKind.Local).AddTicks(414), "Material Escolar" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreateBy", "CreateDate", "ModifiedBy", "ModifiedDate", "Name" },
                values: new object[] { 2, null, new DateTime(2024, 5, 8, 14, 5, 28, 786, DateTimeKind.Local).AddTicks(424), null, new DateTime(2024, 5, 8, 14, 5, 28, 786, DateTimeKind.Local).AddTicks(426), "Eletrônicos" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreateBy", "CreateDate", "ModifiedBy", "ModifiedDate", "Name" },
                values: new object[] { 3, null, new DateTime(2024, 5, 8, 14, 5, 28, 786, DateTimeKind.Local).AddTicks(431), null, new DateTime(2024, 5, 8, 14, 5, 28, 786, DateTimeKind.Local).AddTicks(433), "Acessórios" });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}

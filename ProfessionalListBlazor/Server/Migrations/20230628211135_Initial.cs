﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProfessionalListBlazor.Server.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Styles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Styles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProfessionalLists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StyleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfessionalLists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProfessionalLists_Styles_StyleId",
                        column: x => x.StyleId,
                        principalTable: "Styles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Styles",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Home Office" });

            migrationBuilder.InsertData(
                table: "Styles",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Company" });

            migrationBuilder.InsertData(
                table: "ProfessionalLists",
                columns: new[] { "Id", "Name", "Position", "StyleId" },
                values: new object[] { 1, "Janne", "Senior", 1 });

            migrationBuilder.InsertData(
                table: "ProfessionalLists",
                columns: new[] { "Id", "Name", "Position", "StyleId" },
                values: new object[] { 2, "John", "Treinee", 2 });

            migrationBuilder.CreateIndex(
                name: "IX_ProfessionalLists_StyleId",
                table: "ProfessionalLists",
                column: "StyleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProfessionalLists");

            migrationBuilder.DropTable(
                name: "Styles");
        }
    }
}

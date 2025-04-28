// 20250428_AddBinTable.cs
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace garbage_collection.Migrations
{
    public partial class AddBinTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "bin", 
                columns: table => new
                {
                    Id = table.Column<int>(
                        type: "INTEGER",
                        nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CitizenId = table.Column<int>(    
                        type: "INTEGER",
                        nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bin", x => x.Id);
                    table.ForeignKey(
                        name: "FK_bin_citizen_CitizenId",
                        column: x => x.CitizenId,
                        principalTable: "citizen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_bin_CitizenId",
                table: "bin",
                column: "CitizenId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "bin");
        }
    }
}

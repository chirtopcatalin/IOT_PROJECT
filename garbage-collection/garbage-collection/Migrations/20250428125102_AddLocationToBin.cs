using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace garbage_collection.Migrations
{
    public partial class AddLocationToBin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "bin",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "bin");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace garbage_collection.Migrations
{
    /// <inheritdoc />
    public partial class AddCitizenTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
            name: "Cetateni",
            columns: table => new
            {
                Id = table.Column<int>(nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Nume = table.Column<string>(nullable: true),
                Prenume = table.Column<string>(nullable: true),
                Email = table.Column<string>(nullable: true),
                CNP = table.Column<string>(nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Cetateni", x => x.Id);
            });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}

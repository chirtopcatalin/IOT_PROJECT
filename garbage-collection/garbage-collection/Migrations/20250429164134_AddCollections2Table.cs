using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace garbage_collection.Migrations
{
    /// <inheritdoc />
    public partial class AddCollections2Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "collections2",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NrMasina = table.Column<string>(nullable: true),
                    IdPubela = table.Column<string>(nullable: true),
                    ColectatLa = table.Column<DateTime>(nullable: true),
                    Adresa = table.Column<string>(nullable: true),
                    Latitude = table.Column<double>(nullable: true),
                    Longitude = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_collections", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "collections2");
        }
    }
}

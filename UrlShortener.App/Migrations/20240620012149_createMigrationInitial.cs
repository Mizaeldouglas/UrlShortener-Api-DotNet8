using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UrlShortener.App.Migrations
{
    /// <inheritdoc />
    public partial class createMigrationInitial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OriginalUrls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LongUrl = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OriginalUrls", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShortCodes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Code = table.Column<string>(type: "TEXT", nullable: false),
                    OriginalUrlId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShortCodes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ShortCodes_OriginalUrls_OriginalUrlId",
                        column: x => x.OriginalUrlId,
                        principalTable: "OriginalUrls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShortCodes_Code",
                table: "ShortCodes",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ShortCodes_OriginalUrlId",
                table: "ShortCodes",
                column: "OriginalUrlId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShortCodes");

            migrationBuilder.DropTable(
                name: "OriginalUrls");
        }
    }
}

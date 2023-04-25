using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BirdingJournal.Migrations
{
    /// <inheritdoc />
    public partial class Second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BirdCommonName",
                table: "Birds",
                newName: "BirdyCommonName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BirdyCommonName",
                table: "Birds",
                newName: "BirdCommonName");
        }
    }
}
